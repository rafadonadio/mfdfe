using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsFormsControls {
	/// <summary>
	/// Summary description for HourBox.
	/// </summary>
	public class TimeBox : UserControl {
		private System.Windows.Forms.VScrollBar vsbSpin;
		private System.Windows.Forms.Panel pnlControls;
		private System.Windows.Forms.TextBox txtHour;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public TimeBox() {
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			SpinButtonPosition=eSpinButtonPosition.Right;
			this.Value=DateTime.Now.TimeOfDay;
			ReWrite();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if(components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.vsbSpin = new System.Windows.Forms.VScrollBar();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.txtHour = new System.Windows.Forms.TextBox();
            this.pnlControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // vsbSpin
            // 
            this.vsbSpin.Dock = System.Windows.Forms.DockStyle.Right;
            this.vsbSpin.LargeChange = 1;
            this.vsbSpin.Location = new System.Drawing.Point(108, 0);
            this.vsbSpin.Name = "vsbSpin";
            this.vsbSpin.Size = new System.Drawing.Size(16, 16);
            this.vsbSpin.TabIndex = 1;
            this.vsbSpin.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vsbSpin_Scroll);
            // 
            // pnlControls
            // 
            this.pnlControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlControls.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlControls.Controls.Add(this.txtHour);
            this.pnlControls.Controls.Add(this.vsbSpin);
            this.pnlControls.Location = new System.Drawing.Point(0, 0);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(128, 20);
            this.pnlControls.TabIndex = 2;
            // 
            // txtHour
            // 
            this.txtHour.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHour.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHour.Location = new System.Drawing.Point(0, 0);
            this.txtHour.Name = "txtHour";
            this.txtHour.ReadOnly = true;
            this.txtHour.Size = new System.Drawing.Size(108, 13);
            this.txtHour.TabIndex = 2;
            this.txtHour.Enter += new System.EventHandler(this.txtHour_Enter);
            this.txtHour.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHour_KeyDown);
            // 
            // TimeBox
            // 
            this.Controls.Add(this.pnlControls);
            this.Name = "TimeBox";
            this.Size = new System.Drawing.Size(128, 21);
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
		public enum TimeFormat{HoursMinutesSeconds, HoursMinutes};
		
		protected TimeFormat _format;
		public TimeFormat Format {
			get { return _format; }
			set {
				_format = value;
				switch(_format) {
					case TimeFormat.HoursMinutesSeconds:
						txtHour.MaxLength=8;
						ReWrite();
						break;
					case TimeFormat.HoursMinutes:
						this.txtHour.MaxLength=5;
						ReWrite();
						break;
				}
			}
		}

		public HorizontalAlignment TextAlign {
			get { return txtHour.TextAlign; }
			set { txtHour.TextAlign=value; }
		}

		public enum eSpinButtonPosition {Left, Right};
		protected eSpinButtonPosition _spinButtonPosition;

		public eSpinButtonPosition SpinButtonPosition {
			get { return _spinButtonPosition; }
			set {
				_spinButtonPosition=value;
				switch(_spinButtonPosition) {
					case eSpinButtonPosition.Left: vsbSpin.Dock=DockStyle.Left; break;
					case eSpinButtonPosition.Right: vsbSpin.Dock=DockStyle.Right; break; 
				}
			}
		}

		public bool SpinButtonVisible {
			get { return vsbSpin.Visible; }
			set { vsbSpin.Visible=value; }
		}

		protected int _hours, _minutes, _seconds;

		public TimeSpan Value {
			get { return new TimeSpan(0,_hours,_minutes, _seconds); }
			set {
				Hours=value.Hours;
				Minutes=value.Minutes;
				Seconds=value.Seconds;
			}
		}

		protected int Hours {
			get { return _hours; }
			set {
				_hours=value%24;
				if(_hours<0) _hours+=24;
				ReWrite();
			}
		}

		protected int Minutes {
			get { return _minutes; }
			set {
				Hours+=value/60;
				_minutes=value%60;
				if(_minutes<0) {
					Hours--;
					_minutes+=60;
				}
				ReWrite();
			}
		}

		protected int Seconds {
			get { return _seconds; }
			set {
				Minutes+=value/60;
				_seconds=value%60;
				if(_seconds<0) {
					Minutes--;
					_seconds+=60;
				}
				ReWrite();
			}
		}


		protected void Increment() {
			if((txtHour.SelectionStart==0)||(txtHour.SelectionStart==1)) Hours++;
			else if((txtHour.SelectionStart==3)||(txtHour.SelectionStart==4)) Minutes++;
			else if((txtHour.SelectionStart==6)||(txtHour.SelectionStart==7)) Seconds++;
		}

		protected void Decrement() {
			if((txtHour.SelectionStart==0)||(txtHour.SelectionStart==1)) Hours--;
			else if((txtHour.SelectionStart==3)||(txtHour.SelectionStart==4)) Minutes--;
			else if((txtHour.SelectionStart==6)||(txtHour.SelectionStart==7)) Seconds--;
		}

		protected void ReWrite() {
			int selectionStart=txtHour.SelectionStart;
			switch(Format) {
				case TimeFormat.HoursMinutes:
					txtHour.Text=String.Format("{0:00}:{1:00}",Hours,Minutes);
					break;
				case TimeFormat.HoursMinutesSeconds:
					txtHour.Text=String.Format("{0:00}:{1:00}:{2:00}",Hours,Minutes,Seconds);
					break;
			}
			if(selectionStart>=0) txtHour.SelectionStart=selectionStart;
		}

		private void vsbSpin_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e) {
			if((e.Type==ScrollEventType.LargeIncrement)||(e.Type==ScrollEventType.SmallIncrement)) Decrement();
			else if((e.Type==ScrollEventType.LargeDecrement)||(e.Type==ScrollEventType.SmallDecrement)) Increment();
		}

		private void txtHour_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e) {
			if(e.KeyCode==Keys.Down) {
				e.Handled=true;
				Decrement();
			}
			else if(e.KeyCode==Keys.Up) {
				e.Handled=true;
				Increment();
			}
			else if((e.KeyCode==Keys.D0)||(e.KeyCode==Keys.D1)||(e.KeyCode==Keys.D2)||(e.KeyCode==Keys.D3)||
				(e.KeyCode==Keys.D4)||(e.KeyCode==Keys.D5)||(e.KeyCode==Keys.D6)||(e.KeyCode==Keys.D7)||
				(e.KeyCode==Keys.D8)||(e.KeyCode==Keys.D9)) {
				e.Handled=true;
			}
			else if((e.KeyCode==Keys.NumPad0)||(e.KeyCode==Keys.NumPad1)||(e.KeyCode==Keys.NumPad2)||(e.KeyCode==Keys.NumPad3)||
				(e.KeyCode==Keys.NumPad4)||(e.KeyCode==Keys.NumPad5)||(e.KeyCode==Keys.NumPad6)||(e.KeyCode==Keys.NumPad7)||
				(e.KeyCode==Keys.NumPad8)||(e.KeyCode==Keys.NumPad9)) {
				e.Handled=true;
			}		
		}

		private void txtHour_Enter(object sender, System.EventArgs e) {
			txtHour.SelectionLength=0;
		}

	}
}
