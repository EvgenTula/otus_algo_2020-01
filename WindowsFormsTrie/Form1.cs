using System;
using System.IO;
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

            string[] data = File.ReadAllLines(@"D:\dev\otus_algo_2020-01\WindowsFormsTrie\data\russian_nouns.txt");
            for (int i = 0; i < data.Length; i++)
            {
                trie.Add(data[i]);
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            richTextBox1.Clear();
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                richTextBox1.Text = trie.Search(textBox1.Text);
            }
        }
    }
}
