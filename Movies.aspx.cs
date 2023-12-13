using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;

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

                    // Fetch distinct genres from the Movies table
                    string genreQuery = "SELECT DISTINCT genre FROM Movies";
                    using (SqlCommand genreCommand = new SqlCommand(genreQuery, connection))
                    {
                        SqlDataAdapter genreAdapter = new SqlDataAdapter(genreCommand);
                        DataTable genreDataTable = new DataTable();
                        genreAdapter.Fill(genreDataTable);

                        // Bind the genres to the dropdown list
                        ddlGenres.DataSource = genreDataTable;
                        ddlGenres.DataTextField = "genre";
                        ddlGenres.DataValueField = "genre";
                        ddlGenres.DataBind();

                        // Add an "All" option to show all genres initially
                        ddlGenres.Items.Insert(0, new ListItem("All", ""));
                    }

                    // Fetch all movies initially
                    string movieQuery = "SELECT * FROM Movies WHERE release_date <= GETDATE()";
                    using (SqlCommand command = new SqlCommand(movieQuery, connection))
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
            string selectedGenre = ddlGenres.SelectedValue;

            // Define your database connection string
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            // Create a SQL Connection and SQL Command
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Construct the SQL query with genre filtering
                string query = "SELECT * FROM Movies WHERE title LIKE @searchKeyword AND release_date <= GETDATE()";
                if (!string.IsNullOrEmpty(selectedGenre))
                {
                    query += " AND genre = @genre";
                }

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@searchKeyword", "%" + searchKeyword + "%"); // Use "%" for wildcard search
                    if (!string.IsNullOrEmpty(selectedGenre))
                    {
                        command.Parameters.AddWithValue("@genre", selectedGenre);
                    }

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
