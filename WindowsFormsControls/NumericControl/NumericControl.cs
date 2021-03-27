using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace WindowsFormsControls {
    /// <summary>
    /// Summary description for NumericControl
    /// </summary>
    public class NumericControl : UserControl {
        //Default parameters
        private const char DECIMAL_POINT = ',';
        private const int DECIMAL_PLACES = 2;
        private const int HEIGHT = 20;
        private const char NEGATIVE_SYMBOL = '-';

        private int decimalPlaces;
        private char decimalPoint;
        private bool allowNegatives;

        private string buffer;

        private char lastChar = '\b';
        private bool valid = true;
        private bool keyPressHandled = false;

        private char CultureDecimalPoint = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private Container components = null;
        private TextBox txtNumber;

        private Button cmdCalculator;

        public NumericControl() {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            //// TODO: Add any initialization after the InitComponent call
            //decimalPlaces = DECIMAL_PLACES;
            //decimalPoint = DECIMAL_POINT;

            //buffer = "0";
            //txtNumber.Text = buffer;
            //cmdCalculator.Visible = false;
            //ResizeControl();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.cmdCalculator = new System.Windows.Forms.Button();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmdCalculator
            // 
            this.cmdCalculator.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmdCalculator.Image = global::WindowsFormsControls.Properties.Resources.calc;
            this.cmdCalculator.Location = new System.Drawing.Point(104, 0);
            this.cmdCalculator.Name = "cmdCalculator";
            this.cmdCalculator.Size = new System.Drawing.Size(24, 20);
            this.cmdCalculator.TabIndex = 1;
            this.cmdCalculator.Click += new System.EventHandler(this.cmdCalculator_Click);
            // 
            // txtNumber
            // 
            this.txtNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNumber.Location = new System.Drawing.Point(0, 0);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(104, 20);
            this.txtNumber.TabIndex = 2;
            this.txtNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNumber.Leave += new System.EventHandler(this.txtNumber_Leave);
            this.txtNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            this.txtNumber.TextChanged += new System.EventHandler(this.txtNumber_TextChanged);
            this.txtNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumber_KeyDown);
            // 
            // NumericControl
            // 
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.cmdCalculator);
            this.Name = "NumericControl";
            this.Size = new System.Drawing.Size(128, 20);
            this.Leave += new System.EventHandler(this.txtNumber_Leave);
            this.Resize += new System.EventHandler(this.NumericControl_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private void NumericControl_Resize(object sender, EventArgs e) {
            Height = HEIGHT;
        }

        //Functions
        private string FormatNumber(string number) {
            number = number.Replace(DecimalPoint, CultureDecimalPoint);

            double temp = Math.Round(Convert.ToDouble((number == "") ? 0 : Convert.ToDouble(number)),
                                     decimalPlaces);

            if (!AllowNegatives)
                temp = Math.Abs(temp);

            return temp.ToString().Replace(CultureDecimalPoint, DecimalPoint);
        }

        private bool CanIsertDecimalPoint(string number) {
            return (DecimalPlaces > 0) && (number.IndexOf(DecimalPoint) == -1);
        }

        private bool CanIsertNegativeSymbol(string number) {
            string temp = FormatNumber(number);

            return (AllowNegatives) && (temp.IndexOf(NEGATIVE_SYMBOL) == -1) &&
                   (Convert.ToDouble(temp) != 0);
        }

        private bool IsNegativeSymbol(char ch) {
            return (ch == NEGATIVE_SYMBOL);
        }

        private bool IsDecimalPoint(char ch) {
            return (ch == DecimalPoint);
        }

        private void txtNumber_Leave(object sender, EventArgs e) {
            txtNumber.Text = FormatNumber(buffer);
        }

        private void txtNumber_TextChanged(object sender, EventArgs e) {
            int oldPos = 0;

            if (valid) {
                if (IsNegativeSymbol(lastChar)) {
                    lastChar = 'n';
                    oldPos = txtNumber.SelectionStart;
                    if (CanIsertNegativeSymbol(buffer)) {
                        buffer = NEGATIVE_SYMBOL + buffer;
                        txtNumber.Text = buffer;
                        txtNumber.SelectionStart = oldPos;
                    }
                    else {
                        buffer = buffer.Substring(1);
                        txtNumber.Text = buffer;
                        txtNumber.SelectionStart = oldPos - 2;
                    }
                }
                else
                    buffer = txtNumber.Text;
            }
            else {
                oldPos = txtNumber.SelectionStart;
                txtNumber.Text = buffer;

                if (oldPos != 0)
                    txtNumber.SelectionStart = oldPos - 1;
            }
            OnTextChanged(e);
        }

        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e) {
            if (!keyPressHandled) {
                valid = (ValidCharacters().IndexOf(e.KeyChar) != -1);

                if (valid)
                    if (IsDecimalPoint(e.KeyChar) && (DecimalPlaces > 0))
                        valid = CanIsertDecimalPoint(buffer);

                lastChar = e.KeyChar;
            }
            else if (valid) {
                int position = txtNumber.SelectionStart;
                txtNumber.Text = txtNumber.Text.Insert(txtNumber.SelectionStart, lastChar.ToString());
                txtNumber.SelectionStart = position + 1;
                txtNumber.SelectionLength = 0;
                e.Handled = true;
            }
            OnKeyPress(e);
        }

        private string ValidCharacters() {
            return "0123456789" + ((DecimalPlaces > 0) ? DecimalPoint : '0') + '\b' +
                   ((AllowNegatives) ? NEGATIVE_SYMBOL : '0');
        }

        private void cmdCalculator_Click(object sender, EventArgs e) {
            Calculator calculator = new Calculator(DecimalPoint, DecimalPlaces, CultureDecimalPoint);

            calculator.Location = PointToScreen(new Point(0, Height));
            calculator.ShowDialog();

            if (calculator.Accept)
                txtNumber.Text = FormatNumber(calculator.Result);
        }

        //Properties
        public int DecimalPlaces {
            get { return decimalPlaces; }
            set {
                decimalPlaces = value;
                txtNumber.Text = FormatNumber("0");
                buffer = txtNumber.Text;
            }
        }

        public char DecimalPoint {
            get { return (decimalPoint == '\0') ? CultureDecimalPoint : decimalPoint; }
            set { decimalPoint = value; }
        }

        public override string Text {
            get { return txtNumber.Text; }
            set { txtNumber.Text = value; }
        }

        [Browsable(true)]
        public Boolean AllowNegatives {
            get { return allowNegatives; }
            set { allowNegatives = value; }
        }

        [Browsable(true)]
        public Boolean ShowCalculator {
            get { return cmdCalculator.Visible; }
            set { cmdCalculator.Visible = value; }
        }

        public double Value {
            get { return Convert.ToDouble(buffer.Replace(DecimalPoint, CultureDecimalPoint)); }
            set { txtNumber.Text = Convert.ToString(value).Replace(CultureDecimalPoint, DecimalPoint); }
        }

        public override Color ForeColor {
            get { return base.ForeColor; }
            set { txtNumber.ForeColor = base.ForeColor = value; }
        }

        private void txtNumber_KeyDown(object sender, KeyEventArgs e) {
            keyPressHandled = false;
            if (e.KeyCode == Keys.Decimal) {
                if (DecimalPlaces > 0) valid = CanIsertDecimalPoint(buffer);
                lastChar = DecimalPoint;
                keyPressHandled = true;
            }
        }
    }
}