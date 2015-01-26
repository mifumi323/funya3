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

namespace MifuminSoft.funya3.App.Graphics
{
    public class SLGameCanvas : MifuminSoft.funya3.Graphics.GameCanvas
    {
        /// <summary>対象となるSilverlightキャンバス</summary>
        private Canvas target;
        public SLGameCanvas(Canvas target)
        {
            this.target = target;
        }
    }
}
