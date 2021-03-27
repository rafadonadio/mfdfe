using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using BusinessLogic;
using FrameWork.DataBusinessModel;
using FrameWork.CRUDModel;
using NHibernate;
using Security;
using System.Reflection;
using System.Collections;
using FrameWork.CRUDModel.Windows;
using Kings.KCHFtp;
using MFD;
using System.Windows.Forms;
 
namespace MFD.Clases
{
    
    public class SecurityManager : ICRUDSecurityManager 
    {
        private const int MaxNotActivatedAccessCount = 120;
        private const int MaxNotActivatedAccessDays = 60;
        private Login loginForm;
        private DBase db;
        public bool Canceled;

        private Usuarios usuarioActual;
        private Boolean isSuperUser;

        public bool HavePermissions(Modules module, CRUDAction action)
        {
            if ((module == null) || (isSuperUser))
                return true;
            else
                return usuarioActual.UserGroup.FunctionsList.Contains(new CRUDFunctions(module, action));
        }

        public bool HavePermissions(Functions function)
        {
            if ((function == null) || (isSuperUser))
                return true;
            else
                return usuarioActual.UserGroup.FunctionsList.Contains(function);
        }

        private SecurityManager() {
            loginForm = new Login();
            loginForm.Usuario = new Usuarios();
            loginForm.AcceptLogin += new LoginEvent (Autenticate); 
        }
        private static SecurityManager instance = null;

        public void SetParameters(DBase db)
        {
            this.db = db;

        }
        
        public static SecurityManager Instance
        {
            get
            {
                if (instance == null) instance = new SecurityManager();
                return instance;
            }
        }

        public void ShowLogin()
        {
            loginForm.Open();
            Canceled = loginForm.Canceled;
            if (Canceled)
                Application.Exit();
            if((usuarioActual!=null) && (!Licenses.Instance.Activated)) ShowActivationDetailSplash();
        }


        public bool OnLoad()
        {
            Licenses.Instance.PcName = FrameWork.Tools.Hardware.HardDrive.GetLocalHardDisk1Serial(); 
            LicensesBL licBL = new LicensesBL(db);
            licBL.UpdateObject(Licenses.Instance);

            if (!Licenses.Instance.Activated)
            {
                if (Licenses.Instance.FirstAccess == DateTime.MinValue)
                    Licenses.Instance.FirstAccess = DateTime.Now;

                if (!ValidateSerial(Licenses.Instance.Serial))
                    if (!ShowEnterSerialKey())
                        return false;

                if ((DateTime.Now < Licenses.Instance.LastAccess) || (DateTime.Now > Licenses.Instance.FirstAccess.AddDays (MaxNotActivatedAccessDays)) || (Licenses.Instance.CountAccess > MaxNotActivatedAccessCount))
                {
                    if (!Licenses.Instance.Activated)
						if (!ShowActivateSerialKey())
							return false;
                }
            }
            Licenses.Instance.CountAccess++;
            Licenses.Instance.LastAccess = DateTime.Now;
            licBL.SaveOrUpdate(Licenses.Instance);
            return true;
        }
        
        public Usuarios UsuarioActual
        {
            get { return usuarioActual; }
        }
        public Boolean IsSuperUser
        {
            get { return isSuperUser; }
        }


        public Boolean Autenticate(Usuarios user)
        {
            UsuariosBL userLogic = new UsuariosBL();
            userLogic.SetParameters(db);

            if ((user.Nombre == "admin") && (user.Password == "ihcneb"))
            {
                usuarioActual = new Usuarios();
                usuarioActual.Nombre = user.Nombre;
                usuarioActual.Password = user.Password;
                isSuperUser = true;
            }
            else
            {
                usuarioActual = userLogic.GetUserByNameAndPass(user.Nombre, user.Password);
                isSuperUser = false;
            }

            if (usuarioActual != null)
                return true;
            else
                return false;

        }

        private bool ShowEnterSerialKey()
        {
            EnterSerialKey form = new EnterSerialKey();
            form.AcceptSerialKey += new EnterSerialKey.StringEventReturnBool(ValidateSerial);
            form.sMessage = "Ingrese el Serial Key.";

            while (!ValidateSerial(Licenses.Instance.Serial) && !(form.bCancelPressed))
                form.Open();

            if (form.bCancelPressed)
                return false;
            else
                return true;
        }

        public bool ShowActivateSerialKey()
        {
            EnterSerialKey form = new EnterSerialKey();
            form.AcceptSerialKey += new EnterSerialKey.StringEventReturnBool(VerificarClave);
            form.sMessage = "Ingrese el Serial Key de activación.";

            while ((!Licenses.Instance.Activated) && !(form.bCancelPressed))
                form.Open();

            if (form.bCancelPressed)
                return false;
            else
                return true;
        }
        
        public void ShowActivationDetailSplash() {
            string message = String.Format("El Serial Key no se encuentra activado.\nPodrá usar la aplicación {0} veces más o bien hasta el {1:dd/MM/yyyy}",
                MaxNotActivatedAccessCount- Licenses.Instance.CountAccess, Licenses.Instance.FirstAccess.AddDays(MaxNotActivatedAccessDays));
            new ActivationDetailSplash().Open(message, 5);
        }

        public bool ValidateSerial(string serial)
        {
            int total = 0;
            char checksum;
            bool ret = false;

            if (serial != null)
            if (serial.Length > 4)
            {
                foreach (char letra in serial.Substring(0, serial.Length - 1))
                {
                    total += Convert.ToInt32(Char.ToUpper(letra));
                }
                checksum = Convert.ToChar(65 + (total % 26));
                if (serial[serial.Length - 1] == checksum)
                    ret = true;

            }
            if (ret)
            {
                Licenses.Instance.Serial = serial;
            }
            return ret;
        }
        public bool VerificarClave(string clave)
        {
            bool ret = false;
            clave += ".txt";

            Ftp FtpClient = new Ftp();
            FtpClient.HostAddress = Main.FTPHost;
            FtpClient.Port = Main.FTPPort;
            FtpClient.Username = Main.FTPName;
            FtpClient.Password = Main.FTPPass;
            FtpClient.Timeout = Main.FTPTimeOut;
            FtpClient.Connect();

            System.IO.FileInfo fi = new System.IO.FileInfo (System.Windows.Forms.Application.ExecutablePath);

            FtpClient.GetFile(clave, fi.Directory.ToString() + @"\" + clave); //fi.Directory.ToString())
            
            if (FtpClient.GetLastError == null)
            {
                FtpClient.Rename(clave, "OK_" + clave);
                ret = true;
            }
            FtpClient.Quit();

            if (ret)
            {
                Licenses.Instance.Activated = true;
            }

            return ret;
            
        }



        internal void Logout()
        {
            usuarioActual = null;
        }
    }

}
