using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Web.UI.WebControls;

namespace MoviePlex
{
    public partial class BookingPage : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            int selectedTheaterId = 0; // Declare outside of the if block

            if (!IsPostBack)
            {
                // Retrieve the selected movieId from the session variable
                if (Session["SelectedMovieId"] != null)
                {
                    int selectedMovieId = (int)Session["SelectedMovieId"];

                    // Define your database connection string
                    string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                    // Populate the theaters dropdown with available theaters for the selected movie
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand theaterCmd = new SqlCommand("SELECT [theatre_id], [name] FROM [dbo].[Theatres] " +
                                                             "WHERE [theatre_id] IN (SELECT DISTINCT [theatre_id] FROM [dbo].[TheatreTimings] WHERE [movie_id] = @movieId)", conn);
                        theaterCmd.Parameters.AddWithValue("@movieId", selectedMovieId);
                        SqlDataAdapter theaterDa = new SqlDataAdapter(theaterCmd);
                        DataTable theaterDt = new DataTable();
                        theaterDa.Fill(theaterDt);

                        ddlTheaters.DataSource = theaterDt;
                        ddlTheaters.DataTextField = "name";
                        ddlTheaters.DataValueField = "theatre_id";

                        ddlTheaters.DataBind();
                    }

                    // Populate the show timings dropdown with available show timings for the selected movie
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand timingCmd = new SqlCommand("SELECT DISTINCT [timing_slot] FROM [dbo].[TheatreTimings] " +
                                                             "WHERE [movie_id] = @movieId", conn);
                        timingCmd.Parameters.AddWithValue("@movieId", selectedMovieId);
                        SqlDataAdapter timingDa = new SqlDataAdapter(timingCmd);
                        DataTable timingDt = new DataTable();
                        timingDa.Fill(timingDt);

                        ddlShowTimings.DataSource = timingDt;
                        ddlShowTimings.DataTextField = "timing_slot";
                        ddlShowTimings.DataValueField = "timing_slot";
                        ddlShowTimings.DataBind();
                    }

                    // Populate the auditorium dropdown with available auditoriums for the selected movie and theater
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand auditoriumCmd = new SqlCommand("SELECT DISTINCT [auditorium] FROM [dbo].[TheatreTimings] " +
                                                                 "WHERE [movie_id] = @movieId AND [theatre_id] = @theaterId", conn);
                        auditoriumCmd.Parameters.AddWithValue("@movieId", selectedMovieId);

                        // Assign selectedTheaterId here
                        selectedTheaterId = Convert.ToInt32(ddlTheaters.SelectedValue);

                        auditoriumCmd.Parameters.AddWithValue("@theaterId", selectedTheaterId);
                        SqlDataAdapter auditoriumDa = new SqlDataAdapter(auditoriumCmd);
                        DataTable auditoriumDt = new DataTable();
                        auditoriumDa.Fill(auditoriumDt);

                        ddlAuditorium.DataSource = auditoriumDt;
                        ddlAuditorium.DataTextField = "auditorium";
                        ddlAuditorium.DataValueField = "auditorium";
                        ddlAuditorium.DataBind();
                    }
                }
            }
        }


        protected void calendar_DayRender(object sender, DayRenderEventArgs e)
        {
            // Example: Disable past dates
            if (e.Day.Date < DateTime.Today)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Gray;
            }

            // You can add more custom logic here to style or disable specific dates.
        }


        protected void BtnConfirmBooking_Click(object sender, EventArgs e)
        {
            // Get the selected theater and show timing
            int selectedTheaterId = Convert.ToInt32(ddlTheaters.SelectedValue);
            string selectedShowTiming = ddlShowTimings.SelectedValue;

            // Inside BtnConfirmBooking_Click

            // Get the selected auditorium, theater, and show timing
            string selectedAuditorium = ddlAuditorium.SelectedValue;
            string selectedDate = calendar.SelectedDate.ToShortDateString();
            // Get the theater name
            string selectedTheaterName = ddlTheaters.SelectedItem.Text;

            // Redirect to a confirmation page or perform other booking-related actions
            Response.Redirect($"SeatMatrix.aspx?theaterName={selectedTheaterName}&theaterId={selectedTheaterId}&showTiming={selectedShowTiming}&auditorium={selectedAuditorium}&selectedDate={selectedDate}");
        }
    }
}
