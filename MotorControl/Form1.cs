using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotorControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 3;
            //checkBox1.Checked = true;
            //checkBox2.Checked = false;
            try
            {
                serialPort1.Open();
            }
            catch (Exception ex)
            {
                label5.Text = "Connect Arduino properly";
                MessageBox.Show(ex.Message, "Exception");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = comboBox1.SelectedItem.ToString();
                int baudRate = Int32.Parse(comboBox2.SelectedItem.ToString());
                serialPort1.BaudRate = baudRate;
                label5.Text = "Port: " + serialPort1.PortName + "  Baud Rate: " + serialPort1.BaudRate;
                if (!serialPort1.IsOpen)
                {
                    serialPort1.Open();
                }
            }
            catch (Exception ex)
            {
                label5.Text = "Exception occured";
                MessageBox.Show(ex.Message, "Exception");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            String msg = "Sohel Aman says hello  :-) ";
            MessageBox.Show(msg, "About");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            checkBox3.Checked = !checkBox4.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = !checkBox2.Checked;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = !checkBox1.Checked;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            checkBox4.Checked = !checkBox3.Checked;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            checkBox6.Checked = !checkBox5.Checked;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            checkBox5.Checked = !checkBox6.Checked;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                String str = "Motor,CW," + numericUpDown1.Value;
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Write(str);
                        label5.Text = str;
                    }
                    else
                    {
                        label5.Text = "Serial port closed";
                    }
                }
                catch (Exception ex)
                {
                    label5.Text = "Exception occured";
                    MessageBox.Show(ex.Message, "Exception");
                }
            }
            else
            {
                String str = "Motor,CCW," + numericUpDown1.Value;
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Write(str);
                        label5.Text = str;
                    }
                    else
                    {
                        label5.Text = "Serial port closed";
                    }
                }
                catch (Exception ex)
                {
                    label5.Text = "Exception occured";
                    MessageBox.Show(ex.Message, "Exception");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                String str = "Actuator1,FW," + numericUpDown2.Value;
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Write(str);
                        label5.Text = str;
                    }
                    else
                    {
                        label5.Text = "Serial port closed";
                    }
                }
                catch (Exception ex)
                {
                    label5.Text = "Exception occured";
                    MessageBox.Show(ex.Message, "Exception");
                }
            }
            else
            {
                String str = "Actuator1,BW," + numericUpDown2.Value;
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Write(str);
                        label5.Text = str;
                    }
                    else
                    {
                        label5.Text = "Serial port closed";
                    }
                }
                catch (Exception ex)
                {
                    label5.Text = "Exception occured";
                    MessageBox.Show(ex.Message, "Exception");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                String str = "Actuator2,FW," + numericUpDown3.Value;
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Write(str);
                        label5.Text = str;
                    }
                    else
                    {
                        label5.Text = "Serial port closed";
                    }
                }
                catch (Exception ex)
                {
                    label5.Text = "Exception occured";
                    MessageBox.Show(ex.Message, "Exception");
                }
            }
            else
            {
                String str = "Actuator2,BW," + numericUpDown3.Value;
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Write(str);
                        label5.Text = str;
                    }
                    else
                    {
                        label5.Text = "Serial port closed";
                    }
                }
                catch (Exception ex)
                {
                    label5.Text = "Exception occured";
                    MessageBox.Show(ex.Message, "Exception");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 3;
            checkBox1.Checked = true;
            checkBox2.Checked = !checkBox1.Checked;
            checkBox3.Checked = true;
            checkBox4.Checked = !checkBox3.Checked;
            checkBox5.Checked = true;
            checkBox6.Checked = !checkBox5.Checked;
            numericUpDown1.Value = 1000;
            numericUpDown2.Value = 1000;
            numericUpDown3.Value = 1000;
            label5.Text = "Reset";
            try
            {
                serialPort1.PortName = "COM1";
                serialPort1.BaudRate = 9600;
                serialPort1.Open();
                serialPort1.Write("Stop");
            }
            catch (Exception ex)
            {
                label5.Text = "Exception occured";
                MessageBox.Show(ex.Message, "Exception");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Write("Stop");
                serialPort1.Close();
            }
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            String help = "Following RHS strings are passed through serial: \n\nRESET ALL = 'Stop'\nMotor CW with Delay 1000 = 'Motor,CW,1000'\nMotor CCW with Delay 1000 = 'Motor,CCW,1000'\nActuator 1 FW with Delay 1000 = 'Actuator1,FW,1000'\nActuator 1 BW with Delay 1000 = 'Actuator1,BW,1000'\nActuator 2 FW with Delay 1000 = 'Actuator2,FW,1000'\nActuator 2 BW with Delay 1000 = 'Actuator2,BW,1000'\n\nNote: No whitespace character is used. \nStrings can be split using comma (,) delimiter.";
            MessageBox.Show(help, "Help");
        }
    }
}
