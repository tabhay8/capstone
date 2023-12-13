using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace MoviePlex
{
    public partial class FoodCheckoutPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenerateCaptcha();
            }
        }

        protected void BtnRefreshCaptcha_Click(object sender, EventArgs e)
        {
            // Refresh the CAPTCHA
            GenerateCaptcha();
        }

        protected void BtnVerifyBookingID_Click(object sender, EventArgs e)
        {
            // Verify the Booking ID
            if (VerifyBookingID())
            {
                // Booking ID is correct, display a success message
                lblBookingVerificationResult.Text = "Booking ID verification successful.";
            }
            else
            {
                // Booking ID is incorrect, display an error message
                lblBookingVerificationResult.Text = "Booking ID verification failed. Please try again.";
            }
        }

        protected void BtnFoodCheckout_Click(object sender, EventArgs e)
        {
            // Verify the CAPTCHA and Booking ID
            if (VerifyCaptcha() && VerifyBookingID())
            {
                // CAPTCHA and Booking ID are correct, proceed with food checkout logic
                lblFoodCheckoutInfo.Text = "CAPTCHA and Booking ID verification successful. Proceeding with food checkout.";

                // Implement your food checkout logic here

                // Display the retrieved information on the page
                DisplayFoodOrderDetails();
                Response.Redirect("FoodOrderSuccessPage.aspx");
            }
            else
            {
                // CAPTCHA or Booking ID is incorrect, display an error message
                lblFoodCheckoutInfo.Text = "CAPTCHA or Booking ID verification failed. Please try again.";
            }
        }

        private void DisplayFoodOrderDetails()
        {
            // Implement the logic to display food order details on the page
            // Example: Retrieve data from controls like txtFoodItem, txtQuantity, etc.
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

        private bool VerifyCaptcha()
        {
            // Get the user's input from the TextBox
            string userEnteredCaptcha = txtUserEnteredCaptcha.Text;

            // Get the stored CAPTCHA from the session
            string storedCaptcha = Session["Captcha"] as string;

            // Compare the user's input with the stored CAPTCHA
            return userEnteredCaptcha == storedCaptcha;
        }

        // ...

        private bool VerifyBookingID()
        {
            // Get the user's input from the TextBox
            string userEnteredBookingID = txtBookingID.Text;

            // Retrieve the stored Booking ID from the database
            int storedBookingID = GetBookingIDFromDatabase(userEnteredBookingID);

            // Compare the user's input with the stored Booking ID
            return userEnteredBookingID == storedBookingID.ToString();
        }

        // ...


        private int GetBookingIDFromDatabase(string userEnteredBookingID)
        {
            int storedBookingID = 0;

            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT BookingID FROM Booking WHERE BookingID = @UserEnteredBookingID";

                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@UserEnteredBookingID", userEnteredBookingID);

                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        storedBookingID = Convert.ToInt32(result);
                    }
                }
            }

            return storedBookingID;
        }

    }
}
