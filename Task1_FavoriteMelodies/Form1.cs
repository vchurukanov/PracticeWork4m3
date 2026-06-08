using System;
using System.Drawing;
using System.Windows.Forms;

namespace Task1_FavoriteMelodies
{
    public partial class Form1 : Form
    {
        private ComboBox cmbMelodies;
        private ListBox lstSelectedMelodies;

        private Button btnAdd;
        private Button btnClear;
        private Button btnExit;

        public Form1()
        {
            InitializeComponent();
            BuildInterface();
        }

        private void BuildInterface()
        {
            this.Text = "Практична робота 4 — Улюблені мелодії";
            this.Name = "FavoriteMelodiesForm";
            this.Size = new Size(620, 430);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            Controls.Clear();

            Label lblTitle = new Label
            {
                Text = "Завдання 1. Улюблені мелодії",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(20, 20),
                AutoSize = true
            };
            Controls.Add(lblTitle);

            Label lblComboBox = new Label
            {
                Text = "Оберіть музичний твір:",
                Location = new Point(30, 80),
                AutoSize = true
            };
            Controls.Add(lblComboBox);

            cmbMelodies = new ComboBox
            {
                Location = new Point(30, 105),
                Width = 250,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            cmbMelodies.Items.Add("Океан Ельзи — Без бою");
            cmbMelodies.Items.Add("The Weeknd — Blinding Lights");
            cmbMelodies.Items.Add("Imagine Dragons — Believer");
            cmbMelodies.Items.Add("Queen — Bohemian Rhapsody");
            cmbMelodies.Items.Add("Nirvana — Smells Like Teen Spirit");
            cmbMelodies.Items.Add("Metallica — Nothing Else Matters");
            cmbMelodies.Items.Add("Linkin Park — Numb");
            cmbMelodies.Items.Add("Ricky Martin — Livin La Vida Loca");
            cmbMelodies.Items.Add("Pink Floyd — Another Brick in the Wall");
            cmbMelodies.Items.Add("Daft Punk — Get Lucky");

            cmbMelodies.SelectedIndex = 0;
            Controls.Add(cmbMelodies);

            btnAdd = new Button
            {
                Text = "Додати",
                Location = new Point(300, 103),
                Width = 100
            };
            btnAdd.Click += BtnAdd_Click;
            Controls.Add(btnAdd);

            Label lblListBox = new Label
            {
                Text = "Вибрані мелодії:",
                Location = new Point(30, 155),
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            Controls.Add(lblListBox);

            lstSelectedMelodies = new ListBox
            {
                Location = new Point(30, 180),
                Size = new Size(540, 120)
            };
            Controls.Add(lstSelectedMelodies);

            btnClear = new Button
            {
                Text = "Очистити",
                Location = new Point(30, 325),
                Width = 110
            };
            btnClear.Click += BtnClear_Click;
            Controls.Add(btnClear);

            btnExit = new Button
            {
                Text = "Вихід",
                Location = new Point(160, 325),
                Width = 110
            };
            btnExit.Click += BtnExit_Click;
            Controls.Add(btnExit);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (cmbMelodies.SelectedItem == null)
            {
                MessageBox.Show("Оберіть музичний твір.", "Повідомлення",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string melody = cmbMelodies.SelectedItem.ToString();

            if (!lstSelectedMelodies.Items.Contains(melody))
            {
                lstSelectedMelodies.Items.Add(melody);
            }
            else
            {
                MessageBox.Show("Цю мелодію вже додано до списку.", "Повідомлення",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            lstSelectedMelodies.Items.Clear();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
