using System;
using System.Drawing;
using System.Runtime.Serialization;
using Atalasoft.Annotate;
using Atalasoft.Annotate.UI;
using Atalasoft.Annotate.Renderer;

namespace DotAnnotateDemo
{
	[Serializable]
	public class TrianglePointData : PointBaseData
	{
		private AnnotationBrush _fill = new AnnotationBrush(Color.Red);

		static TrianglePointData()
		{
			AnnotationRenderers.Add(typeof(TrianglePointData), new TrianglePointRenderingEngine());
		}

		public TrianglePointData()
		{
		}

		public TrianglePointData(PointF[] points)
			: base(new PointFCollection(points))
		{
		}

		public TrianglePointData(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			_fill = (AnnotationBrush)info.GetValue("Fill", typeof(AnnotationBrush));
			base.SetBrushEvents(_fill);
		}

		public AnnotationBrush Fill
		{
			get { return _fill; }
			set 
			{
				if (value == _fill) return;

				AnnotationPropertyChangingEventArgs e = new AnnotationPropertyChangingEventArgs(this, "Fill", this._fill, value);
				if (!this.IgnoreDataChanges)
				{
					OnPropertyChanging(e);
					if (e.Cancel) return;
				}

				AnnotationUndo undo = new AnnotationUndo(this, "Fill", this._fill, "Triangle Fill Change");
				
				base.RemoveBrushEvents(_fill);
				_fill = value; 
				base.SetBrushEvents(_fill);
				
				if (!this.IgnoreDataChanges)
					OnAnnotationControllerNotification(new AnnotationControllerNotificationEventArgs(Atalasoft.Annotate.AnnotationControllerNotification.Invalidate, undo));
			}
		}

		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData (info, context);
			info.AddValue("Fill", _fill);
		}


		public override object Clone()
		{
			TrianglePointData data = new TrianglePointData();
			base.CloneBaseData(data);
			
			if (_fill != null) data._fill = _fill.Clone();
			return data;
		}
	}

	[Serializable]
	public class TrianglePointAnnotation : PointBaseAnnotation
	{
		private TrianglePointData _data;
		private int _pointIndex;

		public TrianglePointAnnotation()
			: this(new TrianglePointData())
		{
		}

		public TrianglePointAnnotation(PointF[] points)
			: this(new TrianglePointData(points))
		{
		}

		public TrianglePointAnnotation(TrianglePointData data)
			: base(data)
		{
			_data = data;
		}

		public TrianglePointAnnotation(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			_data = (TrianglePointData)this.Data;
		}

		public AnnotationBrush Fill
		{
			get { return _data.Fill; }
			set { _data.Fill = value; }
		}

		public override AnnotationUI Clone()
		{
			return new TrianglePointAnnotation((TrianglePointData)_data.Clone());
		}

		public override void BeginCreate()
		{
			_pointIndex = 0;
			_data.Points.Clear();
			this.GripMode = AnnotationGripMode.Points;
			base.BeginCreate ();
		}

		protected override void OnMouseDown(AnnotationMouseEventArgs e)
		{
			if (this.State == AnnotationState.Creating)
			{
				_pointIndex++;
				if (this._pointIndex == 1)
				{
					this._data.IgnoreDataChanges = true;
					this._data.Location = new PointF(e.X, e.Y);
					this._data.IgnoreDataChanges = false;
					this._data.Points.Add(PointF.Empty);
				}
			}
			else
				base.OnMouseDown (e);
		}

		protected override void OnMouseMove(AnnotationMouseEventArgs e)
		{
			if (this.State == AnnotationState.Creating)
			{
				PointF pt = new PointF(e.X, e.Y);
				PointF delta = new PointF((pt.X < this._data.Location.X ? this._data.Location.X - pt.X : 0), (pt.Y < this._data.Location.Y ? this._data.Location.Y - pt.Y : 0));
				pt = AnnotateSpaceConverter.DocumentSpaceToAnnotationSpace(this._data, new PointF(e.X, e.Y));
				
				// Add an end point so it will render.
				if (this._pointIndex >= 1)
				{
					if (this._data.Points.Count == 1)
						this._data.Points.Add(pt);
					else
						this._data.Points[1] = pt;
				}
				else
					this._data.Points[1] = pt;
			}
			else
				base.OnMouseMove(e);
		}

		protected override bool OnMouseUp(AnnotationMouseEventArgs e)
		{
			if (this.State == AnnotationState.Creating)
			{
				// We only want 3 points.
				if (_pointIndex == 3) 
				{
                    _pointIndex = 2;
					this.State = AnnotationState.Idle;

					PointF[] pts = this._data.Points.ToArray();
					AnnotateSpaceConverter.AnnotationSpaceToDocumentSpace(this._data, pts);
					RectangleF bounds = GetPointBounds(pts);
					this._data.Location = bounds.Location;
					this._data.Size = bounds.Size;

					PointGrips pt = this.Grips as PointGrips;
					for (int i = 0; i < 3; i++)
					{
                        pt.Add(new AnnotationGrip(_data.Points[i], AnnotationGripState.Default, AnnotationGripAction.Independent));
					}
					return true;
				}

				if (this._data.Points.Count == _pointIndex)
				{
					// Add another end point so it will draw during creation.
					PointF pt = AnnotateSpaceConverter.DocumentSpaceToAnnotationSpace(this._data, new PointF(e.X, e.Y));
					this._data.Points.Add(pt);
				}

				return false;
			}
			else
				return base.OnMouseUp (e);
		}

		private RectangleF GetPointBounds(PointF[] points)
		{
			float x = float.MaxValue;
			float y = float.MaxValue;
			float x2 = float.MinValue;
			float y2 = float.MinValue;

			foreach (PointF pt in points)
			{
				if (pt.X < x) x = pt.X;
				if (pt.Y < y) y = pt.Y;
				if (pt.X > x2) x2 = pt.X;
				if (pt.Y > y2) y2 = pt.Y;
			}

			return new RectangleF(x, y, x2 - x, y2 - y);
		}
	}

    public class TrianglePointAnnotationFactory : IAnnotationUIFactory
    {
        public TrianglePointAnnotationFactory()
        {
        }

        #region IAnnotationUIFactory Members

        public AnnotationUI GetAnnotationUI(AnnotationData data)
        {
            TrianglePointData tri = data as TrianglePointData;
            if (tri == null)
                return null;
            else
                return new TrianglePointAnnotation(tri);
        }

        #endregion
    }

	public class TrianglePointRenderingEngine : AnnotationRenderingEngine
	{
		public TrianglePointRenderingEngine()
		{
		}

		public override void RenderAnnotation(AnnotationData annotation, RenderEnvironment e)
		{
			if (annotation == null)
				throw new ArgumentNullException("annotation");

			if (e == null)
				throw new ArgumentNullException("e");

			TrianglePointData data = annotation as TrianglePointData;
			if (data == null)
				throw new ArgumentException("The TrianglePointRenderingEngine can only be used to render a TrianglePointData class.", "annotation");

			if (data.Points.Count < 2 || data.Fill == null) return;

			base.SetGraphicsTransform(data, e);

			if (data.Points.Count == 2)
			{
				Pen p = CreatePen(new AnnotationPen(data.Fill, 1f / e.Resolution.X));
				e.Graphics.DrawLine(p, data.Points[0], data.Points[1]);
				p.Dispose();
			}
			else
			{
				Brush b = CreateBrush(data.Fill);
				e.Graphics.FillPolygon(b, data.Points.ToArray());
				b.Dispose();
			}

			base.RestoreGraphicsTransform(e);
		}

	}
}
