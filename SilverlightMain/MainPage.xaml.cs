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
using System.Windows.Media.Imaging;

namespace MifuminSoft.funya3.App
{
    public partial class MainPage : UserControl
    {
        /// <summary>処理FPSタイマー</summary>
        FpsTimer fpsTimer = new FpsTimer(Thread.Sleep, 40);
        /// <summary>処理FPS計測</summary>
        FpsCounter gameFpsCounter = new FpsCounter();
        /// <summary>画面更新FPS計測</summary>
        FpsCounter drawFpsCounter = new FpsCounter();

        /// <summary>ゲームのメインループ</summary>
        Thread mainLoop = null;
        /// <summary>描画可能になったことの通知</summary>
        AutoResetEvent drawNotifier = new AutoResetEvent(false);
        /// <summary>メインループが存続しているか</summary>
        bool isAlive = true;

        public string DebugText
        {
            get { return (string)GetValue(DebugTextProperty); }
            set { SetValue(DebugTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DebugText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DebugTextProperty =
            DependencyProperty.Register("DebugText", typeof(string), typeof(MainPage), new PropertyMetadata(""));

        /// <summary>乱数</summary>
        Random random = new Random();

        public MainPage()
        {
            InitializeComponent();

#if DEBUG
            // デバッグ用テキスト
            TextBlock tb = new TextBlock();
            Binding bind = new Binding();
            bind.Path = new PropertyPath("DebugText");
            tb.DataContext = this;
            tb.SetBinding(TextBlock.TextProperty, bind);
            canvas1.Children.Add(tb);
#endif

            // タイマー等の設定
            CompositionTarget.Rendering += new EventHandler(CompositionTarget_Rendering);
            mainLoop = new Thread(MainLoop);
            mainLoop.Start();
        }

        void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            if (drawNotifier.WaitOne(100))
            {
                // 描画を行う
                drawFpsCounter.Step();
                DebugText = string.Format("{0} {1:0.0} {2} {3:0.0}", gameFpsCounter.Frame, gameFpsCounter.Fps, drawFpsCounter.Frame, drawFpsCounter.Fps);
            }
            else
            {
                // フレームスキップ
            }
        }

        void MainLoop()
        {
            while (isAlive)
            {
                drawNotifier.Set();
                fpsTimer.Wait();
                gameFpsCounter.Step();
            }
        }

        internal void StopMainLoop()
        {
            isAlive = false;
        }
    }
}
