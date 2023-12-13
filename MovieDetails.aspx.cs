using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

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

                    // Load average rating, recent reviews, and all reviews
                    LoadAverageRatingAndReviews(movieId);
                    LoadAllReviews(movieId);
                }
            }
        }

        protected void BtnBookShow_Click(object sender, EventArgs e)
        {
            // Redirect to the BookingPage
            Response.Redirect("Loginpage.aspx");
        }

        protected void BtnSubmitReview_Click(object sender, EventArgs e)
        {
            if (Session["SelectedMovieId"] != null)
            {
                int movieId = Convert.ToInt32(Session["SelectedMovieId"]);
                string reviewComment = txtReviewComment.Text;
                int rating = Convert.ToInt32(ddlRating.SelectedValue);

                // Define your database connection string
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                // Create a SQL Connection and SQL Command to insert the review into the database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string insertReviewQuery = "INSERT INTO Reviews (movie_id, UserID, Rating, Comment, ReviewDate) " +
                                                "VALUES (@movie_id, @userId, @rating, @comment, @reviewDate)";

                    using (SqlCommand insertReviewCommand = new SqlCommand(insertReviewQuery, connection))
                    {
                        insertReviewCommand.Parameters.AddWithValue("@movie_id", movieId);
                        // You need to set the UserID (the user who submits the review)
                        insertReviewCommand.Parameters.AddWithValue("@userId", 1); // Replace with the actual user ID.
                        insertReviewCommand.Parameters.AddWithValue("@rating", rating);
                        insertReviewCommand.Parameters.AddWithValue("@comment", reviewComment);
                        insertReviewCommand.Parameters.AddWithValue("@reviewDate", DateTime.Now);

                        insertReviewCommand.ExecuteNonQuery();
                    }
                }

                // Clear the input fields after submission
                txtReviewComment.Text = "";
                ddlRating.SelectedIndex = 0;

                // Reload the reviews after submission
                LoadAverageRatingAndReviews(movieId);
                LoadAllReviews(movieId);
            }
        }

        protected void LoadAllReviews(int movieId)
        {
            // Define your database connection string
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            // Create a SQL Connection and SQL Command to load all reviews
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string allReviewsQuery = "SELECT R.Rating, R.Comment, U.Username " +
                                        "FROM Reviews R " +
                                        "INNER JOIN Users U ON R.UserID = U.UserID " + // Adjusted column name here
                                        "WHERE R.movie_id = @movieId " +
                                        "ORDER BY R.ReviewDate DESC";

                using (SqlCommand allReviewsCommand = new SqlCommand(allReviewsQuery, connection))
                {
                    allReviewsCommand.Parameters.AddWithValue("@movieId", movieId);

                    SqlDataAdapter adapter = new SqlDataAdapter(allReviewsCommand);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Bind the all reviews to the Repeater control
                    allReviewsRepeater.DataSource = dt;
                    allReviewsRepeater.DataBind();
                }
            }
        }


        protected void LoadAverageRatingAndReviews(int movieId)
        {
            // ... (The code for loading average rating and recent reviews, as previously provided)
        }
    }
}
