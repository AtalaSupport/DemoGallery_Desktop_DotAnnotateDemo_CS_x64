using System;
using System.IO;
using System.Xml;

namespace DotAnnotateDemo
{
	public class ApplicationPreferences
	{
		private TemplateManager _template;
		private string _settingsPath;
		private bool _burnConvert = true;
		private bool _multipageSupport;
		private Atalasoft.Annotate.AnnotationConfinementMode _confinement = Atalasoft.Annotate.AnnotationConfinementMode.None;
		private System.Drawing.Drawing2D.SmoothingMode _smoothing = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
		private System.Windows.Forms.Keys _keyMoveLeft;
		private System.Windows.Forms.Keys _keyMoveRight;
		private System.Windows.Forms.Keys _keyMoveUp;
		private System.Windows.Forms.Keys _keyMoveDown;
		private System.Windows.Forms.Keys _keyIncreaseHeight;
		private System.Windows.Forms.Keys _keyIncreaseWidth;
		private System.Windows.Forms.Keys _keyDecreaseHeight;
		private System.Windows.Forms.Keys _keyDecreaseWidth;
		private System.Windows.Forms.Keys _keyClearSelection;
		private System.Windows.Forms.Keys _keySelectNext;
		private System.Windows.Forms.Keys _keySelectPrevious;
		private System.Windows.Forms.Keys _keySelectLeft;
		private System.Windows.Forms.Keys _keySelectRight;
		private System.Windows.Forms.Keys _keySelectAbove;
		private System.Windows.Forms.Keys _keySelectBelow;
		private System.Windows.Forms.Keys _keyRotateClockwise;
		private System.Windows.Forms.Keys _keyRotateCounterclockwise;
		private System.Windows.Forms.Keys _multiSelectKey;
		private Atalasoft.Annotate.AnnotationUnit _units = Atalasoft.Annotate.AnnotationUnit.Pixel;
		private float _rotationSnapInterval;
		private float _rotationSnapThreshold;

		public ApplicationPreferences()
		{
		}

		public ApplicationPreferences(string path, TemplateManager template)
		{
			_settingsPath = path;
			_template = template;
			LoadPreferences();
		}

		public void LoadPreferences()
		{
			if (_settingsPath != null && File.Exists(_settingsPath))
			{
				XmlTextReader reader = new XmlTextReader(_settingsPath);
				try
				{
					while (reader.Read())
					{
						switch (reader.LocalName)
						{
							case "BurnConvert":
								_burnConvert = bool.Parse(reader.ReadString());
								break;

							case "MultipageSupport":
								_multipageSupport = bool.Parse(reader.ReadString());
								break;

							case "Confinement":
								_confinement = (Atalasoft.Annotate.AnnotationConfinementMode)int.Parse(reader.ReadString());
								break;

							case "Smoothing":
								_smoothing = (System.Drawing.Drawing2D.SmoothingMode)int.Parse(reader.ReadString());
								break;

							case "KeyMoveLeft":
								_keyMoveLeft = (System.Windows.Forms.Keys)int.Parse(reader.ReadString());
								break;

							case "KeyMoveRight":
								_keyMoveRight = (System.Windows.Forms.Keys)int.Parse(reader.ReadString());
								break;

							case "KeyMoveUp":
								_keyMoveUp = (System.Windows.Forms.Keys)int.Parse(reader.ReadString());
								break;

							case "KeyMoveDown":
								_keyMoveDown = (System.Windows.Forms.Keys)int.Parse(reader.ReadString());
								break;

							case "KeyIncreaseHeight":
								_keyIncreaseHeight = (System.Windows.Forms.Keys)int.Parse(reader.ReadString());
								break;

							case "KeyIncreaseWidth":
								_keyIncreaseWidth = (System.Windows.Forms.Keys)int.Parse(reader.ReadString());
								break;

							case "KeyDecreaseHeight":
								_keyDecreaseHeight = (System.Windows.Forms.Keys)int.Parse(reader.ReadString());
								break;

							case "KeyDecreaseWidth":
								_keyDecreaseWidth = (System.Windows.Forms.Keys)int.Parse(reader.ReadString());
								break;

							case "KeyClearSelection":
								_keyClearSelection = (System.Windows.Forms.Keys)int.Parse(reader.ReadString());
								break;

							case "KeySelectLeft":
								_keySelectLeft = (System.Windows.Forms.Keys)int.Parse(reader.ReadString());
								break;

							case "KeySelectRight":
								_keySelectRight = (System.Windows.Forms.Keys)int.Parse(reader.ReadString());
								break;

							case "KeySelectAbove":
								_keySelectAbove = (System.Windows.Forms.Keys)int.Parse(reader.ReadString());
								break;

							case "KeySelectBelow":
								_keySelectBelow = (System.Windows.Forms.Keys)int.Parse(reader.ReadString());
								break;

							case "KeySelectNext":
								_keySelectNext = (System.Windows.Forms.Keys)int.Parse(reader.ReadString());
								break;

							case "KeySelectPrevious":
								_keySelectPrevious = (System.Windows.Forms.Keys)int.Parse(reader.ReadString());
								break;

							case "KeyRotateClockwise":
								_keyRotateClockwise = (System.Windows.Forms.Keys)int.Parse(reader.ReadString());
								break;

							case "KeyRotateCounterclockwise":
								_keyRotateCounterclockwise = (System.Windows.Forms.Keys)int.Parse(reader.ReadString());
								break;

							case "MultiSelectKey":
								_multiSelectKey = (System.Windows.Forms.Keys)int.Parse(reader.ReadString());
								break;

							case "Units":
								_units = (Atalasoft.Annotate.AnnotationUnit)int.Parse(reader.ReadString());
								break;

							case "RotationSnapInterval":
								_rotationSnapInterval = float.Parse(reader.ReadString());
								break;

							case "RotationSnapThreshold":
								_rotationSnapThreshold = float.Parse(reader.ReadString());
								break;

							case "Template":
								if (_template != null)
									_template.LoadSettings(reader);
								break;
						}
					}
				}
				catch (Exception ex)
				{
					System.Windows.Forms.MessageBox.Show("Error loading preferences:\r\n\r\n" + ex.Message, "Error");
				}
				finally
				{
					reader.Close();
				}
			}
		}

