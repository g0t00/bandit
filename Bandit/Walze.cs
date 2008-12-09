using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Bandit
{
    class Walze : PictureBox
    {
        #region Deklarationen
        private const int max = 4;
        private Zeichen[] myZeichen = new Zeichen[max];
        private const int AnzZeichenAnzeige = 3;
        private const int height = 300;
        private const int min = 1;
        private const long correctpertick = 150000;
        private const double verschiebungstart = 0.6;
        private long dZeit, lZeit;
        //private int drittel;
        private int IconId;
        public bool running;
        public durchschnitt tZwischenF = new durchschnitt();
        public event EventHandler ausgelaufen;
        private bool auslaufen;
        private int dx = 0;
        private double verschiebung;
        private Timer zaehler;
        Graphics g;
        private Font myFont = new System.Drawing.Font("Microsoft Sans Serif", 80.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        #endregion
        public Walze()
        {
            zaehler = new System.Windows.Forms.Timer();
            zaehler.Interval = 1;
            zaehler.Tick += new EventHandler(zaehler_Tick);
            
        }
        public void stoppen()
        {
            auslaufen = true;
        }
        public void nextNumber()
        {
            dZeit = DateTime.Now.Ticks - lZeit;
            lZeit = DateTime.Now.Ticks;
            tZwischenF.hinzufuegen(dZeit);
            if (verschiebung > 0 && running) {
                dx = (int)(verschiebung * (int)dZeit / 10000);
                foreach (Zeichen thisZeichen in myZeichen)
                {
                    thisZeichen.increaseYPosition(dx);
                    if (thisZeichen.getPosition().Y >= (height/3) * (max-1))
                    {
                        thisZeichen.setYPosition(-height/3);
                    }
                   
                    if (((int)thisZeichen.getPosition().Y > height / 3 && (int)thisZeichen.getPosition().Y < height / 3+5)&& auslaufen)
                    {
                        running = false;
                        auslaufen = false;
                        IconId = thisZeichen.IconId;
                        if (ausgelaufen != null)
                        {
                            ausgelaufen(this, new EventArgs());
                        }
                    }
                    
                }
                
            }
            if (auslaufen)
            {
                if (verschiebung > verschiebungstart/3)
                {
                    verschiebung -= 0.0005*(((double)dZeit) / 10000);
                }
            }

            zeichnen();
        }
        public int getZahl()
        {
            return IconId;
        }
        private void zeichnen()
        {
            Bitmap b = new Bitmap(this.Size.Width, this.Size.Height);
            g = Graphics.FromImage(b);
            foreach (Zeichen thisZeichen in myZeichen)
            {
                //g.DrawImage(thisZeichen.Anzeige(), thisZeichen.getPosition());
                g.DrawImage(thisZeichen.Anzeige(), new Rectangle(thisZeichen.getPosition(), new Size(100, 100)));
            }
            //drittel = (this.Size.Height) / 3;
            //drittel = drittel * 2;
            //g = Graphics.FromImage(b);
            //g.DrawString(Convert.ToString(Zahl[0]), myFont, Brushes.Black, 0, dx - drittel);
            //g.DrawString(Convert.ToString(Zahl[1]), myFont, Brushes.Red, 0, dx);
            //g.DrawString(Convert.ToString(Zahl[2]), myFont, Brushes.Black, 0, dx + (drittel));
            g.DrawLine(Pens.Black, 0, height / 3, this.Size.Width, height / 3);
            g.DrawLine(Pens.Black, 0, height / 3*2, this.Size.Width, height / 3*2);

            this.Image = b;
        }

        public void starten(int button)
        {
            for (int i = 0; i < max; i++)
            {
                myZeichen[i] = new Zeichen();
                myZeichen[i].IconId = i;
                Bitmap b = new Bitmap(Convert.ToString(i + 1) + ".png");
                myZeichen[i].set(b);
                myZeichen[i].setPosition(new Point(0, (height / 3) * i));
            }
            Random zufall = new Random(button);
            lZeit = DateTime.Now.Ticks;
            running = true;
            /*Zahl = new int[3];
            Zahl[0] = 1; //zufall.Next(min, max-2);
            Zahl[1] = Zahl[0] + 1;
            Zahl[2] = Zahl[1] + 1;*/
            auslaufen = false;
            this.zaehler.Start();
            verschiebung = verschiebungstart;
           
        }
        private void zaehler_Tick(object sender, EventArgs e)
        {
           nextNumber();
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }
                    
    }
}
