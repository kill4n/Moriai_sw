using MoriaiLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moriai_Test
{
    public partial class Form1 : Form
    {
        MoriaiClass mc1 = new MoriaiClass(MessageFormat.Format8bit);
        MoriaiClass mc2 = new MoriaiClass(MessageFormat.Format16bit);
        MoriaiClass mc3 = new MoriaiClass(MessageFormat.Format32bit);
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int data = -1;
            bool t = int.TryParse(textBox1.Text, out data);
            textBox2.Text = BitConverter.ToString(mc1.SendOne(data));
            textBox3.Text = BitConverter.ToString(mc2.SendOne(data));
            textBox4.Text = BitConverter.ToString(mc3.SendOne(data));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[] data = { 1, 255, 32450, 2147483647 };
            textBox5.Text = BitConverter.ToString(mc1.SendMany(data));
            textBox6.Text = BitConverter.ToString(mc2.SendMany(data));
            textBox7.Text = BitConverter.ToString(mc3.SendMany(data));

        }
    }
}
