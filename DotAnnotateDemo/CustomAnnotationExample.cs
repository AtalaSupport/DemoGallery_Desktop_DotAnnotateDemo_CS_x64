/// This file contains classes used to provide an example of creating your
/// own custom annotation, including the data, UI and renderer.

using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.Security.Permissions;
using Atalasoft.Annotate;
using Atalasoft.Annotate.UI;

namespace DotAnnotateDemo
{
	/// <summary>
	/// The TriangleData class is used to hold information describing the annotation.
	/// In this case it provide a Fill property and the triangle points.
	/// </summary>
	public class TriangleData : Atalasoft.Annotate.AnnotationData, ISerializable, ICloneable
	{
		private AnnotationBrush _fill = null;

		static TriangleData()
		{
			// This will automatically register the TriangleRenderingEngine
			// when the first TriangleData is created.
			Atalasoft.Annotate.Renderer.AnnotationRenderers.Add(typeof(TriangleData), new TriangleRenderingEngine());
		}

		public TriangleData()
		{
			this._fill = new AnnotationBrush(Color.Blue);
			base.SetBrushEvents(this._fill);
		}

		/// <summary>
		/// This constructor is called when deserializing annotation data.
		/// </summary>
		public TriangleData(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			this._fill = (AnnotationBrush)Atalasoft.Utils.SerializationInfoHelper.GetValue(info, "Fill", new AnnotationBrush(Color.Blue));
			base.SetBrushEvents(this._fill);
		}

