using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace funya3.Draw
{
    interface IImageLoader
    {
        IImage LoadResource(string resourceId);
        IImage LoadFile(string path);
    }
}
