using System;
using System.Windows.Forms;

namespace WindowsFormsControls {
    public partial class TabControl : System.Windows.Forms.TabControl {
        public TabControl() {
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw |
                ControlStyles.UserPaint, true);
        }
    }

    public class TabPageChangeEventArgs : EventArgs {
        private TabPage _Selected = null;
        private TabPage _PreSelected = null;
        public bool Cancel = false;

        public TabPage CurrentTab {
            get { return _Selected; }
        }


        public TabPage NextTab {
            get { return _PreSelected; }
        }


        public TabPageChangeEventArgs(TabPage CurrentTab, TabPage NextTab) {
            _Selected = CurrentTab;
            _PreSelected = NextTab;
        }
    }


    public delegate void SelectedTabPageChangeEventHandler(Object sender, TabPageChangeEventArgs e);
}