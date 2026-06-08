using System;
using System.Drawing;
using System.Windows.Forms;

namespace Task3_CheckedMelodies
{
    public partial class Form1 : Form
    {
        private CheckedListBox checkedMelodies;
        private ListBox lstSelectedMelodies;

        private Button btnShowSelected;
        private Button btnClear;
        private Button btnExit;

        public Form1()
        {
            InitializeComponent();
            BuildInterface();
        }

        private void BuildInterface()
        {
            this.Text = "Практична робота 4 — CheckedListBox";
            this.Name = "CheckedMelodiesForm";
            this.Size = new Size(720, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            Controls.Clear();

            Label lblTitle = new Label
            {
                Text = "Завдання 3. Улюблені мелодії через CheckedListBox",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(20, 20),
                AutoSize = true
            };
            Controls.Add(lblTitle);

            Label lblCheckedList = new Label
            {
                Text = "Оберіть улюблені мелодії:",
                Location = new Point(30, 80),
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            Controls.Add(lblCheckedList);

            checkedMelodies = new CheckedListBox
            {
                Location = new Point(30, 110),
                Size = new Size(300, 220),
                CheckOnClick = true
            };

            checkedMelodies.Items.Add("Океан Ельзи — Без бою");
            checkedMelodies.Items.Add("The Weeknd — Blinding Lights");
            checkedMelodies.Items.Add("Imagine Dragons — Believer");
            checkedMelodies.Items.Add("Queen — Bohemian Rhapsody");
            checkedMelodies.Items.Add("Nirvana — Smells Like Teen Spirit");
            checkedMelodies.Items.Add("Metallica — Nothing Else Matters");
            checkedMelodies.Items.Add("Linkin Park — Numb");
            checkedMelodies.Items.Add("Ricky Martin — Livin La Vida Loca");
            checkedMelodies.Items.Add("Pink Floyd — Another Brick in the Wall");
            checkedMelodies.Items.Add("Daft Punk — Get Lucky");

            Controls.Add(checkedMelodies);

            Label lblSelectedList = new Label
            {
                Text = "Вибрані мелодії:",
                Location = new Point(370, 80),
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            Controls.Add(lblSelectedList);

            lstSelectedMelodies = new ListBox
            {
                Location = new Point(370, 110),
                Size = new Size(300, 220)
            };
            Controls.Add(lstSelectedMelodies);

            btnShowSelected = new Button
            {
                Text = "Вивести вибрані",
                Location = new Point(30, 360),
                Width = 140
            };
            btnShowSelected.Click += BtnShowSelected_Click;
            Controls.Add(btnShowSelected);

            btnClear = new Button
            {
                Text = "Очистити",
                Location = new Point(190, 360),
                Width = 100
            };
            btnClear.Click += BtnClear_Click;
            Controls.Add(btnClear);

            btnExit = new Button
            {
                Text = "Вихід",
                Location = new Point(310, 360),
                Width = 100
            };
            btnExit.Click += BtnExit_Click;
            Controls.Add(btnExit);
        }

        private void BtnShowSelected_Click(object sender, EventArgs e)
        {
            lstSelectedMelodies.Items.Clear();

            foreach (object item in checkedMelodies.CheckedItems)
            {
                lstSelectedMelodies.Items.Add(item.ToString());
            }

            if (lstSelectedMelodies.Items.Count == 0)
            {
                MessageBox.Show("Не вибрано жодної мелодії.", "Повідомлення",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedMelodies.Items.Count; i++)
            {
                checkedMelodies.SetItemChecked(i, false);
            }

            lstSelectedMelodies.Items.Clear();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
