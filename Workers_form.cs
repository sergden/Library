using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Controller;

namespace WindowsFormsApp1
{
    public partial class Workers_form : Form
    {
        Query_workers controller;

        MainForm MForm = new MainForm();

        public Workers_form()
        {
            InitializeComponent();
            controller = new Query_workers(ConnectionString.Connstr);

            dateTimePicker2.Value = DateTime.Today;

            toolTip1.SetToolTip(update_button, "Обновить");
            toolTip1.SetToolTip(edit_item_button, "Для редактирования нужно также указать ID");
            toolTip1.SetToolTip(insert_button, "Для добавления нужно заполнить все поля, кроме поля ID");
            toolTip1.SetToolTip(delete_button, "Для удаления нужно указать только ID");

            textBox2.Focus();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "Admin")
            {
                panel1.Hide();
                dataGridView1.DataSource = controller.Update_Table();
                textBox2.Clear();
            }
            else
            {
                MessageBox.Show("Ошибка ввода логина/пароля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Select();
            }
        }

        private void update_button_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = controller.Update_Table();

            MForm.comboBox3.Items.Clear();
            for (int i = 0; i < dataGridView1.RowCount; i++)   //заполнение ComboB Работник
            {
                MForm.comboBox3.Items.Add(Convert.ToString(dataGridView1[1, i].Value));
            }
        }

        private void insert_button_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox3.Text == "" || maskedTextBox1.Text == "" || maskedTextBox2.Text == "" || maskedTextBox3.Text == "")
            {
                MessageBox.Show("Ошибка ввода данных. Проверьте все ли поля заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                controller.Add_table(textBox1.Text, textBox3.Text, maskedTextBox1.Text, dateTimePicker2.Value, maskedTextBox2.Text, int.Parse(maskedTextBox3.Text));
                dataGridView1.DataSource = controller.Update_Table();

                textBox1.Clear();
                textBox3.Clear();
                maskedTextBox1.Clear();
                maskedTextBox2.Clear();
                maskedTextBox3.Clear();
                MForm.comboBox3.Items.Clear();
                for (int i = 0; i < dataGridView1.RowCount; i++)   //заполнение ComboB Работник
                {
                    MForm.comboBox3.Items.Add(Convert.ToString(dataGridView1[1, i].Value));
                }
            }
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            if (textBox13.Text == "")
            {
                MessageBox.Show("Ошибка ввода данных. Проверьте поле с ID", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                const string message =
"Are you sure that you would like to delete the item?";
                const string caption = "Delete item";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);

                // If the no button was pressed ...
                if (result == DialogResult.Yes)
                {
                    controller.Delete_Item_table(int.Parse(textBox13.Text));
                    dataGridView1.DataSource = controller.Update_Table();

                    textBox13.Clear();
                    MForm.comboBox3.Items.Clear();
                    for (int i = 0; i < dataGridView1.RowCount; i++)   //заполнение ComboB Работник
                    {
                        MForm.comboBox3.Items.Add(Convert.ToString(dataGridView1[1, i].Value));
                    }
                }
            }
        }

        private void edit_item_button_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox3.Text == "" || textBox7.Text == "" || maskedTextBox1.Text == "" || maskedTextBox2.Text == "" || maskedTextBox3.Text == "")
            {
                MessageBox.Show("Ошибка ввода данных. Все поля заполнены должны быть заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                controller.edit_item_table(int.Parse(textBox7.Text), textBox1.Text, textBox3.Text, maskedTextBox1.Text, dateTimePicker2.Value, maskedTextBox2.Text, int.Parse(maskedTextBox3.Text));
                update_button.PerformClick();

                textBox1.Clear();
                textBox3.Clear();
                textBox7.Clear();
                maskedTextBox1.Clear();
                maskedTextBox2.Clear();
                maskedTextBox3.Clear();

            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }
    }
}
