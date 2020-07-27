using System;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsTrie
{
    public partial class frmSuggest : Form
    {
        private Trie trie;
        public frmSuggest()
        {
            InitializeComponent();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (trie == null)
                return;
            txtBoxSelection.Clear();
            if (!String.IsNullOrEmpty(txtStr.Text))
            {
                txtBoxSelection.Text = trie.Search(txtStr.Text);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            trie = new Trie();

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] data = File.ReadAllLines(fileDialog.FileName);
                for (int i = 0; i < data.Length; i++)
                {
                    trie.Add(data[i]);
                }
                txtCount.Text = data.Length.ToString();
            }
        }
    }
}
