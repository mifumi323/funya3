using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MifuminSoft.funya3.Graphics
{
    /// <summary>レイヤー - 絵の前後関係を管理する</summary>
    public class Layer
    {
        /// <summary>表示レベル - レイヤーの前後関係を決める数値</summary>
        private int level;
        /// <summary>要素 - このレイヤーの中にある表示要素</summary>
        List<Element> elements = new List<Element>();

        /// <summary>レイヤーの初期化</summary>
        /// <param name="level">表示レベル</param>
        public Layer(int level)
        {
            this.level = level;
        }

        public void Add(Element element)
        {
            elements.Add(element);
        }
    }
}
