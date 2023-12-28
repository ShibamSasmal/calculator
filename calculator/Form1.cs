using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        public bool singFlag=false;
        public bool equalFlag = false;
        public Form1()
        {
            InitializeComponent();
        }
        public void textCleanOperation()
        {
            if (singFlag)
            {
                textBox1.Text=string.Empty;//"";
                singFlag=false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textCleanOperation();
            textBox1.Text =string.IsNullOrEmpty(textBox1.Text)? Convert.ToString(1): textBox1.Text + Convert.ToString(1);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            textCleanOperation();
            textBox1.Text = string.IsNullOrEmpty(textBox1.Text) ? Convert.ToString(2) : textBox1.Text + Convert.ToString(2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textCleanOperation();
            textBox1.Text = string.IsNullOrEmpty(textBox1.Text) ? Convert.ToString(3) : textBox1.Text + Convert.ToString(3);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textCleanOperation();
            textBox1.Text = string.IsNullOrEmpty(textBox1.Text) ? Convert.ToString(4) : textBox1.Text + Convert.ToString(4);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textCleanOperation();
            textBox1.Text = string.IsNullOrEmpty(textBox1.Text) ? Convert.ToString(5) : textBox1.Text + Convert.ToString(5);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textCleanOperation();
            textBox1.Text = string.IsNullOrEmpty(textBox1.Text) ? Convert.ToString(6) : textBox1.Text + Convert.ToString(6);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textCleanOperation();
            textBox1.Text = string.IsNullOrEmpty(textBox1.Text) ? Convert.ToString(7) : textBox1.Text + Convert.ToString(7);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textCleanOperation();
            textBox1.Text = string.IsNullOrEmpty(textBox1.Text) ? Convert.ToString(8) : textBox1.Text + Convert.ToString(8);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textCleanOperation();
            textBox1.Text = string.IsNullOrEmpty(textBox1.Text) ? Convert.ToString(9) : textBox1.Text + Convert.ToString(9);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            textCleanOperation();
            textBox1.Text = string.IsNullOrEmpty(textBox1.Text) ? Convert.ToString(0) : textBox1.Text + Convert.ToString(0);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textCleanOperation();
            textBox1.Text = string.IsNullOrEmpty(textBox1.Text) ? Convert.ToString(00) : textBox1.Text + Convert.ToString(00);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textCleanOperation();
            textBox1.Text = string.IsNullOrEmpty(textBox1.Text) ? Convert.ToString(".") : textBox1.Text + Convert.ToString(".");
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text= string.Empty;
            singFlag= false;
            equalFlag= false;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            singFlag = true;
            textBox2.Text= equalFlag? textBox1.Text + "+" : string.IsNullOrEmpty(textBox2.Text)? textBox1.Text+ "+" :cal(Convert.ToString(textBox2.Text +textBox1.Text)) +"+" ;
            equalFlag = false;
        }
        public string cal(string val)
        {
            var result = new DataTable().Compute(val, null).ToString();
            return result;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            singFlag = true;
            
            textBox2.Text = equalFlag ? textBox1.Text + "-" : string.IsNullOrEmpty(textBox2.Text) ? textBox1.Text + "-" : cal(Convert.ToString(textBox2.Text + textBox1.Text)) + "-";
            equalFlag = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            singFlag = true;
            

            //textBox2.Text = equalFlag ? textBox1.Text + "%" : string.IsNullOrEmpty(textBox2.Text) ? textBox1.Text + "%" : cal(Convert.ToString(textBox2.Text + textBox1.Text)/100.0) + "%";

            textBox2.Text = string.IsNullOrEmpty(textBox2.Text) ? "0" : string.IsNullOrEmpty(textBox1.Text) ? "0" : Convert.ToString(Convert.ToInt32(textBox1.Text) / 100.0);
            textBox1.Text = textBox2.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            singFlag = true;
            textBox2.Text = equalFlag ? textBox1.Text + "*" : string.IsNullOrEmpty(textBox2.Text) ? textBox1.Text + "*" : cal(Convert.ToString(textBox2.Text + textBox1.Text)) + "*";
            equalFlag = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            singFlag = true;
            textBox2.Text = equalFlag ? textBox1.Text + "/" : string.IsNullOrEmpty(textBox2.Text) ? textBox1.Text + "/" : cal(Convert.ToString(textBox2.Text + textBox1.Text)) + "/";
            equalFlag= false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (singFlag == true)
            {

                var equalString=textBox2.Text+textBox1.Text ;
                textBox2.Text=equalString +"=";
                textBox1.Text = cal(Convert.ToString(equalString));
                singFlag= false;
                equalFlag = true;
            }
            else if (equalFlag == true)
            {
                var result = textBox2.Text.Split(new char[] { '+', '-', '*', '/', '%' })[0];
                var preString = textBox2.Text.Substring(result.Length);
                var preResult = textBox1.Text;
                var equalString = (preResult + preString).Replace("=", "");
                //var equalString = (preResult + preString);
                //equalString=equalString.Remove(equalString.Length-1);
                textBox2.Text = string.IsNullOrEmpty(textBox2.Text) ? string.Empty: equalString +"=";
                textBox1.Text = cal(Convert.ToString(equalString));


            }
            else
            {
                equalFlag = true;
                var equalString = textBox2.Text + textBox1.Text;
                textBox2.Text = string.IsNullOrEmpty(textBox2.Text) ? string.Empty : equalString + "=";
                textBox1.Text = cal(Convert.ToString(equalString));
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.IsNullOrEmpty(textBox1.Text)?"0": textBox1.TextLength-1== 0?"0":textBox1.Text.Substring(0, textBox1.TextLength - 1);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
