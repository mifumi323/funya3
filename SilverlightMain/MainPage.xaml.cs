using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Data;

namespace MifuminSoft.funya3.App
{
    public partial class MainPage : UserControl
    {
        long frame = 0;
        long count = 0;
        long prevTime = 0;
        double fps;

        public string DebugText
        {
            get { return (string)GetValue(DebugTextProperty); }
            set { SetValue(DebugTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DebugText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DebugTextProperty =
            DependencyProperty.Register("DebugText", typeof(string), typeof(MainPage), new PropertyMetadata(""));

        Random random = new Random();
        

        public MainPage()
        {
            InitializeComponent();

            CompositionTarget.Rendering += new EventHandler(CompositionTarget_Rendering);
        }

        void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            if (frame == 0)
            {
                TextBlock tb = new TextBlock();
                Binding bind = new Binding();
                bind.Path = new PropertyPath("DebugText");
                tb.DataContext = this;
                tb.SetBinding(TextBlock.TextProperty, bind);
                canvas1.Children.Add(tb);
            }
            else
            {
                Ellipse el = new Ellipse();
                el.Width = el.Height = 32;
                el.Fill = new SolidColorBrush(Color.FromArgb((byte)random.Next(256), (byte)random.Next(256), (byte)random.Next(256), (byte)random.Next(256)));
                canvas1.Children.Add(el);
                Canvas.SetLeft(el, random.NextDouble() * (canvas1.ActualWidth - el.Width));
                Canvas.SetTop(el, random.NextDouble() * (canvas1.ActualHeight - el.Height) + 16);
            }
            frame++;

            // FPS計測
            if (count == 0)
            {
                count = 60;
                long time = DateTime.Now.Ticks;
                fps = 10000000.0 * count / (time - prevTime);
                prevTime = time;
            }
            count--;

            DebugText = string.Format("{0} {1}", frame, fps);
        }
    }
}
