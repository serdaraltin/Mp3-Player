using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Mp3_Player
{
    public partial class Youtube_Mp3_İndirici : Form
    {
        public Youtube_Mp3_İndirici()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://2conv.com/tr/");
            try
            {
                textBox1.ReadOnly = true;
                button1.Enabled = false;
                webBrowser1.Document.GetElementById("convertUrl").InnerText = textBox1.Text;
                pictureBox1.Visible = true;
                label2.Text = "Dönüştürülüyor...";
                foreach (HtmlElement item in webBrowser1.Document.All)
                {
                    if (item.GetAttribute("classname") == "button large convert orange")
                    {
                        item.InvokeMember("click");
                    }

                }

            }
            catch
            {
                button1.Enabled = true;
                textBox1.ReadOnly = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
         
        }

        private void Youtube_Mp3_İndirici_Load(object sender, EventArgs e)
        {
            this.BackColor = ayarlar.Default.backcolor;
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser1.Navigate("http://2conv.com/tr/");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void webBrowser1_NewWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (textBox1.Text != "")
            {
                foreach (HtmlElement item in webBrowser1.Document.All)
                {
                    if (item.GetAttribute("classname") == "button large orange track download")
                    {
                        timer1.Stop();
                        button1.Enabled = true;
                        textBox1.ReadOnly = false;
                        item.InvokeMember("click");
                        pictureBox1.Visible = false;
                        label2.Text = "...";
                        textBox1.Clear();

                    }

                }
            }
        }
    }
}
