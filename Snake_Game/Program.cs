using Snake_Game;

Border border = new Border();

Console.SetWindowSize(border.ScreenWidth, border.ScreenHeigh);
Console.SetBufferSize(border.ScreenWidth, border.ScreenHeigh);

Console.CursorVisible = false;

border.DrawBorder();

Snake snake = new Snake(7, 12, ConsoleColor.Magenta, ConsoleColor.Yellow);
snake.Start();

