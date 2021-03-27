using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Security;
using FrameWork.CRUDModel;
using FrameWork.CRUDModel.Windows.UI;
using FrameWork.DataBusinessModel.DataModel;
using MFD.Clases ;
using System.Reflection;
using System.Collections;
using BusinessLogic;


namespace MFD
{
    public partial class UsersGroupsCRUD : CRUDForm
    {
        public event PermissionEvent PermissionCreateRequired;
        public event PermissionEvent PermissionDeleteRequired;
        public event CreateCRUDFunctionEvent CreateCRUDFunction;
        public event CreateSpecialFunctionEvent CreateSpecialFunction;


        public UsersGroupsCRUD()
        {
            InitializeComponent();
            this.stylesSheetManager.ApplyStyles();
        }
        protected override void FillObject()
        {
            base.FillObject();
            Persistent.Name = txtNombre.Text;
        }

		

        protected override void RefreshControls()
        {
            base.RefreshControls();
            cmbSpecialModules.DataSource = SecurityModules.Instance.GetModules();
            cmbCRUDModules.DataSource = SecurityModules.Instance.GetModules();

            chkCRUDItems.Items.Add(CRUDAction.Retrieve);
            chkCRUDItems.Items.Add(CRUDAction.Create);
            chkCRUDItems.Items.Add(CRUDAction.Update);
            chkCRUDItems.Items.Add(CRUDAction.Delete);

            foreach (Actions act in SecurityModules.Instance.GetSpecialActions())
                chkSpecialItems.Items.Add(act);

            foreach (Functions gf in SecurityModules.Instance.GetGeneralFunctions())
                chkGeneralItems.Items.Add(gf);
        }

        protected override void FillControls()
        {
            
            txtNombre.Text = Persistent.Name;
            lstPermisos.DataSource = Persistent.FunctionsList; 
            base.FillControls(); 
        }

        public void RefreshPermissionsList()
        {
            lstPermisos.DataSource = null; 
            lstPermisos.DataSource = Persistent.FunctionsList;
        }

        new public UsersGroups Persistent
        {
            get { return (UsersGroups) persistent; }
            set { persistent = value; }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (AcceptForm()) Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rbtCRUD_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtCRUD.Checked)
            {
                gpbCRUDItems.Visible = true;
                gpbGeneralItems.Visible = false;
                gpbSpecialItems.Visible = false;
            }
        }

        private void rbtSpecial_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtSpecial.Checked)
            {
                gpbCRUDItems.Visible = false;
                gpbGeneralItems.Visible = false;
                gpbSpecialItems.Visible = true;
            }
        }

        private void rbtGeneral_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtGeneral.Checked)
            {
                gpbCRUDItems.Visible = false;
                gpbGeneralItems.Visible = true;
                gpbSpecialItems.Visible = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (PermissionDeleteRequired != null)
            {
                PermissionDeleteRequired(Persistent, lstPermisos.SelectedItems); 
            }
        }

        private void btnItemAccept_Click(object sender, EventArgs e)
        {
            IList functionsList = new ArrayList() ;
            if (CreateSpecialFunction != null)
            {
                if (rbtCRUD.Checked)
                {
                    foreach (CRUDAction action in chkCRUDItems.CheckedItems )
                        functionsList.Add(CreateCRUDFunction(cmbCRUDModules.SelectedValue as Modules, (CRUDAction)action));
                }
                if (rbtSpecial.Checked)
                {
                    foreach (Actions action in chkSpecialItems.CheckedItems)
                        functionsList.Add(CreateSpecialFunction(cmbSpecialModules.SelectedValue as Modules, action as Actions));
                }
                if (rbtGeneral.Checked)
                {
                    foreach (Functions function in chkGeneralItems.CheckedItems)
                        functionsList.Add(function);
                }
            }
            if (PermissionCreateRequired != null)
            {
                PermissionCreateRequired(Persistent, functionsList);
            }
            gpbAddFunction.Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            gpbAddFunction.Visible = true;
        }

        private void btnItemCancel_Click(object sender, EventArgs e)
        {
            gpbAddFunction.Visible = false;
        }
                
            
    }
    public delegate void PermissionEvent(UsersGroups userGroup, IList functionsList);
    public delegate Functions CreateCRUDFunctionEvent(Modules module, CRUDAction action);
    public delegate Functions CreateSpecialFunctionEvent(Modules module, Actions action);
}