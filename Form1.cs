using System.Collections;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Windows.Forms;
using System.Xml;
using WinFormsApp1;
using static System.Windows.Forms.DataFormats;

namespace PortfoyUygulamasý
{
    public partial class Form1 : Form
    {
        public static string hisseadi;
        public static string[] ad;
        public static string[] ad2;
        public static string[] tür;
        public static Double[] adet;
        public static Double[] adet2;
        public static Double[] fiyat;
        public static Double[] fiyat2;
        public static Double[] karzarar;
        HalkaArz frm2 = new HalkaArz();
        IslemGecmisi frm3= new IslemGecmisi();

        public Form1()
        {
            InitializeComponent();
            oku();
        }
        public void oku()
        {


            double komisyon = 0;
            string[] read = File.ReadAllLines(Environment.CurrentDirectory + "Portfoy.txt");
            string[][] cells = read.Select(x => x.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray()).ToArray();
            int boyut = read.Length -1;
            ad = new string[boyut];
            ad2 = new string[boyut];
            tür = new string[boyut];
            fiyat = new double[boyut];
            fiyat2 = new double[boyut];
            adet = new double[boyut];
            adet2 = new double[boyut];
            karzarar = new double[boyut];
            string[] list = { "", "", "", "" };
            string[] list2 = { "", "", "", "" ,""};
            string[] list1 = { "", "" };
            int sayac = 0;
            int listesayacý = 0;
            int listesayacý2 = 0;
            int deger;
            double kazanc = 0;
            double portfoy = 0;
            foreach (string i in read)
            {
                if (sayac == 0)
                {
                    sayac += 1;
                    continue;                   
                }
                string[] columns = i.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                ad2[sayac - 1] = columns[0];
                tür[sayac - 1] = columns[3];
                fiyat2[sayac - 1] = Convert.ToDouble(columns[1]);
                adet2[sayac - 1] = Convert.ToDouble(columns[2]);

                komisyon += Convert.ToDouble(columns[1]) * Convert.ToDouble(columns[2]) * 0.00210203;
                deger = Array.IndexOf(ad, columns[0]);
                if(deger == -1)
                {
                    ad[sayac - 1] = columns[0];
                    fiyat[sayac - 1] = Convert.ToDouble(columns[1]);
                    adet[sayac - 1] = Convert.ToDouble(columns[2]);
                    
                }
                else
                {
                    if (columns[3] == "Alis")
                    {
                        fiyat[deger] = (fiyat[deger] * adet[deger] + Convert.ToDouble(columns[1]) * Convert.ToDouble(columns[2]))/(adet[deger] + Convert.ToDouble(columns[2]));
                        adet[deger] = adet[deger] + Convert.ToDouble(columns[2]);
                    }
                    else
                    {
                        adet[deger] = adet[deger] - Convert.ToDouble(columns[2]);
                        karzarar[deger] = karzarar[deger] + (Convert.ToDouble(columns[1]) - fiyat[deger]) * Convert.ToDouble(columns[2]);
                    }
                }

                    sayac += 1;
            }
            sayac = 0;
            cb1.Items.Clear();
            listView1.Items.Clear();
            listView2.Items.Clear();
            listView3.Items.Clear();
            listView4.Items.Clear();
            frm2.listView1.Items.Clear();
            double yuksekfiyatlihisseler = 0;
            foreach (string var in ad)
            {
                if (var != null && var != "ALTIN" && var != "USDTRF")
                {
                    list[0] = var;
                    list[1] = adet[sayac].ToString();
                    fiyat[sayac] = Math.Round(fiyat[sayac], 2);
                    list[2] = fiyat[sayac].ToString();
                    list1[0] = var;
                    list[3] = (Math.Round((adet[sayac] * fiyat[sayac]), 2)).ToString();
                    karzarar[sayac] = Math.Round(karzarar[sayac], 2);
                    list1[1] = karzarar[sayac].ToString();
                    var listV = new ListViewItem(list);
                    var listV1 = new ListViewItem(list1);


                    if (adet[sayac] != 0)
                    {
                        
                        cb1.Items.Add(var);
                        
                        if (cb2.Items.IndexOf(var) == -1)//cb içinde yoksa 
                        {
                            frm2.listView1.Items.Add(listV);
                            
                        }
                        else listView1.Items.Add(listV);//cb içinde varsa

                        if (karzarar[sayac] >= 100 || karzarar[sayac] <= (-100)) 
                        {

                            if (cb2.Items.IndexOf(var) == -1)//cb içinde yoksa Halka Arz kýsmýna yaz
                            {
                                if (listesayacý2 < 21) frm2.listView2.Items.Add(listV1);
                                else
                                {
                                    frm2.Size = new Size(735, 627);
                                    frm2.listView3.Visible = true;
                                    frm2.listView3.Items.Add(listV1);
                                }
                                listesayacý2 += 1;
                            }
                            else
                            {
                                if (listesayacý < 28) listView2.Items.Add(listV1);
                                else
                                {
                                    this.Size = new Size(1150, 800);
                                    listView4.Visible = true;
                                    listView4.Items.Add(listV1);
                                }
                                listesayacý += 1;
                            };
                        } 
                        portfoy = portfoy + adet[sayac] * fiyat[sayac];
                    }
                    else 
                    {
                        if (karzarar[sayac] >= 10 || karzarar[sayac] <= (-10))
                        {
                            if (cb2.Items.IndexOf(var) == -1)//cb içinde yoksa Halka Arz kýsmýna yaz
                            {
                                if (listesayacý2 < 21) frm2.listView2.Items.Add(listV1);
                                else
                                {
                                    frm2.Size = new Size(735, 627);
                                    frm2.listView3.Visible = true;
                                    frm2.listView3.Items.Add(listV1);
                                }
                                listesayacý2 += 1;
                            }
                            else
                            {
                                if (listesayacý < 28) listView2.Items.Add(listV1);
                                else
                                {
                                    this.Size = new Size(1150, 800);
                                    listView4.Visible = true;
                                    listView4.Items.Add(listV1);
                                }
                                listesayacý += 1;
                            }                          
                        }
                    }

                    if (cb2.Items.IndexOf(var) != -1 && (var != "ALTIN" || var != "USDTRF"))
                    {
                        yuksekfiyatlihisseler += adet[sayac] * fiyat[sayac];
                    }
                }
                else if (var == "ALTIN" || var == "USDTRF")
                {
                    if (adet[sayac] != 0)   cb1.Items.Add(var);
                    list2[0] = var;
                    list2[1] = adet[sayac].ToString();
                    fiyat[sayac] = Math.Round(fiyat[sayac], 2);
                    list2[2] = fiyat[sayac].ToString();
                    list2[3] = (Math.Round((adet[sayac] * fiyat[sayac]), 2)).ToString();
                    list2[4] = (Math.Round(karzarar[sayac],1)).ToString();

                    var listV = new ListViewItem(list2);
                    listView3.Items.Add(listV);
                    portfoy = portfoy + adet[sayac] * fiyat[sayac];
                }
                sayac += 1;
            }
            foreach (double a in karzarar)
            {
                kazanc += a;
            }
            komisyon = Math.Round(komisyon, 0);
            portfoy = Math.Round(portfoy, 0);
            kazanc = Math.Round(kazanc, 0);
            yuksekfiyatlihisseler = Math.Round(yuksekfiyatlihisseler, 0);
            label14.Text = "Kar/Zarar                                         " + kazanc.ToString();
            label15.Text = "Vergi =                                             " + komisyon.ToString();
            label16.Text = "Portföy Deðeri =                             " + portfoy.ToString();
            label17.Text = "Halka Arz Olmayanlarýn Deðeri = " + yuksekfiyatlihisseler.ToString();
            listView2.Sorting = SortOrder.Ascending;
            listView2.Sort();
            listView1.Sorting = SortOrder.Ascending;
            listView1.Sort();

        }
        public void yaz(string hisse, string fiyat, string adet, string alsat)
        {
            StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + "Portfoy.txt", true);
            int a = hisse.Length;
            for (int i = 10; i > a; i--) hisse = hisse + " ";
            a = fiyat.Length;
            for (int i = 10; i > a; i--) fiyat = fiyat + " ";
            a = adet.Length;
            for (int i = 10; i > a; i--) adet = adet + " ";
            sw.WriteLine(hisse + fiyat + adet + alsat);
            sw.Close();
        }
        public void xmlyaz(string[] hisse, string[] hisse2, double[] fiyat, double[] adet, string[] tür)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            XmlWriter writer = XmlWriter.Create("HisseGecmisi.xml", settings);
            int sayac = 0;
            double maliyet = 0;
            writer.WriteStartDocument();
            writer.WriteStartElement("Hisse");

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
                fiyat[sayac] = Math.Round(fiyat[sayac], 2);
                maliyet = Math.Round(maliyet, 2);

