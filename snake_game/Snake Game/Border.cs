using System;

namespace Snake_Game
{
    internal struct Border
    {
        private const int mapWidth = 30; 
        private const int mapHeight = 20;
        private const int screenWidth = mapWidth * 3;
        private const int screenHeight = mapHeight * 3;
        private const ConsoleColor BORDER_COLOR 
            = ConsoleColor.Gray;

        public int MapWidth { get => mapWidth; }
        public int MapHeight { get => mapHeight; }
        public int ScreenWidth { get => screenWidth; }
        public int ScreenHeigh { get => screenHeight; }


        public void DrawBorder()
        {
            for (int i = 0; i < MapWidth; i++)
            {
                new Pixel(i, 0, BORDER_COLOR).Draw();
                new Pixel(i, MapHeight - 1, BORDER_COLOR).Draw();
            }

            for (int i = 0; i < MapHeight; i++)
            {
                new Pixel(0, i, BORDER_COLOR).Draw();
                new Pixel(MapWidth - 1, i, BORDER_COLOR).Draw();
            }
        }
    }
}
