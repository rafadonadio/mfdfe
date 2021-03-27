using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Collections;
using Security;

namespace BusinessLogic
{
    public class SecurityModules
    {
        private IList modulesList;
        private IList specialActionsList;
        private IList generalFunctionsList;
        private static SecurityModules instance;

        private SecurityModules() { }
        
        public static SecurityModules Instance
        {
            get
            {
                if (instance == null) instance = new SecurityModules();
                return instance;
            }
        }        
        public IList GetModules()
        {
            if (modulesList == null)
            {
                modulesList = new ArrayList();
                Assembly a = Assembly.GetExecutingAssembly();
                Type[] mytypes = a.GetTypes();
                foreach (Type t in mytypes)
                {
                    if (t.BaseType == typeof(Modules))
                    {
                        Object obj = Activator.CreateInstance(t);
                        modulesList.Add(obj as Modules);
                    }
                }
            }
            return modulesList;
        }
        public IList GetSpecialActions()
        {
            if (specialActionsList == null)
            {
                specialActionsList = new ArrayList();
                Assembly a = Assembly.GetExecutingAssembly();
                Type[] mytypes = a.GetTypes();
                foreach (Type t in mytypes)
                {
                    if (t.BaseType == typeof(Actions))
                    {
                        Object obj = Activator.CreateInstance(t);
                        specialActionsList.Add(obj as Actions);
                    }
                }
            }
            return specialActionsList;
        }
        public IList GetGeneralFunctions()
        {
            if (generalFunctionsList == null)
            {
                generalFunctionsList = new ArrayList();
                Assembly a = Assembly.GetExecutingAssembly();
                Type[] mytypes = a.GetTypes();
                foreach (Type t in mytypes)
                {
                    if (t.BaseType == typeof(Functions))
                    {
                        if ((t != typeof(CRUDFunctions)) && (t != typeof(SpecialFunctions)))
                        {
                            Object obj = Activator.CreateInstance(t);
                            generalFunctionsList.Add(obj as Functions);
                        }
                    }
                }
            }
            return generalFunctionsList;
        }
    }
    [Serializable]
    public class AccionEspecial : Actions
    {
        public AccionEspecial()
        { }
    }
    [Serializable]
    public class FuncionGeneral : Functions
    {
        public FuncionGeneral()
        { }
    }
    [Serializable]
    public class FuncionReportes : Functions
    {
        public FuncionReportes()
        { 
        }
        public override string ToString()
        {
            return "Reportes";
        }
    }
    [Serializable]
    public class FuncionSettings : Functions
    {
        public FuncionSettings()
        {
        }
        public override string ToString()
        {
            return "Settings";
        }
    }
}
