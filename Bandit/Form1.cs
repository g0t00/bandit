using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bandit
{
    public partial class Form1 : Form
    {
        //public static Label[] Anzeige = new Label[3];
        public const int anzWalzen = 3;
        static Walze[] Walzen;
        static Timer stopper = new Timer();
        public Form1()
        {
            InitializeComponent();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            Anzeige.Visible = false;
            Walze myWalze;
            Walzen = new Walze[anzWalzen];
            for (int i = 0; i <= anzWalzen-1; i++)
            {
                myWalze = new Walze();
                myWalze.AutoSize = true;
                myWalze.Location = new Point((this.Size.Width/anzWalzen)*(i), 35);
                myWalze.Size = new Size(100, 300);
                myWalze.TabIndex = 0;
                Walzen[i] = myWalze;
                this.Controls.Add(Walzen[i]);
            }
            #region experiment
            /*Buttion myButton;
            Stopp = new Button[anzWalzen];
            
            for (int i = 0; i <= anzWalzen-1; i++)
            {
            myButton.Location = new System.Drawing.Point(32, 158);
            myButton.Name = "Stopp1";
            myButton.Size = new System.Drawing.Size(70, 70);
            myButton.TabIndex = 2;
            myButton.Text = "Stopp";
            myButton.UseVisualStyleBackColor = true;
            myButton.Stopp1.Click += new System.EventHandler(this.Stopp1_Click);
            // 
            // Stopp2
            // 
            this.Stopp2.Location = new System.Drawing.Point(209, 158);
            this.Stopp2.Name = "Stopp2";
            this.Stopp2.Size = new System.Drawing.Size(70, 70);
            this.Stopp2.TabIndex = 3;
            this.Stopp2.Text = "Stopp";
            this.Stopp2.UseVisualStyleBackColor = true;
            // 
            // Stopp3
            // 
            this.Stopp3.Location = new System.Drawing.Point(397, 158);
            this.Stopp3.Name = "Stopp3";
            this.Stopp3.Size = new System.Drawing.Size(70, 70);
            this.Stopp3.TabIndex = 4;
            this.Stopp3.Text = "Stopp";
            this.Stopp3.UseVisualStyleBackColor = true;*/
            #endregion
        }

       

        private void Start_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= anzWalzen-1; i++)
            {
                Walzen[i].starten(i);
            }
            stopper.Stop();
            Anzeige.Visible = false;
        }

        private void Stopp1_Click(object sender, EventArgs e)
        {
            stoppen(0);
        }

        private void Stopp2_Click(object sender, EventArgs e)
        {
            stoppen(1);
        }

        private void Stopp3_Click(object sender, EventArgs e)
        {
            stoppen(2);
        }
        private void stoppen(int Walzenid)
        {
                stopper.Interval = 1;
                stopper.Tick += new EventHandler(Auswerten);
                stopper.Start();
                Walzen[Walzenid].stoppen();
        }
        private void Auswerten(object sender, EventArgs e)
        {
                bool fertig = true;
                for (int i = 0; i <= anzWalzen - 1; i++)
                {
                    if (Walzen[i].running)
                    { fertig = false; }
                }
                if (fertig)
                {
                    int last = Walzen[0].getZahl();
                    bool gewonnen = false;
                    for (int i = 1; i <= anzWalzen - 1; i++)
                    {
                        gewonnen = (Walzen[i].getZahl() == last);
                    }
                    if (gewonnen)
                    {
                        Anzeige.Text = "Gewonnen";
                        Anzeige.Visible = true;
                    }
                    else
                    {
                        Anzeige.Text = "Verloren";
                        Anzeige.Visible = true;
                    }
            }
        }
        

       

        
    }
}