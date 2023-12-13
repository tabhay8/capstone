using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MoviePlex
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCartData();
            }
        }

        private void BindCartData()
        {
            List<FoodDrinks.CartItem> cartItems = GetCartFromCookie();
            cartRepeater.DataSource = cartItems.Select(item => new
            {
                ItemID = item.ItemID,
                ItemName = GetItemName(item.ItemID),
                Quantity = item.Quantity,
                Price = GetItemPrice(item.ItemID) * item.Quantity
            });
            cartRepeater.DataBind();
        }


        protected void BtnMoveToCheckout_Click(object sender, EventArgs e)
        {
            // Redirect to the checkout page
            Response.Redirect("FoodCheckoutPage.aspx");
        }


        protected void DeleteCartItem_Command(object sender, CommandEventArgs e)
        {
            int itemIDToDelete;
            if (int.TryParse(e.CommandArgument.ToString(), out itemIDToDelete))
            {
                RemoveItemFromCart(itemIDToDelete);
                BindCartData(); // Refresh the cart after deletion
            }
        }


        private void RemoveItemFromCart(int itemID)
        {
            List<FoodDrinks.CartItem> cartItems = GetCartFromCookie();
            var itemToRemove = cartItems.FirstOrDefault(item => item.ItemID == itemID);
            if (itemToRemove != null)
            {
                cartItems.Remove(itemToRemove);
                SaveCartToCookie(cartItems);
            }
        }
        private void SaveCartToCookie(List<FoodDrinks.CartItem> cartItems)
        {
            HttpCookie cartCookie = new HttpCookie("ShoppingCart");
            cartCookie.Value = Newtonsoft.Json.JsonConvert.SerializeObject(cartItems);
            cartCookie.Expires = DateTime.Now.AddMinutes(30); // Set the expiration time as needed
            Response.Cookies.Add(cartCookie);
        }

        private List<FoodDrinks.CartItem> GetCartFromCookie()
        {
            HttpCookie cartCookie = Request.Cookies["ShoppingCart"];
            if (cartCookie != null && !string.IsNullOrEmpty(cartCookie.Value))
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<FoodDrinks.CartItem>>(cartCookie.Value);
            }
            return new List<FoodDrinks.CartItem>();
        }

        // Assuming you have a database with a table named "FoodAndBeverages"
        // and columns "Name" and "Price" that correspond to the item details.

        private string GetItemName(int foodItemId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string queryName = "SELECT Name FROM FoodAndBeverages WHERE ItemID = @ItemID";

                using (SqlCommand cmd = new SqlCommand(queryName, connection))
                {
                    cmd.Parameters.AddWithValue("@ItemID", foodItemId);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        return result.ToString();
                    }
                }
            }

            // Return a default name if not found
            return "Unknown Item";
        }

        private decimal GetItemPrice(int foodItemId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string queryPrice = "SELECT Price FROM FoodAndBeverages WHERE ItemID = @ItemID";

                using (SqlCommand cmd = new SqlCommand(queryPrice, connection))
                {
                    cmd.Parameters.AddWithValue("@ItemID", foodItemId);

                    object result = cmd.ExecuteScalar();

                    if (result != null && decimal.TryParse(result.ToString(), out decimal price))
                    {
                        return price;
                    }
                }
            }

            // Return a default price if not found
            return 0.0m;
        }

    }
}
