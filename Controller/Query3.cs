using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace WindowsFormsApp1.Controller
{
    class Query3
    {
        OleDbConnection connection;
        OleDbCommand command;
        OleDbDataAdapter dataAdapter;
        DataTable bufferTable;

        public Query3(string Conn)
        {
            connection = new OleDbConnection(Conn);
            bufferTable = new DataTable();
        }

        //*******************************************************************Читатели******************************************************************************************
        public DataTable update_table()
        {
            connection.Open();
            dataAdapter = new OleDbDataAdapter("SELECT * FROM Клиенты", connection);
            bufferTable.Clear();
            dataAdapter.Fill(bufferTable);
            connection.Close();
            return bufferTable;
        }

        public void Add_table(string Name_Reader, string Adress, string Phone, DateTime Date_Birthday)  //добавление данных в таблицу
        {
            connection.Open();
            command = new OleDbCommand($"INSERT INTO Клиенты(ФИО, Адрес, Телефон, Дата_рождения) VALUES(@Name_Reader, @Adress, @Phone, Date_Birthday)", connection);
            command.Parameters.AddWithValue("ФИО", Name_Reader);
            command.Parameters.AddWithValue("Адрес", Adress);
            command.Parameters.AddWithValue("Телефон", Phone);
            command.Parameters.AddWithValue("Дата_рождения", Date_Birthday);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete_item_table (int ID)
        {
            connection.Open();
            command = new OleDbCommand($"DELETE FROM Клиенты WHERE ID_клиента = {ID}", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void edit_item_table_3(int ID, string Name_Reader, string Adress, string Phone, DateTime Date_Birthday)
        {
            connection.Open();
            command = new OleDbCommand($"UPDATE Клиенты SET ФИО=@ФИО, Адрес=@Адрес, Телефон=@Телефон, Дата_рождения=@Дата_рождения WHERE ID_клиента=@ID_клиента", connection);
            command.Parameters.AddWithValue("ФИО", Name_Reader);
            command.Parameters.AddWithValue("Адрес", Adress);
            command.Parameters.AddWithValue("Телефон", Phone);
            command.Parameters.AddWithValue("Дата_рождения", Date_Birthday);
            command.Parameters.AddWithValue("ID_клиента", ID);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
