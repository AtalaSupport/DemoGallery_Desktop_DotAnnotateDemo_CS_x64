using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace DotAnnotateDemo
{
	/// <summary>
	/// Summary description for Preferences.
	/// </summary>
	public class Preferences : System.Windows.Forms.Form
	{
		private ApplicationPreferences _settings;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox textMoveUp;
		private System.Windows.Forms.TextBox textMoveDown;
		private System.Windows.Forms.TextBox textMoveLeft;
		private System.Windows.Forms.TextBox textMoveRight;
		private System.Windows.Forms.TextBox textDecreaseHeight;
		private System.Windows.Forms.TextBox textDecreaseWidth;
		private System.Windows.Forms.TextBox textIncreaseHeight;
		private System.Windows.Forms.TextBox textIncreaseWidth;
		private System.Windows.Forms.TextBox textSelectNext;
		private System.Windows.Forms.TextBox textSelectPrevious;
		private System.Windows.Forms.TextBox textSelectLeft;
		private System.Windows.Forms.TextBox textSelectRight;
		private System.Windows.Forms.TextBox textSelectAbove;
		private System.Windows.Forms.TextBox textSelectBelow;
		private System.Windows.Forms.TextBox textRotateClockwise;
		private System.Windows.Forms.TextBox textRotateCounterclockwise;
		private System.Windows.Forms.TextBox textClearSelection;
		private System.Windows.Forms.CheckBox chkBurnConvert;
		private System.Windows.Forms.CheckBox chkMultipageSupport;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.ComboBox cboConfinement;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.ComboBox cboSmoothing;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.TextBox textMultiSelectKey;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.ComboBox cboUnits;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.TextBox textRotationSnapInterval;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.TextBox textRotationSnapThreshold;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Preferences(ApplicationPreferences settings)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			_settings = settings.Clone();
			SetControlValues();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.cboUnits = new System.Windows.Forms.ComboBox();
			this.label21 = new System.Windows.Forms.Label();
			this.textMultiSelectKey = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.cboSmoothing = new System.Windows.Forms.ComboBox();
			this.label19 = new System.Windows.Forms.Label();
			this.cboConfinement = new System.Windows.Forms.ComboBox();
			this.label18 = new System.Windows.Forms.Label();
			this.chkMultipageSupport = new System.Windows.Forms.CheckBox();
			this.chkBurnConvert = new System.Windows.Forms.CheckBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.textClearSelection = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.textRotateCounterclockwise = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.textIncreaseWidth = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.textRotateClockwise = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.textIncreaseHeight = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.textSelectBelow = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.textDecreaseWidth = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.textSelectAbove = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.textSelectRight = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.textSelectLeft = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.textSelectPrevious = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textSelectNext = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textDecreaseHeight = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textMoveRight = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textMoveLeft = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textMoveDown = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textMoveUp = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label22 = new System.Windows.Forms.Label();
			this.textRotationSnapInterval = new System.Windows.Forms.TextBox();
			this.label23 = new System.Windows.Forms.Label();
			this.textRotationSnapThreshold = new System.Windows.Forms.TextBox();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(554, 264);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.textRotationSnapThreshold);
			this.tabPage1.Controls.Add(this.label23);
			this.tabPage1.Controls.Add(this.textRotationSnapInterval);
			this.tabPage1.Controls.Add(this.label22);
			this.tabPage1.Controls.Add(this.cboUnits);
			this.tabPage1.Controls.Add(this.label21);
			this.tabPage1.Controls.Add(this.textMultiSelectKey);
			this.tabPage1.Controls.Add(this.label20);
			this.tabPage1.Controls.Add(this.cboSmoothing);
			this.tabPage1.Controls.Add(this.label19);
			this.tabPage1.Controls.Add(this.cboConfinement);
			this.tabPage1.Controls.Add(this.label18);
			this.tabPage1.Controls.Add(this.chkMultipageSupport);
			this.tabPage1.Controls.Add(this.chkBurnConvert);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(546, 238);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "General";
			// 
			// cboUnits
			// 
			this.cboUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboUnits.Items.AddRange(new object[] {
														  "Pixel",
														  "Inch",
														  "Micrometer",
														  "Centimeter",
														  "Foot",
														  "Yard",
														  "Meter",
														  "Mile",
														  "Kilometer"});
			this.cboUnits.Location = new System.Drawing.Point(392, 96);
			this.cboUnits.Name = "cboUnits";
			this.cboUnits.Size = new System.Drawing.Size(136, 21);
			this.cboUnits.TabIndex = 9;
			this.cboUnits.SelectedIndexChanged += new System.EventHandler(this.cboUnits_SelectedIndexChanged);
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(264, 96);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(96, 21);
			this.label21.TabIndex = 8;
			this.label21.Text = "Units Of Measure:";
			this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textMultiSelectKey
			// 
			this.textMultiSelectKey.Location = new System.Drawing.Point(392, 72);
			this.textMultiSelectKey.Name = "textMultiSelectKey";
			this.textMultiSelectKey.Size = new System.Drawing.Size(136, 20);
			this.textMultiSelectKey.TabIndex = 7;
			this.textMultiSelectKey.Text = "";
			this.textMultiSelectKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textMultiSelectKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProcessKeyDown);
			this.textMultiSelectKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ProcessKeyPress);
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(264, 72);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(120, 20);
			this.label20.TabIndex = 6;
			this.label20.Text = "Multi-select Key:";
			this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cboSmoothing
			// 
			this.cboSmoothing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboSmoothing.Items.AddRange(new object[] {
															  "None",
															  "AntiAlias",
															  "Default",
															  "HighQuality",
															  "HighSpeed"});
			this.cboSmoothing.Location = new System.Drawing.Point(392, 48);
			this.cboSmoothing.Name = "cboSmoothing";
			this.cboSmoothing.Size = new System.Drawing.Size(136, 21);
			this.cboSmoothing.TabIndex = 5;
			this.cboSmoothing.SelectedIndexChanged += new System.EventHandler(this.cboSmoothing_SelectedIndexChanged);
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(264, 48);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(120, 21);
			this.label19.TabIndex = 4;
			this.label19.Text = "Smoothing Mode:";
			this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cboConfinement
			// 
			this.cboConfinement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboConfinement.Items.AddRange(new object[] {
																"None",
																"ClientArea",
																"DocumentBounds"});
			this.cboConfinement.Location = new System.Drawing.Point(392, 24);
			this.cboConfinement.Name = "cboConfinement";
			this.cboConfinement.Size = new System.Drawing.Size(136, 21);
			this.cboConfinement.TabIndex = 3;
			this.cboConfinement.SelectedIndexChanged += new System.EventHandler(this.cboConfinement_SelectedIndexChanged);
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(264, 24);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(136, 21);
			this.label18.TabIndex = 2;
			this.label18.Text = "Annotation Confinement:";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// chkMultipageSupport
			// 
			this.chkMultipageSupport.Location = new System.Drawing.Point(24, 48);
			this.chkMultipageSupport.Name = "chkMultipageSupport";
			this.chkMultipageSupport.Size = new System.Drawing.Size(168, 16);
			this.chkMultipageSupport.TabIndex = 1;
			this.chkMultipageSupport.Text = "Multipage Annotate Support";
			this.chkMultipageSupport.CheckedChanged += new System.EventHandler(this.chkMultipageSupport_CheckedChanged);
			// 
			// chkBurnConvert
			// 
			this.chkBurnConvert.Location = new System.Drawing.Point(24, 24);
			this.chkBurnConvert.Name = "chkBurnConvert";
			this.chkBurnConvert.Size = new System.Drawing.Size(208, 16);
			this.chkBurnConvert.TabIndex = 0;
			this.chkBurnConvert.Text = "Convert Pixel Format When Burning";
			this.chkBurnConvert.CheckedChanged += new System.EventHandler(this.chkBurnConvert_CheckedChanged);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.textClearSelection);
			this.tabPage2.Controls.Add(this.label17);
			this.tabPage2.Controls.Add(this.textRotateCounterclockwise);
			this.tabPage2.Controls.Add(this.label16);
			this.tabPage2.Controls.Add(this.textIncreaseWidth);
			this.tabPage2.Controls.Add(this.label15);
			this.tabPage2.Controls.Add(this.textRotateClockwise);
			this.tabPage2.Controls.Add(this.label14);
			this.tabPage2.Controls.Add(this.textIncreaseHeight);
			this.tabPage2.Controls.Add(this.label13);
			this.tabPage2.Controls.Add(this.textSelectBelow);
			this.tabPage2.Controls.Add(this.label12);
			this.tabPage2.Controls.Add(this.textDecreaseWidth);
			this.tabPage2.Controls.Add(this.label11);
			this.tabPage2.Controls.Add(this.textSelectAbove);
			this.tabPage2.Controls.Add(this.label10);
			this.tabPage2.Controls.Add(this.textSelectRight);
			this.tabPage2.Controls.Add(this.label9);
			this.tabPage2.Controls.Add(this.textSelectLeft);
			this.tabPage2.Controls.Add(this.label8);
			this.tabPage2.Controls.Add(this.textSelectPrevious);
			this.tabPage2.Controls.Add(this.label7);
			this.tabPage2.Controls.Add(this.textSelectNext);
			this.tabPage2.Controls.Add(this.label6);
			this.tabPage2.Controls.Add(this.textDecreaseHeight);
			this.tabPage2.Controls.Add(this.label5);
			this.tabPage2.Controls.Add(this.textMoveRight);
			this.tabPage2.Controls.Add(this.label4);
			this.tabPage2.Controls.Add(this.textMoveLeft);
			this.tabPage2.Controls.Add(this.label3);
			this.tabPage2.Controls.Add(this.textMoveDown);
			this.tabPage2.Controls.Add(this.label2);
			this.tabPage2.Controls.Add(this.textMoveUp);
			this.tabPage2.Controls.Add(this.label1);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(546, 238);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Key Bindings";
			// 
			// textClearSelection
			// 
			this.textClearSelection.Location = new System.Drawing.Point(112, 208);
			this.textClearSelection.Name = "textClearSelection";
			this.textClearSelection.Size = new System.Drawing.Size(120, 20);
			this.textClearSelection.TabIndex = 33;
			this.textClearSelection.Text = "None";
			this.textClearSelection.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textClearSelection.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProcessKeyDown);
			this.textClearSelection.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ProcessKeyPress);
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(16, 208);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(96, 20);
			this.label17.TabIndex = 32;
			this.label17.Text = "Clear Selection:";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textRotateCounterclockwise
			// 
			this.textRotateCounterclockwise.Location = new System.Drawing.Point(408, 184);
			this.textRotateCounterclockwise.Name = "textRotateCounterclockwise";
			this.textRotateCounterclockwise.Size = new System.Drawing.Size(120, 20);
			this.textRotateCounterclockwise.TabIndex = 31;
			this.textRotateCounterclockwise.Text = "None";
			this.textRotateCounterclockwise.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textRotateCounterclockwise.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProcessKeyDown);
			this.textRotateCounterclockwise.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ProcessKeyPress);
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(272, 184);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(136, 20);
			this.label16.TabIndex = 30;
			this.label16.Text = "Rotate Counterclockwise:";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textIncreaseWidth
			// 
			this.textIncreaseWidth.Location = new System.Drawing.Point(112, 184);
			this.textIncreaseWidth.Name = "textIncreaseWidth";
			this.textIncreaseWidth.Size = new System.Drawing.Size(120, 20);
			this.textIncreaseWidth.TabIndex = 29;
			this.textIncreaseWidth.Text = "None";
			this.textIncreaseWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textIncreaseWidth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProcessKeyDown);
			this.textIncreaseWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ProcessKeyPress);
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(16, 184);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(96, 20);
			this.label15.TabIndex = 28;
			this.label15.Text = "Increase Width:";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textRotateClockwise
			// 
			this.textRotateClockwise.Location = new System.Drawing.Point(408, 160);
			this.textRotateClockwise.Name = "textRotateClockwise";
			this.textRotateClockwise.Size = new System.Drawing.Size(120, 20);
			this.textRotateClockwise.TabIndex = 27;
			this.textRotateClockwise.Text = "None";
			this.textRotateClockwise.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textRotateClockwise.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProcessKeyDown);
			this.textRotateClockwise.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ProcessKeyPress);
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(272, 160);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(136, 20);
			this.label14.TabIndex = 26;
			this.label14.Text = "Rotate Clockwise:";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textIncreaseHeight
			// 
			this.textIncreaseHeight.Location = new System.Drawing.Point(112, 160);
			this.textIncreaseHeight.Name = "textIncreaseHeight";
			this.textIncreaseHeight.Size = new System.Drawing.Size(120, 20);
			this.textIncreaseHeight.TabIndex = 25;
			this.textIncreaseHeight.Text = "None";
			this.textIncreaseHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textIncreaseHeight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProcessKeyDown);
			this.textIncreaseHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ProcessKeyPress);
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(16, 160);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(96, 20);
			this.label13.TabIndex = 24;
			this.label13.Text = "Increase Height:";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textSelectBelow
			// 
			this.textSelectBelow.Location = new System.Drawing.Point(408, 136);
			this.textSelectBelow.Name = "textSelectBelow";
			this.textSelectBelow.Size = new System.Drawing.Size(120, 20);
			this.textSelectBelow.TabIndex = 23;
			this.textSelectBelow.Text = "None";
			this.textSelectBelow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textSelectBelow.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProcessKeyDown);
			this.textSelectBelow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ProcessKeyPress);
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(272, 136);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(136, 20);
			this.label12.TabIndex = 22;
			this.label12.Text = "Select Below:";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textDecreaseWidth
			// 
			this.textDecreaseWidth.Location = new System.Drawing.Point(112, 136);
			this.textDecreaseWidth.Name = "textDecreaseWidth";
			this.textDecreaseWidth.Size = new System.Drawing.Size(120, 20);
			this.textDecreaseWidth.TabIndex = 21;
			this.textDecreaseWidth.Text = "None";
			this.textDecreaseWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textDecreaseWidth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProcessKeyDown);
			this.textDecreaseWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ProcessKeyPress);
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(16, 136);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(96, 20);
			this.label11.TabIndex = 20;
			this.label11.Text = "Decrease Width:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textSelectAbove
			// 
			this.textSelectAbove.Location = new System.Drawing.Point(408, 112);
			this.textSelectAbove.Name = "textSelectAbove";
			this.textSelectAbove.Size = new System.Drawing.Size(120, 20);
			this.textSelectAbove.TabIndex = 19;
			this.textSelectAbove.Text = "None";
			this.textSelectAbove.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textSelectAbove.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProcessKeyDown);
			this.textSelectAbove.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ProcessKeyPress);
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(272, 112);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(136, 20);
			this.label10.TabIndex = 18;
			this.label10.Text = "Select Above:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textSelectRight
			// 
			this.textSelectRight.Location = new System.Drawing.Point(408, 88);
			this.textSelectRight.Name = "textSelectRight";
			this.textSelectRight.Size = new System.Drawing.Size(120, 20);
			this.textSelectRight.TabIndex = 17;
			this.textSelectRight.Text = "None";
			this.textSelectRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textSelectRight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProcessKeyDown);
			this.textSelectRight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ProcessKeyPress);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(272, 88);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(136, 20);
			this.label9.TabIndex = 16;
			this.label9.Text = "Select Right:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textSelectLeft
			// 
			this.textSelectLeft.Location = new System.Drawing.Point(408, 64);
			this.textSelectLeft.Name = "textSelectLeft";
			this.textSelectLeft.Size = new System.Drawing.Size(120, 20);
			this.textSelectLeft.TabIndex = 15;
			this.textSelectLeft.Text = "None";
			this.textSelectLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textSelectLeft.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProcessKeyDown);
			this.textSelectLeft.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ProcessKeyPress);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(272, 64);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(136, 20);
			this.label8.TabIndex = 14;
			this.label8.Text = "Select Left:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textSelectPrevious
			// 
			this.textSelectPrevious.Location = new System.Drawing.Point(408, 40);
			this.textSelectPrevious.Name = "textSelectPrevious";
			this.textSelectPrevious.Size = new System.Drawing.Size(120, 20);
			this.textSelectPrevious.TabIndex = 13;
			this.textSelectPrevious.Text = "None";
			this.textSelectPrevious.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textSelectPrevious.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProcessKeyDown);
			this.textSelectPrevious.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ProcessKeyPress);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(272, 40);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(136, 20);
			this.label7.TabIndex = 12;
			this.label7.Text = "Select Previous:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textSelectNext
			// 
			this.textSelectNext.Location = new System.Drawing.Point(408, 16);
			this.textSelectNext.Name = "textSelectNext";
			this.textSelectNext.Size = new System.Drawing.Size(120, 20);
			this.textSelectNext.TabIndex = 11;
			this.textSelectNext.Text = "None";
			this.textSelectNext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textSelectNext.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProcessKeyDown);
			this.textSelectNext.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ProcessKeyPress);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(272, 16);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(136, 20);
			this.label6.TabIndex = 10;
			this.label6.Text = "Select Next:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textDecreaseHeight
			// 
			this.textDecreaseHeight.Location = new System.Drawing.Point(112, 112);
			this.textDecreaseHeight.Name = "textDecreaseHeight";
			this.textDecreaseHeight.Size = new System.Drawing.Size(120, 20);
			this.textDecreaseHeight.TabIndex = 9;
			this.textDecreaseHeight.Text = "None";
			this.textDecreaseHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textDecreaseHeight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProcessKeyDown);
			this.textDecreaseHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ProcessKeyPress);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 112);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(96, 20);
			this.label5.TabIndex = 8;
			this.label5.Text = "Decrease Height:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textMoveRight
			// 
			this.textMoveRight.Location = new System.Drawing.Point(112, 88);
			this.textMoveRight.Name = "textMoveRight";
			this.textMoveRight.Size = new System.Drawing.Size(120, 20);
			this.textMoveRight.TabIndex = 7;
			this.textMoveRight.Text = "None";
			this.textMoveRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textMoveRight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProcessKeyDown);
			this.textMoveRight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ProcessKeyPress);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 88);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(96, 20);
			this.label4.TabIndex = 6;
			this.label4.Text = "Move Right:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textMoveLeft
			// 
			this.textMoveLeft.Location = new System.Drawing.Point(112, 64);
			this.textMoveLeft.Name = "textMoveLeft";
			this.textMoveLeft.Size = new System.Drawing.Size(120, 20);
			this.textMoveLeft.TabIndex = 5;
			this.textMoveLeft.Text = "None";
			this.textMoveLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textMoveLeft.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProcessKeyDown);
			this.textMoveLeft.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ProcessKeyPress);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(96, 20);
			this.label3.TabIndex = 4;
			this.label3.Text = "Move Left:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textMoveDown
			// 
			this.textMoveDown.Location = new System.Drawing.Point(112, 40);
			this.textMoveDown.Name = "textMoveDown";
			this.textMoveDown.Size = new System.Drawing.Size(120, 20);
			this.textMoveDown.TabIndex = 3;
			this.textMoveDown.Text = "None";
			this.textMoveDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textMoveDown.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProcessKeyDown);
			this.textMoveDown.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ProcessKeyPress);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(96, 20);
			this.label2.TabIndex = 2;
			this.label2.Text = "Move Down:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textMoveUp
			// 
			this.textMoveUp.Location = new System.Drawing.Point(112, 16);
			this.textMoveUp.Name = "textMoveUp";
			this.textMoveUp.Size = new System.Drawing.Size(120, 20);
			this.textMoveUp.TabIndex = 1;
			this.textMoveUp.Text = "None";
			this.textMoveUp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textMoveUp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProcessKeyDown);
			this.textMoveUp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ProcessKeyPress);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Move Up:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(166, 280);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(79, 24);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(310, 280);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(79, 24);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(24, 72);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(128, 21);
			this.label22.TabIndex = 10;
			this.label22.Text = "Rotation Snap Interval:";
			this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textRotationSnapInterval
			// 
			this.textRotationSnapInterval.Location = new System.Drawing.Point(160, 72);
			this.textRotationSnapInterval.MaxLength = 5;
			this.textRotationSnapInterval.Name = "textRotationSnapInterval";
			this.textRotationSnapInterval.Size = new System.Drawing.Size(64, 20);
			this.textRotationSnapInterval.TabIndex = 11;
			this.textRotationSnapInterval.Text = "0";
			this.textRotationSnapInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textRotationSnapInterval.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textRotationSnapThreshold_KeyPress);
			this.textRotationSnapInterval.Validating += new System.ComponentModel.CancelEventHandler(this.textRotationSnapInterval_Validating);
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(24, 96);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(144, 21);
			this.label23.TabIndex = 12;
			this.label23.Text = "Rotation Snap Threshold:";
			this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textRotationSnapThreshold
			// 
			this.textRotationSnapThreshold.Location = new System.Drawing.Point(160, 96);
			this.textRotationSnapThreshold.MaxLength = 5;
			this.textRotationSnapThreshold.Name = "textRotationSnapThreshold";
			this.textRotationSnapThreshold.Size = new System.Drawing.Size(64, 20);
			this.textRotationSnapThreshold.TabIndex = 13;
			this.textRotationSnapThreshold.Text = "0";
			this.textRotationSnapThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textRotationSnapThreshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textRotationSnapThreshold_KeyPress);
			this.textRotationSnapThreshold.Validating += new System.ComponentModel.CancelEventHandler(this.textRotationSnapThreshold_Validating);
			// 
			// Preferences
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(554, 320);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.tabControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Preferences";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Preferences";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion


		public ApplicationPreferences Settings
		{
			get { return _settings; }
		}

		private void SetControlValues()
		{
			this.textClearSelection.Text = _settings.KeyClearSelection.ToString();
			this.textDecreaseHeight.Text = _settings.KeyDecreaseHeight.ToString();
			this.textDecreaseWidth.Text = _settings.KeyDecreaseWidth.ToString();
			this.textIncreaseHeight.Text = _settings.KeyIncreaseHeight.ToString();
			this.textIncreaseWidth.Text = _settings.KeyIncreaseWidth.ToString();
			this.textMoveDown.Text = _settings.KeyMoveDown.ToString();
			this.textMoveLeft.Text = _settings.KeyMoveLeft.ToString();
			this.textMoveRight.Text = _settings.KeyMoveRight.ToString();
			this.textMoveUp.Text = _settings.KeyMoveUp.ToString();
			this.textRotateClockwise.Text = _settings.KeyRotateClockwise.ToString();
			this.textRotateCounterclockwise.Text = _settings.KeyRotateCounterclockwise.ToString();
			this.textSelectAbove.Text = _settings.KeySelectAbove.ToString();
			this.textSelectBelow.Text = _settings.KeySelectBelow.ToString();
			this.textSelectLeft.Text = _settings.KeySelectLeft.ToString();
			this.textSelectNext.Text = _settings.KeySelectNext.ToString();
			this.textSelectPrevious.Text = _settings.KeySelectPrevious.ToString();
			this.textSelectRight.Text = _settings.KeySelectRight.ToString();

			this.cboConfinement.Text = _settings.Confinement.ToString();
			this.cboSmoothing.Text = _settings.Smoothing.ToString();
			this.chkBurnConvert.Checked = _settings.BurnConvert;
			this.chkMultipageSupport.Checked = _settings.MultipageSupport;
			this.textMultiSelectKey.Text = _settings.MultiSelectKey.ToString();
			this.cboUnits.Text = _settings.Units.ToString();
			this.textRotationSnapInterval.Text = _settings.RotationSnapInterval.ToString();
			this.textRotationSnapThreshold.Text = _settings.RotationSnapThreshold.ToString();
		}

		private void ProcessKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			TextBox tb = sender as TextBox;
			if (tb == null) return;

            Keys selectedKey = e.KeyData;

            if (selectedKey == (Keys.Control | Keys.ControlKey))
                selectedKey = Keys.ControlKey;
            else if (selectedKey == (Keys.Shift | Keys.ShiftKey))
                selectedKey = Keys.ShiftKey;

            tb.Text = selectedKey.ToString();
			e.Handled = true;

			switch (tb.Name)
			{
                case "textMultiSelectKey":
                    _settings.MultiSelectKey = selectedKey;
                    break;
				case "textClearSelection":
                    _settings.KeyClearSelection = selectedKey;
					break;
				case "textDecreaseHeight":
                    _settings.KeyDecreaseHeight = selectedKey;
					break;
				case "textDecreaseWidth":
                    _settings.KeyDecreaseWidth = selectedKey;
					break;
				case "textIncreaseHeight":
                    _settings.KeyIncreaseHeight = selectedKey;
					break;
				case "textIncreaseWidth":
                    _settings.KeyIncreaseWidth = selectedKey;
					break;
				case "textMoveDown":
                    _settings.KeyMoveDown = selectedKey;
					break;
				case "textMoveLeft":
                    _settings.KeyMoveLeft = selectedKey;
					break;
				case "textMoveRight":
                    _settings.KeyMoveRight = selectedKey;
					break;
				case "textMoveUp":
                    _settings.KeyMoveUp = selectedKey;
					break;
				case "textRotateClockwise":
                    _settings.KeyRotateClockwise = selectedKey;
					break;
				case "textRotateCounterclockwise":
                    _settings.KeyRotateCounterclockwise = selectedKey;
					break;
				case "textSelectAbove":
                    _settings.KeySelectAbove = selectedKey;
					break;
				case "textSelectBelow":
                    _settings.KeySelectBelow = selectedKey;
					break;
				case "textSelectLeft":
                    _settings.KeySelectLeft = selectedKey;
					break;
				case "textSelectNext":
                    _settings.KeySelectNext = selectedKey;
					break;
				case "textSelectPrevious":
                    _settings.KeySelectPrevious = selectedKey;
					break;
				case "textSelectRight":
                    _settings.KeySelectRight = selectedKey;
					break;
			}
		}

		private void ProcessKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			// This will keep the actual key stroke from displaying.
			e.Handled = true;
		}

		private void chkBurnConvert_CheckedChanged(object sender, System.EventArgs e)
		{
			_settings.BurnConvert = this.chkBurnConvert.Checked;
		}

		private void chkMultipageSupport_CheckedChanged(object sender, System.EventArgs e)
		{
			_settings.MultipageSupport = this.chkMultipageSupport.Checked;
		}

		private void cboConfinement_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			_settings.Confinement = (Atalasoft.Annotate.AnnotationConfinementMode)Enum.Parse(typeof(Atalasoft.Annotate.AnnotationConfinementMode), this.cboConfinement.Text, true);
		}

		private void cboSmoothing_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			_settings.Smoothing = (System.Drawing.Drawing2D.SmoothingMode)Enum.Parse(typeof(System.Drawing.Drawing2D.SmoothingMode), this.cboSmoothing.Text, true);
		}

		private void cboUnits_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			_settings.Units = (Atalasoft.Annotate.AnnotationUnit)Enum.Parse(typeof(Atalasoft.Annotate.AnnotationUnit), this.cboUnits.Text, true);
		}

		private void textRotationSnapInterval_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				// The value must be evenly divisible into 360.
				float val = float.Parse(this.textRotationSnapInterval.Text);
				if (val == 360) val = 0;
				if (val != 0)
				{
					if (val < 0) val = -val;
					if (val > 180) val = val % 360;
					if (360 % val != 0)
					{
						e.Cancel = true;
						MessageBox.Show("The value must be evenly divisible into 360.", "Invalid Interval");
						return;
					}
				}

				this.textRotationSnapInterval.Text = val.ToString();
				_settings.RotationSnapInterval = val;
			}
			catch
			{
				e.Cancel = true;
				MessageBox.Show("This should be a float (Single).", "Invalid Interval");
			}
		}

		private void textRotationSnapThreshold_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				float interval = float.Parse(this.textRotationSnapInterval.Text);
				float val = float.Parse(this.textRotationSnapThreshold.Text);
				if (val != 0)
				{
					if (val < 0) val = -val;
					if (val > interval / 2f)
					{
						e.Cancel = true;
						MessageBox.Show("The threshold value cannot be greater than half the interval.", "Invalid Threshold");
						return;
					}
				}

				this.textRotationSnapThreshold.Text = val.ToString();
				_settings.RotationSnapThreshold = val;
			}
			catch
			{
				e.Cancel = true;
				MessageBox.Show("This should be a float (Single).", "Invalid Threshold");
			}
		}

		private void textRotationSnapThreshold_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			string chars = "0123456789.";
			if (chars.IndexOf(e.KeyChar) == -1)
				e.Handled = true;
		}

	}
}
