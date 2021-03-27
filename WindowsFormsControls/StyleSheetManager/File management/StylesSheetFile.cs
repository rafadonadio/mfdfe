//*****************************************************************************
//	Done by : Sylvain BLANCHARD
//	Date : 08/01/2006
//*****************************************************************************
using System;
using System.Collections.Generic;


namespace Sb.Windows.Forms.StylesSheet
{
    /// <summary>
    /// Represents the styles sheet file.
    /// </summary>
    [Serializable]
    public class StylesSheetFile
    {
        /// <summary>
        /// A styles sheet file is composed of a list of styles
        /// </summary>
        private List<Style> styles = new List<Style>();

        /// <summary>
        /// Gets or sets the styles.
        /// </summary>
        /// <value>The styles.</value>
        public List<Style> Styles
        {
            get { return styles; }
            set { styles = value; }
        }
    }
}