		public void Save()
		{
			if (_settingsPath == null) return;

			XmlTextWriter writer = new XmlTextWriter(_settingsPath, System.Text.Encoding.UTF8);
			writer.Formatting = Formatting.Indented;

			try
			{
				writer.WriteStartDocument(true);
				writer.WriteStartElement("Preferences");

				writer.WriteElementString("BurnConvert", _burnConvert.ToString());
				writer.WriteElementString("MultipageSupport", _multipageSupport.ToString());
				writer.WriteElementString("Confinement", ((int)_confinement).ToString());
				writer.WriteElementString("Smoothing", ((int)_smoothing).ToString());
				writer.WriteElementString("KeyMoveLeft", ((int)_keyMoveLeft).ToString());
				writer.WriteElementString("KeyMoveRight", ((int)_keyMoveRight).ToString());
				writer.WriteElementString("KeyMoveUp", ((int)_keyMoveUp).ToString());
				writer.WriteElementString("KeyMoveDown", ((int)_keyMoveDown).ToString());
				writer.WriteElementString("KeyIncreaseHeight", ((int)_keyIncreaseHeight).ToString());
				writer.WriteElementString("KeyIncreaseWidth", ((int)_keyIncreaseWidth).ToString());
				writer.WriteElementString("KeyDecreaseHeight", ((int)_keyDecreaseHeight).ToString());
				writer.WriteElementString("KeyDecreaseWidth", ((int)_keyDecreaseWidth).ToString());
				writer.WriteElementString("KeyClearSelection", ((int)_keyClearSelection).ToString());
				writer.WriteElementString("KeySelectLeft", ((int)_keySelectLeft).ToString());
				writer.WriteElementString("KeySelectRight", ((int)_keySelectRight).ToString());
				writer.WriteElementString("KeySelectAbove", ((int)_keySelectAbove).ToString());
				writer.WriteElementString("KeySelectBelow", ((int)_keySelectBelow).ToString());
				writer.WriteElementString("KeySelectNext", ((int)_keySelectNext).ToString());
				writer.WriteElementString("KeySelectPrevious", ((int)_keySelectPrevious).ToString());
				writer.WriteElementString("KeyRotateClockwise", ((int)_keyRotateClockwise).ToString());
				writer.WriteElementString("KeyRotateCounterclockwise", ((int)_keyRotateCounterclockwise).ToString());
				writer.WriteElementString("MultiSelectKey", ((int)_multiSelectKey).ToString());
				writer.WriteElementString("Units", ((int)_units).ToString());
				writer.WriteElementString("RotationSnapInterval", _rotationSnapInterval.ToString());
				writer.WriteElementString("RotationSnapThreshold", _rotationSnapThreshold.ToString());

				if (_template != null) _template.SaveSettings(writer);

				writer.WriteEndElement();
				writer.WriteEndDocument();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error saving preferences:\r\n\r\n" + ex.Message, "Error");
			}
			finally
			{
				writer.Close();
			}
		}

