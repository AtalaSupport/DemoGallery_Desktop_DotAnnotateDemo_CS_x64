// This source code is property of Atalasoft, Inc. (www.atalasoft.com)
// Permission for usage and modification of this code is only permitted 
// with the purchase of a DotImage source code license.

// Change History:

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Atalasoft.Annotate;
using Atalasoft.Annotate.Renderer;

namespace DotAnnotateDemo
{
	internal class ClassyLineDrawing 
	{
		#region UtilityGeometryRoutines

		// These are utility methods for basic 2D geometry

		private static double GetLineAngle(PointF p1, PointF p2)
		{
			double dx = p2.X - p1.X;
			double dy = p2.Y - p1.Y;
			double angle = Math.Atan2(dy, dx);
			return angle;
		}

		private static double GetLineLength(PointF p1, PointF p2)
		{
			double dx = p1.X - p2.X;
			double dy = p1.Y - p2.Y;
			return Math.Sqrt(dx * dx + dy * dy);
		}

		private static PointF GetLineMidpoint(PointF p1, PointF p2)
		{
			return new PointF((p1.X + p2.X)/2.0f, (p1.Y + p2.Y)/2.0f);
		}

		private static double RadiansToDegrees(double theta)
		{
			return theta * 180.0 / Math.PI;
		}
		#endregion

		#region UtilityRenderingCode
		// these routines are used to draw lines that have diamond pointed ends and an optional diamond middle part
		// when then connecting lines are "thick enough" the connecting lines are doubled

		private static PointF[] _diamondPoints = new PointF[4];
		private static void DrawDiamond(RenderEnvironment re, PointF location, Pen p, double radius, double angle)
		{
			// Draws a diamond of the given radius, rotated at the given angle, at the given location
			// Color is derived from the pen's color

			Matrix diamondMatrix = new Matrix();
			diamondMatrix.Translate(location.X, location.Y);
			diamondMatrix.Rotate((float)angle);
			float fradius = (float)radius;

			// these four points represent the diamond
			_diamondPoints[0] = new PointF(0, -fradius);
			_diamondPoints[1] = new PointF(fradius, 0);
			_diamondPoints[2] = new PointF(0, fradius);
			_diamondPoints[3] = new PointF(-fradius, 0);
			diamondMatrix.TransformPoints(_diamondPoints);

			// draw the diamond
			Brush b = new SolidBrush(p.Color);
			re.Graphics.FillPolygon(b, _diamondPoints);
			b.Dispose();
		}

		private static void DrawLineSegments(RenderEnvironment re, Pen p, PointF[] pts)
		{
			// DrawLines connects segments together   I need them to remain disjoint

			if ((pts.Length  & 1) != 0)
				throw new ArgumentException("need an even number of points", "pts");

			int nPairs = pts.Length / 2;
			for (int i=0; i < nPairs; i++) 
			{
				re.Graphics.DrawLine(p, pts[2 * i], pts[2 * i + 1]);
			}
		}


		static PointF[] _singleLine = new PointF[2];
		static PointF[] _doubleLine = new PointF[4];
		static PointF[] _quadLine = new PointF[8];
		private static void DrawConnectingLines(RenderEnvironment re, PointF from, PointF to, Pen p, double radius, double lineLength, double angle, bool splitLine, bool drawSingleLine)
		{
			// this is a utility method to draw lines that will connect two diamonds

			// radius is the radius of a diamond
			// lineLength is the line's length
			// angle is the angle of the line on the page
			// splitLine determines if there should be a space for a third diamond
			// drawSingleLine determines if the line should a single or a double line


			// the spacing around a diamond is 3/2 the diamond radius -- tweaking this will carry over through the
			// rest of the code - try ranges from fradius/2 up to fradius * 4

			float fradius = (float)radius;
			float diamondSpacing = (3 * fradius)/2f;

			// don't bother drawing if there's nothing to draw
			if ((splitLine && lineLength < 4 * diamondSpacing) || (!splitLine && lineLength < 2 * diamondSpacing))
				return;

			// set up the transform so that all lines get drawn in an axis-aligned orientation
			Matrix lineMatrix = new Matrix();
			lineMatrix.Translate(from.X, from.Y);
			lineMatrix.Rotate((float)angle);

			Pen myPen = (Pen)p.Clone();
			PointF[] pts;

			if (drawSingleLine) 
			{
				if (splitLine) 
				{
					// draw a single line split in half
					float segmentLength = (float)((lineLength / 2) - (2 * diamondSpacing));
					_doubleLine[0] = new PointF(diamondSpacing, 0);
					_doubleLine[1] = new PointF(diamondSpacing + segmentLength, 0);
					_doubleLine[2] = new PointF((float)(lineLength/2) + diamondSpacing, 0);
					_doubleLine[3] = new PointF((float)(lineLength/2) + diamondSpacing + segmentLength, 0);
					pts = _doubleLine;
				}
				else 
				{
					// draw a single continuous line
					_singleLine[0] = new PointF(diamondSpacing, 0);
					_singleLine[1] = new PointF(diamondSpacing + (float)lineLength - 2 * diamondSpacing, 0);
					pts = _singleLine;
				}
			}
			else 
			{
				// Divide the line thickness into thirds.  1/3 above is the top, 1/3 below is the bottom
				float lineOffset = myPen.Width / 3;
				// divide the line thickness by 6 to make the total thickness be 1/3 of the total line thickness
				myPen.Width /= 6f;

				if (splitLine) 
				{
					// draw a double line split in half
					float segmentLength = (float)((lineLength / 2) - (2 * diamondSpacing));
					_quadLine[0] = new PointF(diamondSpacing, lineOffset);
					_quadLine[1] = new PointF(diamondSpacing + segmentLength, lineOffset);
					_quadLine[2] = new PointF((float)(lineLength/2) + diamondSpacing, lineOffset);
					_quadLine[3] = new PointF((float)(lineLength/2) + diamondSpacing + segmentLength, lineOffset);
					_quadLine[4] = new PointF(diamondSpacing, -lineOffset);
					_quadLine[5] = new PointF(diamondSpacing + segmentLength, -lineOffset);
					_quadLine[6] = new PointF((float)(lineLength/2) + diamondSpacing, -lineOffset);
					_quadLine[7] = new PointF((float)(lineLength/2) + diamondSpacing + segmentLength, -lineOffset);
					pts = _quadLine;
				}
				else 
				{
					// draw a double continuous line
					_doubleLine[0] = new PointF(diamondSpacing, lineOffset);
					_doubleLine[1] = new PointF(diamondSpacing + (float)lineLength - 2 * diamondSpacing, lineOffset);
					_doubleLine[2] = new PointF(diamondSpacing, -lineOffset);
					_doubleLine[3] = new PointF(diamondSpacing + (float)lineLength - 2 * diamondSpacing, -lineOffset);
					pts = _doubleLine;
				}
			}
			lineMatrix.TransformPoints(pts);
			DrawLineSegments(re, myPen, pts);
			myPen.Dispose();
		}

