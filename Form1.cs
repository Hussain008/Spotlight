using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spotlight
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // to set the background transparent 
            this.BackColor = Color.Blue;
            this.TransparencyKey = Color.Blue;



            //giving the style and initial size of the drop down
            comboBox1.DropDownStyle = ComboBoxStyle.Simple;
            comboBox1.Size = new Size(720, 100);

            //Initial text in the search
            comboBox1.Text = "Search";
            
            
        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {

            String tmp = comboBox1.Text;
            this.comboBox1.Items.Clear();
            comboBox1.SelectionStart = 0;
            comboBox1.SelectionLength = 0;
            for(int i=0;i<6;i++)
            comboBox1.Items.Add("HEllo");
            comboBox1.Select(tmp.Length, 0);
            comboBox1.Size = new Size(720, 300);




        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
