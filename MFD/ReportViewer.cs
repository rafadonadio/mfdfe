using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace MFD {
    public partial class ReportViewer : Form {
        public ReportViewer() {
            InitializeComponent();
        }

        public void Open(ReportDocument report) {
            viewer.ReportSource = report;
            ShowDialog();
        }
    }
}