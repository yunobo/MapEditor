using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MapEditor
{
    public delegate void PathPassDelegate(string path);
    public partial class NewProjectForm : Form
    {
        private string temp, folderPath;
        PathPassDelegate onCreate;
        public NewProjectForm(PathPassDelegate func)
        {
            InitializeComponent();
            onCreate = func;
        }

        private void NewProjectForm_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Select New Project Folder.";
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    try
                    {
                        folderPath = fbd.SelectedPath;
                        temp = fbd.SelectedPath + "\\" + textBox2.Text;
                        textBox1.Text = temp;
                    }
                    catch(IOException)
                    {

                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            temp = folderPath + "\\" + textBox2.Text;
            if(textBox2.Text == "")
            {
                MessageBox.Show("Enter Project Name.");
                return;
            }
            onCreate(temp);
            Directory.CreateDirectory(temp);
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            temp = folderPath + "\\" + textBox2.Text;
            textBox1.Text = temp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