                hisse[sayac] = var + " " + maliyet.ToString() + " " + tür[sayac] + " " + fiyat[sayac];
                sayac += 1;
            }
            double tutar = 0;
            foreach (string i in hisse2)
            {
                if(i != null)
                {
                    writer.WriteStartElement(i);
                    foreach (string var in hisse)
                    {
                        string[] columns1 = var.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (columns1[0] == i)
                        {
                            writer.WriteStartElement("Ýþlem");
                            writer.WriteAttributeString(columns1[2], columns1[3]);
                            writer.WriteAttributeString("Tutar", columns1[1]);
                            writer.WriteEndElement();

                            tutar += Convert.ToDouble(columns1[1]);
                        }
                    }
                    writer.WriteStartElement("Sonuç");
                    writer.WriteAttributeString("Tutar", tutar.ToString());
                    tutar = 0;
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }
                    
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }

        private void btn_Al_Click(object sender, EventArgs e)
        {
            bool a = true;
            if (textBox1.Text.ToString() != "") hisseadi = textBox1.Text.ToString().ToUpperInvariant();
            else if (cb2.SelectedItem != null) hisseadi = cb2.SelectedItem.ToString();
            else
            {
                a = false;
            }

            if (a != false && numericUpDown1.Value != 0 && numericUpDown2.Value != 0) // Herhangi bir deðerin girilmemesi durumunda yazdýrmasýn.
            {
                yaz(hisseadi, numericUpDown1.Value.ToString(), numericUpDown2.Value.ToString(), "Alis");
                oku();
            }
        }
        private void btn_Sat_Click(object sender, EventArgs e)
        {
            if (cb1.SelectedItem != null && numericUpDown3.Value != 0 && numericUpDown4.Value != 0) 
                yaz(cb1.SelectedItem.ToString(), numericUpDown3.Value.ToString(), numericUpDown4.Value.ToString(), "Satis");
            oku();
        }

        private void cb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int value = Array.IndexOf(ad, cb1.SelectedItem.ToString());
            numericUpDown4.Value = Convert.ToInt32(adet[value]);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) frm2.Show();
            else frm2.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            xmlyaz(ad2, ad, fiyat2, adet2, tür);
            MessageBox.Show("XML Dosyasý Oluþturuldu");
        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                frm3.Show();
                IslemGecmisi form = (IslemGecmisi)Application.OpenForms["IslemGecmisi"];
                form.islemgecmisi(ad2, ad, fiyat2, adet2, tür);
            }
            else frm3.Hide();
        }
    }
}