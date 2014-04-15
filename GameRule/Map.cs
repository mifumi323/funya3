using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MifuminSoft.funya3.Core
{
    public class MapChip
    {
        public bool HitTop { get; private set; }
        public bool HitBottom { get; private set; }
        public bool HitLeft { get; private set; }
        public bool HitRight { get; private set; }
        public bool HitDeath { get; private set; }
    }

    public class MapData
    {
        private MapChip Chip { get; set; }
        private List<MapObject> NeighborObject { get; set; }

        public bool HitTop { get { return Chip.HitTop; } }
        public bool HitBottom { get { return Chip.HitBottom; } }
        public bool HitLeft { get { return Chip.HitLeft; } }
        public bool HitRight { get { return Chip.HitRight; } }
        public bool HitDeath { get { return Chip.HitDeath; } }
    }

    public class Map
    {
        private MapData[,] Data { get; set; }
    }
}
