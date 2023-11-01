using System;
using System.Web.UI;

namespace MoviePlex
{
    public partial class CheckoutPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // You can perform any initialization logic here
            }
        }

        protected void BtnCheckout_Click(object sender, EventArgs e)
        {
            // Retrieve user input from textboxes
            string name = txtName.Text;
            string email = txtEmail.Text;
            string cardNumber = txtCardNumber.Text;
            string expiryDate = txtExpiryDate.Text;
            string cvv = txtCVV.Text;

           
            string checkoutInfo = $"Name: {name}<br>Email: {email}<br>Card Number: {cardNumber}<br>Expiry Date: {expiryDate}<br>CVV: {cvv}";
            lblCheckoutInfo.Text = checkoutInfo;
        }
    }
}
