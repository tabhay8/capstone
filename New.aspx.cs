using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace MoviePlex
{
    public partial class New : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Define your database connection string
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                // Create a SQL connection and command
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.Text;

                        // SQL query to retrieve upcoming movies
                        command.CommandText = "SELECT * FROM Movies WHERE release_date > GETDATE() ORDER BY release_date";

                        // Open the database connection
                        connection.Open();

                        // Create a data adapter and data table to retrieve data
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();

                        // Fill the data table with the results of the SQL query
                        adapter.Fill(dataTable);

                        // Bind the data table to the Repeater
                        MoviesRepeater.DataSource = dataTable;
                        MoviesRepeater.DataBind();

                        // Close the database connection
                        connection.Close();
                    }
                }
            }
        }
    }
}
