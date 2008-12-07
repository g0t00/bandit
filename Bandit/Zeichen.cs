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
        public int IconId;
        //private Font myFont;
        //private Brush myBrush;
        //private string Zahl;
        public Point getPosition()
        {
            return Position;
        }
        #region unnütz gewordene set overwrites
        //public void set(Font newFont)
        //{
        //    myFont = newFont;
        //    redraw();
        //}
        //public void set(Brush newBrush)
        //{
        //    myBrush = newBrush;
        //    redraw();
        //}
        //public void set(Font newFont, Brush newBrush)
        //{
        //    set(newBrush);
        //    set(newFont);
        //}
        //public void set(string newZahl)
        //{
        //    Zahl = newZahl;
        //    redraw();
        //}
        //public void set(string Zahl, Font newFont, Brush newBrush)
        //{
        //    set(newFont, newBrush);
        //    set(Zahl);
        //}
        #endregion
        public void set(Image newImage)
        {
            b = new Bitmap(newImage);
            
            redraw();
        }
        public virtual void redraw()
        {
            //b = new Bitmap(100, 100);

            g = Graphics.FromImage(b);
           // g.ScaleTransform(0.5F, 0.5F);
            //g.DrawString(Zahl, myFont, myBrush, 0, 0);
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
