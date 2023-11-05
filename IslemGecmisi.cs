using PortfoyUygulaması;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class IslemGecmisi : Form
    {
        public IslemGecmisi()
        {
            InitializeComponent();
        }

       public void islemgecmisi(string[] hisse, string[] hisse2, double[] fiyat, double[] adet, string[] tür)
        {
            int sayac = 0;
            int sayac2 = 10;
            double maliyet = 0;

            foreach (string var in hisse)
            {
                if (tür[sayac] == "Alis")
                {
                    maliyet = (-1) * fiyat[sayac] * adet[sayac];
                }
                else if (tür[sayac] == "Satis")
                {
                    maliyet = fiyat[sayac] * adet[sayac];                    
                }
                maliyet = Math.Round(maliyet, 2);

                hisse[sayac] = var + " " + maliyet.ToString() + " " + tür[sayac];
                sayac += 1;
            }
            sayac = 1;

            foreach (string i in hisse2)
            {
                if (i != null)
                {
                    Label l1 = new Label();
                    l1.Location = new System.Drawing.Point(sayac2, sayac * 20);                    
                    l1.Text = i.ToString() + ". ";
                    l1.BackColor= Color.Red;
                    Controls.Add(l1);
                    foreach (string var in hisse)
                    {
                        string[] columns1 = var.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (columns1[0] == i)
                        {
                            Label l2 = new Label();
                            l2.Location = new System.Drawing.Point((100+sayac2), sayac * 20);
                            l2.Text = columns1[1].ToString() + ". ";
                            sayac += 1;
                            Controls.Add(l2);
                            if (sayac % 40 == 0)
                            {
                                sayac = 1;
                                sayac2 += 200;
                            }
                        }
                    }
                }
            }
        }
    }
}
