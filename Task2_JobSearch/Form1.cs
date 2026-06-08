using System;
using System.Drawing;
using System.Windows.Forms;

namespace Task2_JobSearch
{
    public partial class Form1 : Form
    {
        private ListBox lstJobs;
        private ComboBox cmbSalary;
        private NumericUpDown nudExperience;
        private TextBox txtResult;

        private Button btnShowResult;
        private Button btnClear;
        private Button btnExit;

        public Form1()
        {
            InitializeComponent();
            BuildInterface();
        }

        private void BuildInterface()
        {
            this.Text = "Практична робота 4 — Пошук роботи";
            this.Name = "JobSearchForm";
            this.Size = new Size(720, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            Controls.Clear();

            Label lblTitle = new Label
            {
                Text = "Завдання 2. Пошук роботи",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(20, 20),
                AutoSize = true
            };
            Controls.Add(lblTitle);

            Label lblJobs = new Label
            {
                Text = "Тип роботи:",
                Location = new Point(30, 75),
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            Controls.Add(lblJobs);

            lstJobs = new ListBox
            {
                Location = new Point(30, 105),
                Size = new Size(250, 180),
                Sorted = true
            };

            lstJobs.Items.Add("Системний адміністратор");
            lstJobs.Items.Add("Веб-програміст");
            lstJobs.Items.Add("Веб-дизайнер");
            lstJobs.Items.Add("Модератор сайтів");
            lstJobs.Items.Add("Тестувальник ПЗ");
            lstJobs.Items.Add("DevOps інженер");
            lstJobs.Items.Add("UI/UX дизайнер");
            lstJobs.Items.Add("Контент-менеджер");
            lstJobs.Items.Add("Бізнес-аналітик");
            lstJobs.Items.Add("Frontend-розробник");

            lstJobs.SelectedIndex = 0;
            Controls.Add(lstJobs);

            Label lblSalary = new Label
            {
                Text = "Початкова зарплата:",
                Location = new Point(330, 105),
                AutoSize = true
            };
            Controls.Add(lblSalary);

            cmbSalary = new ComboBox
            {
                Location = new Point(500, 102),
                Width = 130,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            cmbSalary.Items.Add("10000");
            cmbSalary.Items.Add("15000");
            cmbSalary.Items.Add("20000");
            cmbSalary.Items.Add("25000");
            cmbSalary.Items.Add("30000");
            cmbSalary.Items.Add("35000");
            cmbSalary.Items.Add("40000");
            cmbSalary.Items.Add("50000");

            cmbSalary.SelectedIndex = 0;
            Controls.Add(cmbSalary);

            Label lblCurrency = new Label
            {
                Text = "грн",
                Location = new Point(640, 105),
                AutoSize = true
            };
            Controls.Add(lblCurrency);

            Label lblExperience = new Label
            {
                Text = "Стаж роботи:",
                Location = new Point(330, 155),
                AutoSize = true
            };
            Controls.Add(lblExperience);

            nudExperience = new NumericUpDown
            {
                Location = new Point(500, 153),
                Width = 80,
                Minimum = 0,
                Maximum = 50,
                Value = 1
            };
            Controls.Add(nudExperience);

            Label lblYears = new Label
            {
                Text = "років",
                Location = new Point(590, 155),
                AutoSize = true
            };
            Controls.Add(lblYears);

            btnShowResult = new Button
            {
                Text = "Показати результат",
                Location = new Point(330, 215),
                Width = 150
            };
            btnShowResult.Click += BtnShowResult_Click;
            Controls.Add(btnShowResult);

            btnClear = new Button
            {
                Text = "Очистити",
                Location = new Point(500, 215),
                Width = 100
            };
            btnClear.Click += BtnClear_Click;
            Controls.Add(btnClear);

            btnExit = new Button
            {
                Text = "Вихід",
                Location = new Point(330, 260),
                Width = 100
            };
            btnExit.Click += BtnExit_Click;
            Controls.Add(btnExit);

            Label lblResult = new Label
            {
                Text = "Результат:",
                Location = new Point(30, 315),
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            Controls.Add(lblResult);

            txtResult = new TextBox
            {
                Location = new Point(30, 345),
                Size = new Size(640, 80),
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical
            };
            Controls.Add(txtResult);
        }

        private void BtnShowResult_Click(object sender, EventArgs e)
        {
            if (lstJobs.SelectedItem == null)
            {
                MessageBox.Show("Оберіть тип роботи.", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedJob = lstJobs.SelectedItem.ToString();
            int startSalary = int.Parse(cmbSalary.SelectedItem.ToString());
            int experience = (int)nudExperience.Value;

            int bonusForExperience = experience * 1000;
            int finalSalary = startSalary + bonusForExperience;

            txtResult.Text =
                "Результати пошуку роботи:" + Environment.NewLine +
                $"Тип роботи: {selectedJob}" + Environment.NewLine +
                $"Початкова зарплата: {startSalary} грн" + Environment.NewLine +
                $"Стаж роботи: {experience} років" + Environment.NewLine +
                $"Надбавка за стаж: {bonusForExperience} грн" + Environment.NewLine +
                $"Орієнтовна зарплата: {finalSalary} грн";
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            lstJobs.SelectedIndex = 0;
            cmbSalary.SelectedIndex = 0;
            nudExperience.Value = 1;
            txtResult.Clear();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