		public ApplicationPreferences Clone()
		{
			ApplicationPreferences ap = new ApplicationPreferences();

			ap._burnConvert = this._burnConvert;
			ap._confinement = this._confinement;
			ap._keyClearSelection = this._keyClearSelection;
			ap._keyDecreaseHeight = this._keyDecreaseHeight;
			ap._keyDecreaseWidth = this._keyDecreaseWidth;
			ap._keyIncreaseHeight = this._keyIncreaseHeight;
			ap._keyIncreaseWidth = this._keyIncreaseWidth;
			ap._keyMoveDown = this._keyMoveDown;
			ap._keyMoveLeft = this._keyMoveLeft;
			ap._keyMoveRight = this._keyMoveRight;
			ap._keyMoveUp = this._keyMoveUp;
			ap._keyRotateClockwise = this._keyRotateClockwise;
			ap._keyRotateCounterclockwise = this._keyRotateCounterclockwise;
			ap._keySelectAbove = this._keySelectAbove;
			ap._keySelectBelow = this._keySelectBelow;
			ap._keySelectLeft = this._keySelectLeft;
			ap._keySelectNext = this._keySelectNext;
			ap._keySelectPrevious = this._keySelectPrevious;
			ap._keySelectRight = this._keySelectRight;
			ap._multipageSupport = this._multipageSupport;
			ap._settingsPath = this._settingsPath;
			ap._smoothing = this._smoothing;
			ap._multiSelectKey = this._multiSelectKey;
			ap._units = this._units;
			ap._rotationSnapInterval = this._rotationSnapInterval;
			ap._rotationSnapThreshold = this._rotationSnapThreshold;
			ap._template = this._template;

			return ap;
		}

		#region Properties

		public float RotationSnapInterval
		{
			get { return _rotationSnapInterval; }
			set { _rotationSnapInterval = value; }
		}

		public float RotationSnapThreshold
		{
			get { return _rotationSnapThreshold; }
			set { _rotationSnapThreshold = value; }
		}

		public Atalasoft.Annotate.AnnotationUnit Units
		{
			get { return _units; }
			set { _units = value; }
		}

		public bool BurnConvert
		{
			get { return _burnConvert; }
			set { _burnConvert = value; }
		}

		public bool MultipageSupport
		{
			get { return _multipageSupport; }
			set { _multipageSupport = value; }
		}

		public Atalasoft.Annotate.AnnotationConfinementMode Confinement
		{
			get { return _confinement; }
			set { _confinement = value; }
		}

		public System.Drawing.Drawing2D.SmoothingMode Smoothing
		{
			get { return _smoothing; }
			set { _smoothing = value; }
		}

		public System.Windows.Forms.Keys KeyMoveLeft
		{
			get { return _keyMoveLeft; }
			set { _keyMoveLeft = value; }
		}

		public System.Windows.Forms.Keys KeyMoveRight
		{
			get { return _keyMoveRight; }
			set { _keyMoveRight = value; }
		}

		public System.Windows.Forms.Keys KeyMoveUp
		{
			get { return _keyMoveUp; }
			set { _keyMoveUp = value; }
		}

		public System.Windows.Forms.Keys KeyMoveDown
		{
			get { return _keyMoveDown; }
			set { _keyMoveDown = value; }
		}

		public System.Windows.Forms.Keys KeyIncreaseHeight
		{
			get { return _keyIncreaseHeight; }
			set { _keyIncreaseHeight = value; }
		}

		public System.Windows.Forms.Keys KeyIncreaseWidth
		{
			get { return _keyIncreaseWidth; }
			set { _keyIncreaseWidth = value; }
		}

		public System.Windows.Forms.Keys KeyDecreaseHeight
		{
			get { return _keyDecreaseHeight; }
			set { _keyDecreaseHeight = value; }
		}

		public System.Windows.Forms.Keys KeyDecreaseWidth
		{
			get { return _keyDecreaseWidth; }
			set { _keyDecreaseWidth = value; }
		}

		public System.Windows.Forms.Keys KeyRotateClockwise
		{
			get { return _keyRotateClockwise; }
			set { _keyRotateClockwise = value; }
		}

		public System.Windows.Forms.Keys KeyRotateCounterclockwise
		{
			get { return _keyRotateCounterclockwise; }
			set { _keyRotateCounterclockwise = value; }
		}

		public System.Windows.Forms.Keys KeyClearSelection
		{
			get { return _keyClearSelection; }
			set { _keyClearSelection = value; }
		}

		public System.Windows.Forms.Keys KeySelectNext
		{
			get { return _keySelectNext; }
			set { _keySelectNext = value; }
		}

		public System.Windows.Forms.Keys KeySelectPrevious
		{
			get { return _keySelectPrevious; }
			set { _keySelectPrevious = value; }
		}

		public System.Windows.Forms.Keys KeySelectLeft
		{
			get { return _keySelectLeft; }
			set { _keySelectLeft = value; }
		}

		public System.Windows.Forms.Keys KeySelectRight
		{
			get { return _keySelectRight; }
			set { _keySelectRight = value; }
		}

		public System.Windows.Forms.Keys KeySelectAbove
		{
			get { return _keySelectAbove; }
			set { _keySelectAbove = value; }
		}

		public System.Windows.Forms.Keys KeySelectBelow
		{
			get { return _keySelectBelow; }
			set { _keySelectBelow = value; }
		}

		public System.Windows.Forms.Keys MultiSelectKey
		{
			get { return _multiSelectKey; }
			set { _multiSelectKey = value; }
		}

		#endregion

	}
}
