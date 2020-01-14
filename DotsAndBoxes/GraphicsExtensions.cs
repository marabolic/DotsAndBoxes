using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DotsAndBoxes
{
    public static class GraphicsExtensions
    {
        public static void FillCircle(this Graphics g, Brush b, float x, float y, float r)
        {
            g.FillEllipse(b, x - r, y - r, 2 * r, 2 * r);
        }

        public static void FillRectangle(this Graphics g, Brush b, float x, float y, float w, float h)
        {
            g.FillRectangle(b, x, y, w, h);
        }

    }
}
