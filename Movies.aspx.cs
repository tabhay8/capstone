using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace MoviePlex
{
    public partial class Movies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Define your database connection string
                string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                // Create a SQL Connection and SQL Command
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Movies"; // Replace with your table name

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Bind the movie data to the Repeater control
                        MovieRepeater.DataSource = dt;
                        MovieRepeater.DataBind();
                    }
                }
            }

        }
        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            string searchKeyword = txtSearch.Text;

            // Define your database connection string
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            // Create a SQL Connection and SQL Command
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Movies WHERE title LIKE @searchKeyword";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@searchKeyword", "%" + searchKeyword + "%"); // Use "%" for wildcard search

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Check if any results were found
                    if (dt.Rows.Count > 0)
                    {
                        // Bind the movie data to the data control on your page
                        MovieRepeater.DataSource = dt;
                        MovieRepeater.DataBind();

                        // Hide the "No results found" message
                        lblNoResults.Visible = false;
                        notFound.Visible = false;
                    }
                    else
                    {
                        // No results found, display the message
                        lblNoResults.Visible = true;
                        notFound.Visible = true; 

                        // Clear the data control
                        MovieRepeater.DataSource = null;
                        MovieRepeater.DataBind();
                    }
                }
            }
        }

    }
}
