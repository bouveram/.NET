using FormationEF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormationWindows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BookRepository repo = new BookRepository { Entities = new FormationEntities() };
            label3.Text = repo.GetById((int)numericUpDown1.Value).Title;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
