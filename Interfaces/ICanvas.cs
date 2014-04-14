using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace funya3.Draw
{
    interface ICanvas
    {
        void Draw(IImage image, double x, double y);
    }
}
