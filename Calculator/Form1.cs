using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        double a, b;
        char s;
        bool yes, ChangeZnak_;
        public Calculator()
        {
            InitializeComponent();
            a = 0;
            b = 0;
            s = '\0';
            yes = false;
            ChangeZnak_ = false;
        }
        
        private bool CheckMinus()
        {
            if (textBox1.Text == "" && yes == false)
            {
                textBox1.Text = "-";
                return false;
            }
            return true;
        }
        private void Check_cnange_diya(char sym)
        {
            if (textBox1.Text == "" && yes == false)
            {
                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1, 1);
                textBox2.Text = textBox2.Text + sym;
                //textBox2.Text = textBox2.Text.Replace(s,sym);
                s = sym;
            }
        }
        private void Diya(char symbol , string symbol2, object sender, EventArgs e)
        {
            CheckDot();
     
            if (yes == true)
            {
                s = symbol;
                a = Convert.ToDouble(textBox2.Text);
                textBox2.Text += symbol2;
                textBox1.Clear();
                yes = false;
                return;
            }
            if(textBox2.Text != ""&& textBox1.Text!="")
            {
                is_equal_to_Click(sender, e);
                s = symbol;
                textBox2.Text += symbol2;
                textBox1.Clear();
                yes = false;
                return;
            }
            if (textBox2.Text == "")
            {
                a = Convert.ToDouble(textBox1.Text);
                textBox2.Text = textBox1.Text;
                textBox1.Text = symbol2;
            }
            else if (yes == false)
            {
                is_equal_to_Click(sender, e);
                textBox2.Text = textBox1.Text;
            }
            s = symbol;
            textBox2.Text += symbol2;
            textBox1.Clear();
        }
        private void  CheckDot()
        {
            foreach (var item in textBox1.Text)
                if (item == '.')  
                    textBox1.Text = textBox1.Text.Replace(".", ",");//перевірка на крапку. Можна було і без цього обійтись але на всякий випадок нехай буде
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
        }
       
        private void CE_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void C_Click(object sender, EventArgs e)
        {
            a = 0;
            b = 0;
            textBox1.Clear();
            textBox2.Clear();
            yes = false;
            ChangeZnak_ = false;

        }

        private void Del_one_symbol_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
            for (int i = 0; i < textBox1.Text.Length; i++) 
            {
                if(textBox1.Text[i] == ',' && i+1 != textBox1.Text.Length-1)
                {
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
                    return;
                }
            }
        }

        private void Seven_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }

        private void Eight_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }

        private void nine_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }

        private void Four_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
        }

        private void Five_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }

        private void Six_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }

        private void One_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }

        private void Two_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }

        private void Three_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";

        }

        private void Dot_Click(object sender, EventArgs e)
        {
            textBox1.Text += ",";
        }

        private void Zero_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }

        private void is_equal_to_Click(object sender, EventArgs e)
        {
            b = Convert.ToDouble(textBox1.Text);

            switch (s)
            {
                case '+':
                    a += b;
                    break;
                case '-':
                    a -= b;
                    break;
                case '*':
                    a *= b;
                    break;
                case '/':
                    a /= b;
                    break;
                default:
                    break;
            }
            textBox1.Clear();
            textBox2.Text = Convert.ToString(a);
            yes = true;
        }

        private void PLus_Click(object sender, EventArgs e)
        {
            if (ChangeZnak_ == true)
            {
                Check_cnange_diya('+');
                ChangeZnak_ = false;
                return;
            }
            Diya('+', "+", sender, e);
        }

        private void Minus_Click(object sender, EventArgs e)
        {
            if (ChangeZnak_ == true)
            {
                Check_cnange_diya('-');
                ChangeZnak_ = false;
                return;
            }
            if (!CheckMinus())
                return;
            Diya('-', "-", sender, e);
        }
        private void multiplication_Click(object sender, EventArgs e)
        {
            if (ChangeZnak_ == true)
            {
       
                Check_cnange_diya('*');
                ChangeZnak_ = false;

                return;
            }
            Diya('*', "*", sender, e);
        }
        private void division_Click(object sender, EventArgs e)
        {
            if (ChangeZnak_ == true)
            {
                Check_cnange_diya('/');
                ChangeZnak_ = false;
                return;
            }
            Diya('/', "/", sender, e);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("cool calculator?", "Calculator", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
                MessageBox.Show("His score is 12!!!");
            else
            {
                MessageBox.Show("look closely\nyou can change the action sign\ndo operations on negative numbers\n" +
                    "keyboard input\nESC clear");

            }
        }
        private void Seven_Clicks(object sender, KeyEventArgs e)
        {
            textBox1.Text += "7";
        }

        private void Key_downs(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D1|| e.KeyCode == Keys.NumPad1)
            {
                One_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                C_Click(sender, e);
            }
            else if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2)
            {
                Two_Click(sender, e);
            }
            else if (e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3)
            {
               Three_Click(sender, e);
            }
            else if (e.KeyCode == Keys.D4 || e.KeyCode == Keys.NumPad4)
            {
                Four_Click(sender, e);
            }
            else if (e.KeyCode == Keys.D5 || e.KeyCode == Keys.NumPad5)
            {
                Five_Click(sender, e);
            }
            else if (e.KeyCode == Keys.D6 || e.KeyCode == Keys.NumPad6)
            {
                Six_Click(sender, e);
            }
            else if (e.KeyCode == Keys.D7 || e.KeyCode == Keys.NumPad7)
            {
                Seven_Click(sender, e);
            }
            else if (e.KeyCode == Keys.D8 || e.KeyCode == Keys.NumPad8)
            {
                Eight_Click(sender, e);
            }
            else if (e.KeyCode == Keys.D9 || e.KeyCode == Keys.NumPad9)
            {
                nine_Click(sender, e);
            }
            else if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.NumPad0)
            {
                Zero_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Add)
            {
                PLus_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Subtract)
            {
                Minus_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Multiply)
            {
                multiplication_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Divide)
            {
                division_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Enter)
            {
                is_equal_to_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Decimal)
            {
                Dot_Click(sender, e);
            }
        }

        private void ChangeZnak_Click(object sender, EventArgs e)
        {
            ChangeZnak_ = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
