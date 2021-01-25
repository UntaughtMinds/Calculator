using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class MainForm : Form
    {
        private string currentNumberText = string.Empty;
        private List<string> inputElement = new();

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblRes_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(lblRes.Text);
            MessageBox.Show("内容已复制");
        }

        private void lblExp_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(lblExp.Text);
            MessageBox.Show("内容已复制");
        }

        private void butNagate_Click(object sender, EventArgs e)
        {
            if (currentNumberText != string.Empty)
            {
                inputElement.Add(currentNumberText);
            }
            if (inputElement.Count != 0)
            {
                inputElement.Add("×");
            }
            inputElement.Add("-1");
            currentNumberText = string.Empty;
            displaylblRes(currentNumberText);
            displaylblExp();
        }

        private void butNum_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (currentNumberText != null && button.Text == "." && currentNumberText.Contains("."))
            {
                return;
            }
            currentNumberText += button.Text;
            displaylblRes(currentNumberText);
            displaylblExp();
        }

        private void butOperate_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (inputElement.Count == 0 && currentNumberText == string.Empty)
            {
                return;
            }

            if (inputElement.Count > 0 && currentNumberText == string.Empty &&
                (inputElement.Last() == "+" ||
                inputElement.Last() == "-" ||
                inputElement.Last() == "×" ||
                inputElement.Last() == "÷"))
            {
                inputElement[inputElement.Count - 1] = button.Text;
            }
            else
            {
                inputElement.Add(currentNumberText);
                inputElement.Add(button.Text);
            }

            currentNumberText = string.Empty;
            displaylblRes(cal().ToString());
            displaylblExp();
        }

        private void butRes_Click(object sender, EventArgs e)
        {
            if (inputElement.Count == 0)
            {
                return;
            }
            inputElement.Add(currentNumberText);
            inputElement.Add("=");
            currentNumberText = string.Empty;
            displaylblRes(cal());
            displaylblExp();
            inputElement.Clear();
        }

        private void butDel_Click(object sender, EventArgs e)
        {
            currentNumberText.Remove(currentNumberText.Length - 1, 1);
            displaylblRes(currentNumberText);
        }

        private void butC_Click(object sender, EventArgs e)
        {
            currentNumberText = string.Empty;
            inputElement.Clear();
            displaylblRes(currentNumberText);
            displaylblExp();
        }

        private void butCE_Click(object sender, EventArgs e)
        {
            currentNumberText = string.Empty;
            displaylblRes(currentNumberText);
        }

        private String cal()
        {
            decimal tempNumber = 0.0M;
            string currentOperator = string.Empty;
            string res;

            try
            {
                for (int i = 0; i < inputElement.Count - 1; i++)
                {
                    var item = inputElement[i];
                    switch (item)
                    {
                        case "+":
                        case "-":
                        case "×":
                        case "÷":
                            currentOperator = item;
                            break;
                        default:
                            switch (currentOperator)
                            {
                                case "+":
                                    tempNumber += decimal.Parse(item);
                                    break;
                                case "-":
                                    tempNumber -= decimal.Parse(item);
                                    break;
                                case "×":
                                    tempNumber *= decimal.Parse(item);
                                    break;
                                case "÷":
                                    tempNumber /= decimal.Parse(item);
                                    break;
                                default:
                                    tempNumber = decimal.Parse(item);
                                    break;
                            }
                            break;
                    }
                }
                res = tempNumber.ToString();
            }
            catch (Exception)
            {
                res = "出现错误";
                currentNumberText = string.Empty;
                inputElement.Clear();
                displaylblExp();
            }
            return res;
        }

        private void displaylblRes(string input)
        {
            lblRes.Text = input;
        }

        private void displaylblExp()
        {
            lblExp.Text = string.Join(" ", inputElement);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // if it is a hotkey, return true; otherwise, return false
            switch (keyData)
            {
                case Keys.NumPad0:
                    but0.Focus();
                    but0.PerformClick();
                    return true;
                case Keys.NumPad1:
                    but1.Focus();
                    but1.PerformClick();
                    return true;
                case Keys.NumPad2:
                    but2.Focus();
                    but2.PerformClick();
                    return true;
                case Keys.NumPad3:
                    but3.Focus();
                    but3.PerformClick();
                    return true;
                case Keys.NumPad4:
                    but4.Focus();
                    but4.PerformClick();
                    return true;
                case Keys.NumPad5:
                    but5.Focus();
                    but5.PerformClick();
                    return true;
                case Keys.NumPad6:
                    but6.Focus();
                    but6.PerformClick();
                    return true;
                case Keys.NumPad7:
                    but7.Focus();
                    but7.PerformClick();
                    return true;
                case Keys.NumPad8:
                    but8.Focus();
                    but8.PerformClick();
                    return true;
                case Keys.NumPad9:
                    but9.Focus();
                    but9.PerformClick();
                    return true;
                case Keys.Add:
                    butAdd.Focus();
                    butAdd.PerformClick();
                    return true;
                case Keys.Subtract:
                    butSub.Focus();
                    butSub.PerformClick();
                    return true;
                case Keys.Multiply:
                    butMult.Focus();
                    butMult.PerformClick();
                    return true;
                case Keys.Divide:
                    butDiv.Focus();
                    butDiv.PerformClick();
                    return true;
                case Keys.Enter:
                    butRes.Focus();
                    butRes.PerformClick();
                    return true;
                case Keys.Escape:
                    butCE.Focus();
                    butCE.PerformClick();
                    return true;
                case Keys.Decimal:
                    butDot.Focus();
                    butDot.PerformClick();
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
