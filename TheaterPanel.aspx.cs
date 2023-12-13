using System;
using System.Configuration;
using System.Data.SqlClient;

namespace MoviePlex
{
    public partial class TheaterPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadTheaters();
            LoadMovies();
        }
        private void LoadTheaters()
        {
            // Load theaters from the database and bind to the dropdown list
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT theatre_id, name FROM Theatres";
                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        ddlTheater.DataSource = reader;
                        ddlTheater.DataTextField = "name";
                        ddlTheater.DataValueField = "theatre_id";
                        ddlTheater.DataBind();
                    }
                }
            }
        }
        private void LoadMovies()
        {
            // Load movies from the database and bind to the dropdown list
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT movie_id, title FROM Movies";
                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        ddlMovie.DataSource = reader;
                        ddlMovie.DataTextField = "title";
                        ddlMovie.DataValueField = "movie_id";
                        ddlMovie.DataBind();
                    }
                }
            }
        }
        protected void btnAddTiming_Click(object sender, EventArgs e)
        {
            // Validate and add theater timing to the database
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                int theaterId = int.Parse(ddlTheater.SelectedValue);
                int auditorium = int.Parse(txtAuditorium.Text);
                int movieId = int.Parse(ddlMovie.SelectedValue);
                string timingSlot = txtTimingSlot.Text;

                string insertQuery = "INSERT INTO TheatreTimings (theatre_id, auditorium, movie_id, timing_slot) VALUES (@TheaterId, @Auditorium, @MovieId, @TimingSlot)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@TheaterId", theaterId);
                    cmd.Parameters.AddWithValue("@Auditorium", auditorium);
                    cmd.Parameters.AddWithValue("@MovieId", movieId);
                    cmd.Parameters.AddWithValue("@TimingSlot", timingSlot);

                    cmd.ExecuteNonQuery();

                    // Optionally, you can display a success message or redirect to another page
                    Response.Write("Theater timing added successfully!");
                }
            }
        }

        protected void btnAddTheater_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO Theatres (name, location, total_seats) VALUES (@Name, @Location, @TotalSeats)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", txtTheaterName.Text);
                    cmd.Parameters.AddWithValue("@Location", txtLocation.Text);
                    
                    // Check if the total_seats input is a valid integer
                    int totalSeats;
                    if (int.TryParse(txtTotalSeats.Text, out totalSeats))
                    {
                        cmd.Parameters.AddWithValue("@TotalSeats", totalSeats);

                        // Execute the query
                        cmd.ExecuteNonQuery();
                        
                        // Optionally, you can display a success message or redirect to another page
                        Response.Write("Theater added successfully!");
                    }
                    else
                    {
                        // Display an error message for invalid total seats input
                        Response.Write("Invalid total seats. Please enter a valid integer.");
                    }
                }
            }
        }
    }
}
