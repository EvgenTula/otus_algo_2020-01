using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsTrie
{
    public partial class Form1 : Form
    {
        private Trie trie;
        public Form1()
        {
            InitializeComponent();

            trie = new Trie();

            string[] data = File.ReadAllLines(@"D:\dev\otus_algo_2020-01\Task18Trie\data\russian_nouns.txt");
            for (int i = 0; i < data.Length; i++)
            {
                trie.Add(data[i]);
            }
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            richTextBox1.Clear();
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                string result = String.Empty;
                //while ((result = trie.Search(textBox1.Text)) != "not fount")
                {
                    result = trie.Search(textBox1.Text);
                    richTextBox1.Text = result;
                }
            }
        }
    }
}
