using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Bandit
{
    class Walze : PictureBox
    {
        private const int max = 10;
        private const int min = 1;
        private const long correctpertick = 150000;
        private const int verschiebungstart = 30;
        private long dZeit, lZeit;
        private int drittel;
        private int[] Zahl;
        public bool running;
        public durchschnitt tZwischenF = new durchschnitt();
        private bool auslaufen;
        private int dx = 0;
        private int verschiebung;
        private Timer zaehler;
        private Font myFont = new System.Drawing.Font("Microsoft Sans Serif", 80.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        public Walze()
        {
            zaehler = new System.Windows.Forms.Timer();
            zaehler.Interval = 1;
            zaehler.Tick += new EventHandler(zaehler_Tick);
        }
        public void stoppen()
        {
            auslaufen = true;
           // MessageBox.Show(Convert.ToString(tZwischenF.getDurchschnitt()));
        }
        public void nextNumber()
        {
            dZeit = DateTime.Now.Ticks - lZeit;
            lZeit = DateTime.Now.Ticks;
            tZwischenF.hinzufuegen(dZeit);
            if (verschiebung > 0 && running) {
                dx += (verschiebung/3)*Convert.ToInt32(dZeit / correctpertick);
                if (dZeit / correctpertick > 1.5 || dZeit / correctpertick < 0.5)
                {
                }
                if (dx >= drittel)
                {
                    Zahl[2] = Zahl[1];
                    Zahl[1] = Zahl[0];
                    if (++Zahl[0] == max)
                        Zahl[0] = 1;
                    dx = 0;
                }
            }
            if (auslaufen)
            {
                if (verschiebung > 10)
                {
                    verschiebung--;
                }else if (dx >= drittel/2 - 5)
                {
                    dx = drittel/2;
                    running = false;
                    auslaufen = false;
                }
            }

            zeichnen();
        }
        public int getZahl()
        {
            return Zahl[1];
        }
        private void zeichnen()
        {
            Bitmap b = new Bitmap(this.Size.Width, this.Size.Height);
            Graphics g;
            drittel = (this.Size.Height) / 3;
            drittel = drittel * 2;
            g = Graphics.FromImage(b);
            g.DrawString(Convert.ToString(Zahl[0]), myFont, Brushes.Black, 0, dx - drittel);
            g.DrawString(Convert.ToString(Zahl[1]), myFont, Brushes.Red, 0, dx);
            g.DrawString(Convert.ToString(Zahl[2]), myFont, Brushes.Black, 0, dx + (drittel));
            g.DrawLine(Pens.Black, 0, drittel/2, this.Size.Width, drittel/2);
            g.DrawLine(Pens.Black, 0, (this.Size.Height / 3) * 2, this.Size.Width, (this.Size.Height / 3) * 2);

            this.Image = b;
        }

        public void starten(int button)
        {
            Random zufall = new Random(button);
            lZeit = DateTime.Now.Ticks;
            running = true;
            Zahl = new int[3];
            Zahl[0] = 1; //zufall.Next(min, max-2);
            Zahl[1] = Zahl[0] + 1;
            Zahl[2] = Zahl[1] + 1;
            auslaufen = false;
            this.zaehler.Start();
            verschiebung = verschiebungstart;
        }
        private void zaehler_Tick(object sender, EventArgs e)
        {
            nextNumber();
        }
                    
    }
}
