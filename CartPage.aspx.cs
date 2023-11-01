using System;
using System.Collections.Generic;
using System.Web.UI;

namespace MoviePlex
{
    public partial class CartPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if the "ShoppingCart" session variable exists
                if (Session["ShoppingCart"] != null)
                {
                    List<string> shoppingCart = (List<string>)Session["ShoppingCart"];

                    // Bind the shopping cart data to the repeater control
                    CartRepeater.DataSource = shoppingCart;
                    CartRepeater.DataBind();
                }
            }
        }
        protected void BtnCheckout_Click(object sender, EventArgs e)
        {
            // Redirect to the checkout page
            Response.Redirect("CheckoutPage.aspx");
        }


    }

}