		public static void DrawDiamondLines(RenderEnvironment re, PointF from, PointF to, bool drawFromDiamond, bool drawToDiamond, Pen p)
		{
			// draw a diamond-adorned line between from and to
			// drawFromDiamond determines whether or not a diamond will be drawn at the originating point (space is left if not)
			// drawToDiamond determines whether or not a diamond will be drawn at the ending point (space is left if not)

			double diamondRadius = p.Width / 2.0f;

			// pin the radius to 4.5  Anything smaller doesn't look like anything
			if (diamondRadius < 4.5)
				diamondRadius = 4.5;

			// get the line angle
			double lineAngle = RadiansToDegrees(GetLineAngle(from, to));
			// get its length
			double lineLength = GetLineLength(from, to);

			// determine if we need a middle diamond.  Basically, the space taken up in a line with three
			// diamonds is 4 * the diamond diameter or span, or 8 * the radius
			bool drawMiddleDiamond = lineLength > 8 * diamondRadius;

			// where does the middle point go?
			PointF middleDiamondLocation = GetLineMidpoint(from, to);

			// leave single line at a width < 3 - if you double up any smaller, the lines run together
			bool drawSingleLine = p.Width < 3f;

			if (drawFromDiamond) 
			{
				DrawDiamond(re, from, p, diamondRadius, lineAngle);
			}

			if (drawToDiamond)
			{
				DrawDiamond(re, to, p, diamondRadius, lineAngle);
			}

			if (drawMiddleDiamond)
			{
				DrawDiamond(re, middleDiamondLocation, p, diamondRadius, lineAngle);
			}

			DrawConnectingLines(re, from, to, p, diamondRadius, lineLength, lineAngle, drawMiddleDiamond, drawSingleLine);
		}
	#endregion
	}
	



	public class DiamondLineRenderingEngine : LineRenderingEngine
	{
		// Implementation of the LineRenderingEngine using a "stylish" line instead of the regular one

		public override void RenderAnnotation(AnnotationData annotation, RenderEnvironment e)
		{
			// check args
			if (annotation == null)
				throw new ArgumentNullException("annotation");

			if (e == null)
				throw new ArgumentNullException("e");

			LineData data = annotation as LineData;
			if (data == null)
				throw new ArgumentException("DashedLineRendered can't handle data of type " + annotation.GetType().Name);

			if (!annotation.Visible || data.Outline == null) return;

			base.SetGraphicsTransform(annotation, e);

			PointF lockPoint = PointF.Empty;

			Pen p = CreatePen(data.Outline);
			if (p != null)
			{
				// draw a single line
				ClassyLineDrawing.DrawDiamondLines(e, new PointF(data.StartPoint.X, data.StartPoint.Y),
					new PointF(data.EndPoint.X, data.EndPoint.Y), true, true, p);

				RectangleF bounds = data.Bounds;
				lockPoint = new PointF(bounds.Width / 2f, bounds.Height / 2f);
				p.Dispose();
			}

			if (e.Device == RenderDevice.Display && annotation.Security != null && annotation.Security.Locked && annotation.Security.LockedImage != null)
				base.RenderLockImage(annotation.Security.LockedImage, lockPoint, e);

			base.RestoreGraphicsTransform(e);
		}
	}

