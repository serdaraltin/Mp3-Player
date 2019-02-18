using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace Mp3_Player
{
    public partial class Ayarlar : Form
    {
        public Ayarlar()
        {
            InitializeComponent();
        }
        Color backcolor;
        Color button;
        Font font;
        Color listbox;
        Font kyazi;
        private void Ayarlar_Load(object sender, EventArgs e)
        {
            this.BackColor = ayarlar.Default.backcolor;
            numericUpDown1.Value = ayarlar.Default.timer;
            textBox1.Text = ayarlar.Default.text;
            pictureBox1.BackColor = ayarlar.Default.backcolor;
            pictureBox2.BackColor = ayarlar.Default.button;
            pictureBox3.BackColor = ayarlar.Default.listbox;
            font = ayarlar.Default.font;
            backcolor = ayarlar.Default.backcolor;
            button = ayarlar.Default.button;
            listbox = ayarlar.Default.listbox;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
          /*  OpenFileDialog resim = new OpenFileDialog();
            resim.Filter = "Jpeg Dosyaları|*.jpg|Png Dosyaları|*.png|Bmp Dosyaları|*.bmp";
            resim.Title = "Dosya Seç";
            if (resim.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists("data\\background.jpg") == true)
                {
                    Form1 ana = new Form1();
                    ana.BackgroundImage = Image.FromFile("");
                    File.Delete("data\\background.jpg");

                }
                File.Copy(resim.FileName, "data\\background.jpg");
            }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog renk = new ColorDialog();
            if (renk.ShowDialog() == DialogResult.OK) 
            {
                backcolor = renk.Color;
                pictureBox1.BackColor = renk.Color;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ayarlar.Default.kayanyazi = kyazi; 
            ayarlar.Default.backcolor = backcolor;
            ayarlar.Default.button = button;
            ayarlar.Default.listbox = listbox;
            ayarlar.Default.timer =Convert.ToInt32(numericUpDown1.Value);
            ayarlar.Default.font = font;
            ayarlar.Default.text = textBox1.Text;
            ayarlar.Default.Save();
            manin main = Application.OpenForms["manin"] as manin;
            main.listBox1.Font = ayarlar.Default.font;
            main.timer2.Interval = ayarlar.Default.timer;
            main.timer3.Interval = ayarlar.Default.timer;
            main.listBox1.ForeColor = ayarlar.Default.listbox;
            main.axWindowsMediaPlayer1.Location = new Point(5, 20);
            //  axWindowsMediaPlayer1.Size = new Size(this.Height, (this.Width/2)-37);
             main.Font = ayarlar.Default.font;
             main.Text = ayarlar.Default.text;
             main.BackColor = ayarlar.Default.backcolor;
            main.diskoModuToolStripMenuItem.BackColor = ayarlar.Default.button;
            main.listBox1.BackColor = ayarlar.Default.button;
            main.button1.BackColor = ayarlar.Default.button;
            main.button8.BackColor = ayarlar.Default.button;
            main.button7.BackColor = ayarlar.Default.button;
            main.button2.BackColor = ayarlar.Default.button;
            main.button3.BackColor = ayarlar.Default.button;
            main.button4.BackColor = ayarlar.Default.button;
            main.button5.BackColor = ayarlar.Default.button;
            main.equalizerToolStripMenuItem.BackColor = ayarlar.Default.button;
            main.equalizerToolStripMenuItem1.BackColor = ayarlar.Default.button;
            main.mp3İndiriciToolStripMenuItem.BackColor = ayarlar.Default.button;
            main.arayüzAyarlarıToolStripMenuItem.BackColor = ayarlar.Default.button;
            main.çokluEkleToolStripMenuItem.BackColor = ayarlar.Default.button;
            main.oynatıcıAyarlarıToolStripMenuItem.BackColor = ayarlar.Default.button;
            main.panel1.BackColor = ayarlar.Default.backcolor;
            //yenidenBaşlarToolStripMenuItem.BackColor = ayarlar.Default.button;
            main.label3.BackColor = ayarlar.Default.button;

            main.contextMenuStrip1.BackColor = ayarlar.Default.button;
            main.dosyaToolStripMenuItem.BackColor = ayarlar.Default.button;
            main.menuStrip1.BackColor = ayarlar.Default.button;
            main.açToolStripMenuItem.BackColor = ayarlar.Default.button;
            main.çıkışToolStripMenuItem.BackColor = ayarlar.Default.button;
            main.trackBar1.BackColor = ayarlar.Default.backcolor;
            main.trackBar2.BackColor = ayarlar.Default.backcolor;
            main.trackBar3.BackColor = ayarlar.Default.backcolor;
            main.trackBar4.BackColor = ayarlar.Default.backcolor;
            MessageBox.Show("Ayarlar kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ayarlar.Default.kayanyazi = new Font("Lucida Sans Unicode", 11, FontStyle.Bold);
            ayarlar.Default.backcolor = Color.Indigo;
            ayarlar.Default.button = Color.MediumPurple;
            ayarlar.Default.timer = 60;
            ayarlar.Default.listbox = Color.DarkBlue;
            ayarlar.Default.font = new Font("Segoe UI",10, FontStyle.Regular);
            ayarlar.Default.text = "Eko Player";
            ayarlar.Default.Save();
            manin main = Application.OpenForms["manin"] as manin;
            main.listBox1.Font = ayarlar.Default.font;
            main.timer2.Interval = ayarlar.Default.timer;
            main.timer3.Interval = ayarlar.Default.timer;
            main.listBox1.ForeColor = ayarlar.Default.listbox;
            main.axWindowsMediaPlayer1.Location = new Point(5, 20);
            //  axWindowsMediaPlayer1.Size = new Size(this.Height, (this.Width/2)-37);
            main.Font = ayarlar.Default.font;
            main.Text = ayarlar.Default.text;
            main.BackColor = ayarlar.Default.backcolor;
            main.diskoModuToolStripMenuItem.BackColor = ayarlar.Default.button;
            main.listBox1.BackColor = ayarlar.Default.button;
            main.button1.BackColor = ayarlar.Default.button;
            main.button8.BackColor = ayarlar.Default.button;
            main.button7.BackColor = ayarlar.Default.button;
            main.button2.BackColor = ayarlar.Default.button;
            main.button3.BackColor = ayarlar.Default.button;
            main.button4.BackColor = ayarlar.Default.button;
            main.button5.BackColor = ayarlar.Default.button;
            main.equalizerToolStripMenuItem.BackColor = ayarlar.Default.button;
            main.equalizerToolStripMenuItem1.BackColor = ayarlar.Default.button;
            main.mp3İndiriciToolStripMenuItem.BackColor = ayarlar.Default.button;
            main.arayüzAyarlarıToolStripMenuItem.BackColor = ayarlar.Default.button;
            main.çokluEkleToolStripMenuItem.BackColor = ayarlar.Default.button;
            main.oynatıcıAyarlarıToolStripMenuItem.BackColor = ayarlar.Default.button;
            main.panel1.BackColor = ayarlar.Default.backcolor;
            //yenidenBaşlarToolStripMenuItem.BackColor = ayarlar.Default.button;
            main.label3.BackColor = ayarlar.Default.button;
            main.contextMenuStrip1.BackColor = ayarlar.Default.button;
            main.dosyaToolStripMenuItem.BackColor = ayarlar.Default.button;
            main.menuStrip1.BackColor = ayarlar.Default.button;
            main.açToolStripMenuItem.BackColor = ayarlar.Default.button;
            main.çıkışToolStripMenuItem.BackColor = ayarlar.Default.button;
            main.trackBar1.BackColor = ayarlar.Default.backcolor;
            main.trackBar2.BackColor = ayarlar.Default.backcolor;
            main.trackBar3.BackColor = ayarlar.Default.backcolor;
            main.trackBar4.BackColor = ayarlar.Default.backcolor;
            MessageBox.Show("Ayarlar Sıfırlandı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ColorDialog renk = new ColorDialog();
            if (renk.ShowDialog() == DialogResult.OK) 
            {
                button = renk.Color;
                pictureBox2.BackColor = renk.Color;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FontDialog sec = new FontDialog();
            sec.MaxSize = 10;
            sec.MinSize = 8;
            if (sec.ShowDialog() == DialogResult.OK)
            {
                font = sec.Font;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ColorDialog renk = new ColorDialog();
            if (renk.ShowDialog() == DialogResult.OK)
            {
                listbox = renk.Color;
                pictureBox3.BackColor = renk.Color;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FontDialog sec = new FontDialog();
            sec.MaxSize = 13;
            sec.MinSize = 9;
            if (sec.ShowDialog() == DialogResult.OK)
            {
                kyazi = sec.Font;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            manin ana = new manin();
            ana.axWindowsMediaPlayer1.ShowPropertyPages();
        }
    }
}
