using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace _16._11
{
    internal class ColorItem
    {
        public string Name { get; set; }
        public SolidColorBrush ColorBrush { get; set; }

        public ColorItem(string name, Color color)
        {
            Name = name;
            ColorBrush = new SolidColorBrush(color);
        }

    }
}