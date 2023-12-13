using System;
using System.Web.UI;

namespace MoviePlex
{
    public partial class CartPage : Page
    {
        // Define the price per seat
        private const decimal PricePerSeat = 50;

        protected void Page_Load(object sender, EventArgs e)
        {
            string selectedButtons = Request.QueryString["selectedButtons"];
            string selectedTheaterId = Request.QueryString["theaterId"];
            string selectedShowTiming = Request.QueryString["showTiming"];
            string selectedAuditorium = Request.QueryString["auditorium"];
            string selectedDate = Request.QueryString["selectedDate"];
            string theaterName = Request.QueryString["theaterName"];

            if (!string.IsNullOrEmpty(selectedButtons))
            {
                // Display selected toggle buttons on the CartPage
                selectedButtonsLabel.Text = $"Selected Toggle Buttons: {selectedButtons}";
            }

            // Display other details
            lblTheaterId.Text = $"Theater ID: {selectedTheaterId}";
            lblShowTiming.Text = $"Show Timing: {selectedShowTiming}";
            lblAuditorium.Text = $"Auditorium: {selectedAuditorium}";
            lblSelectedDate.Text = $"Selected Date: {selectedDate}";
            lblTheaterName.Text = $"Theater Name: {theaterName}";

            // Calculate and display the total price
            int numberOfSeats = CountSeats(selectedButtons);
            decimal totalPrice = numberOfSeats * PricePerSeat;
            lblTotalPrice.Text = $"Total Price: {totalPrice:C}";
        }

        // Helper method to count the number of seats based on the selected buttons
        private int CountSeats(string selectedButtons)
        {
            // Implement your logic to count the seats based on the selected buttons
            // For example, you might count the number of occurrences of "Seat" in the selectedButtons string
            // Here, we assume that each "Seat" in the string represents one seat
            return selectedButtons.Split(new[] { "Seat" }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        protected void BtnCheckout_Click(object sender, EventArgs e)
        {
            string url = $"CheckoutPage.aspx?selectedButtons={Request.QueryString["selectedButtons"]}" +
                 $"&theaterId={Request.QueryString["theaterId"]}" +
                 $"&showTiming={Request.QueryString["showTiming"]}" +
                 $"&auditorium={Request.QueryString["auditorium"]}" +
                 $"&selectedDate={Request.QueryString["selectedDate"]}" +
                 $"&theaterName={Request.QueryString["theaterName"]}";

            // Redirect to the checkout page with the cart information in the URL
            Response.Redirect(url);
        }
    }
}
