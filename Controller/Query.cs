using System.Data;
using System.Data.OleDb;

namespace WindowsFormsApp1.Controller
{
    class Query
    {
        OleDbConnection connection;
        OleDbCommand command;
        OleDbDataAdapter dataAdapter;
        DataTable bufferTable;

        public Query(string Conn)
        {
            connection = new OleDbConnection(Conn);
            bufferTable = new DataTable();
        }

        //******************************************************************************Книжный фонд*********************************************************************************************************
        public DataTable Update_Table_1() //метод на обновление данных в таблице 1
        {
            connection.Open();
            dataAdapter = new OleDbDataAdapter("SELECT * FROM Книжный_фонд", connection);
            bufferTable.Clear();
            dataAdapter.Fill(bufferTable);
            connection.Close();
            return bufferTable;
        }

        public void Add_table_1(string Name_Book, string Author, int Year, string Publisher)  //добавление данных в таблицу
        {
            connection.Open();
            command = new OleDbCommand($"INSERT INTO Книжный_фонд(Название, Автор, Год_Издания, Издательсво) VALUES(@Name_Book, @Author, @Year, @Publisher)", connection);
            command.Parameters.AddWithValue("Название", Name_Book);
            command.Parameters.AddWithValue("Автор", Author);
            command.Parameters.AddWithValue("Год_Издания", Year);
            command.Parameters.AddWithValue("Издательсво", Publisher);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete_Item_table_1(int ID)
        {
            connection.Open();
            command = new OleDbCommand($"DELETE FROM Книжный_фонд WHERE ID_книги = {ID}", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }


        public void Update_item_table_1(int ID, string Name_Book, string Author, string Year, string Publisher)
        {
            connection.Open();
            command = new OleDbCommand($"UPDATE Книжный_фонд SET Название=@Название, Автор=@Автор, Год_Издания=@Год_Издания, Издательсво=@Издательсво  WHERE ID_книги=@ID_книги", connection);
            command.Parameters.AddWithValue("Название", Name_Book);
            command.Parameters.AddWithValue("Автор", Author);
            command.Parameters.AddWithValue("Год_Издания", Year);
            command.Parameters.AddWithValue("Издательсво", Publisher);
            command.Parameters.AddWithValue("ID_книги", ID);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
