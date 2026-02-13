using System;
using System.Drawing;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Atalasoft.Annotate;
using Atalasoft.Annotate.UI;

namespace DotAnnotateDemo
{
	public class TemplateManager
	{
		private AnnotationBrush _fill = new AnnotationBrush(Color.White);
		private AnnotationPen _outline = new AnnotationPen(Color.Black, 1);
		private AnnotationFont _font = new AnnotationFont();
		private AnnotationBrush _shadow = null;
		private string _text = "Atalasoft DotAnnotate";
		private PointF _shadowOffset = new PointF(6, 6);
		private AnnotationBrush _fontBrush = new AnnotationBrush(Color.Black);

		public TemplateManager()
		{
		}

		public void SaveSettings(XmlTextWriter writer)
		{
			writer.WriteStartElement("Template");

			if (_fill != null) SerializeObject(writer, "Fill", _fill);
			if (_outline != null) SerializeObject(writer, "Outline", _outline);
			if (_font != null) SerializeObject(writer, "Font", _font);
			if (_shadow != null) SerializeObject(writer, "Shadow", _shadow);
			if (_fontBrush != null) SerializeObject(writer, "FontBrush", _fontBrush);

			writer.WriteElementString("Text", _text);
			writer.WriteElementString("ShadowOffset", _shadowOffset.X.ToString() + "," + _shadowOffset.Y.ToString());

			writer.WriteEndElement();
		}

		private void SerializeObject(XmlTextWriter writer, string element, object obj)
		{
			BinaryFormatter formatter = new BinaryFormatter();
			MemoryStream ms = new MemoryStream();
			try
			{
				formatter.Serialize(ms, obj);
				byte[] data = ms.ToArray();
				
				writer.WriteStartElement(element);
				writer.WriteBinHex(data, 0, data.Length);
				writer.WriteEndElement();
			}
			finally
			{
				ms.Close();
			}
		}

		private object DeserializeObject(XmlTextReader reader)
		{
			BinaryFormatter formatter = new BinaryFormatter();
			formatter.Binder = new CustomDataBinder();
			MemoryStream ms = new MemoryStream();
			try
			{
				// It's a shame that you have to guess at the size.
				int len = 4096;
				byte[] buffer = new byte[len];
				do
				{
					len = reader.ReadBinHex(buffer, 0, len);
					ms.Write(buffer, 0, len);
				} while(len == 4096);

				if (ms.Length > 0)
				{
					ms.Seek(0, SeekOrigin.Begin);
					return formatter.Deserialize(ms);
				}
				else
					return null;
			}
			finally
			{
				ms.Close();
			}
		}

		public void LoadSettings(XmlTextReader reader)
		{
			bool working = true;
			while (reader.Read())
			{
				switch (reader.LocalName)
				{
					case "Template":
						if (!reader.IsStartElement()) working = false;
						break;

					case "Fill":
						_fill = (AnnotationBrush)DeserializeObject(reader);
						break;

					case "Outline":
						_outline = (AnnotationPen)DeserializeObject(reader);
						break;

					case "Font":
						_font = (AnnotationFont)DeserializeObject(reader);
						break;

					case "Shadow":
						_shadow = (AnnotationBrush)DeserializeObject(reader);
						break;

					case "FontBrush":
						_fontBrush = (AnnotationBrush)DeserializeObject(reader);
						break;

					case "Text":
						_text = reader.ReadString();
						break;

					case "ShadowOffset":
						string p = reader.ReadString();
						int pos = p.IndexOf(",");
						if (pos > -1)
							_shadowOffset = new PointF(float.Parse(p.Substring(0, pos)), float.Parse(p.Substring(pos + 1)));
						break;
				}

				if (!working) break;
			}
		}

		[Description("The default fill for annotations.")]
		public AnnotationBrush Fill
		{
			get { return this._fill; }
			set { this._fill = value; }
		}

		[Description("The default outline for annotations.")]
		public AnnotationPen Outline
		{
			get { return this._outline; }
			set { this._outline = value; }
		}

		[Description("The default shadow for annotations.")]
		public AnnotationBrush Shadow
		{
			get { return this._shadow; }
			set { this._shadow = value; }
		}

		[Description("The default font for Text Annotations.")]
		public AnnotationFont Font
		{
			get { return this._font; }
			set { this._font = value; }
		}

		[Description("The default text for Text Annotations.")]
		public string Text
		{
			get { return this._text; }
			set { this._text = value; }
		}

		[Description("The default brush used for text.")]
		public AnnotationBrush FontBrush
		{
			get { return this._fontBrush; }
			set { this._fontBrush = value; }
		}

		[Description("The distance to offset the shadow from the annotation.")]
		[TypeConverter(typeof(Atalasoft.Converters.PointFTypeConverter))]
		public PointF ShadowOffset
		{
			get { return this._shadowOffset; }
			set { this._shadowOffset = value; }
		}

		public void SetAnnotationDefaults(AnnotationUI annotation)
		{
			// There are probably several ways to handle this.
			// We're just going to use reflection to search for
			// specific property names and types.
			Type t = annotation.GetType();
			
			SetProperty(t, "Fill", annotation, typeof(AnnotationBrush), (this._fill == null ? null : this._fill.Clone()));
			SetProperty(t, "Outline", annotation, typeof(AnnotationPen), (this._outline == null ? null : this._outline.Clone()));
			SetProperty(t, "Shadow", annotation, typeof(AnnotationBrush), (this._shadow == null ? null : this._shadow.Clone()));
			SetProperty(t, "ShadowOffset", annotation, typeof(PointF), this._shadowOffset);
			SetProperty(t, "Font", annotation, typeof(AnnotationFont), (this._font == null ? null : this._font.Clone()));
			SetProperty(t, "Text", annotation, typeof(string), this._text);
			SetProperty(t, "FontBrush", annotation, typeof(AnnotationBrush), (this._fontBrush == null ? null : this._fontBrush.Clone()));
		}

		private void SetProperty(Type annType, string propertyName, AnnotationUI annotation, Type valueType, object value)
		{
			PropertyInfo info = annType.GetProperty(propertyName);
			if (info != null && info.CanWrite)
			{
				if (info.PropertyType == valueType)
					info.SetValue(annotation, value, null);
			}
		}
	}

	// This is used to keep the BinaryFormatter from crying about any version change.
	public class CustomDataBinder : SerializationBinder
	{
		public CustomDataBinder()
		{
		}

		public override Type BindToType(string assemblyName, string typeName)
		{
			// We will just ignore the version.
			int pos = assemblyName.IndexOf(",");
			if (pos == -1) return null;

			Assembly asm = Assembly.Load(assemblyName.Substring(0, pos));
			if (asm == null) return null;

			return asm.GetType(typeName);
		}

	}
}
