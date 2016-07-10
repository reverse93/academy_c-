using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apka
{
    class Direction
    {
        public enum Direct
        {
            Up,
            Down,
            Left,
            Right,
        };
        public static Direct direction { get; set; }
    }
}
