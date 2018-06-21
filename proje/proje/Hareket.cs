using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proje
{
    class Hareket:Form
    {
        ArrayList aUcak = new ArrayList();
        Random r = new Random();
        ArrayList aMermi = new ArrayList();
        public void UcakOlustur()
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
        public void Vurulma()
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
    }
}
