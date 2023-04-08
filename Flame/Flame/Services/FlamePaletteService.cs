using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Flame.Services
{
    public sealed class FlamePaletteService
    {
        /// <summary>
        /// Словарь палитры.
        /// </summary>
        private Dictionary<byte, SolidColorBrush> _palette = new Dictionary<byte, SolidColorBrush>();

        /// <summary>
        /// Инстанс.
        /// </summary>
        public static FlamePaletteService Source
        {
            get
            {
                return source;
            }
        }
        private static readonly FlamePaletteService source = new FlamePaletteService();

        /// <summary>
        /// Явный статический конструктор.
        /// </summary>
        static FlamePaletteService() { }

        /// <summary>
        /// Закрытый конструктор.
        /// </summary>
        private FlamePaletteService() 
        {
            // Инициализация палитры.
            int i = 0;
            byte r = 0;
            byte g = 0;
            byte b = 0;

            for(; i < 100; i++ )
            {
                var color = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                _palette.Add((byte)i, color);
            }

            for(; i < 256 ; i++)
            {
                var color = new SolidColorBrush(Color.FromArgb(255, r, g, b));
                _palette.Add((byte)i, color);

                if (r > 160)
                    g += 10;

                if (g > 170)
                    b += 10;

                if (r < 244)
                    r += 12;
                else
                {
                    i++;
                    break;
                }   
            }

            for (; i < 256; i++)
            {
                var color = new SolidColorBrush(Color.FromArgb(255, r, g, b));
                _palette.Add((byte)i, color);

                if (g > 170)
                    b += 10;

                if (g < 246)
                    g += 10;
                else
                {
                    i++;
                    break;
                }  
            }

            for (; i < 256; i++)
            {
                var color = new SolidColorBrush(Color.FromArgb(255, r, g, b));
                _palette.Add((byte)i, color);

                if(b < 246)
                    b += 10;
            }
        }

        /// <summary>
        /// Получить кисть.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public SolidColorBrush GetBrush(byte key)
        {
            return _palette.First(x => x.Key == key).Value;
        }
    }
}
