using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MifuminSoft.funya3.Graphics
{
    /// <summary>表示要素 - 表示されるもの</summary>
    public abstract class Sprite : IDisposable
    {
        /// <summary>Zオーダー</summary>
        private int zOrder;

        /// <summary>Zオーダー</summary>
        public int ZOrder
        {
            get { return zOrder; }
            set { zOrder = value; }
        }

        /// <summary>キャンバスから削除されるときにDisposeを行うか否か</summary>
        private bool disposeOnRemove;

        /// <summary>キャンバスから削除されるときにDisposeを行うか否かを設定・取得します</summary>
        public bool DisposeOnRemove
        {
            get { return disposeOnRemove; }
            set { disposeOnRemove = value; }
        }

        /// <summary>左端の座標</summary>
        private double left;

        /// <summary>左端の座標</summary>
        public double Left
        {
            get { return left; }
            set { left = value; }
        }

        /// <summary>上端の座標</summary>
        private double top;

        /// <summary>上端の座標</summary>
        public double Top
        {
            get { return top; }
            set { top = value; }
        }

        /// <summary>幅</summary>
        private double width;

        /// <summary>幅</summary>
        public double Width
        {
            get { return width; }
            set { width = value; }
        }

        /// <summary>高さ</summary>
        private double height;

        /// <summary>高さ</summary>
        public double Height
        {
            get { return height; }
            set { height = value; }
        }
        
        /// <summary>所属するキャンバス</summary>
        public Canvas Canvas { get; set; }

        public virtual void Dispose() { }
    }
}
