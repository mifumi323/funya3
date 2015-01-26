using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MifuminSoft.funya3.Graphics
{
    /// <summary>表示要素 - 表示されるもの</summary>
    public abstract class GameSprite : IDisposable
    {
        /// <summary>Zオーダー</summary>
        private int zOrder;

        /// <summary>Zオーダー</summary>
        public int ZOrder
        {
            get { return zOrder; }
            set { zOrder = value; }
        }

        private bool disposeOnRemove;

        /// <summary>キャンバスから削除されるときにDisposeを行うか否かを設定・取得します</summary>
        public bool DisposeOnRemove
        {
            get { return disposeOnRemove; }
            set { disposeOnRemove = value; }
        }

        /// <summary>所属するキャンバス</summary>
        public GameCanvas Canvas { get; set; }

        public virtual void Dispose() { }
    }
}
