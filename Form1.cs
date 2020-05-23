using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Controller;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        Query controller;

        Query2 controller_2;

        Query3 controller_3;

        Query4 controller_4;

        Query_workers controller_workers;

        public MainForm()
        {
            InitializeComponent();
            controller = new Query(ConnectionString.Connstr);
            controller_2 = new Query2(ConnectionString.Connstr);
            controller_3 = new Query3(ConnectionString.Connstr);
            controller_4 = new Query4(ConnectionString.Connstr);
            controller_workers = new Query_workers(ConnectionString.Connstr);

            dataGridView1.DataSource = controller.Update_Table_1();
            dataGridView2.DataSource = controller_3.update_table();
            dataGridView3.DataSource = controller_2.update_table();
            dataGridView4.DataSource = controller_4.update_table();
            dataGridView5.DataSource = controller_workers.Update_Table();

            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today;
            dateTimePicker3.Value = DateTime.Today;
            dateTimePicker4.Value = DateTime.Today;

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();

          //  toolTip1.SetToolTip(update_button_1, "Обновить");
            toolTip1.SetToolTip(update_button_2, "Обновить");
            toolTip1.SetToolTip(update_button_3, "Обновить");
            toolTip1.SetToolTip(update_button_4, "Обновить");
            toolTip1.SetToolTip(edit_item_button_1,"Для редактирования нужно также указать ID");
            toolTip1.SetToolTip(edit_item_button_2,"Для редактирования нужно также указать ID");
            toolTip1.SetToolTip(edit_item_button_3,"Для редактирования нужно также указать ID");
            toolTip1.SetToolTip(edit_item_button_4,"Для редактирования нужно также указать ID");
            toolTip1.SetToolTip(insert_button1,"Для добавления нужно заполнить все поля, кроме поля ID");
            toolTip1.SetToolTip(insert_button_2,"Для добавления нужно заполнить все поля, кроме поля ID");
            toolTip1.SetToolTip(insert_button_3,"Для добавления нужно заполнить все поля, кроме поля ID");
            toolTip1.SetToolTip(insert_button_4,"Для добавления нужно заполнить все поля, кроме поля ID");
            toolTip1.SetToolTip(delete_button_1,"Для удаления нужно указать только ID");
            toolTip1.SetToolTip(delete_button_2,"Для удаления нужно указать только ID");
            toolTip1.SetToolTip(delete_button_3,"Для удаления нужно указать только ID");
            toolTip1.SetToolTip(delete_button_4,"Для удаления нужно указать только ID");

            comboBox4.SelectedIndex = 0;

            for (int i = 0; i < dataGridView1.RowCount; i++)   //заполнение ComboB Книга
            {
                comboBox2.Items.Add(Convert.ToString(dataGridView1[1, i].Value));
            }

            for (int i = 0; i < dataGridView2.RowCount; i++)   //заполнение ComboB Читатели
            {
                comboBox1.Items.Add(Convert.ToString(dataGridView2[1, i].Value));
            }

            for (int i = 0; i < dataGridView5.RowCount; i++)   //заполнение ComboB Работник
            {
                comboBox3.Items.Add(Convert.ToString(dataGridView5[1, i].Value));
            }
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string message =
        "Are you sure that you would like to close the form?";
            const string caption = "Form Closing";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.Yes)
            {
                // cancel the closure of the form.
                PasswdForm passwdform = new PasswdForm();
                passwdform.Show();
                this.Hide();
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutform = new AboutForm();
            aboutform.Show();
        }

        private void ПерсоналtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            Workers_form workers = new Workers_form();
            workers.Show();
        }


        //*****************************************Книжный фонд******************************************************************************************
        private void update_button_1_Click(object sender, EventArgs e) //кнопка обновить
        {
            dataGridView1.DataSource = controller.Update_Table_1();

            comboBox2.Items.Clear();


            for (int i = 0; i < dataGridView1.RowCount; i++)   //заполнение ComboB Книга
            {
                comboBox2.Items.Add(Convert.ToString(dataGridView1[1, i].Value));
            }
        }

        private void insert_button1_Click(object sender, EventArgs e) //кнопка добавить запись
        {
            if (maskedTextBox6.Text == "" || maskedTextBox4.Text == "" || maskedTextBox2.Text == "" || maskedTextBox7.Text == "")
            {
                MessageBox.Show("Ошибка ввода данных. Проверьте все ли поля заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                controller.Add_table_1(maskedTextBox6.Text, maskedTextBox4.Text, int.Parse(maskedTextBox2.Text), maskedTextBox7.Text);
                dataGridView1.DataSource = controller.Update_Table_1();

                comboBox2.Items.Clear();
                for (int i = 0; i < dataGridView1.RowCount; i++)   //заполнение ComboB Книга
                {
                    comboBox2.Items.Add(Convert.ToString(dataGridView1[1, i].Value));
                }
            }
        }

        private void delete_button_1_Click(object sender, EventArgs e) //удаление записи
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
                    int ID = int.Parse(textBox13.Text);
                    controller.Delete_Item_table_1(ID);
                    dataGridView1.DataSource = controller.Update_Table_1();

                    textBox13.Clear();
                    comboBox2.Items.Clear();
                    for (int i = 0; i < dataGridView1.RowCount; i++)   //заполнение ComboB Книга
                    {
                        comboBox2.Items.Add(Convert.ToString(dataGridView1[1, i].Value));
                    }
                }
            }
        }

        private void edit_item_button_1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox6.Text == "" || maskedTextBox4.Text == "" || maskedTextBox2.Text == "" || maskedTextBox7.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("Ошибка ввода данных. Все поля заполнены должны быть заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                controller.Update_item_table_1(int.Parse(textBox7.Text), maskedTextBox6.Text, maskedTextBox4.Text, maskedTextBox2.Text, maskedTextBox7.Text);
                update_button_1.PerformClick();
                maskedTextBox6.Clear();
                maskedTextBox4.Clear();
                maskedTextBox2.Clear();
                maskedTextBox7.Clear();
                textBox7.Clear();
            }
        }
        //****************************************************************************************************************************************





        //***********************************Выдача книг*******************************************************************************************
        private void update_button_2_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = controller_2.update_table();
        }

        private void insert_button_2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || comboBox4.Text=="")
            {
                MessageBox.Show("Ошибка ввода данных. Проверьте все ли поля заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                controller_2.Add_table(comboBox2.Text, comboBox1.Text, comboBox3.Text, dateTimePicker1.Value, dateTimePicker2.Value, comboBox4.Text);
                dataGridView3.DataSource = controller_2.update_table();
            }
        }

        private void delete_button_2_Click(object sender, EventArgs e)
        {
            if (textBox14.Text == "")
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
                    controller_2.Delete_Item_table(int.Parse(textBox14.Text));
                    dataGridView3.DataSource = controller_2.update_table();

                    textBox14.Clear();
                }
            }
        }

        private void edit_item_button_2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || textBox8.Text == "")
            {
                MessageBox.Show("Ошибка ввода данных. Все поля заполнены должны быть заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                controller_2.edit_item_table_2(int.Parse(textBox8.Text), comboBox2.Text, comboBox1.Text, comboBox3.Text, dateTimePicker1.Value, dateTimePicker2.Value, comboBox4.Text);
                update_button_2.PerformClick();

                textBox8.Clear();
            }
        }
        //**********************************************************************************************************************************************






        //*******************************************Читатели*******************************************************************************************
        private void update_button_3_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = controller_3.update_table();

            comboBox1.Items.Clear();
            for (int i = 0; i < dataGridView2.RowCount; i++)   //заполнение ComboB Читатели
            {
                comboBox1.Items.Add(Convert.ToString(dataGridView2[1, i].Value));
            }
        }

        private void insert_button_3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "" || maskedTextBox1.Text == "")
            {
                MessageBox.Show("Ошибка ввода данных. Проверьте все ли поля заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                controller_3.Add_table(textBox2.Text, textBox3.Text, maskedTextBox1.Text, dateTimePicker4.Value);
                dataGridView2.DataSource = controller_3.update_table();

                textBox2.Clear();
                textBox3.Clear();
                maskedTextBox1.Clear();
                comboBox1.Items.Clear();
                for (int i = 0; i < dataGridView2.RowCount; i++)   //заполнение ComboB Читатели
                {
                    comboBox1.Items.Add(Convert.ToString(dataGridView2[1, i].Value));
                }
            }
        }

        private void delete_dutton_3_Click(object sender, EventArgs e)
        {
            if (textBox15.Text == "")
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
                    controller_3.Delete_item_table(int.Parse(textBox15.Text));
                    dataGridView2.DataSource = controller_3.update_table();

                    textBox15.Clear();
                    comboBox1.Items.Clear();
                    for (int i = 0; i < dataGridView2.RowCount; i++)   //заполнение ComboB Читатели
                    {
                        comboBox1.Items.Add(Convert.ToString(dataGridView2[1, i].Value));
                    }
                }
            }
        }

        private void edit_item_button_3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "" || maskedTextBox1.Text == "" || textBox10.Text == "")
            {
                MessageBox.Show("Ошибка ввода данных. Все поля заполнены должны быть заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                controller_3.edit_item_table_3(int.Parse(textBox10.Text), textBox2.Text, textBox3.Text, maskedTextBox1.Text, dateTimePicker4.Value);
                update_button_3.PerformClick();
                textBox2.Clear();
                textBox3.Clear();
                textBox10.Clear();
                maskedTextBox1.Clear();
            }
        }
        //**********************************************************************************************************************************************




        //*******************************************************************Поступление книг***********************************************************
        private void update_button_4_Click(object sender, EventArgs e)
        {
            dataGridView4.DataSource = controller_4.update_table();
        }

        private void insert_button_4_Click(object sender, EventArgs e)
        {
            if (maskedTextBox5.Text == "" || maskedTextBox3.Text == "" || textBox9.Text == "")
            {
                MessageBox.Show("Ошибка ввода данных. Проверьте все ли поля заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                controller_4.Add_table(textBox9.Text, maskedTextBox5.Text, maskedTextBox3.Text, dateTimePicker3.Value);
                dataGridView4.DataSource = controller_4.update_table();

                maskedTextBox5.Clear();
                maskedTextBox3.Clear();
                textBox9.Clear();

            }
        }

        private void delete_button_4_Click(object sender, EventArgs e)
        {
            if (textBox16.Text == "")
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
                    controller_4.Delete_item_table(int.Parse(textBox16.Text));
                    dataGridView4.DataSource = controller_4.update_table();

                    textBox16.Clear();
                }
            }
        }

        private void edit_item_button_4_Click(object sender, EventArgs e)
        {
            if (maskedTextBox5.Text == "" || maskedTextBox3.Text == "" || textBox9.Text == "" || textBox12.Text == "")
            {
                MessageBox.Show("Ошибка ввода данных. Все поля заполнены должны быть заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
              //  controller_4.edit_item_table_4(int.Parse(textBox7.Text), textBox9.Text, maskedTextBox5.Text, maskedTextBox3.Text, dateTimePicker3.Value);
                controller_4.edit_item_table_4(int.Parse(textBox12.Text), textBox9.Text, maskedTextBox5.Text, maskedTextBox3.Text, dateTimePicker3.Value);
                update_button_4.PerformClick();
                maskedTextBox5.Clear();
                maskedTextBox3.Clear();
                textBox9.Clear();
                textBox12.Clear();
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

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }
        //**********************************************************************************************************************************************

        private void query2_1_button_Click(object sender, EventArgs e)
        {
            Query2_1_Form Q2_1_F = new Query2_1_Form();
            Q2_1_F.Show();
        }
    }
}