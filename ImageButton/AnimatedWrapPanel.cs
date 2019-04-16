using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Controls
{
    public class AnimatedWrapPanel : Panel
    {
        private readonly TimeSpan _AnimationLength = TimeSpan.FromMilliseconds(200);
        private int Offset;

        protected override Size MeasureOverride(Size availableSize)
        {
            var infiniteSize = new Size(double.PositiveInfinity, double.PositiveInfinity);
            double curX = 0, curY = 0, curLineHeight = 0;
            foreach (UIElement child in Children)
            {
                child.Measure(infiniteSize);

                if (curX + child.DesiredSize.Width + Offset > availableSize.Width)
                {
                    //Wrap to next line
                    curY += curLineHeight + Offset;
                    curX = 0;
                    curLineHeight = 0;
                }

                curX += child.DesiredSize.Width + Offset;
                if (child.DesiredSize.Height > curLineHeight)
                    curLineHeight = child.DesiredSize.Height;
            }

            curY += curLineHeight + Offset;

            var resultSize = new Size();
            resultSize.Width = double.IsPositiveInfinity(availableSize.Width) ? curX : availableSize.Width;
            resultSize.Height = double.IsPositiveInfinity(availableSize.Height) ? curY : availableSize.Height;

            return resultSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            if (Children == null || Children.Count == 0)
                return finalSize;

            TranslateTransform trans = null;
            double curX = 0, curY = 0, curLineHeight = 0;

            foreach (UIElement child in Children)
            {
                trans = child.RenderTransform as TranslateTransform;
                if (trans == null)
                {
                    child.RenderTransformOrigin = new Point(0, 0);
                    trans = new TranslateTransform();
                    child.RenderTransform = trans;
                }

                if (child.Visibility == Visibility.Visible)
                    Offset = 10;
                else
                    Offset = 0;

                {
                    if (curX + child.DesiredSize.Width + Offset > finalSize.Width)
                    {
                        //Wrap to next line
                        curY += curLineHeight + Offset;
                        curX = 0;
                        curLineHeight = 0;
                    }

                    child.Arrange(new Rect(0, 0, child.DesiredSize.Width, child.DesiredSize.Height));

                    trans.BeginAnimation(TranslateTransform.XProperty, new DoubleAnimation(curX, _AnimationLength),
                                         HandoffBehavior.Compose);
                    trans.BeginAnimation(TranslateTransform.YProperty, new DoubleAnimation(curY, _AnimationLength),
                                         HandoffBehavior.Compose);

                    curX += child.DesiredSize.Width + Offset;
                    if (child.DesiredSize.Height > curLineHeight)
                        curLineHeight = child.DesiredSize.Height;
                }
            }

            return finalSize;
        }
    }
}