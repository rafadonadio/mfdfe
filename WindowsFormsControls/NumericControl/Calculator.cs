using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsFormsControls {
    internal class Calculator : Form {
        private Button cmdEight;
        private Button cmdNine;
        private Button cmdDivide;
        private Button cmdSeven;
        private Button cmdFive;
        private Button cmdSix;
        private Button cmdMultiply;
        private Button cmdFour;
        private Button cmdPlusMinus;
        private Button cmdPlus;
        private Button cmdTwo;
        private Button cmdThree;
        private Button cmdMinus;
        private Button cmdEqual;
        private Button cmdClear;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private Container components = null;

        private TextBox txtResult;
        private Button cmdCancel;
        private Button cmdAccept;
        private Button cmdDot;
        private Button cmdZero;
        private Button cmdOne;

        private int decimalPlaces;
        private char decimalPoint;
        private char cultureDecimalPoint;

        private double acumulator = 0;
        private char operation = 'n';
        private bool startNew = true;
        private bool accept = false;

        public Calculator() {
        }

        public Calculator(char decimalPoint, int decimalPlaces, char cultureDecimalPoint) {
            InitializeComponent();

            this.decimalPoint = decimalPoint;
            this.decimalPlaces = decimalPlaces;
            this.cultureDecimalPoint = cultureDecimalPoint;
            cmdDot.Text = decimalPoint.ToString();
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.cmdEight = new System.Windows.Forms.Button();
            this.cmdNine = new System.Windows.Forms.Button();
            this.cmdDivide = new System.Windows.Forms.Button();
            this.cmdSeven = new System.Windows.Forms.Button();
            this.cmdFive = new System.Windows.Forms.Button();
            this.cmdSix = new System.Windows.Forms.Button();
            this.cmdMultiply = new System.Windows.Forms.Button();
            this.cmdFour = new System.Windows.Forms.Button();
            this.cmdDot = new System.Windows.Forms.Button();
            this.cmdPlusMinus = new System.Windows.Forms.Button();
            this.cmdPlus = new System.Windows.Forms.Button();
            this.cmdZero = new System.Windows.Forms.Button();
            this.cmdTwo = new System.Windows.Forms.Button();
            this.cmdThree = new System.Windows.Forms.Button();
            this.cmdMinus = new System.Windows.Forms.Button();
            this.cmdOne = new System.Windows.Forms.Button();
            this.cmdEqual = new System.Windows.Forms.Button();
            this.cmdClear = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdAccept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdEight
            // 
            this.cmdEight.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmdEight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdEight.Location = new System.Drawing.Point(32, 29);
            this.cmdEight.Name = "cmdEight";
            this.cmdEight.Size = new System.Drawing.Size(22, 22);
            this.cmdEight.TabIndex = 9;
            this.cmdEight.TabStop = false;
            this.cmdEight.Text = "8";
            this.cmdEight.UseVisualStyleBackColor = false;
            this.cmdEight.Click += new System.EventHandler(this.cmdEight_Click);
            // 
            // cmdNine
            // 
            this.cmdNine.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmdNine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdNine.Location = new System.Drawing.Point(54, 29);
            this.cmdNine.Name = "cmdNine";
            this.cmdNine.Size = new System.Drawing.Size(22, 22);
            this.cmdNine.TabIndex = 10;
            this.cmdNine.TabStop = false;
            this.cmdNine.Text = "9";
            this.cmdNine.UseVisualStyleBackColor = false;
            this.cmdNine.Click += new System.EventHandler(this.cmdNine_Click);
            // 
            // cmdDivide
            // 
            this.cmdDivide.BackColor = System.Drawing.Color.DarkGray;
            this.cmdDivide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdDivide.Location = new System.Drawing.Point(76, 29);
            this.cmdDivide.Name = "cmdDivide";
            this.cmdDivide.Size = new System.Drawing.Size(22, 22);
            this.cmdDivide.TabIndex = 16;
            this.cmdDivide.TabStop = false;
            this.cmdDivide.Text = "/";
            this.cmdDivide.UseVisualStyleBackColor = false;
            this.cmdDivide.Click += new System.EventHandler(this.cmdDivide_Click);
            // 
            // cmdSeven
            // 
            this.cmdSeven.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmdSeven.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSeven.Location = new System.Drawing.Point(10, 29);
            this.cmdSeven.Name = "cmdSeven";
            this.cmdSeven.Size = new System.Drawing.Size(22, 22);
            this.cmdSeven.TabIndex = 8;
            this.cmdSeven.TabStop = false;
            this.cmdSeven.Text = "7";
            this.cmdSeven.UseVisualStyleBackColor = false;
            this.cmdSeven.Click += new System.EventHandler(this.cmdSeven_Click);
            // 
            // cmdFive
            // 
            this.cmdFive.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmdFive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdFive.Location = new System.Drawing.Point(32, 51);
            this.cmdFive.Name = "cmdFive";
            this.cmdFive.Size = new System.Drawing.Size(22, 22);
            this.cmdFive.TabIndex = 6;
            this.cmdFive.TabStop = false;
            this.cmdFive.Text = "5";
            this.cmdFive.UseVisualStyleBackColor = false;
            this.cmdFive.Click += new System.EventHandler(this.cmdFive_Click);
            // 
            // cmdSix
            // 
            this.cmdSix.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmdSix.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSix.Location = new System.Drawing.Point(54, 51);
            this.cmdSix.Name = "cmdSix";
            this.cmdSix.Size = new System.Drawing.Size(22, 22);
            this.cmdSix.TabIndex = 7;
            this.cmdSix.TabStop = false;
            this.cmdSix.Text = "6";
            this.cmdSix.UseVisualStyleBackColor = false;
            this.cmdSix.Click += new System.EventHandler(this.cmdSix_Click);
            // 
            // cmdMultiply
            // 
            this.cmdMultiply.BackColor = System.Drawing.Color.DarkGray;
            this.cmdMultiply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMultiply.Location = new System.Drawing.Point(76, 51);
            this.cmdMultiply.Name = "cmdMultiply";
            this.cmdMultiply.Size = new System.Drawing.Size(22, 22);
            this.cmdMultiply.TabIndex = 15;
            this.cmdMultiply.TabStop = false;
            this.cmdMultiply.Text = "*";
            this.cmdMultiply.UseVisualStyleBackColor = false;
            this.cmdMultiply.Click += new System.EventHandler(this.cmdMultiply_Click);
            // 
            // cmdFour
            // 
            this.cmdFour.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmdFour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdFour.Location = new System.Drawing.Point(10, 51);
            this.cmdFour.Name = "cmdFour";
            this.cmdFour.Size = new System.Drawing.Size(22, 22);
            this.cmdFour.TabIndex = 5;
            this.cmdFour.TabStop = false;
            this.cmdFour.Text = "4";
            this.cmdFour.UseVisualStyleBackColor = false;
            this.cmdFour.Click += new System.EventHandler(this.cmdFour_Click);
            // 
            // cmdDot
            // 
            this.cmdDot.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmdDot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdDot.Location = new System.Drawing.Point(32, 95);
            this.cmdDot.Name = "cmdDot";
            this.cmdDot.Size = new System.Drawing.Size(22, 22);
            this.cmdDot.TabIndex = 11;
            this.cmdDot.TabStop = false;
            this.cmdDot.Text = ".";
            this.cmdDot.UseVisualStyleBackColor = false;
            this.cmdDot.Click += new System.EventHandler(this.cmdDot_Click);
            // 
            // cmdPlusMinus
            // 
            this.cmdPlusMinus.BackColor = System.Drawing.Color.DarkGray;
            this.cmdPlusMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdPlusMinus.Location = new System.Drawing.Point(54, 95);
            this.cmdPlusMinus.Name = "cmdPlusMinus";
            this.cmdPlusMinus.Size = new System.Drawing.Size(22, 22);
            this.cmdPlusMinus.TabIndex = 12;
            this.cmdPlusMinus.TabStop = false;
            this.cmdPlusMinus.Text = "±";
            this.cmdPlusMinus.UseVisualStyleBackColor = false;
            this.cmdPlusMinus.Click += new System.EventHandler(this.cmdPlusMinus_Click);
            // 
            // cmdPlus
            // 
            this.cmdPlus.BackColor = System.Drawing.Color.DarkGray;
            this.cmdPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdPlus.Location = new System.Drawing.Point(76, 95);
            this.cmdPlus.Name = "cmdPlus";
            this.cmdPlus.Size = new System.Drawing.Size(22, 22);
            this.cmdPlus.TabIndex = 13;
            this.cmdPlus.TabStop = false;
            this.cmdPlus.Text = "+";
            this.cmdPlus.UseVisualStyleBackColor = false;
            this.cmdPlus.Click += new System.EventHandler(this.cmdPlus_Click);
            // 
            // cmdZero
            // 
            this.cmdZero.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmdZero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdZero.Location = new System.Drawing.Point(10, 95);
            this.cmdZero.Name = "cmdZero";
            this.cmdZero.Size = new System.Drawing.Size(22, 22);
            this.cmdZero.TabIndex = 1;
            this.cmdZero.TabStop = false;
            this.cmdZero.Text = "0";
            this.cmdZero.UseVisualStyleBackColor = false;
            this.cmdZero.Click += new System.EventHandler(this.cmdZero_Click);
            // 
            // cmdTwo
            // 
            this.cmdTwo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmdTwo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdTwo.Location = new System.Drawing.Point(32, 73);
            this.cmdTwo.Name = "cmdTwo";
            this.cmdTwo.Size = new System.Drawing.Size(22, 22);
            this.cmdTwo.TabIndex = 3;
            this.cmdTwo.TabStop = false;
            this.cmdTwo.Text = "2";
            this.cmdTwo.UseVisualStyleBackColor = false;
            this.cmdTwo.Click += new System.EventHandler(this.cmdTwo_Click);
            // 
            // cmdThree
            // 
            this.cmdThree.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmdThree.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdThree.Location = new System.Drawing.Point(54, 73);
            this.cmdThree.Name = "cmdThree";
            this.cmdThree.Size = new System.Drawing.Size(22, 22);
            this.cmdThree.TabIndex = 4;
            this.cmdThree.TabStop = false;
            this.cmdThree.Text = "3";
            this.cmdThree.UseVisualStyleBackColor = false;
            this.cmdThree.Click += new System.EventHandler(this.cmdThree_Click);
            // 
            // cmdMinus
            // 
            this.cmdMinus.BackColor = System.Drawing.Color.DarkGray;
            this.cmdMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMinus.Location = new System.Drawing.Point(76, 73);
            this.cmdMinus.Name = "cmdMinus";
            this.cmdMinus.Size = new System.Drawing.Size(22, 22);
            this.cmdMinus.TabIndex = 14;
            this.cmdMinus.TabStop = false;
            this.cmdMinus.Text = "-";
            this.cmdMinus.UseVisualStyleBackColor = false;
            this.cmdMinus.Click += new System.EventHandler(this.cmdMinus_Click);
            // 
            // cmdOne
            // 
            this.cmdOne.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmdOne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOne.Location = new System.Drawing.Point(10, 73);
            this.cmdOne.Name = "cmdOne";
            this.cmdOne.Size = new System.Drawing.Size(22, 22);
            this.cmdOne.TabIndex = 2;
            this.cmdOne.TabStop = false;
            this.cmdOne.Text = "1";
            this.cmdOne.UseVisualStyleBackColor = false;
            this.cmdOne.Click += new System.EventHandler(this.cmdOne_Click);
            // 
            // cmdEqual
            // 
            this.cmdEqual.BackColor = System.Drawing.Color.DarkGray;
            this.cmdEqual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdEqual.Location = new System.Drawing.Point(76, 117);
            this.cmdEqual.Name = "cmdEqual";
            this.cmdEqual.Size = new System.Drawing.Size(22, 22);
            this.cmdEqual.TabIndex = 17;
            this.cmdEqual.TabStop = false;
            this.cmdEqual.Text = "=";
            this.cmdEqual.UseVisualStyleBackColor = false;
            this.cmdEqual.Click += new System.EventHandler(this.cmdEqual_Click);
            // 
            // cmdClear
            // 
            this.cmdClear.BackColor = System.Drawing.Color.OliveDrab;
            this.cmdClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdClear.Location = new System.Drawing.Point(54, 117);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(22, 22);
            this.cmdClear.TabIndex = 18;
            this.cmdClear.TabStop = false;
            this.cmdClear.Text = "C";
            this.cmdClear.UseVisualStyleBackColor = false;
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(10, 8);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(88, 20);
            this.txtResult.TabIndex = 0;
            this.txtResult.TabStop = false;
            this.txtResult.Text = "0";
            this.txtResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.Color.Red;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.Location = new System.Drawing.Point(10, 117);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(22, 22);
            this.cmdCancel.TabIndex = 20;
            this.cmdCancel.TabStop = false;
            this.cmdCancel.Text = "X";
            this.cmdCancel.UseVisualStyleBackColor = false;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdAccept
            // 
            this.cmdAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cmdAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAccept.Location = new System.Drawing.Point(32, 117);
            this.cmdAccept.Name = "cmdAccept";
            this.cmdAccept.Size = new System.Drawing.Size(22, 22);
            this.cmdAccept.TabIndex = 19;
            this.cmdAccept.TabStop = false;
            this.cmdAccept.Text = "T";
            this.cmdAccept.UseVisualStyleBackColor = false;
            this.cmdAccept.Click += new System.EventHandler(this.cmdAccept_Click);
            // 
            // Calculator
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(104, 144);
            this.Controls.Add(this.cmdAccept);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdEqual);
            this.Controls.Add(this.cmdClear);
            this.Controls.Add(this.cmdDot);
            this.Controls.Add(this.cmdPlusMinus);
            this.Controls.Add(this.cmdPlus);
            this.Controls.Add(this.cmdZero);
            this.Controls.Add(this.cmdTwo);
            this.Controls.Add(this.cmdThree);
            this.Controls.Add(this.cmdMinus);
            this.Controls.Add(this.cmdOne);
            this.Controls.Add(this.cmdFive);
            this.Controls.Add(this.cmdSix);
            this.Controls.Add(this.cmdMultiply);
            this.Controls.Add(this.cmdFour);
            this.Controls.Add(this.cmdEight);
            this.Controls.Add(this.cmdNine);
            this.Controls.Add(this.cmdDivide);
            this.Controls.Add(this.cmdSeven);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Calculator";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmCalculator";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Calculator_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private void cmdCancel_Click(object sender, EventArgs e) {
            Exit(false);
        }

        private void cmdAccept_Click(object sender, EventArgs e) {
            Exit(true);
        }

        private void cmdClear_Click(object sender, EventArgs e) {
            acumulator = 0;
            txtResult.Text = "0";
            startNew = true;
            operation = 'n';
        }

        private void cmdThree_Click(object sender, EventArgs e) {
            AppendResult('3');
            cmdEqual.Focus();
        }

        private void AppendResult(char ch) {
            if (startNew) {
                startNew = false;
                txtResult.Text = ch.ToString();
            }
            else if (txtResult.Text != "0")
                txtResult.Text += ch;
        }

        private void cmdZero_Click(object sender, EventArgs e) {
            AppendResult('0');
            cmdEqual.Focus();
        }

        private void cmdOne_Click(object sender, EventArgs e) {
            AppendResult('1');
            cmdEqual.Focus();
        }

        private void cmdTwo_Click(object sender, EventArgs e) {
            AppendResult('2');
            cmdEqual.Focus();
        }

        private void cmdFour_Click(object sender, EventArgs e) {
            AppendResult('4');
            cmdEqual.Focus();
        }

        private void cmdFive_Click(object sender, EventArgs e) {
            AppendResult('5');
            cmdEqual.Focus();
        }

        private void cmdSix_Click(object sender, EventArgs e) {
            AppendResult('6');
            cmdEqual.Focus();
        }

        private void cmdSeven_Click(object sender, EventArgs e) {
            AppendResult('7');
            cmdEqual.Focus();
        }

        private void cmdEight_Click(object sender, EventArgs e) {
            AppendResult('8');
            cmdEqual.Focus();
        }

        private void cmdNine_Click(object sender, EventArgs e) {
            AppendResult('9');
            cmdEqual.Focus();
        }

        private void cmdPlus_Click(object sender, EventArgs e) {
            DoOperation('+');
            cmdEqual.Focus();
        }

        private void cmdDivide_Click(object sender, EventArgs e) {
            DoOperation('/');
            cmdEqual.Focus();
        }

        private void cmdMultiply_Click(object sender, EventArgs e) {
            DoOperation('*');
            cmdEqual.Focus();
        }

        private void cmdMinus_Click(object sender, EventArgs e) {
            DoOperation('-');
            cmdEqual.Focus();
        }

        private void cmdEqual_Click(object sender, EventArgs e) {
            DoOperation('n');
            cmdEqual.Focus();
        }

        private void DoOperation(char op) {
            PerformPreviousOperation(op);
            acumulator = FormatNumber(txtResult.Text);
            operation = op;
        }

        private void PerformPreviousOperation(char op) {
            switch (operation) {
                case '+':
                    acumulator += FormatNumber(txtResult.Text);
                    txtResult.Text = DisplayNumber(acumulator);
                    break;

                case '*':
                    acumulator *= FormatNumber(txtResult.Text);
                    txtResult.Text = DisplayNumber(acumulator);
                    break;

                case '-':
                    acumulator -= FormatNumber(txtResult.Text);
                    txtResult.Text = DisplayNumber(acumulator);
                    break;

                case '/':
                    acumulator /= FormatNumber(txtResult.Text);
                    txtResult.Text = DisplayNumber(acumulator);
                    break;

                case 'n':
                    if (op == 'n')
                        Exit(true);

                    break;
            }

            startNew = true;
        }

        private void Exit(bool transcribe) {
            Accept = transcribe;
            Close();
        }

        private void cmdPlusMinus_Click(object sender, EventArgs e) {
            acumulator *= -1;

            //If the result is already negative
            if (txtResult.Text.IndexOf('-') == -1)
                txtResult.Text = '-' + txtResult.Text;
            else
                txtResult.Text = txtResult.Text.Substring(1);
        }

        private void cmdDot_Click(object sender, EventArgs e) {
            //If the dot was not already inserted
            if (txtResult.Text.IndexOf(decimalPoint) == -1)
                txtResult.Text += decimalPoint;
        }

        private void Calculator_KeyDown(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.Escape:
                    Close();
                    break;

                case Keys.NumPad0:
                    AppendResult('0');
                    break;

                case Keys.NumPad1:
                    AppendResult('1');
                    break;

                case Keys.NumPad2:
                    AppendResult('2');
                    break;

                case Keys.NumPad3:
                    AppendResult('3');
                    break;

                case Keys.NumPad4:
                    AppendResult('4');
                    break;

                case Keys.NumPad5:
                    AppendResult('5');
                    break;

                case Keys.NumPad6:
                    AppendResult('6');
                    break;

                case Keys.NumPad7:
                    AppendResult('7');
                    break;

                case Keys.NumPad8:
                    AppendResult('8');
                    break;

                case Keys.NumPad9:
                    AppendResult('9');
                    break;

                case Keys.Add:
                    DoOperation('+');
                    break;

                case Keys.Subtract:
                    DoOperation('-');
                    break;

                case Keys.Divide:
                    DoOperation('/');
                    break;

                case Keys.Multiply:
                    DoOperation('*');
                    break;

                case Keys.Return:
                    DoOperation('n');
                    cmdEqual.Focus(); 
                    break;

                case Keys.Decimal:
                    if (txtResult.Text.IndexOf(decimalPoint) == -1)
                        txtResult.Text += decimalPoint;
                    break;
            }

            e.Handled = true;
        }

        public bool Accept {
            get { return accept; }
            set { accept = value; }
        }

        public string Result {
            get { return txtResult.Text; }
        }

        private double FormatNumber(string number) {
            number = number.Replace(decimalPoint, cultureDecimalPoint);

            return Math.Round(Convert.ToDouble(number), decimalPlaces);
        }

        private string DisplayNumber(double number) {
            return number.ToString().Replace(cultureDecimalPoint, decimalPoint);
        }
    }
}