using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snek
{
    [Serializable]
    public class Snake
    {
        public List<BodyPart> snake { get; set; }// = new List<BodyPart>();
        public Direction Dir { get; set; }

        public Color Color { get; set; }


        public Snake()
        {
            snake = new List<BodyPart>();
            Dir = Direction.Left;
            Color = Color.Green;
        }

        ~Snake() { }

        public void grow()
        {
            BodyPart head = snake[snake.Count - 1];
            snake.Add(head);
        }

        internal void Move()
        {
            BodyPart tail = snake.First();
            snake.Remove(tail);
            BodyPart head = GetNextPoint();
            snake.Add(head);
            head.move(Dir);
            //tail.Dispose();
        }

        public BodyPart GetNextPoint()
        {
            BodyPart head = snake.Last();
            BodyPart nextPoint = new BodyPart(head.X, head.Y, head.radius);
            nextPoint.move(Dir);
            return nextPoint;
        }

        internal bool IsHitTail()
        {
            var head = snake.Last();
            for (int i = 0; i < snake.Count - 3; i++)
            {
                if (head.IsOn(snake[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public void CheckWalls()
        {
            if (snake[snake.Count - 1].X > 430)
            {
                snake[snake.Count - 1].X = 2;
            }
            else if (snake[snake.Count - 1].Y > 375)
            {
                snake[snake.Count - 1].Y = 2;
            }
            else if (snake[snake.Count - 1].X < 2)
            {
                snake[snake.Count - 1].X = 430;
            }
            else if (snake[snake.Count - 1].Y < 2)
            {
                snake[snake.Count - 1].Y = 375;
            }
        }

    }
}
