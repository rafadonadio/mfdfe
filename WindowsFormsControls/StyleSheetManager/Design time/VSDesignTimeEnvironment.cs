//*****************************************************************************
//	Done by : Sylvain BLANCHARD
//	Date : 08/01/2006
//*****************************************************************************
using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Windows.Forms;
using EnvDTE;

namespace Sb.Windows.Forms.StylesSheet
{
    class VSDesignTimeEnvironment
    {
        Component c;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:VSDesignTimeEnvironment"/> class.
        /// </summary>
        /// <param name="c">The c.</param>
        public VSDesignTimeEnvironment(Component c)
        {
            this.c = c;
        }

        /// <summary>
        /// Gets the app config path.
        /// </summary>
        /// <returns></returns>
        public string GetAppConfigPath()
        {
            DTE devenv = (DTE)c.Site.GetService(typeof(DTE));
            Array projects = (Array)devenv.ActiveSolutionProjects;
            Project activeProject = (Project)projects.GetValue(0);

            foreach (ProjectItem item in activeProject.ProjectItems)
            {
                if (item.Name.ToLower().Equals("app.config"))
                {
                    System.IO.FileInfo info = new System.IO.FileInfo(activeProject.FullName);
                    return info.Directory.FullName + "\\" + item.Name;
                }
            }

            return null;
        }
    }
}
