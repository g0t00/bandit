using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;


namespace Bandit
{
    class Zeichen
    {
        private Point Position;
        private Graphics g;
        private Bitmap b;
        private Font myFont;
        private Brush myBrush;
        public Point getPosition()
        {
            return Position;
        }
        public void set(Font newFont)
        {
            myFont = newFont;
        }
        public void set(Brush newBrush)
        {
            myBrush = newBrush;
        }
        public void set(Font newFont, Brush newBrush)
        {
            set(newBrush);
            set(newFont);
        }
        public void set(string Zahl, Font newFont, Brush newBrush)
        {
            set(newFont, newBrush);
            set(Zahl);
        }
        public void set(string Zahl)
        {
            b = new Bitmap(100, 100);
            g = Graphics.FromImage(b);
            g.DrawString(Zahl, myFont, myBrush, 0, 0);
        }
        public Bitmap Anzeige()
        {
            return b;
        }
        public void setPosition(Point newPosition)
        {
            Position = newPosition;
        }
        public void setYPosition(int newY)
        {
            Position = new Point(Position.X, newY);
        }
        public void increaseYPosition(int increasement)
        {
            setYPosition(Position.Y + increasement);
        }
    }
}
