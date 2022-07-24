using System;

namespace Snake_Game
{
    internal struct Pixel
    {
        private int _x;
        private int _y;
        private ConsoleColor _color;
        private const char ASCII = '█';
        private int _pixelSize;

        public Pixel(int x, int y, 
            ConsoleColor color, 
            int pixelSize = 3)
        {
            _x = x;
            _y = y;
            _color = color;
            _pixelSize = pixelSize;
        }

        public int X { get => _x; }
        public int Y { get => _y; }
        public ConsoleColor Color { get => _color; }
        public int PixelSize { get => _pixelSize; }

        public void Draw()
        {
            Console.ForegroundColor = Color;

            for (int i = 0; i < PixelSize; i++)
            {
                for (int j = 0; j < PixelSize; j++)
                {
                    Console.SetCursorPosition(X * PixelSize + i, Y * PixelSize + j);
                    Console.Write(ASCII);
                }
            }
        }

        public void Clear()
        {
            for (int i = 0; i < PixelSize; i++)
            {
                for (int j = 0; j < PixelSize; j++)
                {
                    Console.SetCursorPosition(X * PixelSize + i, Y * PixelSize + j);
                    Console.Write(' ');
                }
            }
        }
    }
}
