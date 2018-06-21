using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace proje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ArrayList aUcak = new ArrayList();

        ArrayList aMermi = new ArrayList();

        Random r = new Random();
        

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
           

                int x = ucaksavar.Location.X;
                int y = ucaksavar.Location.Y;

                if (e.KeyCode == Keys.Enter)
                {
                     label3.Dispose();
                     panel1.Size = new System.Drawing.Size(827, 45);
                     timer1.Start();
                     timer2.Start();                  
                     timer3.Start();
                     for (int j = 0; j < aUcak.Count; j++)
                     {
                          PictureBox btnUcak = ((PictureBox)aUcak[j]);
                          btnUcak.Dispose();
                          

                     }
                     for (int j = 0; j < aMermi.Count; j++)
                     {
                          PictureBox btnmermi = ((PictureBox)aMermi[j]);
                          btnmermi.Dispose();
                     }
               
                         aUcak.Clear();
                         aMermi.Clear();
                }
                else if (e.KeyCode == Keys.Space)
                {
              
                    MermiOlustur();
                    timer2.Start();
             
                
                }
               else if (e.KeyCode == Keys.Right && ucaksavar.Right < this.ClientSize.Width)
                {
                    x = x + 10;
                }
              else  if (e.KeyCode == Keys.Left && x > -5)
                {
                    x = x - 10;
                }
              else  if (ucaksavar.Bottom < this.ClientSize.Height)
                {
               
                }

                ucaksavar.Location = new Point(x, y);
            
        }

        private void UcakOlustur()
        {
            PictureBox u = new PictureBox();
            u.ImageLocation = "Ucak.png";
            u.SizeMode = PictureBoxSizeMode.Zoom;
            u.Size = new Size(53, 63);
            u.Location = new Point(r.Next(20, ClientSize.Width) - 40);
            u.BackColor = Color.Transparent;
            this.Controls.Add(u);
            aUcak.Add(u);

        }
        private void MermiOlustur()
        {
            PictureBox m = new PictureBox();
            m.ImageLocation = "mermi.png";
            m.SizeMode = PictureBoxSizeMode.Zoom;
            m.Size = new Size(25, 20);
            m.Location = new Point(ucaksavar.Location.X+39, ucaksavar.Location.Y-15);
            m.BackColor = Color.Transparent;
            this.Controls.Add(m);
            aMermi.Add(m);
        }

        private void Vurulma()
        {
            Rectangle _ucak = new Rectangle();
            Rectangle _mermi = new Rectangle();

            for (int i = 0; i < aUcak.Count; i++)
            {
                PictureBox btnUcak = ((PictureBox)aUcak[i]);
                for (int j = 0; j < aMermi.Count; j++)
                {
                    
                    _ucak.Height = btnUcak.Height;
                    _ucak.Width = btnUcak.Width;
                    _ucak.X = btnUcak.Left;
                    _ucak.Y = btnUcak.Top;

                    PictureBox btnMermi = ((PictureBox)aMermi[j]);
                    _mermi.Height = btnMermi.Height;
                    _mermi.Width = btnMermi.Width;
                    _mermi.X = btnMermi.Left;
                    _mermi.Y = btnMermi.Top;

                    if (_ucak.IntersectsWith(_mermi))
                    {
                        aUcak.RemoveAt(i);
                        aMermi.RemoveAt(j);
                        btnUcak.Dispose();
                        btnMermi.Dispose();
                    }

                }
            }
        }

        private void Yanma()
        {
            for (int i = 0; i < aUcak.Count; i++)
            {
                PictureBox btnUcak = ((PictureBox)aUcak[i]);

                if (btnUcak.Location.Y >= ClientSize.Height-85)
                {
                    timer1.Stop();
                    timer2.Stop();
                    timer3.Stop();
                    MessageBox.Show("Yandınız!");
                }
            }

        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            UcakOlustur();
        }
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            Yanma();
            Vurulma();
             for(int i = 0; i <aUcak.Count; i++)
             {
                 PictureBox btn = ((PictureBox)aUcak[i]);
                 btn.Top = btn.Top+10;
             }
             
           
        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            for (int i = 0; i < aMermi.Count; i++)
            {
                PictureBox btn = ((PictureBox)aMermi[i]);
                btn.Top = btn.Top - 15;
            }

        }
    }
}
