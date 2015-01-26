using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MifuminSoft.funya3.Graphics
{
    /// <summary>キャンバス - 絵を置く場所</summary>
    public class GameCanvas
    {
        /// <summary>レイヤー</summary>
        Dictionary<int, GameLayer> layers = new Dictionary<int, GameLayer>();

        /// <summary>表示要素をキャンバスに置く</summary>
        /// <param name="element">表示要素</param>
        /// <param name="level">表示レベル</param>
        /// <returns>表示要素(elementそのもの)</returns>
        public GameSprite PutElement(GameSprite element, int level = 0)
        {
            GameLayer layer;
            if (!layers.ContainsKey(level))
            {
                layer = layers[level] = new GameLayer(level);
            }
            else
            {
                layer = layers[level];
            }
            layer.Add(element);
            element.Canvas = this;
            return element;
        }

        public void Clear()
        {
            foreach (var layer in layers)
            {
                layer.Value.Clear();
            }
            layers.Clear();
        }
    }
}
