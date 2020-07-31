using System;
using System.IO;
using System.Threading.Tasks;
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

            if (!String.IsNullOrEmpty(txtStr.Text))
            {
                ShowResults();
            }
            else
            {
                txtBoxSelection.Clear();
            }
        }

        async void ShowResults()
        {
            await Task.Run(() =>
            {
                string result = trie.Search(txtStr.Text).ToString(); 
                txtBoxSelection.Invoke(new Action(() => txtBoxSelection.Text = result));
            });
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
