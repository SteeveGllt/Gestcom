namespace GestcomWF.Views
{
    partial class calculatrice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }




        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            result = new TextBox();
            result.Location = new System.Drawing.Point(10, 10);
            result.Width = 260;
            result.ReadOnly = true;
            this.Controls.Add(result);

            buttonAdd = new Button { Text = "+", Location = new System.Drawing.Point(220, 40), Width = 50, Height = 50 };
            buttonAdd.Click += new EventHandler(operator_click);
            this.Controls.Add(buttonAdd);

            buttonSubtract = new Button { Text = "-", Location = new System.Drawing.Point(220, 100), Width = 50, Height = 50 };
            buttonSubtract.Click += new EventHandler(operator_click);
            this.Controls.Add(buttonSubtract);

            buttonMultiply = new Button { Text = "*", Location = new System.Drawing.Point(220, 160), Width = 50, Height = 50 };
            buttonMultiply.Click += new EventHandler(operator_click);
            this.Controls.Add(buttonMultiply);

            buttonDivide = new Button { Text = "/", Location = new System.Drawing.Point(220, 220), Width = 50, Height = 50 };
            buttonDivide.Click += new EventHandler(operator_click);
            this.Controls.Add(buttonDivide);

            buttonEquals = new Button { Text = "=", Location = new System.Drawing.Point(150, 280), Width = 120, Height = 50 };
            buttonEquals.Click += new EventHandler(buttonEquals_Click);
            this.Controls.Add(buttonEquals);

            buttonCE = new Button { Text = "CE", Location = new System.Drawing.Point(10, 280), Width = 130, Height = 50 };
            buttonCE.Click += new EventHandler(buttonCE_Click);
            this.Controls.Add(buttonCE);

            this.Text = "Calculatrice";
            this.ClientSize = new System.Drawing.Size(280, 340);

            this.KeyDown += Form_KeyDown;
        }

        private void InitializeNumberButtons()
        {
            numberButtons = new Button[10];
            for (int i = 1; i <= 9; i++)  // Notez que nous commençons à 1 ici
            {
                numberButtons[i] = new Button();
                numberButtons[i].Text = i.ToString();
                numberButtons[i].Width = 60;
                numberButtons[i].Height = 60;
                numberButtons[i].Location = new System.Drawing.Point(10 + ((i - 1) % 3) * 70, 40 + ((i - 1) / 3) * 70);
                numberButtons[i].Click += new EventHandler(button_Click);
                this.Controls.Add(numberButtons[i]);
            }

            // Pour le bouton 0, placez-le séparément pour qu'il apparaisse correctement
            numberButtons[0] = new Button();
            numberButtons[0].Text = "0";
            numberButtons[0].Width = 60;
            numberButtons[0].Height = 60;
            numberButtons[0].Location = new System.Drawing.Point(10, 250);  // Ajusté pour l'aligner avec les autres boutons
            numberButtons[0].Click += new EventHandler(button_Click);
            this.Controls.Add(numberButtons[0]);

           
        }

        #endregion


        private TextBox result;
        private Button[] numberButtons;
        private Button buttonAdd, buttonSubtract, buttonMultiply, buttonDivide, buttonEquals, buttonCE;
    }
}