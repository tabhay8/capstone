using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MoviePlex
{
    public partial class AdminDashboard : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Load the movies when the page loads
                LoadMovies();
            }
        }

        protected void LoadMovies()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT * FROM Movies";
                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Bind the data to a GridView or other data control on your page
                        MoviesGridView.DataSource = dt;
                        MoviesGridView.DataBind();
                    }
                }
            }
        }
        protected void LogoutButton_Click(object sender, EventArgs e)
        {


            // Redirect to the login page (adjust the URL as needed)
            Response.Redirect("Home.aspx");
        }
        protected void TheaterTimings_Click(object sender, EventArgs e)
        {


            // Redirect to the login page (adjust the URL as needed)
            Response.Redirect("TheaterPanel.aspx");
        }

        protected void AddMovieButton_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO Movies (title, genre, release_date, description, duration, director, poster_url) " +
                    "VALUES (@Title, @Genre, @ReleaseDate, @Description, @Duration, @Director, @PosterURL)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@Title", TitleTextBox.Text);
                    cmd.Parameters.AddWithValue("@Genre", GenreTextBox.Text);
                    cmd.Parameters.AddWithValue("@ReleaseDate", ReleaseDateTextBox.Text);
                    cmd.Parameters.AddWithValue("@Description", DescriptionTextBox.Text);
                    cmd.Parameters.AddWithValue("@Duration", Convert.ToInt32(DurationTextBox.Text));
                    cmd.Parameters.AddWithValue("@Director", DirectorTextBox.Text);

                    if (PosterUpload.HasFile)
                    {
                        string fileName = PosterUpload.FileName;
                        string serverPath = Server.MapPath("~/Images/Movies/");
                        string posterPath = serverPath + fileName;
                        PosterUpload.SaveAs(posterPath);

                        // Store the poster URL in the database
                        string posterUrl = "/Images/Movies/" + fileName;
                        cmd.Parameters.AddWithValue("@PosterURL", posterUrl);
                    }

                    cmd.ExecuteNonQuery();
                }
            }

            // Refresh the movies list after adding a new movie
            LoadMovies();
        }


        protected void MoviesGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int movieId = Convert.ToInt32(MoviesGridView.DataKeys[e.RowIndex].Value);

            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string deleteQuery = "DELETE FROM Movies WHERE movie_id = @MovieId";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@MovieId", movieId);
                    cmd.ExecuteNonQuery();
                }
            }

            // Refresh the movies list after deleting a movie
            LoadMovies();
        }





    }




}

