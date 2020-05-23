using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace WindowsFormsApp1.Controller
{
    class Query2_1
    {
        OleDbConnection connection;
        OleDbCommand command;
        OleDbDataAdapter dataAdapter;
        DataTable bufferTable;

        public Query2_1(string Conn)
        {
            connection = new OleDbConnection(Conn);
            bufferTable = new DataTable();
        }

        public DataTable Select_from_table()
        {
            connection.Open();
            dataAdapter = new OleDbDataAdapter("SELECT ID_выдачи, Название_книги, ФИО_читателя, Дата_выдачи, Дата_возврата FROM Выдача WHERE Статус = " + "\"Выдана\"", connection);;
            bufferTable.Clear();
            dataAdapter.Fill(bufferTable);
            connection.Close();
            return bufferTable; 
        }
    }
}
