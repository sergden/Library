using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Controller
{
    class Query_workers
    {
        OleDbConnection connection;
        OleDbCommand command;
        OleDbDataAdapter dataAdapter;
        DataTable bufferTable;

        public Query_workers(string Conn)
        {
            connection = new OleDbConnection(Conn);
            bufferTable = new DataTable();
        }
        //******************************************************************************Персонал****************************************************************
        public DataTable Update_Table() //метод на обновление данных в таблице
        {
            connection.Open();
            dataAdapter = new OleDbDataAdapter("SELECT * FROM Персонал", connection);
            bufferTable.Clear();
            dataAdapter.Fill(bufferTable);
            connection.Close();
            return bufferTable;
        }

        public void Add_table(string Name, string Address, string Phone, DateTime Date_Birhday, string Salary, int Exp)  //добавление данных в таблицу
        {
            connection.Open();
            command = new OleDbCommand($"INSERT INTO Персонал(ФИО, Адрес, Телефон, Дата_рождения, Зарплата, Стаж) VALUES(@Name, @Address, @Phone, Date_Birhday, @Salary, Exp)", connection);
            command.Parameters.AddWithValue("ФИО", Name);
            command.Parameters.AddWithValue("Адрес", Address);
            command.Parameters.AddWithValue("Телефон", Phone);
            command.Parameters.AddWithValue("Дата_рождения", Date_Birhday);
            command.Parameters.AddWithValue("Зарплата", Salary);
            command.Parameters.AddWithValue("Стаж", Exp);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete_Item_table(int ID)
        {
            connection.Open();
            command = new OleDbCommand($"DELETE FROM Персонал WHERE ID_работника = {ID}", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void edit_item_table(int ID, string Name, string Address, string Phone, DateTime Date_Birhday, string Salary, int Exp)
        {
            connection.Open();
            command = new OleDbCommand($"UPDATE Персонал SET ФИО = @ФИО, Адрес = @Адрес, Телефон = @Телефон, Дата_рождения = Дата_рождения, Зарплата = @Зарплата, Стаж = @Стаж WHERE ID_работника = @ID_работника", connection);
            command.Parameters.AddWithValue("ФИО", Name);
            command.Parameters.AddWithValue("Адрес", Address);
            command.Parameters.AddWithValue("Телефон", Phone);
            command.Parameters.AddWithValue("Дата_рождения", Date_Birhday);
            command.Parameters.AddWithValue("Зарплата", Salary);
            command.Parameters.AddWithValue("Стаж", Exp);
            command.Parameters.AddWithValue("ID_работника", ID);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
