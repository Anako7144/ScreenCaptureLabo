using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CapMaster
{
    public partial class PicForm : Form
    {
        public PicForm()
        {
            InitializeComponent();
        }

        public void SetPicture(string path)
        {
            using (FileStream fs = File.OpenRead(path))
            {
                pictureBox1.Image = Image.FromStream(fs);
                Clipboard.SetImage(pictureBox1.Image);
            }
        }
        public void ClearPicture()
        {
            pictureBox1.Image.Dispose();
            pictureBox1.Image = null;
        }
        private void PicForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
