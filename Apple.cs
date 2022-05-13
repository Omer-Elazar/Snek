using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snek
{
    [Serializable]
    public class Apple : Food // Red apple
    {
         
        public int points = 1;

        public override Color Color { get; set; }

        [NonSerialized] SolidBrush br;
        [NonSerialized] SolidBrush br2;
        [NonSerialized] Pen pen;

        public Apple()
        {
            X = random.Next(100, 200);
            Y = random.Next(100, 200);
            X = X - (X % 10) + 5;
            Y = Y - (Y % 10) + 5;
            Color = Color.Red;
            br = new SolidBrush(Color);
        }

        public Apple(int x, int y)
        {
            X = x - (x % 10) + 5;
            Y = y - (y % 10) + 5;
            Color = Color.Red;
            br = new SolidBrush(Color);
            br2 = new SolidBrush(Color.Green);
        }

        ~Apple() { }

        public override void Eat(int score)
        {
            score += points;
        }

        public override void Draw(Graphics g)
        {
            SolidBrush br = new SolidBrush(Color);
            SolidBrush br2 = new SolidBrush(Color.Green);
            Pen pen = new Pen(Color.DarkRed, 2);
            g.FillEllipse(br, X - radius, Y - radius, 2 * radius, 2 * radius);
            g.DrawEllipse(pen, X - radius, Y - radius, 2 * radius, 2 * radius);
            g.FillEllipse(br2, X - radius + 2, Y - radius - 1, 0.8F * radius, 1.2F * radius);
        }
    }
}
