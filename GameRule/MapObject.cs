using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MifuminSoft.funya3.Core
{
    /// <summary>マップオブジェクトの向き</summary>
    public enum MapObjectDirection
    {
        Front, Left, Right
    }

    /// <summary>マップオブジェクトのタイプ</summary>
    public enum MapObjectType
    {
        Main,
        Food,
        Needle,
        Geasprin,
        Eelpitcher,
        Ice,
        IceZone,
        HeatZone,
        Effect,
    }

    /// <summary>マップオブジェクト</summary>
    public class MapObject
    {
        /// <summary>マップオブジェクトのタイプ</summary>
        public MapObjectType ObjectType { get; private set; }

        /// <summary>有効なオブジェクトかどうか</summary>
        public bool IsValid { get; private set; }

        /// <summary>所属するマップ</summary>
        public Map Parent { get; private set; }

        /// <summary>マップ中のX座標</summary>
        public float X { get; protected set; }

        /// <summary>マップ中のY座標</summary>
        public float Y { get; protected set; }

        /// <summary>表示X座標</summary>
        public float VX { get; protected set; }

        /// <summary>表示Y座標</summary>
        public float VY { get; protected set; }

        /// <summary>マップチップ単位のX座標</summary>
        public int CX { get; protected set; }

        /// <summary>マップチップ単位のY座標</summary>
        public int CY { get; protected set; }

        public MapObject(MapObjectType objectType, Map parent)
        {
            ObjectType = objectType;
            IsValid = true;
            Parent = parent;
            X = Y = 0;
        }
    }
}
