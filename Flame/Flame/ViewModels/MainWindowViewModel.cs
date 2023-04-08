using Avalonia.Media;
using Avalonia.Threading;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Flame.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private const int WIDTH = 51;
        private const int HEIGHT = 51;

        private DispatcherTimer _timer = new DispatcherTimer();

        public bool IsVisiblePalette
        {
            get
            {
                return _isVisiblePalette;
            }

            set
            {
                this.RaiseAndSetIfChanged(ref _isVisiblePalette, value);
            }
        }
        public bool _isVisiblePalette = false;

        public ObservableCollection<Square> Squares
        {
            get
            {
                return _squares;
            }
        }
        private ObservableCollection<Square> _squares = new ObservableCollection<Square>();

        public ObservableCollection<Square> Palette
        {
            get
            {
                return _palette;
            }
        }
        private ObservableCollection<Square> _palette = new ObservableCollection<Square>();

        public MainWindowViewModel()
        {
            // Палитра.
            for (int i = 0; i <= 255 ;i++)
            {
                var square = new Square() { X = i * 1, Y = 0, Z = 0, Width = 1, Height = 20, Temperature = (byte)i };
                Palette.Add(square);
            }

            byte t = 255;

            for (int y = 0; y < HEIGHT; y++)
            {
                for (int x = 0; x < WIDTH; x++)
                {
                    Square square;

                    if (y < HEIGHT -1)
                    {
                        square = new Square() { X = x * 5, Y = y * 5, Z = 1, Height = 5, Width = 5, Temperature = t };
                    }
                    else
                    {
                        square = new Square() { X = x * 5, Y = y * 5, Z = 0, Height = 0, Width = 0, Temperature = t };
                    }

                    Squares.Add(square);
                    t--;
                }
            }

            _timer.Interval = TimeSpan.FromMilliseconds(42);
            _timer.Tick += TimerTick;
            _timer.IsEnabled = true;
            _timer.Start();
        }

        public async void TimerTick(object sender, EventArgs e)
        {
            

            try
            {
                //_timer.Stop();

                foreach (var square in Squares)
                {
                    if (Squares.IndexOf(square) > WIDTH * HEIGHT - HEIGHT - 1)
                        continue;

                    var list = new List<byte>();
                    var i = Squares.IndexOf(square);

                    //list.Add((byte)(Squares[i].Temperature / 0.99));
                    list.Add(Squares[i].Temperature);

                    if (i - 1 > -1)
                    {
                        list.Add(Squares[i - 1].Temperature);
                    }

                    if (i + 1 < Squares.Count)
                    {
                        list.Add(Squares[i + 1].Temperature);
                    }

                    if (i + WIDTH - 1 < Squares.Count)
                    {
                        list.Add(Squares[i + WIDTH - 1].Temperature);
                    }

                    if (i + WIDTH < Squares.Count)
                    {
                        list.Add(Squares[i + WIDTH].Temperature);
                    }

                    if (i + WIDTH + 1 < Squares.Count)
                    {
                        list.Add(Squares[i + WIDTH + 1].Temperature);
                    }

                    int sum = 0;

                    foreach (var s in list)
                    {
                        sum += s;
                    }

                    square.Temperature = (byte)(sum / list.Count);

                }

                Random rnd = new Random();
                var y = HEIGHT - 1;

                for (var x = 0; x < WIDTH; x++)
                {
                    Squares[(y * WIDTH) + x].Temperature = (byte)rnd.Next(5, 255);
                }

                //var sqr = Squares.Any(m => m.Y == 50);

                for (var n = (WIDTH * HEIGHT - HEIGHT) + 1; n < (WIDTH * HEIGHT) -1; n++)
                {
                    int n0 = Squares[n - 1].Temperature;
                    int n1 = Squares[n].Temperature;
                    int n2 = Squares[n + 1].Temperature;
                    Squares[n].Temperature = (byte)((n0 + n1 + n2) / 3);
                }

                Squares[WIDTH * HEIGHT - HEIGHT].Temperature = (byte)0;
                Squares[WIDTH * HEIGHT - 1].Temperature = (byte)0;

                //_timer.Start();

            }
            catch(Exception ez)
            {
                
            }
        }


    }
}
