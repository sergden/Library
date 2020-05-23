using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace WindowsFormsApp1.Controller
{
    class Query2
    {
        OleDbConnection connection;
        OleDbCommand command;
        OleDbDataAdapter dataAdapter;
        DataTable bufferTable;

        public Query2(string Conn)
        {
            connection = new OleDbConnection(Conn);
            bufferTable = new DataTable();
        }


        //*******************************************************************Выдача книг*********************************************************************************************************
        public DataTable update_table()
        {
            connection.Open();
            dataAdapter = new OleDbDataAdapter("SELECT * FROM Выдача", connection);
            bufferTable.Clear();
            dataAdapter.Fill(bufferTable);
            connection.Close();
            return bufferTable;
        }

        public void Add_table(string Name_Book, string Name_Reader, string Name_worker, DateTime Date_Give, DateTime Date_Return, string Status)  //добавление данных в таблицу
        {
            connection.Open();
            command = new OleDbCommand($"INSERT INTO Выдача(Название_книги, ФИО_читателя, ФИО_работника, Дата_выдачи, Дата_возврата, Статус) VALUES(@Name_Book, @Name_Reader, @Name_worker, Date_Give, Date_Return, @Status)", connection);
            command.Parameters.AddWithValue("Название_книги", Name_Book);
            command.Parameters.AddWithValue("ФИО_читателя", Name_Reader);
            command.Parameters.AddWithValue("ФИО_работника", Name_worker);
            command.Parameters.AddWithValue("Дата_выдачи", Date_Give);
            command.Parameters.AddWithValue("Дата_возврата", Date_Return);
            command.Parameters.AddWithValue("Статус", Status);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete_Item_table(int ID)
        {
            connection.Open();
            command = new OleDbCommand($"DELETE FROM Выдача WHERE ID_выдачи = {ID}", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void edit_item_table_2(int ID, string Name_Book, string Name_Reader, string Name_worker, DateTime Date_Give, DateTime Date_Return, string Status)
        {
            connection.Open();
            command = new OleDbCommand($"UPDATE Выдача SET Название_книги=@Название_книги, ФИО_читателя=@ФИО_читателя, ФИО_работника=@ФИО_работника, Дата_выдачи=@Дата_выдачи, Дата_возврата=@Дата_возврата, Статус=@Статус WHERE ID_выдачи=@ID_выдачи", connection);
            command.Parameters.AddWithValue("Название_книги", Name_Book);
            command.Parameters.AddWithValue("ФИО_читателя", Name_Reader);
            command.Parameters.AddWithValue("ФИО_работника", Name_worker);
            command.Parameters.AddWithValue("Дата_выдачи", Date_Give);
            command.Parameters.AddWithValue("Дата_возврата", Date_Return);
            command.Parameters.AddWithValue("Статус", Status);
            command.Parameters.AddWithValue("ID_выдачи", ID);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
