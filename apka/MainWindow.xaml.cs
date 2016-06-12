using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace apka
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private static readonly int SIZE = 20;
        private MainCharacter _maincharacter;
        private int _directionX = 1;
        private int _directionY = 0;
        private DispatcherTimer _timer;
        private MainCharacterElements _prize;
        private int _partsToAdd;

        public MainWindow()
        {
            InitializeComponent();
            InitBoard();
            InitCharacter();
            InitTimer();
            InitPrize();
        }
        void InitBoard()
        {
            for (int i = 0; i < grid.Width / SIZE; i++)
            {
                ColumnDefinition columnDefinition = new ColumnDefinition();
                columnDefinition.Width = new GridLength(SIZE);
                grid.ColumnDefinitions.Add(columnDefinition);
            }
            for (int j = 0; j < grid.Height / SIZE; j++)
            {
                RowDefinition rowDefinition = new RowDefinition();
                rowDefinition.Height = new GridLength(SIZE);
                grid.RowDefinitions.Add(rowDefinition);
            }
            _maincharacter = new MainCharacter();
          
        }
        void InitCharacter()
      
        {
            grid.Children.Add(_maincharacter.Top.Rect);
            foreach (MainCharacterElements mainCharacterElements in _maincharacter.Elements) {
                grid.Children.Add(mainCharacterElements.Rect);
                _maincharacter.RedrawCharacter();
            }
        }

        private void MoveCharacter()
        {
            int mainCharacterPart = _maincharacter.Elements.Count;
            if (_partsToAdd > 0)
            {
                MainCharacterElements newPart = new MainCharacterElements(_maincharacter.Elements[_maincharacter.Elements.Count - 1].X,
                _maincharacter.Elements[_maincharacter.Elements.Count - 1].Y);
                grid.Children.Add(newPart.Rect);
                _maincharacter.Elements.Add(newPart);
                _partsToAdd--;
            }
          
            for (int i = mainCharacterPart- 1; i >= 1; i--)
            {
                _maincharacter.Elements[i].X = _maincharacter.Elements[i - 1].X;
                _maincharacter.Elements[i].Y = _maincharacter.Elements[i - 1].Y;
            }

            _maincharacter.Elements[0].X = _maincharacter.Top.X;
            _maincharacter.Elements[0].Y = _maincharacter.Top.Y;
            _maincharacter.Top.X += _directionX;
            _maincharacter.Top.Y += _directionY;
            _maincharacter.RedrawCharacter();

            if (CheckCollision()) EndGame();
            else
            {
                if (CheckPrize())
                    RedrawPrize();
                _maincharacter.RedrawCharacter();
            }
        }
        void InitTimer()
        {
            _timer = new DispatcherTimer();
            _timer.Tick += new EventHandler(_timer_Tick);
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            _timer.Start();
        }

        void _timer_Tick(object sender, EventArgs e)
        {
            MoveCharacter();
        }
        private void WinKeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.Left) {
                _directionX = -1;
                _directionY = 0; 
            }
            if (e.Key == Key.Right)
            {
                _directionX = 1;
                _directionY = 0;
            }
            if (e.Key == Key.Up)
            {
                _directionX = 0;
                _directionY = -1;
            }
            if (e.Key == Key.Down)
            {
                _directionX = 0;
                _directionY = 1;
            }

        }
        void InitPrize()
        {
            _prize = new MainCharacterElements(10, 10);
            _prize.Elli.Width = _prize.Elli.Height = 5;
            _prize.Elli.Fill = Brushes.Purple;
            grid.Children.Add(_prize.Elli);
            Grid.SetColumn(_prize.Elli, _prize.X);
            Grid.SetRow(_prize.Elli, _prize.Y);
        }
        private bool CheckPrize()
        {
            Random rand = new Random();
            if (_maincharacter.Top.X == _prize.X && _maincharacter.Top.Y == _prize.Y)
            {
                _partsToAdd += 1;
                for (int i = 0; i < 20; i++)
                {
                    int x = rand.Next(0, (int)(grid.Width / SIZE));
                    int y = rand.Next(0, (int)(grid.Height / SIZE));
                    if (IsFieldFree(x, y))
                    {
                        _prize.X = x;
                        _prize.Y = y;
                        return true;
                    }
                }
                for (int i = 0; i < grid.Width / SIZE; i++)
                    for (int j = 0; j < grid.Height / SIZE; j++)
                    {
                        if (IsFieldFree(i, j))
                        {
                            _prize.X = i;
                            _prize.Y = j;
                            return true;
                        }
                    }
                EndGame();
            }
            return false;
        }

        private bool IsFieldFree(int x, int y)
        {
            if (_maincharacter.Top.X == x && _maincharacter.Top.Y == y)
                return false;
            foreach (MainCharacterElements mainCharacterElements in _maincharacter.Elements)
            {
                if (mainCharacterElements.X == x && mainCharacterElements.Y == y)
                    return false;
            }
            return true;
        }

        void EndGame()
        {
            _timer.Stop();
            MessageBox.Show("KONIEC GRY");
        }
        private void RedrawPrize()
        {
            Grid.SetColumn(_prize.Elli, _prize.X);
            Grid.SetRow(_prize.Elli, _prize.Y);

        }
        bool CheckCollision()
        {
            if (CheckBoardCollision())
                return true;
            if (CheckItselfCollision())
                return true;
            return false;
        }

        bool CheckBoardCollision()
        {
            if (_maincharacter.Top.X < 0 || _maincharacter.Top.X > grid.Width / SIZE)
                return true;
            if (_maincharacter.Top.Y < 0 || _maincharacter.Top.Y > grid.Height / SIZE)
                return true;
            return false;
        }

        bool CheckItselfCollision()
        {
            foreach (MainCharacterElements mainCharacterElement in _maincharacter.Elements)
            {
                if (_maincharacter.Top.X == mainCharacterElement.X && _maincharacter.Top.Y == mainCharacterElement.Y)
                    return true;
            }
            return false;
        }
    }
}
