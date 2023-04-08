using Avalonia.Media;
using Flame.Services;
using ReactiveUI;

namespace Flame.ViewModels
{
    public class Square : ReactiveObject, IPrimitiveCoordinates, IPrimitiveSize, IPrimitiveFill
    {
        public double X 
        { 
            get
            {
                return _x;
            }

            set
            {
                this.RaiseAndSetIfChanged(ref _x, value);
            }
        }
        private double _x;

        public double Y 
        {
            get 
            {
                return _y;
            }

            set 
            {
                this.RaiseAndSetIfChanged(ref _y, value);
            }
        }
        private double _y;

        public int Z 
        {
            get 
            {
                return _z;
            }
            set 
            {
                this.RaiseAndSetIfChanged(ref _z, value);
            } 
        }
        private int _z;

        public double Height
        {
            get
            {
                return _height;
            }

            set
            {
                this.RaiseAndSetIfChanged(ref _height, value);
                this.RaiseAndSetIfChanged(ref _width, value); // Потому что квадрат.
            }

        }
        private double _height;

        public double Width 
        {

            get 
            {
                return _width;
            }

            set
            {
                this.RaiseAndSetIfChanged(ref _width, value);
                this.RaiseAndSetIfChanged(ref _height, value); // Потому что квадрат.
            }
        }
        private double _width;

        public byte Temperature
        {
            get
            {
                return _temperature;
            }

            set
            {
                this.RaiseAndSetIfChanged(ref _temperature, value);
                Fill = FlamePaletteService.Source.GetBrush(_temperature).Color;
                
            }
        }
        private byte _temperature;

        public Color Fill 
        { 
            get
            {
                return _fill;
            }

            private set
            {
                this.RaiseAndSetIfChanged(ref _fill, value);
                FillRed = value.R;
                FillGreen = value.G;
                FillBlue = value.B;
            }
        }
        private Color _fill = Brushes.Transparent.Color;

        public byte FillRed
        {
            get
            {
                return _fillRed;
            }

            private set
            {
                this.RaiseAndSetIfChanged(ref _fillRed, value);
            }
        }
        private byte _fillRed;

        public byte FillGreen
        {
            get
            {
                return _fillGreen;
            }

            private set
            {
                this.RaiseAndSetIfChanged(ref _fillGreen, value);
            }
        }
        private byte _fillGreen;

        public byte FillBlue
        {
            get
            {
                return _fillBlue;
            }

            private set
            {
                this.RaiseAndSetIfChanged(ref _fillBlue, value);
            }
        }
        private byte _fillBlue;

    }
}
