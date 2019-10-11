using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualFredkin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Engine.Init(pictureBox2);
        }


        private void button1_Click(object sender, EventArgs e) //NextStep
        {
            Engine.Step();
        }

        private void button2_Click(object sender, EventArgs e) //InfiniteSteps
        {
            for (int i = 0; i < 100; i++)
            {
                Engine.Step();
                Update();
            }
        }
    }
}