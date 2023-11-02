using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestcomWF.Views
{
    public partial class calculatrice : Form
    {
        private double _value = 0;
        private string _operation = "";
        private bool _operationPressed = false;

        public calculatrice()
        {
            InitializeComponent();
            InitializeNumberButtons();
            this.KeyPreview = true;
        }

        private void button_Click(object sender, EventArgs e)
        {
            if ((result.Text == "0") || (_operationPressed))
                result.Clear();
            _operationPressed = false;
            Button button = (Button)sender;
            result.Text = result.Text + button.Text;
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            result.Text = "0";
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            _operation = button.Text;
            _value = double.Parse(result.Text);
            _operationPressed = true;
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            switch (_operation)
            {
                case "+":
                    result.Text = (_value + double.Parse(result.Text)).ToString();
                    break;
                case "-":
                    result.Text = (_value - double.Parse(result.Text)).ToString();
                    break;
                case "*":
                    result.Text = (_value * double.Parse(result.Text)).ToString();
                    break;
                case "/":
                    result.Text = (_value / double.Parse(result.Text)).ToString();
                    break;
                default:
                    break;
            }
            _operationPressed = false;
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.NumPad0:
                case Keys.D0:
                    button_Click(numberButtons[0], EventArgs.Empty);
                    break;
                case Keys.NumPad1:
                case Keys.D1:
                    button_Click(numberButtons[1], EventArgs.Empty);
                    break;
                case Keys.NumPad2:
                case Keys.D2:
                    button_Click(numberButtons[2], EventArgs.Empty);
                    break;
                case Keys.NumPad3:
                case Keys.D3:
                    button_Click(numberButtons[3], EventArgs.Empty);
                    break;
                case Keys.NumPad4:
                case Keys.D4:
                    button_Click(numberButtons[4], EventArgs.Empty);
                    break;
                case Keys.NumPad5:
                case Keys.D5:
                    button_Click(numberButtons[5], EventArgs.Empty);
                    break;
                case Keys.NumPad6:
                case Keys.D6:
                    button_Click(numberButtons[6], EventArgs.Empty);
                    break;
                case Keys.NumPad7:
                case Keys.D7:
                    button_Click(numberButtons[7], EventArgs.Empty);
                    break;
                case Keys.NumPad8:
                case Keys.D8:
                    button_Click(numberButtons[8], EventArgs.Empty);
                    break;
                case Keys.NumPad9:
                case Keys.D9:
                    button_Click(numberButtons[9], EventArgs.Empty);
                    break;
                // Vous pouvez également ajouter d'autres touches comme Enter pour "=", etc.
                case Keys.Add:
                case Keys.Oemplus:  // Pour la touche + qui n'est pas sur le pavé numérique
                    button_Click(buttonAdd, EventArgs.Empty);
                    break;
                case Keys.Subtract:
                case Keys.OemMinus:  // Pour la touche - qui n'est pas sur le pavé numérique
                    button_Click(buttonSubtract, EventArgs.Empty);
                    break;
                case Keys.Multiply:
                    button_Click(buttonMultiply, EventArgs.Empty);
                    break;
                case Keys.Divide:
                case Keys.Oem2:  // Pour la touche / qui n'est pas sur le pavé numérique
                    button_Click(buttonDivide, EventArgs.Empty);
                    break;
                case Keys.Enter:
                    button_Click(buttonEquals, EventArgs.Empty);
                    break;
                case Keys.Delete:
                    button_Click(buttonCE, EventArgs.Empty);
                    break;
                case Keys.Back:
                    if (result.Text.Length > 0)  // Vérifiez si la longueur du texte est supérieure à 0 pour éviter une exception
                        result.Text = result.Text.Substring(0, result.Text.Length - 1);  // Supprime le dernier caractère
                    break;

                default:
                    break;
            }
        }
    }
}
