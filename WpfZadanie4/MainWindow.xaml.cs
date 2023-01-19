using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfZadanie4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

        }

        private Rectangle rectangle;
        private Rectangle lastrectangle;
        double top;
        double bottom;
        double left;
        double right;
        double pomTop;
        double pomBottom;
        double pomLeft;
        double pomRight;

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                Point pt = e.GetPosition(canvas);
                bottom = pt.Y;
                right = pt.X;
                rectangle.SetValue(Canvas.BottomProperty, bottom);
                rectangle.SetValue(Canvas.RightProperty, right);
                if (left > right && top > bottom)
                {
                    rectangle.SetValue(Canvas.TopProperty, bottom);
                    rectangle.SetValue(Canvas.LeftProperty, right);
                    rectangle.Width = left - right;
                    rectangle.Height = top - bottom;
                }
                else if(right >= left && top > bottom)
                {
                    rectangle.SetValue(Canvas.TopProperty, bottom);
                    rectangle.SetValue(Canvas.LeftProperty, left);
                    rectangle.Width = right - left;
                    rectangle.Height = top - bottom;
                }
                else if(left > right && top <= bottom)
                {
                    rectangle.SetValue(Canvas.TopProperty, top);
                    rectangle.SetValue(Canvas.LeftProperty, right);
                    rectangle.Width = left - right;
                    rectangle.Height = bottom - top;
                }
                else
                {
                    rectangle.SetValue(Canvas.TopProperty, top);
                    rectangle.SetValue(Canvas.LeftProperty, left);
                    rectangle.Width = right - left;
                    rectangle.Height = bottom - top;
                }
                lastrectangle = rectangle;
            }
            
        }

        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (left > right && top > bottom)
            {
                pomLeft = left;
                pomRight = right;
                pomTop = top;
                pomBottom = bottom;
                left = pomRight;
                right = pomLeft;
                top = pomBottom;
                bottom = pomTop;

            }
            else if (right >= left && top > bottom)
            {
                pomTop = top;
                pomBottom = bottom;
                top = pomBottom;
                bottom = pomTop;
            }
            else if (left > right && top <= bottom)
            {
                pomLeft = left;
                pomRight = right;
                left = pomRight;
                right = pomLeft;
            }
            Mouse.Capture(null);
            
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Mouse.Capture(canvas);
            Point pt = e.GetPosition(canvas);
            rectangle = new Rectangle();
            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = Colors.Black;
            rectangle.Stroke = brush;
            rectangle.SetValue(Canvas.TopProperty, pt.Y);
            rectangle.SetValue(Canvas.LeftProperty, pt.X);
            top = pt.Y;
            left = pt.X;
            canvas.Children.Add(rectangle);
        }

        private void canvas_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyboardDevice.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
            {
                if (e.Key == Key.Up)
                {
                    top -= 1;
                    lastrectangle.Height += 1;
                    lastrectangle.SetValue(Canvas.TopProperty, top);
                }
                else if (e.Key == Key.Down)
                {
                    bottom += 1;
                    lastrectangle.Height += 1;
                    lastrectangle.SetValue(Canvas.BottomProperty, bottom);
                }
                else if (e.Key == Key.Left)
                {
                    left -= 1;
                    lastrectangle.Width += 1;
                    lastrectangle.SetValue(Canvas.LeftProperty, left);
                }
                else if (e.Key == Key.Right)
                {
                    right += 1;
                    lastrectangle.Width += 1;
                    lastrectangle.SetValue(Canvas.RightProperty, right);
                }
            }
            else
            {
                if (e.Key == Key.Down)
                {
                    top += 1;
                    bottom += 1;
                    lastrectangle.SetValue(Canvas.TopProperty, top);
                    lastrectangle.SetValue(Canvas.BottomProperty, bottom);
                }
                else if (e.Key == Key.Up)
                {
                    top -= 1;
                    bottom -= 1;
                    lastrectangle.SetValue(Canvas.TopProperty, top);
                    lastrectangle.SetValue(Canvas.BottomProperty, bottom);
                }
                else if (e.Key == Key.Left)
                {
                    left -= 1;
                    right -= 1;
                    lastrectangle.SetValue(Canvas.LeftProperty, left);
                    lastrectangle.SetValue(Canvas.RightProperty, right);
                }
                else if (e.Key == Key.Right)
                {
                    left += 1;
                    right += 1;
                    lastrectangle.SetValue(Canvas.LeftProperty, left);
                    lastrectangle.SetValue(Canvas.RightProperty, right);
                }
            }
        }
    }
}
