﻿
using AdornerLib;
using Contract;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace EllipseShape
{
    public class Ellipse2D : IShape
    {
        public override string Name => "Ellipse";

        public override string Icon => "○";

        public override IShape Clone()
        {
            return new Ellipse2D();
        }

        public override UIElement Draw()
        {
            var deltaX = 0.0;
            var deltaY = 0.0;
            var _width = points[1].X - points[0].X;
            var _height = points[1].Y - points[0].Y;
            if (_width < 0) deltaX = _width;
            if (_height < 0) deltaY = _height;

            this.centerX = _width / 2;
            this.centerY = _height / 2;

            Ellipse ellipse = new Ellipse()
            {
                Width = Math.Abs(_width),
                Height = Math.Abs(_height),
                Stroke = Brushes.Black,
                StrokeThickness = this.StrokeThickness,
                Fill = this.Fill,
                RenderTransform = new RotateTransform(this.Angle, this.centerX, this.centerY)
            };
            Canvas.SetTop(ellipse, points[0].Y + deltaY);
            Canvas.SetLeft(ellipse, points[0].X + deltaX);
            ellipse.MouseLeftButtonDown += EllipseClick;
            return ellipse;
        }

        private void EllipseClick(object sender, MouseButtonEventArgs e)
        {
            this.isSelected = true;
            var ellipse = sender as UIElement;
            if (e.ClickCount == 1 && ellipse != null)
            {
                AdornerLayer.GetAdornerLayer(VisualTreeHelper.GetParent(ellipse) as UIElement).Add(new RectResize(ellipse, this));
            }
        }

        public override void UpdatePoints(Point newPoint)
        {
            if (this.points != null) this.points[1] = newPoint;
        }
    }

}
