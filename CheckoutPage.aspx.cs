using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.IO;
using System.Web.UI;
using iText.Barcodes.Qrcode;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using ZXing;
using ZXing.Common;

namespace MoviePlex
{
    public partial class CheckoutPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenerateCaptcha();

                // Display the retrieved information on the page
                DisplayTicketDetails();
            }
        }

        protected void BtnRefreshCaptcha_Click(object sender, EventArgs e)
        {
            // Refresh the CAPTCHA
            GenerateCaptcha();
        }

        private int GenerateUniqueBookingID()
        {
            // Generate a unique booking ID (you can customize this logic based on your requirements)
            // For simplicity, I'm using a random number in this example
            Random random = new Random();
            return random.Next(100000, 999999);
        }

        private void StoreBookingInDatabase(int bookingID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Add other columns related to booking details in the INSERT statement
                string insertQuery = "INSERT INTO Booking (BookingID) VALUES (@BookingID)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@BookingID", bookingID);

                    // Add other parameters for additional booking details

                    cmd.ExecuteNonQuery();
                }
            }
        }

        protected void BtnCheckout_Click(object sender, EventArgs e)
        {
            // Verify the CAPTCHA
            if (VerifyCaptcha())
            {
                // CAPTCHA is correct, proceed with checkout logic
                lblCheckoutInfo.Text = "CAPTCHA verification successful. Proceeding with checkout.";

                int bookingID = GenerateUniqueBookingID();

                // Store the booking information in the database
                StoreBookingInDatabase(bookingID);

                // Generate and download the HTML ticket
                GenerateHtmlTicket();

                // Display the retrieved information on the page
                DisplayTicketDetails();
            }
            else
            {
                // CAPTCHA is incorrect, display an error message
                lblCheckoutInfo.Text = "CAPTCHA verification failed. Please try again.";
            }
        }

        private void DisplayTicketDetails()
        {
            string selectedButtons = Request.QueryString["selectedButtons"];
            string selectedTheaterId = Request.QueryString["theaterId"];
            string selectedShowTiming = Request.QueryString["showTiming"];
            string selectedAuditorium = Request.QueryString["auditorium"];
            string selectedDate = Request.QueryString["selectedDate"];
            string theaterName = Request.QueryString["theaterName"];

            // Display the retrieved information on the page
            lblSelectedButtons.Text = $"Selected Toggle Buttons: {selectedButtons}";
            lblTheaterId.Text = $"Theater ID: {selectedTheaterId}";
            lblShowTiming.Text = $"Show Timing: {selectedShowTiming}";
            lblAuditorium.Text = $"Auditorium: {selectedAuditorium}";
            lblSelectedDate.Text = $"Selected Date: {selectedDate}";
            lblTheaterName.Text = $"Theater Name: {theaterName}";
        }

        private void GenerateCaptcha()
        {
            // Generate a random CAPTCHA (you can customize this logic)
            Random random = new Random();
            string captcha = random.Next(1000, 9999).ToString();

            // Store the CAPTCHA in a session variable for verification
            Session["Captcha"] = captcha;

            // Display the CAPTCHA in the TextBox
            txtCaptcha.Text = captcha;
        }

        protected void BtnPayPal_Click(object sender, EventArgs e)
        {
            // Redirect to PayPal payment page
            Response.Redirect("https://www.paypal.com");
        }

        protected void BtnOnlineBanking_Click(object sender, EventArgs e)
        {
            // Redirect to online banking payment page
            Response.Redirect("https://www.yourbank.com/online-banking");
        }

        private bool VerifyCaptcha()
        {
            // Get the user's input from the TextBox
            string userEnteredCaptcha = txtUserEnteredCaptcha.Text;

            // Get the stored CAPTCHA from the session
            string storedCaptcha = Session["Captcha"] as string;

            // Compare the user's input with the stored CAPTCHA
            return userEnteredCaptcha == storedCaptcha;
        }

        private void GenerateHtmlTicket()
        {
            string selectedButtons = Request.QueryString["selectedButtons"];
            string selectedTheaterId = Request.QueryString["theaterId"];
            string selectedShowTiming = Request.QueryString["showTiming"];
            string selectedAuditorium = Request.QueryString["auditorium"];
            string selectedDate = Request.QueryString["selectedDate"];
            string theaterName = Request.QueryString["theaterName"];

            var htmlContent = $@"
        <html>
        <head>
            <title>Movie Ticket</title>
        </head>
        <body>
            <h1>Movie Ticket</h1>
            <p>Selected Toggle Buttons: {selectedButtons}</p>
            <p>Theater ID: {selectedTheaterId}</p>
            <p>Show Timing: {selectedShowTiming}</p>
            <p>Auditorium: {selectedAuditorium}</p>
            <p>Selected Date: {selectedDate}</p>
            <p>Theater Name: {theaterName}</p>
            <p>Booking ID: {GetBookingIDFromDatabase()}</p>
            <img src='data:image/png;base64,{GenerateQRCodeBase64()}'>
        </body>
        </html>
    ";

            // Save HTML content to a file or send it directly to the response
            Response.Clear();
            Response.ContentType = "text/html";
            Response.Write(htmlContent);
            Response.End();
        }

        private string GenerateQRCodeBase64()
        {
            // Generate your QR code and convert it to base64
            // Example using ZXing.Net
            var writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            var qrCodeBitmap = writer.Write("Your QR Code Content");

            using (MemoryStream ms = new MemoryStream())
            {
                qrCodeBitmap.Save(ms, ImageFormat.Png);
                byte[] byteImage = ms.ToArray();
                return Convert.ToBase64String(byteImage);
            }
        }

        private int GetBookingIDFromDatabase()
        {
            int bookingID = 0; // Default value

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string selectQuery = "SELECT TOP 1 BookingID FROM Booking ORDER BY BookingID DESC";

                    using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Retrieve the booking ID from the database
                                bookingID = Convert.ToInt32(reader["BookingID"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (log, display, etc.)
                Console.WriteLine("Error retrieving booking ID from the database: " + ex.Message);
            }

            return bookingID;
        }
    }
}
