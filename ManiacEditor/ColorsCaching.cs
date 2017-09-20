using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;

namespace ManiacEditor
{
    class ColorsCaching
    {
        private static Hashtable cache;
        private static Hashtable cacheb;

        public static Color Get(int transparency)
        {
            if (cache == null) cache = new Hashtable();
            if (!cache.Contains(transparency)) cache.Add(transparency, Color.FromArgb(transparency, Color.White));
            return (Color)cache[transparency];
        }
        public static Color GetBlack(int transparency)
        {
            if (cacheb == null) cacheb = new Hashtable();
            if (!cacheb.Contains(transparency)) cacheb.Add(transparency, Color.FromArgb(transparency, Color.Black));
            return (Color)cacheb[transparency];
        }

    }
}
