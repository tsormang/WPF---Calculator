using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsCalculator
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

        // NUMBERS -------------------------------------------------->>
        private void ButtonClick(object sender, EventArgs e)
        {
            // Clears '0' if there is any on the Text Screen
            if (TextBoxResult.Text == "0" || isOperationPerformed)
            {
                TextBoxResult.Clear();
            }

            isOperationPerformed = false;

            // Gets the value of each button on to the text Screen
            Button button = (Button)sender;

            // Take care to only have ONE decimal (".") in the Text Screen
            if (button.Text == ".")
            {
                if (!TextBoxResult.Text.Contains("."))
                {
                    TextBoxResult.Text = TextBoxResult.Text + button.Text;
                }
            }
            else
            {
                TextBoxResult.Text = TextBoxResult.Text + button.Text;
            }

            
        }

        // OPERATIONS ----------------------------------------------->>
        private void OperatorClick(object sender, EventArgs e)
        {
            // Gets the value of each button on to the text Screen
            Button button = (Button)sender;

            if (resultValue != 0)
            {
                button20.PerformClick();
                operationPerformed = button.Text;
                labelCurrentOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
            else
            {
                operationPerformed = button.Text;
                // Convert the text Screen value into Double
                resultValue = Double.Parse(TextBoxResult.Text);
                // Place the value to the label above the Text Screen
                labelCurrentOperation.Text = resultValue + " " + operationPerformed;

                isOperationPerformed = true;
            }
        }

        // CE Button
        private void button5_Click(object sender, EventArgs e)
        {
            TextBoxResult.Text = "0";
        }

        // C Button
        private void button10_Click(object sender, EventArgs e)
        {
            TextBoxResult.Text = "0";
            resultValue = 0;
        }

        // EQUALS
        private void button20_Click(object sender, EventArgs e)
        {
            switch (operationPerformed)
            {
                case "+":
                    TextBoxResult.Text = (resultValue + Double.Parse(TextBoxResult.Text)).ToString();
                    break;
                case "-":
                    TextBoxResult.Text = (resultValue - Double.Parse(TextBoxResult.Text)).ToString();
                    break;
                case "*":
                    TextBoxResult.Text = (resultValue * Double.Parse(TextBoxResult.Text)).ToString();
                    break;
                case "/":
                    TextBoxResult.Text = (resultValue / Double.Parse(TextBoxResult.Text)).ToString();
                    break;
                default:
                    break;
            }
            resultValue = Double.Parse(TextBoxResult.Text);
            labelCurrentOperation.Text = "";
        }
    }
}
