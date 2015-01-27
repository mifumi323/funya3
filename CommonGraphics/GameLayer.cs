using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MifuminSoft.funya3.Graphics
{
    /// <summary>レイヤー - 絵の前後関係を管理する</summary>
    public class GameLayer : IDisposable
    {
        /// <summary>1レイヤーに表示する表示要素の想定最大数</summary>
        public const int SpriteMax = 10000;

        /// <summary>表示レベル - レイヤーの前後関係を決める数値</summary>
        private int level;
        /// <summary>要素 - このレイヤーの中にある表示要素</summary>
        List<GameSprite> sprites = new List<GameSprite>();

        /// <summary>レイヤーの初期化</summary>
        /// <param name="level">表示レベル</param>
        public GameLayer(int level)
        {
            this.level = level;
        }

        /// <summary>表示要素を追加する</summary>
        /// <param name="sprite">表示要素</param>
        public void Add(GameSprite sprite)
        {
            sprite.ZOrder = sprites.Count > 0 ? sprites.Last().ZOrder + 1 : LevelToZOrder(level);
            sprites.Add(sprite);
        }

        /// <summary>レイヤーの内容を無効化する</summary>
        public void Dispose()
        {
            Clear();
        }

        /// <summary>レイヤーの内容を消去する</summary>
        public void Clear()
        {
            foreach (var sprite in sprites)
            {
                if (sprite.DisposeOnRemove) sprite.Dispose();
            }
            sprites.Clear();
        }

        public static int ZOrderToLevel(int zOrder)
        {
            return zOrder / SpriteMax;
        }

        public static int LevelToZOrder(int level, int offset = 0)
        {
            return level * SpriteMax + offset;
        }
    }
}
