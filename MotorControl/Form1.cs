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
            comboBox1.SelectedIndex = 1;
            comboBox2.SelectedIndex = 3;
            try
            {
                serialPort1.Open();
            }
            catch (Exception ex)
            {
                label5.Text = "Please connect Arduino properly";
                MessageBox.Show(ex.Message, "Exception");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SET
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
            String msg = "Sohel Aman says hello from the other side!  :-) ";
            MessageBox.Show(msg, "About");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void button3_Click(object sender, EventArgs e)
        {
            //MOTOR START
            String dir = ( trackBar2.Value == 0 ) ? "CW" : "CCW";
            String delay = numericUpDown1.Value + "";
            String speed = Math.Ceiling((trackBar1.Value * 25.5)) + "";
            String str = "Motor," + dir + "," + delay + "," + speed;
            //MessageBox.Show(str);
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

        private void button4_Click(object sender, EventArgs e)
        {
            //ACTUATOR 1 START
            String dir = (trackBar3.Value == 0) ? "FW" : "BW";
            String delay = numericUpDown2.Value + "";
            String speed = Math.Ceiling((trackBar4.Value * 25.5)) + "";
            String str = "Actuator1," + dir + "," + delay + "," + speed;
            //MessageBox.Show(str);
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

        private void button5_Click(object sender, EventArgs e)
        {
            //ACTUATOR 2 START
            String dir = (trackBar6.Value == 0) ? "FW" : "BW";
            String delay = numericUpDown3.Value + "";
            String speed = Math.Ceiling((trackBar5.Value * 25.5)) + "";
            String str = "Actuator2," + dir + "," + delay + "," + speed;
            //MessageBox.Show(str);
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

        private void button2_Click(object sender, EventArgs e)
        {
            //RESET ALL
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 3;
            numericUpDown1.Value = 1000;
            numericUpDown2.Value = 1000;
            numericUpDown3.Value = 1000;
            trackBar1.Value = 10;
            trackBar4.Value = 10;
            trackBar5.Value = 10;
            trackBar2.Value = 0;
            trackBar3.Value = 0;
            trackBar6.Value = 0;
            label5.Text = "Reset";
            try
            {
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
            //EXIT
            if (serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.Write("Stop");
                    serialPort1.Close();
                }
                catch (Exception ex)
                {
                    label5.Text = "Exception occured";
                    MessageBox.Show(ex.Message, "Exception");
                }
            }
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            String help = "Following RHS strings are passed through serial: \n\nRESET ALL = 'Stop'\nSTOP ALL = 'Stop'\nMotor CW with Delay 1000 and 100% Duty Cycle = 'Motor,CW,1000,255'\nMotor CCW with Delay 1000 and 50% Duty Cycle = 'Motor,CCW,1000,128'\nActuator 1 FW with Delay 1000 and 100% Duty Cycle = 'Actuator1,FW,1000,255'\nActuator 1 BW with Delay 1000 and 20% Duty Cycle = 'Actuator1,BW,1000,51'\nActuator 2 FW with Delay 1000 and 0% Duty Cycle = 'Actuator2,FW,1000,0'\nActuator 2 BW with Delay 1000 and 100% Duty Cycle = 'Actuator2,BW,1000,255'\n\nNote: No whitespace character is used. \nStrings can be split using comma (,) delimiter.\nSpeed Slider defines Duty Cycle. Each segment = 10% Duty Cycle. \nCorresponding data sent [0-255].";
            MessageBox.Show(help, "Help");
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            //STOP ALL
            if (serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.Write("Stop");
                    label5.Text = "Stopped all";
                }
                catch (Exception ex)
                {
                    label5.Text = "Exception occured";
                    MessageBox.Show(ex.Message, "Exception");
                }
            }
        }
    }
}
