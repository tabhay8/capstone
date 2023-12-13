using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MoviePlex
{
    public partial class MovieDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["movieId"] != null)
                {
                    int movieId = Convert.ToInt32(Request.QueryString["movieId"]);

                    // Define your database connection string
                    string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                    // Create a SQL Connection and SQL Command to retrieve movie details
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = "SELECT * FROM Movies WHERE movie_id = @movieId";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@movieId", movieId);

                            SqlDataReader reader = command.ExecuteReader();

                            if (reader.Read())
                            {
                                // Populate the labels with movie details
                                lblTitle.Text = reader["title"].ToString();
                                lblDuration.Text = reader["duration"].ToString();
                                lblDescription.Text = reader["description"].ToString();
                                lblGenre.Text = reader["genre"].ToString();
                                lblReleaseDate.Text = reader["release_date"].ToString();
                                lblDirector.Text = reader["director"].ToString();
                                imgPoster.ImageUrl = reader["poster_url"].ToString();
                            }

                            reader.Close();
                        }
                    }

                    // Store the movieId in a session variable for later use on the BookingPage
                    Session["SelectedMovieId"] = movieId;
                }
            }
        }

        protected void BtnBookShow_Click(object sender, EventArgs e)
        {
            // Redirect to the BookingPage
            Response.Redirect("Loginpage.aspx");
        }
    }
}
