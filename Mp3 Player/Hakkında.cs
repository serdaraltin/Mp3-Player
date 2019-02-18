using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mp3_Player
{
    public partial class Hakkında : Form
    {
        public Hakkında()
        {
            InitializeComponent();
        }

        private void Hakkında_Load(object sender, EventArgs e)
        {
            this.BackColor = ayarlar.Default.backcolor;
            label1.ForeColor = ayarlar.Default.button;
        }
    }
}
