using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MifuminSoft.funya3.Graphics
{
    /// <summary>キャンバス - 絵を置く場所</summary>
    public class Canvas
    {
        /// <summary>レイヤー</summary>
        Dictionary<int, Layer> layers = new Dictionary<int, Layer>();

        /// <summary>表示要素をキャンバスに置く</summary>
        /// <param name="element">表示要素</param>
        /// <param name="level">表示レベル</param>
        /// <returns>表示要素(elementそのもの)</returns>
        public Element PutElement(Element element, int level = 0)
        {
            Layer layer;
            if (!layers.ContainsKey(level))
            {
                layer = layers[level] = new Layer(level);
            }
            else
            {
                layer = layers[level];
            }
            layer.Add(element);
            element.Canvas = this;
            return element;
        }
    }
}
