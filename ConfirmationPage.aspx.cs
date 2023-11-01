using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MoviePlex
{
    public partial class ConfirmationPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Load cart items from session or database and bind to the repeater
                BindCartItems();
            }
        }

        protected void BindCartItems()
        {
            // Fetch the cart items from the session or database and bind to the repeater
            List<CartItem> cartItems = GetCartItems(); // Implement this method to get cart items

            cartRepeater.DataSource = cartItems;
            cartRepeater.DataBind();

            // Calculate and display the total price
            decimal totalPrice = CalculateTotalPrice(cartItems);
            lblTotalPrice.Text = totalPrice.ToString("0.00");
        }

        // Event handler for the "Remove" button in the cart
        protected void cartRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                int movieId = Convert.ToInt32(e.CommandArgument);

                // Implement the logic to remove the selected item from the cart (session or database)
                RemoveItemFromCart(movieId);

                // Rebind the cart items to reflect the removal
                BindCartItems();
            }
        }

        protected void BtnCheckout_Click(object sender, EventArgs e)
        {
            // Implement the checkout logic, which may involve processing the order and payment
            // After successful checkout, you can redirect to a confirmation or payment page.
            Response.Redirect("CheckoutPage.aspx");
        }

        // Implement these methods to fetch, remove, and calculate cart items
        private List<CartItem> GetCartItems()
        {
            // Implement this method to get cart items from the session or database
            return new List<CartItem>();
        }

        private void RemoveItemFromCart(int movie_id)
        {
            // Implement this method to remove the selected item from the cart (session or database)
        }

        private decimal CalculateTotalPrice(List<CartItem> cartItems)
        {
            // Implement this method to calculate the total price of cart items
            return 0;
        }
    }
}
public class CartItem
{
    public int movie_id { get; set; }
    public string MovieTitle { get; set; }
    public int Duration { get; set; }
    public string Genre { get; set; }
    public decimal Price { get; set; }
}
