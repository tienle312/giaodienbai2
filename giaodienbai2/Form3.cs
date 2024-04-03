using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace giaodienbai2
{
    public partial class Form3 : Form
    {
        private SerialPort serCOM = new SerialPort();
        public Form3()
        {
            InitializeComponent();
            string[] Baurate = { "1200", "2400", "4800", "9600", "15200" };
            comboBox2.Items.AddRange(Baurate);
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            comboBox2.Text = "9600";
            comboBox1.DataSource = SerialPort.GetPortNames();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }
        private void buttonlogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }
        private void serCOM_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string receivedData = serCOM.ReadLine();
                if (!string.IsNullOrEmpty(receivedData))
                {
                    string[] dataParts = receivedData.Split(':');
                    if (dataParts.Length == 2)
                    {
                        string variableName = dataParts[0].Trim();
                        string value = dataParts[1].Trim();
                        if (variableName == "DC")
                        {
                            if (value == "1")
                                label11.Invoke((MethodInvoker)delegate
                                {
                                    label10.Text = "ON";
                                    label10.ForeColor = Color.Green;
                                });
                            else if (value == "0")
                                label11.Invoke((MethodInvoker)delegate
                                {
                                    label11.Text = "OFF";
                                    label11.ForeColor = Color.Green;
                                });
                        }
                        else if (variableName == "Gtri")
                        {
                            textBox1.Invoke((MethodInvoker)delegate { textBox1.Text = value; });
                        }
                        else if (variableName == "Chieu")
                        {
                            if (value == "0")
                                label11.Invoke((MethodInvoker)delegate
                                {
                                    label11.Text = "FORWARD";
                                    label11.ForeColor = Color.Green;
                                });
                            else if (value == "1")
                                label11.Invoke((MethodInvoker)delegate
                                {
                                    label11.Text = "RESERVE";
                                    label11.ForeColor = Color.Green;
                                });
                        }

                        else if (variableName == "LED")
                        {
                            if (value == "1")
                            {
                                label9.Invoke((MethodInvoker)delegate
                                {
                                    label9.Text = "ACTIVATE";
                                    label9.ForeColor = Color.Green;
                                });
                            }
                            else if (value == "0")
                            {
                                label9.Invoke((MethodInvoker)delegate
                                {
                                    label9.Text = "NOT ACTIVATED";
                                    label9.ForeColor = Color.Red;
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error receiving data from COM port: " + ex.Message);
            }
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please attach COM port before connecting!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            serCOM.PortName = comboBox1.Text;
            serCOM.BaudRate = Convert.ToInt32(comboBox2.Text);
            serCOM.Open();
            {
                label5.Text = "CONNECTED";
                label5.ForeColor = Color.Green;
                button3.Enabled = false;
                button4.Enabled = true;
                button2.Enabled = false;
                buttonlogout.Enabled = false;
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            serCOM.Close();
            if (!serCOM.IsOpen)
            {
                label5.Text = "DISCONNECTED";
                label5.ForeColor = Color.Red;
                button3.Enabled = true;
                button4.Enabled = false;
                button2.Enabled = true;
                buttonlogout.Enabled = true;
            }
        }
    }
}
