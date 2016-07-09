using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace apka
{
    class MainCharacter
    {
        public MainCharacterElements Top { get; private set; }
        public List<MainCharacterElements> Elements { get; private set;}

        public MainCharacter() {
            Top = new MainCharacterElements(20, 4);
            Top.Rect.Width = Top.Rect.Height = 10;
            Top.Rect.Fill = System.Windows.Media.Brushes.Pink;
            Elements = new List<MainCharacterElements>();
            Elements.Add(new MainCharacterElements(19, 4));
            Elements.Add(new MainCharacterElements(18, 4));
            Elements.Add(new MainCharacterElements(17, 4));
            Elements.Add(new MainCharacterElements(16, 4));
            Elements.Add(new MainCharacterElements(15, 4));

        }

        public void RedrawCharacter() {
            Grid.SetColumn(Top.Rect, Top.X);
            Grid.SetRow(Top.Rect, Top.Y);
            foreach (MainCharacterElements mainCharacterElements in Elements) {
                Grid.SetColumn(mainCharacterElements.Rect, mainCharacterElements.X);
                Grid.SetRow(mainCharacterElements.Rect, mainCharacterElements.Y);
            }

        }
    }
}
