using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MoviePlex
{
    public partial class SeatSelect : System.Web.UI.Page

    {
        private List<string> shoppingCart = new List<string>();
        private List<string> selectedSeats = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ShoppingCart"] != null)
                {
                    selectedSeats = (List<string>)Session["ShoppingCart"];
                    UpdateCartButtonVisibility();
                }

                // Define the number of rows and seats per row
                int numRows = 5; // Change this to your desired number of rows
                int seatsPerRow = 10;

                // Create a list of rows with seat numbers
                List<SeatRow> seatRows = new List<SeatRow>();

                for (int row = 1; row <= numRows; row++)
                {
                    List<int> seats = new List<int>();
                    for (int seat = 1; seat <= seatsPerRow; seat++)
                    {
                        seats.Add(seat);
                    }
                    seatRows.Add(new SeatRow { RowNumber = row, Seats = seats });
                }

                // Bind the seat matrix data to the repeater controls
                SeatMatrixRepeater.DataSource = seatRows;
                SeatMatrixRepeater.DataBind();
            }
        }

        protected void SeatButton_Click(object sender, EventArgs e)
        {
            Button seatButton = (Button)sender;
            string selectedSeat = seatButton.Text;

            // Check if the seat is already selected
            if (selectedSeats.Contains(selectedSeat))
            {
                // Seat is already selected, remove it from the selection
                selectedSeats.Remove(selectedSeat);
                seatButton.CssClass = "seat-button";
            }
            else if (selectedSeats.Count < 5)
            {
                // Seat is not selected, and fewer than 5 seats are selected
                selectedSeats.Add(selectedSeat);
                seatButton.CssClass = "seat-button selected";
            }

            // Store the selected seats in the "ShoppingCart" session variable
            Session["ShoppingCart"] = selectedSeats;
            UpdateCartButtonVisibility();
        }


        protected void BtnGoToCart_Click(object sender, EventArgs e)
        {
            // Navigate to the cart page
            Response.Redirect("CartPage.aspx");
        }

        private void UpdateCartButtonVisibility()
        {
            // Show the "Go to Cart" button if there are items in the cart or at least 1 seat is selected
            btnGoToCart.Visible = shoppingCart.Count > 0 || selectedSeats.Count > 0;
        }


        public class SeatRow
        {
            public int RowNumber { get; set; }
            public List<int> Seats { get; set; }
        }
    }
}
