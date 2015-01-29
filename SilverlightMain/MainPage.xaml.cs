using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MifuminSoft.funya3.App.Graphics;
using MifuminSoft.funya3.Utility;

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

        SLGameCanvas slCanvas = null;

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
            mainScreen.Children.Add(tb);
#endif

            // キャンバスの設定
            slCanvas = new SLGameCanvas(mainScreen);

            // タイマー等の設定
            CompositionTarget.Rendering += new EventHandler(CompositionTarget_Rendering);
            mainLoop = new Thread(MainLoop);
            mainLoop.Start();
        }

        void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            if (drawFpsCounter.Frame == 0)
            {
                // 初期配置
                gameScreen.Width = mainScreen.ActualWidth;
                gameScreen.Height = mainScreen.ActualHeight;
                var image = new BitmapImage(new Uri("/funya3;component/Resource/Ice.png", UriKind.Relative));
                int length = 200;
                for (int x = 0; x < length; x++)
                {
                    for (int y = 0; y < length; y++)
                    {
                        var rect = new Rectangle();
                        rect.Width = 32;
                        rect.Height = 32;

                        var brush = new ImageBrush();
                        brush.AlignmentX = AlignmentX.Left;
                        brush.AlignmentY = AlignmentY.Top;
                        brush.ImageSource = image;
                        var transform = new TranslateTransform();
                        transform.X = -((x + y) % 3);
                        brush.RelativeTransform = transform;
                        brush.Stretch = Stretch.UniformToFill;
                        rect.Fill = brush;
                        //rect.Fill = new SolidColorBrush(Color.FromArgb(255, (byte)random.Next(256), (byte)random.Next(256), (byte)random.Next(256)));

                        mainScreen.Children.Add(rect);
                        Canvas.SetLeft(rect, x * gameScreen.ActualWidth / length);
                        Canvas.SetTop(rect, y * (gameScreen.ActualHeight - 16) / length + 16);
                        //rect.Visibility = System.Windows.Visibility.Collapsed;
                    }
                }
            }
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
                OnFrame();
                gameFpsCounter.Step();
                drawNotifier.Set();
                fpsTimer.Wait();
            }
        }

        private void OnFrame()
        {
            // まだ何も作っていない
        }

        internal void StopMainLoop()
        {
            isAlive = false;
        }
    }
}
