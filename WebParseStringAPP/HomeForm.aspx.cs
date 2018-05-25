using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace WebParseStringAPP
{
    public partial class HomeForm : System.Web.UI.Page
    {   
        private string text_from_File;

        protected void Page_Load(object sender, EventArgs e)
        {
            string connection_string = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 
                                               C:\Users\VikToR\source\repos\WebParseStringAPP\WebParseStringAPP\App_Data\StringDatabase.mdf;
                                                       Integrated Security = True";
            SqlConnection mydb = new SqlConnection(connection_string);
            mydb.Open();
            SqlCommand databCommand = new SqlCommand();
            databCommand.CommandText = "select * from StringTable";
            databCommand.Connection = mydb;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(databCommand);
            DataTable dbf = new DataTable();
            dataAdapter.Fill(dbf);

            ListBox1.Items.Clear();
            for (int i = 0; i < dbf.Rows.Count; i++)
                ListBox1.Items.Add(dbf.Rows[i]["number_of_words"].ToString() + ": " + dbf.Rows[i]["Sentence"].ToString());
            mydb.Close();
        }

        protected void ReadTextFromFile(object sender, EventArgs e)
        {
           
            if (FileUpload1.HasFile)
            {
                ParseText searching = new ParseText();
                Stream test = FileUpload1.FileContent;
                StreamReader inputStreamReader = new StreamReader(FileUpload1.PostedFile.InputStream);
                text_from_File = inputStreamReader.ReadToEnd();
                
            

                searching.GetSentence(text_from_File, TextBox1.Text);
                int count = 0;
                foreach (string a in searching.Sentence_colection)
                {
                    string connection_string = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 
                                               C:\Users\VikToR\source\repos\WebParseStringAPP\WebParseStringAPP\App_Data\StringDatabase.mdf;
                                                       Integrated Security = True";
                    SqlConnection DataSconnect = new SqlConnection(connection_string);

                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT StringTable (Sentence,number_of_words) VALUES ('" + searching.String_Convert(a) + "','" + searching.Word_count[count] + "')";

                    command.Connection = DataSconnect;
                    DataSconnect.Open();
                    command.ExecuteNonQuery();
                    DataSconnect.Close();
                    count++;
                }

                ReloadData();
          }     
            
        
        }
        protected void ClearDataBase(object sender, EventArgs e)
        {
            string connection_string = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 
                                               C:\Users\VikToR\source\repos\WebParseStringAPP\WebParseStringAPP\App_Data\StringDatabase.mdf;
                                                       Integrated Security = True";
            SqlConnection DataSconnect =
               new SqlConnection(connection_string);

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "Delete from StringTable";
            command.Connection = DataSconnect;

            DataSconnect.Open();
            command.ExecuteNonQuery();
            DataSconnect.Close();
        }

        private void ReloadData()
        {
            string connection_string = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 
                                               C:\Users\VikToR\source\repos\WebParseStringAPP\WebParseStringAPP\App_Data\StringDatabase.mdf;
                                                       Integrated Security = True";
            SqlConnection mydb = new SqlConnection(connection_string);
            mydb.Open();
            SqlCommand databCommand = new SqlCommand();
            databCommand.CommandText = "select * from StringTable";
            databCommand.Connection = mydb;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(databCommand);
            DataTable dbf = new DataTable();
            dataAdapter.Fill(dbf);

            ListBox1.Items.Clear();
            for (int i = 0; i < dbf.Rows.Count; i++)
                ListBox1.Items.Add(dbf.Rows[i]["number_of_words"].ToString() + ": " + dbf.Rows[i]["Sentence"].ToString());
            mydb.Close();
        }

    }
}