		[SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter=true)]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);
			info.AddValue("Fill", this._fill);
		}

		public override object Clone()
		{
			TriangleData data = new TriangleData();
			base.CloneBaseData(data);
			data._fill = (this._fill == null ? null : this._fill.Clone());
			return data;
		}

		public AnnotationBrush Fill
		{
			get { return this._fill; }
			set 
			{ 
				// If there is no change just ignore it.
				if (value == this._fill) return;

				// Raise the PropertyChanging event so any derived classes are notified.
				// If IgnoreDataChanges is true, we should not raise events.  This can
				// happen when making internal changes that we don't want propagated.
				AnnotationPropertyChangingEventArgs e = new AnnotationPropertyChangingEventArgs(this, "Fill", this._fill, value);
				if (!this.IgnoreDataChanges)
				{
					OnPropertyChanging(e);
					if (e.Cancel) return;
				}

				// If we want this property to work with the UndoManager, we must
				// pass in an AnnotationUndo object for this change.
				AnnotationUndo undo = new AnnotationUndo(this, "Fill", this._fill, "Fill Change");

				// If dynamic changes are required for brush properties,
				// the SetBrushEvents and RemoveBrushEvents methods should
				// be used.  These allow the brush properties to notify
				// the AnnotationController that a change was made.
				base.RemoveBrushEvents(this._fill);
				this._fill = value; 
				base.SetBrushEvents(this._fill);
				
				// Finally, pass the undo object to the AnnotationController.
				if (!this.IgnoreDataChanges)
					OnAnnotationControllerNotification(new AnnotationControllerNotificationEventArgs(Atalasoft.Annotate.AnnotationControllerNotification.Invalidate, undo));
			}
		}

		/// <summary>
		/// Returns the points for the triangle in annotation space.
		/// </summary>
		/// <returns></returns>
		public PointF[] GetTrianglePoints()
		{
			PointF[] points = new PointF[3];
			points[0] = new PointF(0, this.Size.Height);
			points[1] = new PointF(this.Size.Width, this.Size.Height);
			points[2] = new PointF(this.Size.Width / 2f, 0);
			return points;
		}

	}


	/// <summary>
	/// Here is the actual UI annotation that will be created for the viewer.
	/// </summary>
	public class TriangleAnnotation : Atalasoft.Annotate.UI.AnnotationUI, ISerializable, Atalasoft.Annotate.Formatters.ILegacyXmpSupport
	{
		// It's sometimes useful to hold onto a specific data object.
		private TriangleData _data;

		public TriangleAnnotation() : base(new TriangleData())
		{
			this._data = this.Data as TriangleData;
			base.SetGrips(new RectangleGrips());
		}

		public TriangleAnnotation(TriangleData data) : base(data)
		{
			this._data = data;
			base.SetGrips(new RectangleGrips());
		}

		public TriangleAnnotation(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			this._data = this.Data as TriangleData;
			base.SetGrips(new RectangleGrips());
		}

		public override AnnotationUI Clone()
		{
			return new TriangleAnnotation((TriangleData)this._data.Clone());
		}

		/// <summary>
		/// Primarily this region is used for hit testing and cursor changes.
		/// </summary>
		/// <param name="space">The space coordinates that should be returned.</param>
		
		public override AnnotationRegion GetRegion(AnnotateSpace space)
		{
			AnnotationRegion region = new AnnotationRegion();
			SizeF size = this.Data.Size;

			// Specify the points in annotation space.
			region.Path.AddPolygon(this._data.GetTrianglePoints());

			// Be sure to add the grips to the region.
			base.AddGripsToRegion(region);

			// Apply the required transformation.
			base.ApplyRegionTransform(region, space);
			return region;
		}

		#region ILegacyXmpSupport Members

		public void FromXmp(System.Xml.XmlTextReader reader)
		{
			// The reader will only contain custom tags.
			while (reader.Read())
			{
				if (reader.LocalName == "Fill")
				{
					this._data.Fill = Atalasoft.Annotate.Formatters.LegacyXmpFormatter.DeserializeBrush(reader);
					break;
				}
			}
		}

		public void ToXmp(System.Xml.XmlTextWriter writer)
		{
			// The CustomAnnotation tag and base have already been written
			// by the formatter.  We only have to add custom properties.
			Atalasoft.Annotate.Formatters.LegacyXmpFormatter.SerializeBrush(writer, this._data.Fill, "ann:Fill");
		}

		#endregion

	}

    public class TriangleAnnotationFactory : IAnnotationUIFactory
    {
        public TriangleAnnotationFactory()
        {
        }

        #region IAnnotationUIFactory Members

        public AnnotationUI GetAnnotationUI(AnnotationData data)
        {
            TriangleData tri = data as TriangleData;
            if (tri == null)
                return null;
            else
                return new TriangleAnnotation(tri);
        }

        #endregion
    }

	/// <summary>
	/// This is the rendering engine for the triangle.
	/// By deriving from the AnnotationRenderingEngine we are
	/// able to simplify the rendering code.
	/// </summary>
	public class TriangleRenderingEngine : Atalasoft.Annotate.Renderer.AnnotationRenderingEngine
	{
		public TriangleRenderingEngine()
		{
			// We will use our own custom grip renderer.
			// We could simply override the RenderGrips method as well.
			//this.GripRenderer = new MyCustomGripRenderer();
		}

		public override void RenderAnnotation(AnnotationData annotation, Atalasoft.Annotate.Renderer.RenderEnvironment e)
		{
			// Perform a basic check.
			TriangleData data = annotation as TriangleData;
			if (data == null) return;

			if (data.Fill == null) return;

			// SetGraphicsTransform handles combining multiple
			// transformation matrix objects so you can render normally.
			base.SetGraphicsTransform(annotation, e);

			Brush b = CreateBrush(data.Fill);
			if (b != null)
			{
				PointF[] points = data.GetTrianglePoints();
				e.Graphics.FillPolygon(b, points);
				b.Dispose();
			}

			// If you call SetGraphicsTransform you must also
			// call RestoreGraphicsTransform when finished.
			base.RestoreGraphicsTransform(e);
		}

		protected override void RenderGrips(IAnnotationGrips grips, AnnotationData annotation, Atalasoft.Annotate.Renderer.RenderEnvironment e, PointF scale)
		{
			// Create the brush and pen objects.
			Brush brush = Atalasoft.Annotate.Renderer.AnnotationRenderingEngine.CreateBrush(grips.Fill);
			Pen pen = Atalasoft.Annotate.Renderer.AnnotationRenderingEngine.CreatePen(grips.Outline);
			Brush rotateBrush = (grips.RotationFill == null ? brush : Atalasoft.Annotate.Renderer.AnnotationRenderingEngine.CreateBrush(grips.RotationFill));
			Pen rotatePen = (grips.RotationOutline == null ? pen : Atalasoft.Annotate.Renderer.AnnotationRenderingEngine.CreatePen(grips.RotationOutline));
			
			SizeF size = grips.Size;
			float w2 = size.Width / 2f;
			float h2 = size.Height / 2f;

			foreach (AnnotationGrip grip in grips)
			{
				// Ignore grips that should not be drawn.
				if (!grip.Visible) continue;
				if (grip.Action == AnnotationGripAction.Rotating && !annotation.CanRotate) continue;

				// While the grip size does not scale, the position of the grip does.
				RectangleF rc = new RectangleF(Convert.ToInt32(grip.Position.X * scale.X - w2), Convert.ToInt32(grip.Position.Y * scale.Y - h2), size.Width, size.Height);

				if (grip.Action == AnnotationGripAction.Rotating && rotateBrush != null)
					e.Graphics.FillRectangle(rotateBrush, rc);
				else if (brush != null)
					e.Graphics.FillEllipse(brush, rc);

				if (grip.Action == AnnotationGripAction.Rotating && rotatePen != null)
					e.Graphics.DrawRectangle(rotatePen, rc.X, rc.Y, rc.Width, rc.Height);
				else if (pen != null)
					e.Graphics.DrawEllipse(pen, rc);
			}

			// Clean up
			if (rotateBrush != null && rotateBrush != brush)
				rotateBrush.Dispose();

			if (rotatePen != null && rotatePen != pen)
				rotatePen.Dispose();

			if (brush != null)
				brush.Dispose();

			if (pen != null)
				pen.Dispose();
		}

	}

	public class MyCustomGripRenderer : Atalasoft.Annotate.Renderer.IAnnotationGripRenderer
	{
		public MyCustomGripRenderer()
		{
		}

		#region IAnnotationGripRenderer Members

		public void RenderGrips(IAnnotationGrips grips, AnnotationData annotation, Atalasoft.Annotate.Renderer.RenderEnvironment e)
		{
			// For a simple example, we will draw circles instead of rectangles
			// for normal grips and rectangles for rotation grips.

			// Just in case...
			if (annotation == null || grips == null || e == null) return;

			// Multiple the annotation transform to the viewer matrix.
			System.Drawing.Drawing2D.Matrix vm = null;
			if (e.Transform != null)
				vm = e.Transform.Clone();
			else if (e.Graphics.Transform != null)
				vm = e.Graphics.Transform.Clone();

			float scaleX = vm.Elements[0];
			float scaleY = vm.Elements[3];

			// The annotation transform.
			System.Drawing.Drawing2D.Matrix m = annotation.GetRenderTransform();
			if (vm != null)
			{
				vm.Multiply(m);
				m.Dispose();
			}
			else
				vm = m;

			// This will undo the scaling the transformation
			// matrix wants to perform, since grips don't scale.
			vm.Scale(1f / scaleX, 1f / scaleY);

			System.Drawing.Drawing2D.GraphicsState state = e.Graphics.Save();
			e.Graphics.Transform = vm;

			// Create the brush and pen objects.
			Brush brush = Atalasoft.Annotate.Renderer.AnnotationRenderingEngine.CreateBrush(grips.Fill);
			Pen pen = Atalasoft.Annotate.Renderer.AnnotationRenderingEngine.CreatePen(grips.Outline);
			Brush rotateBrush = (grips.RotationFill == null ? brush : Atalasoft.Annotate.Renderer.AnnotationRenderingEngine.CreateBrush(grips.RotationFill));
			Pen rotatePen = (grips.RotationOutline == null ? pen : Atalasoft.Annotate.Renderer.AnnotationRenderingEngine.CreatePen(grips.RotationOutline));
			
			SizeF size = grips.Size;
			float w2 = size.Width / 2f;
			float h2 = size.Height / 2f;

			foreach (AnnotationGrip grip in grips)
			{
				// Ignore grips that should not be drawn.
				if (!grip.Visible) continue;
				if (grip.Action == AnnotationGripAction.Rotating && !annotation.CanRotate) continue;

				// While the grip size does not scale, the position of the grip does.
				RectangleF rc = new RectangleF(Convert.ToInt32(grip.Position.X * scaleX - w2), Convert.ToInt32(grip.Position.Y * scaleY - h2), size.Width, size.Height);

				if (grip.Action == AnnotationGripAction.Rotating && rotateBrush != null)
					e.Graphics.FillRectangle(rotateBrush, rc);
				else if (brush != null)
					e.Graphics.FillEllipse(brush, rc);

				if (grip.Action == AnnotationGripAction.Rotating && rotatePen != null)
					e.Graphics.DrawRectangle(rotatePen, rc.X, rc.Y, rc.Width, rc.Height);
				else if (pen != null)
					e.Graphics.DrawEllipse(pen, rc);
			}

			// Clean up
			if (rotateBrush != null && rotateBrush != brush)
				rotateBrush.Dispose();

			if (rotatePen != null && rotatePen != pen)
				rotatePen.Dispose();

			if (brush != null)
				brush.Dispose();

			if (pen != null)
				pen.Dispose();

			e.Graphics.Restore(state);
			vm.Dispose();
		}

		#endregion

	}

}
