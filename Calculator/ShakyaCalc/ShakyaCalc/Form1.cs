using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShakyaCalc
{
    public partial class Form1 : Form
    {

        Double resultValue = 0;
        String operationPerformed = "";
        bool isOperationPerformed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_click(object sender, EventArgs e)
        {
            if((textBox_Result.Text=="0") || (isOperationPerformed))
            {
                textBox_Result.Clear();
            }
            isOperationPerformed = false;
            Button button = (Button)sender;
            if(button.Text==".")
            {
                if(!textBox_Result.Text.Contains("."))
                {
                    textBox_Result.Text = textBox_Result.Text + button.Text;
                }
            }else
            {
                textBox_Result.Text = textBox_Result.Text + button.Text;
            }
           
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if(resultValue!=0)
            {
                button18.PerformClick();
                operationPerformed = button.Text;
                label.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
            else
            { 
                operationPerformed = button.Text;
                resultValue = Double.Parse(textBox_Result.Text);
                label.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
            resultValue = 0;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            switch(operationPerformed)
            {
                case "+":
                    textBox_Result.Text = (resultValue + Double.Parse(textBox_Result.Text)).ToString();
                break;

                case "-":
                    textBox_Result.Text = (resultValue - Double.Parse(textBox_Result.Text)).ToString();
                    break;

                case "X":
                    textBox_Result.Text = (resultValue * Double.Parse(textBox_Result.Text)).ToString();
                    break;

                case "/":
                    textBox_Result.Text = (resultValue / Double.Parse(textBox_Result.Text)).ToString();
                    break;

                default:
                    break;


            }
            resultValue = Double.Parse(textBox_Result.Text);
            label.Text = "";

        }

       

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            if(this.WindowState== FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.ShowBalloonTip(1000, "Importent Notice", "Your Calculator Is Minimized. Click Here to Open", ToolTipIcon.Info);

            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }
    }
}
