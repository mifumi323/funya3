using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MifuminSoft.funya3.Graphics
{
    /// <summary>表示要素 - 表示されるもの</summary>
    public class GameSprite
    {
        /// <summary>Zオーダー</summary>
        private int zOrder;

        /// <summary>Zオーダー</summary>
        public int ZOrder
        {
            get { return zOrder; }
            set { zOrder = value; }
        }

        /// <summary>所属するキャンバス</summary>
        public GameCanvas Canvas { get; set; }
    }
}
