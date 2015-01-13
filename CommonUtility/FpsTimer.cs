using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MifuminSoft.funya3.Utility
{
    public class FpsTimer
    {
        /// <summary>FPS</summary>
        double fps = 60.0;
        /// <summary>1フレームあたりの待機Tick数</summary>
        long waitSpan = 0;
        /// <summary>次回の時刻</summary>
        long nextTime = 0;

        /// <summary>Sleep用の関数(引数はミリ秒)</summary>
        Action<int> sleepFunc;

        /// <summary>FPSを設定または取得します</summary>
        public double Fps
        {
            get { return fps; }
            set
            {
                if (value < 0.0) throw new ArgumentOutOfRangeException();
                fps = value;
                if (fps == 0)
                {
                    waitSpan = 0;
                }
                else
                {
                    waitSpan = (long)(10000000 / fps);
                }
                ResetNextTime();
            }
        }

        /// <summary>FPSタイマーを生成します</summary>
        /// <param name="fps">1秒間のフレーム数</param>
        public FpsTimer(Action<int> sleepFunc, double fps = 60.0)
        {
            this.sleepFunc = sleepFunc;
            Fps = fps;
        }

        public void ResetNextTime()
        {
            nextTime = DateTime.Now.Ticks + waitSpan;
        }

        /// <summary>次のフレーム開始時刻まで待機</summary>
        public void Wait()
        {
            long waitTicks = nextTime - DateTime.Now.Ticks;
            if (waitTicks > 0)
            {
                // 通常待機
                sleepFunc((int)(waitTicks / 10000));
                nextTime += waitSpan;
            }
            else if (waitTicks > -waitSpan)
            {
                // 微妙に遅れているので待機なし
                nextTime += waitSpan;
            }
            else
            {
                // 遅れすぎているのでFPS維持放棄
                ResetNextTime();
            }
        }
    }
}
