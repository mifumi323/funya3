using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using f3g = MifuminSoft.funya3.Graphics;

namespace MifuminSoft.funya3.App.Graphics
{
    public class SLGameCanvas : f3g.Canvas
    {
        /// <summary>対象となるSilverlightキャンバス</summary>
        private Canvas target;
        /// <summary>初期化</summary>
        /// <param name="target"></param>
        public SLGameCanvas(Canvas target)
        {
            this.target = target;
        }
    }
}
