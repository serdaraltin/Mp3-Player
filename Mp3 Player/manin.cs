using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace Mp3_Player
{
    public partial class manin : Form
    {
        public manin()
        {
            InitializeComponent();
        }
        OleDbConnection baglan=new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+Application.StartupPath+"\\data\\data.db");
        bool diskmod = false;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            string g = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string[] kelimeler = Environment.GetCommandLineArgs();
            foreach (string dosya_yolu in kelimeler)
            {
                if (!dosya_yolu.StartsWith(Application.StartupPath))
                {
                    try
                    {

                        saniye = 0;
                        axWindowsMediaPlayer1.URL = dosya_yolu;
                        label2.Text = dosya_yolu;
                        mp3ismi = dosya_yolu;
                        button1.Text = "ıı";

                    }
                    catch (Exception hata)
                    {
                        //MessageBox.Show(hata.Message.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                    
                }
        
            
            label2.Font = ayarlar.Default.kayanyazi;
            if (System.IO.File.Exists(Application.StartupPath+"\\data\\data.db") == false)
            {
                MessageBox.Show("VeriTabanı bulunamadı!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            axWindowsMediaPlayer1.settings.volume = 80;
            trackBar1.Value = 80;
            listBox1.Font = ayarlar.Default.font;
            timer2.Interval = ayarlar.Default.timer;
            timer3.Interval = ayarlar.Default.timer;
            listBox1.ForeColor = ayarlar.Default.listbox;
            axWindowsMediaPlayer1.Location = new Point(5, 20);
          //  axWindowsMediaPlayer1.Size = new Size(this.Height, (this.Width/2)-37);
            this.Font = ayarlar.Default.font;
            this.Text = ayarlar.Default.text;
            this.BackColor = ayarlar.Default.backcolor;
            diskoModuToolStripMenuItem.BackColor = ayarlar.Default.button;
            listBox1.BackColor = ayarlar.Default.button;
            button1.BackColor = ayarlar.Default.button;
            button8.BackColor = ayarlar.Default.button;
            button7.BackColor = ayarlar.Default.button;
            button2.BackColor = ayarlar.Default.button;
            button3.BackColor = ayarlar.Default.button;
            button4.BackColor = ayarlar.Default.button;
            button5.BackColor = ayarlar.Default.button;
            equalizerToolStripMenuItem.BackColor = ayarlar.Default.button;
            equalizerToolStripMenuItem1.BackColor = ayarlar.Default.button;
            mp3İndiriciToolStripMenuItem.BackColor = ayarlar.Default.button;
            arayüzAyarlarıToolStripMenuItem.BackColor = ayarlar.Default.button;
            çokluEkleToolStripMenuItem.BackColor = ayarlar.Default.button;
            oynatıcıAyarlarıToolStripMenuItem.BackColor = ayarlar.Default.button;
            panel1.BackColor = ayarlar.Default.backcolor;
            //yenidenBaşlarToolStripMenuItem.BackColor = ayarlar.Default.button;
            label3.BackColor = ayarlar.Default.button;
         
            contextMenuStrip1.BackColor = ayarlar.Default.button;
            dosyaToolStripMenuItem.BackColor = ayarlar.Default.button;
            menuStrip1.BackColor = ayarlar.Default.button;
            açToolStripMenuItem.BackColor = ayarlar.Default.button;
            çıkışToolStripMenuItem.BackColor = ayarlar.Default.button;
            trackBar1.BackColor = ayarlar.Default.backcolor;
            trackBar2.BackColor = ayarlar.Default.backcolor;
            trackBar3.BackColor = ayarlar.Default.backcolor;
            trackBar4.BackColor = ayarlar.Default.backcolor;
            trackBar1.Value = axWindowsMediaPlayer1.settings.volume;
            label1.Text = axWindowsMediaPlayer1.settings.volume.ToString()+"%";
            mp3listele();
            axWindowsMediaPlayer1.uiMode = "none";
            
        }
        string mp3ismi="";
        int sira=0;
        int saniye = 0;
        bool karıstır=false;
        bool tekrar = false;
        int mp3sira;
        private void mp3listele()
        {
            try
            {
                listBox1.Items.Clear();
                baglan.Open();
                OleDbCommand komut = new OleDbCommand("Select *From veri", baglan);
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    string mpeisim = oku["mp3"].ToString();
                    listBox1.Items.Add(mpeisim.Substring(0, mpeisim.Length - 4));

                }
                baglan.Close();
            }
            catch { baglan.Close(); }
        }
        private void mp3oynat()
        {
            try
            {
                baglan.Open();
                OleDbCommand komut = new OleDbCommand("Select *From veri where mp3 like'" + listBox1.SelectedItem.ToString()+".mp3" + "%'", baglan);
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    saniye = 0;
                    axWindowsMediaPlayer1.URL = oku["dizin"].ToString();
                    label2.Text = listBox1.SelectedItem.ToString();
                    mp3ismi = label2.Text+".mp3";
                    button1.Text = "ıı";
                    
                }
                baglan.Close();
            }
            catch (Exception hata)
            {
                //MessageBox.Show(hata.Message.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglan.Close();
            } 
        }
        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog mp3sec = new OpenFileDialog();
            mp3sec.Title = "Dosya Seç";
            mp3sec.Filter = "Müzik Dosyaları|*.mp3|Wav Dosyaları|*.wav|Flac Dosyaları|*.flac";
            mp3sec.Multiselect = false;
            if (mp3sec.ShowDialog() == DialogResult.OK)
            {           
                    listBox1.Items.Add(mp3sec);
                    baglan.Open();
                    OleDbCommand komut = new OleDbCommand("Insert Into veri(mp3,dizin,tarih) values(@mp3,@dizin,@tarih)", baglan);
                    komut.Parameters.AddWithValue("@mp3", mp3sec.SafeFileName);
                    komut.Parameters.AddWithValue("@dizin", mp3sec.FileName);
                    komut.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    mp3listele();
                    
                }

            
        }
        private void çalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mp3oynat();
        }

        private void kaldırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
                OleDbCommand komut = new OleDbCommand("delete from veri where mp3=@sil", baglan);
                komut.Parameters.AddWithValue("@sil", listBox1.SelectedItem.ToString() + ".mp3");
                komut.ExecuteNonQuery();
                baglan.Close();
                axWindowsMediaPlayer1.URL = "";
                mp3listele();
                label2.Text = "";
                if(listBox1.Items.Count>0)
                listBox1.SelectedIndex=0;
                
            }
            catch { mp3listele(); }
        }

        private void sİlToolStripMenuItem_Click(object sender, EventArgs e)
        {/*
             try
            {
                baglan.Open();
                OleDbCommand komut = new OleDbCommand("Select *From veri where mp3 like'" + listBox1.SelectedItem.ToString()+".mp3" + "%'", baglan);
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    saniye = 0;
                    System.IO.File.Delete(oku["dizin"].ToString());
                    OleDbCommand komut2 = new OleDbCommand("delete from veri where mp3'" + listBox1.SelectedItem.ToString() +""+ "'", baglan);
                    komut2.ExecuteNonQuery();
                    mp3listele();
                    MessageBox.Show("Dosya Silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                baglan.Close();
            }
            catch (Exception hata)
            {
                //MessageBox.Show(hata.Message.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglan.Close();
            } */
         
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            sira = listBox1.SelectedIndex;
            mp3oynat();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume = trackBar1.Value;
            label1.Text = trackBar1.Value.ToString()+"%";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.MediumSeaGreen;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = ayarlar.Default.button;
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            button2.BackColor = Color.MediumSeaGreen;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = ayarlar.Default.button;
        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            button3.BackColor = Color.MediumSeaGreen;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = ayarlar.Default.button;
        }

        private void button4_MouseMove(object sender, MouseEventArgs e)
        {
            button4.BackColor = Color.MediumSeaGreen;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = ayarlar.Default.button;
        }

        private void button5_MouseMove(object sender, MouseEventArgs e)
        {
            button5.BackColor = Color.MediumSeaGreen;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = ayarlar.Default.button;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (button1.Text == "ıı")
                {
                    if (label3.ForeColor == Color.Black)
                    {
                        label3.ForeColor = Color.Red;
                    }
                    else
                    {
                        label3.ForeColor = Color.Black;
                    }
                    saniye++;
                    trackBar2.Maximum = Convert.ToInt32(axWindowsMediaPlayer1.currentMedia.duration);
                    trackBar2.Value = saniye;
                   // this.Text = axWindowsMediaPlayer1.currentMedia.duration.ToString();
                    
                }
                if (axWindowsMediaPlayer1.URL == "")
                {
                    trackBar2.Value = 0;
                }
                
            }
            catch { }
           
            Random rd = new Random();
            if (diskmod == true)
            {
                this.BackColor = Color.FromArgb(((int)(((byte)(rd.Next(0, 255))))), ((int)(((byte)(rd.Next(0, 255))))), ((int)(((byte)(rd.Next(0, 255))))));
                trackBar1.BackColor = this.BackColor;
                trackBar2.BackColor = this.BackColor;
                trackBar3.BackColor = this.BackColor;
                trackBar4.BackColor = this.BackColor;
                panel1.BackColor = this.BackColor;
                // label2.ForeColor = Color.FromArgb(((int)(((byte)(rd.Next(0, 255))))), ((int)(((byte)(rd.Next(0, 255))))), ((int)(((byte)(rd.Next(0, 255))))));
                listBox1.BackColor = Color.FromArgb(((int)(((byte)(rd.Next(0, 255))))), ((int)(((byte)(rd.Next(0, 255))))), ((int)(((byte)(rd.Next(0, 255))))));
                //  listBox1.ForeColor = Color.FromArgb(((int)(((byte)(rd.Next(0, 255))))), ((int)(((byte)(rd.Next(0, 255))))), ((int)(((byte)(rd.Next(0, 255))))));
                button1.BackColor = listBox1.BackColor;
                button2.BackColor = listBox1.BackColor;
                button3.BackColor = listBox1.BackColor;
                button4.BackColor = listBox1.BackColor;
                button5.BackColor = listBox1.BackColor;
                button6.BackColor = listBox1.BackColor;
                button7.BackColor = listBox1.BackColor;
                button8.BackColor = listBox1.BackColor;
                label2.ForeColor = listBox1.BackColor;
                menuStrip1.BackColor = listBox1.BackColor;
                label3.BackColor = listBox1.BackColor;
                dosyaToolStripMenuItem.BackColor = listBox1.BackColor;
                açToolStripMenuItem.BackColor = listBox1.BackColor;
                çıkışToolStripMenuItem.BackColor = listBox1.BackColor;
                //yenidenBaşlarToolStripMenuItem.BackColor = listBox1.BackColor;
                ayarlarToolStripMenuItem.BackColor = listBox1.BackColor;
                equalizerToolStripMenuItem.BackColor = listBox1.BackColor;
                equalizerToolStripMenuItem1.BackColor = listBox1.BackColor;
                arayüzAyarlarıToolStripMenuItem.BackColor = listBox1.BackColor;
                çokluEkleToolStripMenuItem.BackColor = listBox1.BackColor;
                oynatıcıAyarlarıToolStripMenuItem.BackColor = listBox1.BackColor;
                mp3İndiriciToolStripMenuItem.BackColor = listBox1.BackColor;
                diskoModuToolStripMenuItem.BackColor = listBox1.BackColor;
                listBox1.ForeColor = Color.White;
                
            }
            
                label2.ForeColor=Color.FromArgb(((int)(((byte)(rd.Next(0, 255))))), ((int)(((byte)(rd.Next(0, 255))))), ((int)(((byte)(rd.Next(0, 255))))));
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            button1.Focus();
            if (button1.Text == "ıı" && axWindowsMediaPlayer1.URL != "")
            {
                axWindowsMediaPlayer1.Ctlcontrols.pause();
                button1.Text = "▷";
                label3.ForeColor = Color.Black;
            }
            else if (button1.Text == "▷" && axWindowsMediaPlayer1.URL == "")
            {
            }
            else
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
                button1.Text = "ıı";
            } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
                try
                {
                    baglan.Open();
                    OleDbCommand komut = new OleDbCommand("Select *From veri where mp3 like'" + listBox1.Items[sira + 1].ToString() + ".mp3" + "%'", baglan);
                    OleDbDataReader oku = komut.ExecuteReader();
                    while (oku.Read())
                    {
                        saniye = 0;
                        axWindowsMediaPlayer1.URL = oku["dizin"].ToString();
                        label2.Text = listBox1.Items[sira + 1].ToString();
                        mp3ismi = label2.Text+".mp3";
                        listBox1.SelectedIndex = sira + 1;
                        button1.Text = "ıı";
                        sira++;
                    }
                    baglan.Close();
                }
                catch (Exception hata)
                {
                   // MessageBox.Show(hata.Message.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    baglan.Close();
                } 
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
                OleDbCommand komut = new OleDbCommand("Select *From veri where mp3 like'" + listBox1.Items[sira - 1].ToString() + ".mp3" + "%'", baglan);
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    saniye = 0;
                    axWindowsMediaPlayer1.URL = oku["dizin"].ToString();
                    label2.Text = listBox1.Items[sira -1].ToString();
                    mp3ismi = label2.Text+".mp3";
                    listBox1.SelectedIndex = sira -1;
                    sira--;
                }
                baglan.Close();
            }
            catch (Exception hata)
            {
                // MessageBox.Show(hata.Message.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglan.Close();
            } 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (tekrar == false)
            {
                tekrar = true;
                button4.ForeColor = ayarlar.Default.backcolor;
                karıstır = false;
                button5.ForeColor = Color.Black;
            }
            else
            {
                tekrar = false;
                button4.ForeColor = Color.Black;
            }
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            açToolStripMenuItem.PerformClick();
        }
        
        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            
            if (trackBar2.Value == trackBar2.Maximum && karıstır==true)
            {
                Random karıs = new Random();
                int salla = karıs.Next(0, listBox1.Items.Count);
                try
                {
                  
                    baglan.Open();
                    OleDbCommand komut = new OleDbCommand("Select *From veri where mp3 like'" + listBox1.Items[salla].ToString() + ".mp3" + "%'", baglan);
                    OleDbDataReader oku = komut.ExecuteReader();
                    while (oku.Read())
                    {
                        saniye = 0;
                        axWindowsMediaPlayer1.URL = oku["dizin"].ToString();
                        label2.Text = listBox1.Items[salla].ToString();
                        listBox1.SelectedIndex = salla;
                        mp3ismi = label2.Text+".mp3";
                        button1.Text = "ıı";
                    }
                    baglan.Close();
                }
                catch (Exception hata)
                {
                    //MessageBox.Show(hata.Message.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    baglan.Close();
                } 
            }
             if (trackBar2.Value == trackBar2.Maximum && tekrar == true)
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop();
                axWindowsMediaPlayer1.Ctlcontrols.play();
                saniye = 0;

            }
            if (trackBar2.Value == trackBar2.Maximum && tekrar == false && karıstır == false)
            {
                trackBar2.Value = 0;
                button1.Text = "▷";
                button2.PerformClick();
            }
            int kalan;
            int tam;
            int saat;
            saat = saniye / 60 / 60;
                 tam = saniye / 60;
                 kalan = saniye % 60;
                 if (tam.ToString().Length < 2 && kalan.ToString().Length > 1)
                 {
                     label4.Text = "0"+tam.ToString() + ":" + kalan.ToString() + " / " + axWindowsMediaPlayer1.currentMedia.durationString;
                 }
                 else if (tam.ToString().Length > 1 && kalan.ToString().Length > 1)
                 {
                     label4.Text =  tam.ToString() + ":" + kalan.ToString() + " / " + axWindowsMediaPlayer1.currentMedia.durationString;
                 }
                 else if (tam.ToString().Length < 2 && kalan.ToString().Length<2)
                 {
                     label4.Text = "0" + tam.ToString() + ":0" + kalan.ToString() + " / " + axWindowsMediaPlayer1.currentMedia.durationString;
                 }
                 else if (tam.ToString().Length < 1 && kalan.ToString().Length > 1)
                 {
                     label4.Text =  "00"+tam.ToString() + ":" + kalan.ToString() + " / " + axWindowsMediaPlayer1.currentMedia.durationString;
                 }
                 else if (tam.ToString().Length<1 && kalan.ToString().Length < 2)
                 {
                     label4.Text = tam.ToString() + ":0" + kalan.ToString() + " / " + axWindowsMediaPlayer1.currentMedia.durationString;
                 }
                /* else if (saat.ToString().Length > 0 && kalan.ToString().Length < 2)
                 {
                     label4.Text = saat.ToString() + ":" + label4.Text;
                 }*/
        }

        private void toolStripSeparator1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (karıstır == false)
            {
                karıstır = true;
                button5.ForeColor = ayarlar.Default.backcolor;
                tekrar = false;
                button4.ForeColor = Color.Black;
            }
            else
            {
                karıstır = false;
                button5.ForeColor = Color.Black;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (label2.Text != "")
            {
                if (label2.Left <= 290) label2.Left++;
                if (label2.Left == 290)
                {
                    timer2.Enabled = false;
                    timer3.Enabled = true;
                  
                }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (label2.Text != "")
            {
                
                if (label2.Right >= -2) label2.Left--;
                if (label2.Right == -2)
                {
                    timer3.Enabled = false;
                    timer2.Enabled = true;
                }
            }
        }

        private void ayarlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void yenidenBaşlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void equalizerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void equalizerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == false) panel1.Visible = true;
            else panel1.Visible = false;
        }

        private void mp3İndiriciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Youtube_Mp3_İndirici indir = new Youtube_Mp3_İndirici();
            indir.Show();
        }

        private void tümünüKaldırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= listBox1.Items.Count- 1; i++)
            {
                label2.Text = "";
                try
                {
                    baglan.Open();
                    OleDbCommand komut = new OleDbCommand("delete from veri where mp3=@sil", baglan);
                    komut.Parameters.AddWithValue("@sil", listBox1.Items[i].ToString() + ".mp3");
                    komut.ExecuteNonQuery();
                    baglan.Close();
                }
                catch { mp3listele(); }
            }
            mp3listele();
        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.rate = trackBar3.Value;
            label6.Text =  trackBar3.Value.ToString();
            timer1.Interval = 1000 / trackBar3.Value;
            
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void trackBar4_ValueChanged(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.balance = trackBar4.Value;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            trackBar4.Value = 50;
            axWindowsMediaPlayer1.settings.balance = 50;
        
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.currentPosition = trackBar2.Value;
            saniye = trackBar2.Value;
        }

        private void trackBar2_MouseCaptureChanged(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.settings.mute == false)
            {
                trackBar1.Enabled = false;
                axWindowsMediaPlayer1.settings.mute=true;
                button7.BackColor = Color.Transparent;
            }
            else
            {
                
                trackBar1.Enabled = true;
                axWindowsMediaPlayer1.settings.mute = false;
                
                button7.BackColor = ayarlar.Default.button;
            }
            }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hakkında info = new Hakkında();
            info.Show();
        }

        private void button7_MouseMove(object sender, MouseEventArgs e)
        {
            
            button7.BackColor = Color.MediumSeaGreen;
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            if (trackBar1.Enabled == false)
            {
                button7.BackColor = Color.Gray;
            }
            else
            {
                button7.BackColor = ayarlar.Default.button;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            button8.BackColor = ayarlar.Default.button;
        }

        private void button8_MouseMove(object sender, MouseEventArgs e)
        {
           
            button8.BackColor = Color.MediumSeaGreen;
        }

        private void diskoModuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (diskmod == false)
            {
                diskoModuToolStripMenuItem.ForeColor = Color.White;
                diskmod = true;
            }
            else
            {
                diskmod = false;
                diskoModuToolStripMenuItem.ForeColor = Color.Black;
                this.BackColor = ayarlar.Default.backcolor;
                listBox1.BackColor = ayarlar.Default.button;
                button1.BackColor = ayarlar.Default.button;
                button8.BackColor = ayarlar.Default.button;
                button7.BackColor = ayarlar.Default.button;
                button2.BackColor = ayarlar.Default.button;
                button3.BackColor = ayarlar.Default.button;
                button4.BackColor = ayarlar.Default.button;
                button5.BackColor = ayarlar.Default.button;
                equalizerToolStripMenuItem.BackColor = ayarlar.Default.button;
                equalizerToolStripMenuItem1.BackColor = ayarlar.Default.button;
                mp3İndiriciToolStripMenuItem.BackColor = ayarlar.Default.button;
                arayüzAyarlarıToolStripMenuItem.BackColor = ayarlar.Default.button;
                çokluEkleToolStripMenuItem.BackColor = ayarlar.Default.button;
                oynatıcıAyarlarıToolStripMenuItem.BackColor = ayarlar.Default.button;
                panel1.BackColor = ayarlar.Default.backcolor;
                //yenidenBaşlarToolStripMenuItem.BackColor = ayarlar.Default.button;
                label3.BackColor = ayarlar.Default.button;
                diskoModuToolStripMenuItem.BackColor = ayarlar.Default.button;
                ayarlarToolStripMenuItem.BackColor = ayarlar.Default.button;
                contextMenuStrip1.BackColor = ayarlar.Default.button;
                dosyaToolStripMenuItem.BackColor = ayarlar.Default.button;
                menuStrip1.BackColor = ayarlar.Default.button;
                açToolStripMenuItem.BackColor = ayarlar.Default.button;
                çıkışToolStripMenuItem.BackColor = ayarlar.Default.button;
                trackBar1.BackColor = ayarlar.Default.backcolor;
                trackBar2.BackColor = ayarlar.Default.backcolor;
                trackBar3.BackColor = ayarlar.Default.backcolor;
                trackBar4.BackColor = ayarlar.Default.backcolor;
            }
            }

        private void arayüzAyarlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ayarlar ayar = new Ayarlar();
            ayar.ShowDialog();
        }

        private void oynatıcıAyarlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.ShowPropertyPages();
        }

        private void çokluEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog mp3sec = new OpenFileDialog();
            mp3sec.Title = "Dosya Seç";
            mp3sec.Filter = "Müzik Dosyaları|*.mp3|Wav Dosyaları|*.wav|Flac Dosyaları|*.flac";
            mp3sec.Multiselect = true;
            if (mp3sec.ShowDialog() == DialogResult.OK)
            {
                int dosyasira = 0;
                foreach (String mp3 in mp3sec.SafeFileNames)
                {
                    listBox1.Items.Add(mp3);
                    mp3ismi = mp3;
                    baglan.Open();
                    OleDbCommand komut = new OleDbCommand("Insert Into veri(mp3,dizin,tarih) values(@mp3,@dizin,@tarih)", baglan);
                    komut.Parameters.AddWithValue("@mp3", mp3ismi);
                    komut.Parameters.AddWithValue("@dizin", mp3sec.FileNames[dosyasira]);
                    komut.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    mp3listele();
                    dosyasira++;
                }

            }
        }

        private void çokluEkleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            çokluEkleToolStripMenuItem.PerformClick();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (listBox1.SelectedIndex<0)
            {
                kaldırToolStripMenuItem.Enabled = false;
                çalToolStripMenuItem.Enabled = false;
            }
            else
            {
                kaldırToolStripMenuItem.Enabled = true;
                çalToolStripMenuItem.Enabled = true;
            }
            if (listBox1.Items.Count > 1)
                tümünüKaldırToolStripMenuItem.Enabled = true;
            else 
                tümünüKaldırToolStripMenuItem.Enabled = false;
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mp3listele();
        }

   
    }
}
