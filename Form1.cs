using System;
using System.IO;
using System.Diagnostics;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




/*
     TO DO LIST => 
     REFER THIS GUY -> https://www.youtube.com/watch?v=xrYTjaK5QVM 
     DECIDE ON WHICH FOLDERS TO CRAWL -->done
     DECIDE ON WHETHER TO HAVE A SEPARATE PROGRAM TO CRAWL FOR US --> done
     LET THAT PROGRAM CREATE A TRIE , WHERE EACH PREFIX IN THE TRIE WILL CONTAIN TOP 5 SUGGESTIONS BASED ON SOME RANK
     THEN STORE THIS TRIE , MAYBE SERIALISE IT AND DESRIALISE IT INTO A PREFIX HASHTABLE , WHERE FOR EVERY PREFIX YOU HAVE A LIST OF SUGGESTIONS
     USE THIS PREFIX MAP FOR EVERY QUERY IN THE SEARCH TO GET TOP 5 SUGGESTIONS ! 
     USE THIS TO OPEN THE SELECTED FILE FINALLY https://stackoverflow.com/a/10174230
*/




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

            //foreach (string file in GetFiles("C:\\Users\\gunny\\Downloads"))
            //{
            //    Debug.WriteLine(file);
            //}

            //foreach (string file in GetFiles("C:\\Users\\gunny\\Documents"))
            //{
            //    Debug.WriteLine(file);
            //}




        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {



            this.comboBox1.Items.Clear();

            for (int i = 0; i < 6; i++)
                comboBox1.Items.Add("HEllo");

            //This is for putting the cursor to the end of the previous typed string
            comboBox1.Select(comboBox1.Text.Length, 0);

            //setting the dropdown size
            comboBox1.Size = new Size(720, 300);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //escaping the application when ESC is pressed 
            if (e.KeyCode == Keys.Escape)
                Application.Exit();
        }


        static IEnumerable<string> GetFiles(string path)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(path);
            while (queue.Count > 0)
            {
                path = queue.Dequeue();
                try
                {
                    foreach (string subDir in Directory.GetDirectories(path))
                    {
                        queue.Enqueue(subDir);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                string[] files = null;
                try
                {
                    files = Directory.GetFiles(path);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                if (files != null)
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        yield return files[i];
                    }
                }
            }

        }
    }

}
