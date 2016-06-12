﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;

namespace apka
{
    class MainCharacterElements
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Rectangle Rect { get; private set; }
        public Ellipse Elli { get; private set; }


        public MainCharacterElements(int x, int y) {
            X = x;
            Y = y;
            Rect = new Rectangle();
            Elli = new Ellipse();
           /// Elli.Width = Elli.Height = 5; 
            Rect.Width = Rect.Height = 15;
            Rect.Fill = Brushes.Gold;

        }

    }
}