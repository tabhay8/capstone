using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web;

namespace MoviePlex
{
    public partial class FoodDrinks : System.Web.UI.Page
    {
        private int selectedFoodItemId;
        private int userId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM FoodAndBeverages";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        foodRepeater.DataSource = reader;
                        foodRepeater.DataBind();
                    }
                }
                int firstItemId = 1; // Replace this with the actual item ID
                List<Review> top5Reviews = GetTop5Reviews(firstItemId);
            }
        }
        // Add a new method to fetch the top 5 reviews for a given item
        protected List<Review> GetTop5Reviews(int foodItemId)
        {
            List<Review> reviews = new List<Review>();
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT TOP 5 * FROM FoodAndBeveragesReviews WHERE ItemID = @ItemID ORDER BY ReviewDate DESC";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ItemID", foodItemId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Review review = new Review
                            {
                                Rating = Convert.ToInt32(reader["Rating"]),
                                Comment = reader["Comment"].ToString(),
                                ReviewDate = Convert.ToDateTime(reader["ReviewDate"])
                            };

                            reviews.Add(review);
                        }
                    }
                }
            }

            return reviews;
        }


        // Add a new class to represent a review
        public class Review
        {
            public int Rating { get; set; }
            public string Comment { get; set; }
            public DateTime ReviewDate { get; set; }
        }
        protected void SubmitReview_Click(object sender, EventArgs e)
        {
            selectedFoodItemId = Convert.ToInt32((sender as Button).CommandArgument);
            userId = GetUserId();

            var repeaterItem = (RepeaterItem)(sender as Button).NamingContainer;
            var ratingDropdown = (DropDownList)repeaterItem.FindControl("DropDownList1");
            var commentTextBox = (TextBox)repeaterItem.FindControl("TextBox1");

            if (ratingDropdown != null && commentTextBox != null)
            {
                var rating = int.Parse(ratingDropdown.SelectedValue);
                var comment = commentTextBox.Text;

                SaveReviewToDatabase(selectedFoodItemId, userId, rating, comment);
            }
        }

        protected void AddToCart_Click(object sender, EventArgs e)
        {
            selectedFoodItemId = Convert.ToInt32((sender as Button).CommandArgument);
            int quantity = GetQuantityFromRepeaterItem((sender as Button).NamingContainer);

            AddToCart(selectedFoodItemId, quantity);

            // Debugging statements
            Response.Write($"Item ID: {selectedFoodItemId}, Quantity: {quantity}<br>");

            
           
        }

        private int GetQuantityFromRepeaterItem(Control container)
        {
            var quantityTextbox = (TextBox)container.FindControl("quantityTextbox");
            if (quantityTextbox != null && int.TryParse(quantityTextbox.Text, out int quantity))
            {
                return quantity;
            }
            return 1; // Default to 1 if not found or parsing fails
        }

        public class CartItem
        {
            public int ItemID { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
        }
        // Your existing code ...

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


        // Rest of your existing code ...

        private void AddToCart(int foodItemId, int quantity)
        {
            string itemName = GetItemName(foodItemId);
            decimal itemPrice = GetItemPrice(foodItemId);

            List<CartItem> cartItems = GetCartFromCookie();
            cartItems.Add(new CartItem
            {
                ItemID = foodItemId,
                Name = itemName,
                Price = itemPrice,
                Quantity = quantity
            });
            SaveCartToCookie(cartItems);
        }

        private List<CartItem> GetCartFromCookie()
        {
            HttpCookie cartCookie = Request.Cookies["ShoppingCart"];
            if (cartCookie != null && !string.IsNullOrEmpty(cartCookie.Value))
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<CartItem>>(cartCookie.Value);
            }
            return new List<CartItem>();
        }

        private void SaveCartToCookie(List<CartItem> cartItems)
        {
            HttpCookie cartCookie = new HttpCookie("ShoppingCart");
            cartCookie.Value = Newtonsoft.Json.JsonConvert.SerializeObject(cartItems);
            cartCookie.Expires = DateTime.Now.AddMinutes(30); // Set the expiration time as needed
            Response.Cookies.Add(cartCookie);
        }

        protected void GoToCart_Click(object sender, EventArgs e)
        {
            // Redirect to the shopping cart page
            Response.Redirect("ShoppingCart.aspx");
        }

        private int GetUserId()
        {
            return 1; // Replace this with the actual logic
        }

        private void SaveReviewToDatabase(int foodItemId, int userId, int rating, string comment)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO FoodAndBeveragesReviews (ItemID, UserID, Rating, Comment, ReviewDate) " +
                               "VALUES (@ItemID, @UserID, @Rating, @Comment, getdate())";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ItemID", foodItemId);
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@Rating", rating);
                    cmd.Parameters.AddWithValue("@Comment", comment);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
