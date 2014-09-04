using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class IntroForm : Form
    {
        public IntroForm()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            // Empty
        }

        private void ProgressIncrementButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("ProgressIncrementButton clicked.");
        }

        private void LoadFileButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("LoadFileButton clicked.");
            DialogResult result = openFileDialog1.ShowDialog();
            if(result == System.Windows.Forms.DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                string fileText = System.IO.File.ReadAllText(fileName);
                Console.WriteLine("File size: {0}", fileText.Length);
                Console.WriteLine("File contents: {0}", fileText);
                richTextBox1.Text = fileText;
            }
        }

        private void SaveToDBButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("SaveToDBButton clicked.");
            DBBinder dbBinder = new DBBinder();
            dbBinder.UploadFileContents(richTextBox1.Text);
        }

        private void LoadFromDBButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("LoadFromDBButton clicked.");
            DBBinder dbBinder = new DBBinder();
            richTextBox1.Text = dbBinder.GetLatestFileContents();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = String.Empty;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
