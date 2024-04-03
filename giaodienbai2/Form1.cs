using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace giaodienbai2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonlogin_Click(object sender, EventArgs e)
        {
            string Username = textBox2.Text;
            string Password = textBox1.Text;
            string correctUsername = "LEMINHTIEN";
            string correctPassword = "21138185";
            if (Username == correctUsername && Password == correctPassword)
            {
                MessageBox.Show("Logged in successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Form2 f2 = new Form2();
                f2.ShowDialog();
            }
            else
            { MessageBox.Show("Wrong password or username", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void buttonclear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void buttonexit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to exit?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.UseSystemPasswordChar = true;
        }
    }
}
