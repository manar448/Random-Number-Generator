using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task
{
    public partial class Form1 : Form
    {
        LCG LCG = new LCG();
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            LCG.Multiplier = Convert.ToInt32(textBox1.Text);
            LCG.seed = Convert.ToInt32(textBox2.Text);
            LCG.Increment = Convert.ToInt32(textBox3.Text); 
            LCG.Modulus= Convert.ToInt32(textBox4.Text);
            LCG.Number_of_Iterations = Convert.ToInt32(textBox5.Text);


            LCG.systemoutput();
            for(int i=0;i< LCG.generated.Count;i++)
            {

                this.dataGridView1.Rows.Add(i+1,LCG.generated[i].ToString());

            }
            LCG.CalculateCycleLength();
            textBox6.Text= LCG.Cycle_length.ToString();





        }
    }
}