	public class DiamondRectangleRenderingEngine : RectangleRenderingEngine
	{
		// Implementation of RectangleRenderingEngine using a "stylish" appearance
		public override void RenderAnnotation(AnnotationData annotation, RenderEnvironment e)
		{
			// check args
			if (annotation == null)
				throw new ArgumentNullException("annotation");

			if (e == null)
				throw new ArgumentNullException("e");

			RectangleData data = annotation as RectangleData;
			if (data == null)
				throw new ArgumentException("Only RectangleData objects can be rendered using the RectangleRenderingEngine.", "annotation");

			if (!annotation.Visible) return;

			base.SetGraphicsTransform(annotation, e);

			RectangleF rect = CorrectRectangle(new RectangleF(0, 0, data.Size.Width, data.Size.Height));

			Brush fill = CreateBrush(data.Fill);

			// fill if need be
			if (fill != null)
			{
				e.Graphics.FillRectangle(fill, rect);				
			}

			Pen p = CreatePen(data.Outline);
			if (p != null)
			{
				// get the top-left, top-right, bottom-left, and bottom-right points of the rect and draw them
				PointF tl = rect.Location;
				PointF tr = new PointF(rect.Right, rect.Top);
				PointF bl = new PointF(rect.Left, rect.Bottom);
				PointF br = new PointF(rect.Right, rect.Bottom);

				// end points on top and bottom
				ClassyLineDrawing.DrawDiamondLines(e, tl, tr, true, true, p);
				ClassyLineDrawing.DrawDiamondLines(e, bl, br, true, true, p);

				// no end points needed on the sides
				ClassyLineDrawing.DrawDiamondLines(e, tl, bl, false, false, p);
				ClassyLineDrawing.DrawDiamondLines(e, tr, br, false, false, p);
				p.Dispose();
			}

			if (e.Device == RenderDevice.Display && annotation.Security != null && annotation.Security.Locked && annotation.Security.LockedImage != null)
				base.RenderLockImage(annotation.Security.LockedImage, rect, e);

			base.RestoreGraphicsTransform(e);

		}
	}

	public class DiamondPolygonRenderingEngine : PolygonRenderingEngine 
	{
		// Implementation of a polygon rendering engine using a "stylish" appearance
		public override void RenderAnnotation(AnnotationData annotation, RenderEnvironment e)
		{
			// check args
			if (annotation == null)
				throw new ArgumentNullException("annotation");

			if (e == null)
				throw new ArgumentNullException("e");

			PolygonData polygon = annotation as PolygonData;
			if (polygon == null)
				throw new ArgumentException("Only PolygonData objects can be rendered using the PolygonRenderingEngine.", "annotation");

			if (!annotation.Visible) return;
			if (polygon.Points == null || polygon.Points.Count < 2) return; 


			base.SetGraphicsTransform(annotation, e);

			// get the points
			PointF[] pts = polygon.Points.ToArray();
			PointF lockPoint = pts[0];


			// non-degenerate case (filled and more than two points)
			if (polygon.Fill != null && pts.Length > 2)
			{
				Brush fill = CreateBrush(polygon.Fill);
				if (fill != null)
				{
					e.Graphics.FillPolygon(fill, pts);
					fill.Dispose();
				}
			}

			Pen p = CreatePen(polygon.Outline);
			if (p != null)
			{
				// degenerate case - single line
				if (pts.Length == 2) 
				{
					ClassyLineDrawing.DrawDiamondLines(e, pts[0], pts[1], true, true, p);
				}
				else 
				{
					// many lines
					for (int i=0; i < pts.Length - 1; i++) 
					{
						ClassyLineDrawing.DrawDiamondLines(e, pts[i], pts[i+1], true, false, p);
					}
					// connect last to first
					ClassyLineDrawing.DrawDiamondLines(e, pts[pts.Length-1], pts[0], true, false, p);
				}
				p.Dispose();
			}
			if (e.Device == RenderDevice.Display && annotation.Security != null && annotation.Security.Locked && annotation.Security.LockedImage != null)
				base.RenderLockImage(annotation.Security.LockedImage, lockPoint, e);

			base.RestoreGraphicsTransform(e);
		}
	}

	public class ClassyAnnotationRenderers
	{
		public static void InstallClassyRenderers()
		{
			AnnotationRenderers.Add(typeof(LineData), new DiamondLineRenderingEngine());
			AnnotationRenderers.Add(typeof(RectangleData), new DiamondRectangleRenderingEngine());
			AnnotationRenderers.Add(typeof(PolygonData), new DiamondPolygonRenderingEngine());
		}

		public static void InstallDefaultRenderers()
		{
			AnnotationRenderers.Add(typeof(LineData), new LineRenderingEngine());
			AnnotationRenderers.Add(typeof(RectangleData), new RectangleRenderingEngine());
			AnnotationRenderers.Add(typeof(PolygonData), new PolygonRenderingEngine());
		}
	}
}
