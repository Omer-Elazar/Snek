using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snek
{
    [Serializable]
    public class GoldenApple : Food // spawns randomly, gives more points, has decay
    {

        [NonSerialized] SolidBrush br;
        [NonSerialized] SolidBrush br2;
        [NonSerialized] Pen pen;

        public override Color Color { get; set; }

        public int Opacity;
        public bool exist { get; set; } 
        public int Points { get; set; }

        public GoldenApple()
        {
            exist = false;
            Points = 5;
            br = new SolidBrush(Color.FromArgb(Opacity, Color));
            br2 = new SolidBrush(Color.FromArgb(Opacity, Color.Green));
            pen = new Pen(Color.FromArgb(Opacity, Color.Gold), 2);
            Color = Color.Yellow;
            Opacity = 255;
        }

        ~GoldenApple() { }

        public override void Eat(int score)
        {
            score += Points;
            exist = false;
            Opacity = 255;
        }

        public void Draw(Graphics g, int opacity)
        {
            SolidBrush br = new SolidBrush(Color.FromArgb(opacity, Color));
            SolidBrush br2 = new SolidBrush(Color.FromArgb(opacity, Color.Green));
            Pen pen = new Pen(Color.FromArgb(opacity, Color.Gold), 2);
            g.FillEllipse(br, X - radius, Y - radius, 2 * radius, 2 * radius);
            g.DrawEllipse(pen, X - radius, Y - radius, 2 * radius, 2 * radius);
            g.FillEllipse(br2, X - radius + 2, Y - radius - 1, 0.8F * radius, 1.2F * radius);
        }
    }
}
