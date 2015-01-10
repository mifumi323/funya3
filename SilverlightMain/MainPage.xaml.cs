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
using System.ComponentModel;
using System.Threading;
using MifuminSoft.funya3.Utility;
using System.Threading.Tasks;

namespace MifuminSoft.funya3.App
{
    public partial class MainPage : UserControl
    {
        FpsCounter fpsCounter = new FpsCounter();

        /// <summary>ゲームのメインループ</summary>
        Thread mainLoop = null;
        /// <summary>描画ループ</summary>
        Thread drawLoop = null;
        /// <summary>描画可能になったことの通知</summary>
        AutoResetEvent drawNotifier = null;

        Image mainImage = null;

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

            // タイマー等の設定
            CompositionTarget.Rendering += new EventHandler(CompositionTarget_Rendering);
            drawNotifier = new AutoResetEvent(false);
            mainLoop = new Thread(MainLoop);
        }

        void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            if (fpsCounter.Frame == 0)
            {
                mainImage = new Image();
                canvas1.Children.Add(mainImage);
                ;

                TextBlock tb = new TextBlock();
                Binding bind = new Binding();
                bind.Path = new PropertyPath("DebugText");
                tb.DataContext = this;
                tb.SetBinding(TextBlock.TextProperty, bind);
                canvas1.Children.Add(tb);
            }
            else
            {
            }
            fpsCounter.Step();

            DebugText = string.Format("{0} {1} {2} {3}", mainImage.ActualWidth, mainImage.ActualHeight, fpsCounter.Frame, fpsCounter.Fps);
        }

        void MainLoop()
        {
            ;
        }

        void DrawLoop()
        {
            ;
        }
    }
}
