using System;
using System.Collections.Generic;

namespace Snake_Game
{
    internal class Snake
    {        
        private Pixel _head;
        private Queue<Pixel> _body = new Queue<Pixel>();
        private readonly ConsoleColor _headColor;
        private readonly ConsoleColor _bodyColor;
        private int score = default;

        public Snake(int startX, int startY, 
            ConsoleColor headColor, ConsoleColor bodyColor, 
            int bodyLenght = 3)
        {
            _headColor = headColor;
            _bodyColor = bodyColor;

            _head = new Pixel(startX, startY, _headColor);

            for (int i = bodyLenght; i >= 0; i--)
            {
                _body.Enqueue(new Pixel(_head.X - i - 1, startY, _bodyColor));
            }

            Draw();
        }

        public Pixel Head { get => _head; private set => _head = value; }
        public Queue<Pixel> Body { get => _body; }
        public ConsoleColor HeadColor { get => _headColor; }
        public ConsoleColor BodyColor { get => _bodyColor; }

        public void Start()
        {
            Border border;

            Clear();

            Pixel food = new Food().CreateFood(this);
            food.Draw();

            Direction currentMovement = Direction.Right;

            while (true)
            {
                currentMovement = Controle(currentMovement);

                Move(currentMovement);

                Thread.Sleep(200);

                if (Head.X == food.X && Head.Y == food.Y)
                {
                    this.Move(currentMovement, true);

                    food = new Food().CreateFood(this);
                    food.Draw();

                    score++;
                }
                else this.Move(currentMovement);

                if (Head.X == border.MapWidth - 1
                    || Head.X == 0
                    || Head.Y == border.MapHeight - 1
                    || Head.Y == 0
                    || Body.Any(b => b.X == Head.X && b.Y == Head.Y))
                    break;
            }

            this.Clear();
            food.Clear();

            Console.SetCursorPosition(border.ScreenWidth / 2, border.ScreenHeigh / 2);
            Console.WriteLine($"Game Over! Your score is {score}");

            Console.ReadKey();
        }

        public void Move(Direction direction, bool feed = false)
        {
            Clear();

            Body.Enqueue(new Pixel(Head.X, Head.Y, BodyColor));

            if (!feed)
            {
                Body.Dequeue();
            }            

            Head = direction switch
            {
                Direction.Left => new Pixel(Head.X - 1, Head.Y, HeadColor),
                Direction.Right => new Pixel(Head.X + 1, Head.Y, HeadColor),
                Direction.Up => new Pixel(Head.X, Head.Y - 1, HeadColor),
                Direction.Down => new Pixel(Head.X, Head.Y + 1, HeadColor),
                _ => Head
            };

            Draw();
        }

        public Direction Controle(Direction currentDirection)
        {
            if (!Console.KeyAvailable)
            {
                return currentDirection;
            }

            ConsoleKey key = Console.ReadKey(true).Key;

            currentDirection = key switch
            {
                ConsoleKey.UpArrow when currentDirection != Direction.Down => Direction.Up,
                ConsoleKey.DownArrow when currentDirection != Direction.Up => Direction.Down,
                ConsoleKey.LeftArrow when currentDirection != Direction.Right => Direction.Left,
                ConsoleKey.RightArrow when currentDirection != Direction.Left => Direction.Right,
                _ => currentDirection
            };

            return currentDirection;
        }

        public void Draw()
        {
            Head.Draw();

            foreach (Pixel pixel in Body)
            {
                pixel.Draw();
            }
        }

        public void Clear()
        {
            Head.Clear();

            foreach (Pixel pixel in Body)
            {
                pixel.Clear();
            }
        }
    }
}
