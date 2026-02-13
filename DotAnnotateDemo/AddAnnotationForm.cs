using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;

using Atalasoft.Annotate;
using Atalasoft.Annotate.UI;

namespace DotAnnotateDemo
{
	/// <summary>
	/// Summary description for AddAnnotationForm.
	/// </summary>
	public class AddAnnotationForm : System.Windows.Forms.Form
	{
		private Atalasoft.Annotate.UI.AnnotationUI _annotation;

		private System.Windows.Forms.Label label1;
		private Atalasoft.Annotate.UI.AnnotateViewer annotateViewer1;
		private System.Windows.Forms.PropertyGrid propertyGrid1;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cboAnnotation;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AddAnnotationForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AddAnnotationForm));
			this.label1 = new System.Windows.Forms.Label();
			this.annotateViewer1 = new Atalasoft.Annotate.UI.AnnotateViewer();
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.cboAnnotation = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Preview:";
			// 
			// annotateViewer1
			// 
			// 
			// annotateViewer1.Annotations
			// 
			this.annotateViewer1.Annotations.ActiveAnnotation = null;
			this.annotateViewer1.Annotations.AnnotationConfinement = Atalasoft.Annotate.AnnotationConfinementMode.None;
			this.annotateViewer1.Annotations.CurrentLayer = null;
			this.annotateViewer1.Annotations.DefaultSecurity = null;
			this.annotateViewer1.Annotations.InteractMode = Atalasoft.Annotate.AnnotateInteractMode.Edit;
			this.annotateViewer1.Annotations.Parent = this.annotateViewer1;
			this.annotateViewer1.Annotations.Site = null;
			this.annotateViewer1.Annotations.ToolTip = null;
			this.annotateViewer1.Annotations.UndoManager.Levels = 0;
			this.annotateViewer1.AntialiasDisplay = Atalasoft.Imaging.WinControls.AntialiasDisplayMode.ScaleToGray;
			this.annotateViewer1.BackColor = System.Drawing.SystemColors.Control;
			this.annotateViewer1.DisplayProfile = null;
			this.annotateViewer1.Location = new System.Drawing.Point(17, 32);
			this.annotateViewer1.Magnifier.BackColor = System.Drawing.Color.White;
			this.annotateViewer1.Magnifier.BorderColor = System.Drawing.Color.Black;
			this.annotateViewer1.Magnifier.Size = new System.Drawing.Size(100, 100);
			this.annotateViewer1.Name = "annotateViewer1";
			this.annotateViewer1.OutputProfile = null;
			this.annotateViewer1.Resolution = ((System.Drawing.PointF)(resources.GetObject("annotateViewer1.Resolution")));
			this.annotateViewer1.ScrollPosition = new System.Drawing.Point(0, 0);
			this.annotateViewer1.ScrollSize = new System.Drawing.Size(0, 0);
			this.annotateViewer1.Selection = null;
			this.annotateViewer1.Size = new System.Drawing.Size(264, 72);
			this.annotateViewer1.TabIndex = 1;
			this.annotateViewer1.Text = "annotateViewer1";
			this.annotateViewer1.ToolTip = null;
			this.annotateViewer1.Units = Atalasoft.Annotate.AnnotationUnit.Pixel;
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.CommandsVisibleIfAvailable = true;
			this.propertyGrid1.HelpVisible = false;
			this.propertyGrid1.LargeButtons = false;
			this.propertyGrid1.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.propertyGrid1.Location = new System.Drawing.Point(17, 152);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
			this.propertyGrid1.Size = new System.Drawing.Size(264, 136);
			this.propertyGrid1.TabIndex = 2;
			this.propertyGrid1.Text = "propertyGrid1";
			this.propertyGrid1.ToolbarVisible = false;
			this.propertyGrid1.ViewBackColor = System.Drawing.SystemColors.Window;
			this.propertyGrid1.ViewForeColor = System.Drawing.SystemColors.WindowText;
			// 
			// btnAdd
			// 
			this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnAdd.Location = new System.Drawing.Point(41, 304);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(72, 32);
			this.btnAdd.TabIndex = 3;
			this.btnAdd.Text = "&Add";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(185, 304);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(72, 32);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "&Cancel";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 120);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(96, 16);
			this.label2.TabIndex = 5;
			this.label2.Text = "Annotation:";
			// 
			// cboAnnotation
			// 
			this.cboAnnotation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboAnnotation.Location = new System.Drawing.Point(88, 118);
			this.cboAnnotation.Name = "cboAnnotation";
			this.cboAnnotation.Size = new System.Drawing.Size(192, 21);
			this.cboAnnotation.TabIndex = 6;
			this.cboAnnotation.SelectedIndexChanged += new System.EventHandler(this.cboAnnotation_SelectedIndexChanged);
			// 
			// AddAnnotationForm
			// 
			this.AcceptButton = this.btnAdd;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(298, 352);
			this.ControlBox = false;
			this.Controls.Add(this.cboAnnotation);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.propertyGrid1);
			this.Controls.Add(this.annotateViewer1);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AddAnnotationForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add Annotation";
			this.Load += new System.EventHandler(this.AddAnnotationForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void AddAnnotationForm_Load(object sender, System.EventArgs e)
		{
			// Fill the combobox with annotation names.
			Assembly asm = GetDotAnnotateAssembly();
			Type[] types = asm.GetTypes();
			Type ann = typeof(Atalasoft.Annotate.UI.AnnotationUI);
			Type ann2 = typeof(Atalasoft.Annotate.UI.PointBaseAnnotation);

			foreach (Type t in types)
			{
				if (t.Namespace == "Atalasoft.Annotate.UI" && !t.IsAbstract && t.IsPublic)
				{
					// Check for classes deriving from AnnotationUI or PointBaseAnnotation.
					if (t.BaseType == ann || t.BaseType == ann2)
					{
						if (t.Name != "LayerAnnotation")
							this.cboAnnotation.Items.Add(t.Name);
					}
				}
			}
		}

		private void cboAnnotation_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// Create the active annotation and show it in the preview.
			Assembly asm = GetDotAnnotateAssembly();
			if (asm == null) return;

			this._annotation = (AnnotationUI)asm.CreateInstance("Atalasoft.Annotate.UI." + this.cboAnnotation.Text);
			this._annotation.Data.Location = new PointF((float)(this.annotateViewer1.Width - 250) / 2f, (float)(this.annotateViewer1.Height - 50) / 2f);
			this._annotation.Data.Size = new SizeF(250, 50);
			this.propertyGrid1.SelectedObject = this._annotation;

			// Add the first layer.
			if (this.annotateViewer1.Annotations.CurrentLayer == null)
				this.annotateViewer1.Annotations.Layers.Add(new LayerAnnotation());

			this.annotateViewer1.Annotations.CurrentLayer.Items.Clear();
			this.annotateViewer1.Annotations.CurrentLayer.Items.Add(this._annotation);
		}

		private Assembly GetDotAnnotateAssembly()
		{
			// Fill the combobox with annotation names.
			Assembly asm = Assembly.LoadWithPartialName("Atalasoft.DotAnnotate");
			if (asm == null)
			{
				MessageBox.Show(this, "Failed loadding the DotAnnotate assembly.", "DotAnnoate Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return null;
			}

			return asm;
		}

		public AnnotationUI Annotation
		{
			get { return this._annotation; }
		}
	}
}
