namespace Snake_Game
{
    internal class Food
    {
        private Random random = new Random();

        public Pixel CreateFood(Snake snake)
        {
            Pixel food;
            Border border;

            do
            {
                food = new Pixel(random.Next(1, border.MapWidth - 3),
                    random.Next(1, border.MapHeight - 3),
                    ConsoleColor.Green);
            } while (snake.Head.X == food.X && snake.Head.Y == food.Y 
                     || snake.Body.Any(b => b.X == snake.Head.X && b.Y == snake.Head.Y));

            return food; 
        }
    }
}
