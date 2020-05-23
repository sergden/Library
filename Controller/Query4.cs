using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace WindowsFormsApp1.Controller
{
    class Query4
    {
        OleDbConnection connection;
        OleDbCommand command;
        OleDbDataAdapter dataAdapter;
        DataTable bufferTable;

        public Query4(string Conn)
        {
            connection = new OleDbConnection(Conn);
            bufferTable = new DataTable();
        }

        //*******************************************************************Поступление книг******************************************************************************************
        public DataTable update_table()
        {
            connection.Open();
            dataAdapter = new OleDbDataAdapter("SELECT * FROM Поставки", connection);
            bufferTable.Clear();
            dataAdapter.Fill(bufferTable);
            connection.Close();
            return bufferTable;
        }

        public void Add_table(string Publisher, string Name_book, string Author, DateTime Date_Delivery)  //добавление данных в таблицу
        {
            connection.Open();
            command = new OleDbCommand($"INSERT INTO Поставки(Издательсво, Название, Автор, Дата_поставки) VALUES(@Publisher, @Name_book, @Author, Date_Delivery)", connection);
            command.Parameters.AddWithValue("Издательсво", Publisher);
            command.Parameters.AddWithValue("Название", Name_book);
            command.Parameters.AddWithValue("Автор", Author);
            command.Parameters.AddWithValue("Дата_поставки", Date_Delivery);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete_item_table(int ID)
        {
            connection.Open();
            command = new OleDbCommand($"DELETE FROM Поставки WHERE ID_поставки = {ID}", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void edit_item_table_4(int ID, string Publisher, string Name_book, string Author, DateTime Date_Delivery)
        {
            connection.Open();
            command = new OleDbCommand($"UPDATE Поставки SET Издательсво=@Издательсво, Название=@Название, Автор=@Автор, Дата_поставки=@Дата_поставки WHERE ID_поставки=@ID_поставки", connection);
            command.Parameters.AddWithValue("Издательсво", Publisher);
            command.Parameters.AddWithValue("Название", Name_book);
            command.Parameters.AddWithValue("Автор", Author);
            command.Parameters.AddWithValue("Дата_поставки", Date_Delivery);
            command.Parameters.AddWithValue("ID_поставки", ID);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
