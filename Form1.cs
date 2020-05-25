﻿using System;
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
using System.Collections;





/*
     TO DO LIST =>  make the python file run in the background every 30 mins and map getting updated.
*/




namespace Spotlight
{
    public partial class Form1 : Form
    {
        Trie trie;
        List<FileObj> list;
        public Form1()
        {
            BuildTrie();
            InitializeComponent();

            // to set the background transparent 
            this.BackColor = Color.Blue;
            this.TransparencyKey = Color.Blue;



            //giving the style and initial size of the drop down
            searchBox.DropDownStyle = ComboBoxStyle.Simple;
            searchBox.Size = new Size(720, 100);

            //Initial text in the search    
            searchBox.Text = "Search";

            
            


            

        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {


            string query = searchBox.Text;

            this.searchBox.Items.Clear();


            //populating the drop down
            if (trie.map.ContainsKey(query) == true)
            {
                list = trie.map[query];

                for (int i = 0; i < 50 && i < list.Count; i++)
                    searchBox.Items.Add(list[i].name);
            }

            //This is for putting the cursor to the end of the previous typed string
            searchBox.Select(searchBox.Text.Length, 0);

            //setting the dropdown size
            searchBox.Size = new Size(720, 300);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }


        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
            
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == NativeMethods.WM_SHOWME)
            {
                this.Visible = true;
                ShowMe();
            }
            base.WndProc(ref m);
        }
        private void ShowMe()
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }
            
            // get our current "TopMost" value (ours will always be false though)
            bool top = TopMost;
            // make our form jump to the top of everything
            TopMost = true;
            // set it back to whatever it was
            TopMost = top;
        }




        void BuildTrie()
        {
             trie = new Trie(new TrieNode('H'));

            string[] lines = File.ReadAllLines(@"C:\\Users\\gunny\\source\\repos\\Spotlight\\allFilesCopy.txt", Encoding.UTF8);


            foreach (string line in lines)
            {
                char[] spearator = { '<' };
                char[] sep2 = { '\\' };
                char[] sep3 = { ' ' };

                String[] strlist = line.Split(spearator);
                String location = strlist[0];

                String[] tmp = location.Split(sep2);

                string name = tmp[tmp.Length - 1];

                FileObj newFile = new FileObj(name.ToLower(), location, Convert.ToInt32(strlist[1]));

                trie.Insert(trie.root, newFile, 0);

            }
            Debug.WriteLine("Trie built");
            trie.Update(trie.root);

            trie.Dfs(trie.root, "", 0);
            Debug.WriteLine("DFS done");

            Debug.WriteLine(trie.map.Count);


        }

        private void searchBox_KeyUp(object sender, KeyEventArgs e)
        {
            //escaping the application when ESC is pressed 
            if (e.KeyCode == Keys.Escape)
            {
                this.WindowState = FormWindowState.Minimized;

                this.Visible = false;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (searchBox.SelectedIndex == -1)
                    return;

                string selectedFile = list[searchBox.SelectedIndex].location;
                Process.Start(@selectedFile);
                this.WindowState = FormWindowState.Minimized;
                this.Visible = false;
            }
        }


        private void comboBoxDb_DrawItem(object sender, DrawItemEventArgs e)
        {
            //var combo = sender as ComboBox;

            //if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            //{
            //    e.Graphics.FillRectangle(new SolidBrush(Color.Pink), e.Bounds);
            //}
            //else
            //{
            //    e.Graphics.FillRectangle(new SolidBrush(Color.White), e.Bounds);
            //}

            //e.Graphics.DrawString(combo.Items[e.Index].ToString(),
            //                              e.Font,
            //                              new SolidBrush(Color.Green),
            //                              new Point(e.Bounds.X, e.Bounds.Y));
        }

        private void searchBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            var combo = sender as ComboBox;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(9, 4, 145)), e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Black), e.Bounds);
            }

            e.Graphics.DrawString(combo.Items[e.Index].ToString(),
                                          e.Font,
                                          new SolidBrush(Color.White),
                                          new Point(e.Bounds.X, e.Bounds.Y));
        }
    }

    

}
