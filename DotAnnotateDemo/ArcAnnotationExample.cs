using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using Atalasoft.Annotate;
using Atalasoft.Annotate.UI;
using Atalasoft.Annotate.Renderer;

namespace DotAnnotateDemo
{
	[Serializable]
	public class ArcData : PointBaseData
	{
		private AnnotationBrush _fill = new AnnotationBrush(Color.Red);

		static ArcData()
		{
			AnnotationRenderers.Add(typeof(ArcData), new ArcRenderingEngine());
		}

		public ArcData()
		{
		}

		public ArcData(PointF[] points)
			: base(new PointFCollection(points))
		{
		}

		public ArcData(SerializationInfo info, StreamingContext context)
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

				AnnotationUndo undo = new AnnotationUndo(this, "Fill", this._fill, "Arc Fill Change");
				
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
			ArcData data = new ArcData();
			base.CloneBaseData(data);
			
			if (_fill != null) data._fill = _fill.Clone();
			return data;
		}
	}

	[Serializable]
	public class ArcAnnotation : PointBaseAnnotation
	{
		private ArcData _data;
		private int _pointIndex;

		public ArcAnnotation()
			: this(new ArcData())
		{
		}

		public ArcAnnotation(PointF[] points)
			: this(new ArcData(points))
		{
		}

		public ArcAnnotation(ArcData data)
			: base(data)
		{
			_data = data;
		}

		public ArcAnnotation(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			_data = (ArcData)this.Data;
		}

		public AnnotationBrush Fill
		{
			get { return _data.Fill; }
			set { _data.Fill = value; }
		}

		public override AnnotationUI Clone()
		{
			return new ArcAnnotation((ArcData)_data.Clone());
		}

		public override void BeginCreate()
		{
			_pointIndex = 0;
			_data.Points.Clear();
			this.GripMode = AnnotationGripMode.Points;
			base.BeginCreate ();
		}

        protected override void OnGripPositionChanged(AnnotationGripChangedEventArgs e)
        {

            //This updates our underlying data to the e.NewPosition as well as moving the grip.
            base.OnGripPositionChanged(e);

            //Make sure the two end-points are the same distance from the center point.
            EnforceGripEquidistance(e.Grip);
       }

        private void EnforceGripEquidistance(AnnotationGrip peggedGrip)
        {
            AnnotationGrip otherGrip;
            int gripIndex = 0, otherGripIndex = 0;

            //If we're moving Grip[1], move Grip[2] to match.
            if (this.Grips[1] == peggedGrip)
            {
                otherGrip = this.Grips[2];
                gripIndex = 1;
                otherGripIndex = 2;
            }
            //If we're moving Grip[2], move Grip[1] to match.
            else if (this.Grips[2] == peggedGrip)
            {
                otherGrip = this.Grips[1];
                gripIndex = 2;
                otherGripIndex = 1;
            }
            //We're moving the center grip. Peg against the second grip.
            else
            {
                otherGrip = this.Grips[2];
                gripIndex = 1;
                otherGripIndex = 2;
            }

            PointFCollection points = this._data.Points;

            points = AnnotateSpaceConverter.AnnotationSpaceToDocumentSpace(this._data, points);

            //We only want to adjust the radius of the 'other' grip, not the angle. 
            double otherGripAngle = Math.Atan2((points[otherGripIndex].Y - points[0].Y), (points[otherGripIndex].X - points[0].X));
            //Get the radius we want to adjust to.
            double radius = Math.Sqrt(Math.Pow(points[gripIndex].Y - points[0].Y, 2) + Math.Pow(points[gripIndex].X - points[0].X, 2));

            PointF newPosition = new PointF();

            newPosition.X = (float)(Math.Cos(otherGripAngle) * radius) + points[0].X;
            newPosition.Y = (float)(Math.Sin(otherGripAngle) * radius) + points[0].Y;
            
            //Move the grip and update the underlying annotation data.
            otherGrip.Position = AnnotateSpaceConverter.DocumentSpaceToAnnotationSpace(this._data, newPosition);
            this._data.Points[otherGripIndex] = otherGrip.Position;
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
            {
                base.OnMouseDown(e);
            }
		}

		protected override void OnMouseMove(AnnotationMouseEventArgs e)
		{
            if (this.State == AnnotationState.Creating)
			{
				PointF pt = new PointF(e.X, e.Y);
				pt = AnnotateSpaceConverter.DocumentSpaceToAnnotationSpace(this._data, new PointF(e.X, e.Y));
				
				 //Add an end point so it will render.
				if (this._pointIndex == 1)
				{
					if (this._data.Points.Count == 1)
						this._data.Points.Add(pt);
					else
						this._data.Points[1] = pt;
				}
				else if(this._pointIndex == 2 && this._data.Points.Count == 3)
					this._data.Points[2] = pt;
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

                    PointGrips pt = this.Grips as PointGrips;

                    for (int i = 0; i < 3; i++)
                    {
                        pt.Add(new AnnotationGrip(_data.Points[i], AnnotationGripState.Default, AnnotationGripAction.Independent));
                    }

                    //When creating, make sure the first end point is set to the same radius as the final point.
                    EnforceGripEquidistance(pt[2]);

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
                return base.OnMouseUp(e);
		}

        public override RectangleF Bounds
        {
            get
            {
                if (this._data.Points.Count == 3)
                {
                    PointF[] pts = this._data.Points.ToArray();
                    AnnotateSpaceConverter.AnnotationSpaceToDocumentSpace(this._data, pts);

                    return GetPointBounds(pts);
                }
                else
                    return base.Bounds;
            }
        }

		private RectangleF GetPointBounds(PointF[] points)
		{
            float x = float.MaxValue;
			float y = float.MaxValue;

			float x2 = float.MinValue;
			float y2 = float.MinValue;

            //If we have < 3 points, we just have a line.
            if (points.Length < 3)
            {
                foreach (PointF pt in points)
                {
                    if (pt.X < x) x = pt.X;
                    if (pt.Y < y) y = pt.Y;
                    if (pt.X > x2) x2 = pt.X;
                    if (pt.Y > y2) y2 = pt.Y;
                }
            }
            else
            {
                //In theory, the radius of the two non-center points should be equal. In practice they may differ slightly, but not enough to really worry about.
                double radius = Math.Sqrt(Math.Pow(points[1].Y - points[0].Y, 2) + Math.Pow(points[1].X - points[0].X, 2));

                //This is a bit lazy, in theory we could figure out what quadrants the arc goes through and limit our bounds based on that
                //However, this is much faster and doesn't really cause that much more redraw.

                x = points[0].X - (float)radius;
                y = points[0].Y - (float)radius;

                x2 = (float)radius + points[0].X;
                y2 = (float)radius + points[0].Y;

             }

			return new RectangleF(x, y, x2 - x, y2 - y);
		}
	}

    public class ArcAnnotationFactory : IAnnotationUIFactory
    {
        public ArcAnnotationFactory()
        {
        }

        #region IAnnotationUIFactory Members

        public AnnotationUI GetAnnotationUI(AnnotationData data)
        {
            ArcData arcData = data as ArcData;
            if (arcData == null)
                return null;
            else
                return new ArcAnnotation(arcData);
        }

        #endregion
    }

	public class ArcRenderingEngine : AnnotationRenderingEngine
	{
		public ArcRenderingEngine()
		{
		}

		public override void RenderAnnotation(AnnotationData annotation, RenderEnvironment e)
		{
			if (annotation == null)
				throw new ArgumentNullException("annotation");

			if (e == null)
				throw new ArgumentNullException("e");

			ArcData data = annotation as ArcData;
			if (data == null)
				throw new ArgumentException("The ArcRenderingEngine can only be used to render a ArcData class.", "annotation");

			if (data.Points.Count < 2 || data.Fill == null) return;

			base.SetGraphicsTransform(data, e);

            //If we only have 2 points, we don't have an arc, we have a line.
			if (data.Points.Count == 2)
			{
				Pen p = CreatePen(new AnnotationPen(data.Fill, 1f / e.Resolution.X));
				e.Graphics.DrawLine(p, data.Points[0], data.Points[1]);
				p.Dispose();
			}
			else
			{
                //Get the start and end angle
                double startAngle= Math.Atan2((data.Points[1].Y - data.Points[0].Y), (data.Points[1].X - data.Points[0].X));
                double endAngle = Math.Atan2((data.Points[2].Y - data.Points[0].Y), (data.Points[2].X - data.Points[0].X));

                //For the sake of sanity, make sure we have one contiguous set of points.
                if (endAngle < startAngle)
                    endAngle += 2 * Math.PI;

                double currAngle = startAngle;

                double radius = Math.Sqrt(Math.Pow(data.Points[2].Y - data.Points[0].Y, 2) + Math.Pow(data.Points[2].X - data.Points[0].X, 2));

                double x;
                double y;


                //Step one angle at a time. Build an array of points defining the outline of our arc.
                List<PointF> segmentBounds = new List<PointF>();
                segmentBounds.Add(data.Points[0]);
                do
                {
                    x = (Math.Cos(currAngle) * radius) + data.Points[0].X;
                    y = (Math.Sin(currAngle) * radius) + data.Points[0].Y;

                    segmentBounds.Add(new PointF((float)x, (float)y));

                    currAngle += 0.0174532925d; //One degree (rad), feel free to alter this value to better reflect the quality/speed trade-off you desire.
                } while (currAngle < endAngle);

			    Brush b = CreateBrush(data.Fill);

                //Draw a filled polygon with our outline.
                e.Graphics.FillPolygon(b, segmentBounds.ToArray());
				b.Dispose();
			}

			base.RestoreGraphicsTransform(e);
		}

	}


}
