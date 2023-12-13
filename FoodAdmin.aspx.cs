using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace MoviePlex
{
    public partial class FoodAdmin : System.Web.UI.Page


    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM FoodAndBeverages", connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridViewFoodAndBeverages.DataSource = dt;
                GridViewFoodAndBeverages.DataBind();
            }
        }
        protected void LogoutButton_Click(object sender, EventArgs e)
        {
           

            // Redirect to the login page (adjust the URL as needed)
            Response.Redirect("Home.aspx");
        }
        protected void GridViewFoodAndBeverages_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewFoodAndBeverages.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void GridViewFoodAndBeverages_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if (GridViewFoodAndBeverages.EditIndex == e.RowIndex)
            {
                int itemID = Convert.ToInt32(GridViewFoodAndBeverages.DataKeys[e.RowIndex].Values["ItemID"]);
                string name = (GridViewFoodAndBeverages.Rows[e.RowIndex].FindControl("txtName") as TextBox)?.Text;
                string description = (GridViewFoodAndBeverages.Rows[e.RowIndex].FindControl("txtDescription") as TextBox)?.Text;
                string category = (GridViewFoodAndBeverages.Rows[e.RowIndex].FindControl("txtCategory") as TextBox)?.Text;
                decimal price = Convert.ToDecimal((GridViewFoodAndBeverages.Rows[e.RowIndex].FindControl("txtPrice") as TextBox)?.Text);
                bool availability = Convert.ToBoolean((GridViewFoodAndBeverages.Rows[e.RowIndex].FindControl("chkAvailability") as CheckBox)?.Checked);
                int stockQuantity = Convert.ToInt32((GridViewFoodAndBeverages.Rows[e.RowIndex].FindControl("txtStockQuantity") as TextBox)?.Text);
                string imageURL = (GridViewFoodAndBeverages.Rows[e.RowIndex].FindControl("txtImageURL") as TextBox)?.Text;

                // Update the database with the new values
                UpdateFoodItem(itemID, name, description, category, price, availability, stockQuantity, imageURL);

                GridViewFoodAndBeverages.EditIndex = -1;
                BindGrid();
            }
        }


        protected void GridViewFoodAndBeverages_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewFoodAndBeverages.EditIndex = -1;
            BindGrid();
        }

        protected void GridViewFoodAndBeverages_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int itemID = Convert.ToInt32(GridViewFoodAndBeverages.DataKeys[e.RowIndex].Values["ItemID"]);
            // Delete the record from the database
            DeleteFoodItem(itemID);
            BindGrid();
        }

        // Placeholder method for updating a food item in the database
        private void UpdateFoodItem(int itemID, string name, string description, string category, decimal price, bool availability, int stockQuantity, string imageURL)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("UPDATE FoodAndBeverages SET Name=@name, Description=@description, Category=@category, Price=@price, Availability=@availability, StockQuantity=@stockQuantity, ImageURL=@imageURL WHERE ItemID=@itemID", connection);

                // Add parameters to the SqlCommand
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@category", category);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@availability", availability);
                cmd.Parameters.AddWithValue("@stockQuantity", stockQuantity);
                cmd.Parameters.AddWithValue("@imageURL", imageURL);
                cmd.Parameters.AddWithValue("@itemID", itemID);

                // Execute the command
                cmd.ExecuteNonQuery();
            }
        }


        protected void AddFoodItemButton_Click(object sender, EventArgs e)
        {
            // Get values from the input controls
            string name = FoodNameTextBox.Text;
            string description = DescriptionTextBox.Text;
            string category = CategoryTextBox.Text;
            decimal price = Convert.ToDecimal(PriceTextBox.Text);
            bool availability = AvailabilityCheckBox.Checked;
            int stockQuantity = Convert.ToInt32(StockQuantityTextBox.Text);

            // Save the image file and get its URL
            string imageURL = SaveImageFile();

            // Insert the new food item into the database
            AddFoodItem(name, description, category, price, availability, stockQuantity, imageURL);

            // Refresh the grid view or perform any other actions as needed
            BindGrid();
        }

        private string SaveImageFile()
        {
            if (ImageUpload.HasFile)
            {
                // Specify the path where you want to save the image file
                string imagePath = Server.MapPath("~/Images/FoodItems/");

                // Create the directory if it doesn't exist
                Directory.CreateDirectory(imagePath);

                // Generate a unique file name to avoid overwriting existing files
                string fileName = Guid.NewGuid().ToString() + "_" + ImageUpload.FileName;

                // Combine the path and file name
                string filePath = Path.Combine(imagePath, fileName);

                // Check if the file already exists (unlikely due to the unique file name)
                if (File.Exists(filePath))
                {
                    // Log or handle the situation where a file with the same name already exists
                    return "";
                }

                // Save the file to the server
                ImageUpload.SaveAs(filePath);

                // Debug statement: Output the saved file path
                System.Diagnostics.Debug.WriteLine("File saved: " + filePath);

                // Return the URL of the saved image
                return "/Images/FoodItems/" + fileName;
            }

            // Return an empty string if no file was uploaded
            return "";
        }




        // Method to add a food item to the database
        private void AddFoodItem(string name, string description, string category, decimal price, bool availability, int stockQuantity, string imageURL)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO FoodAndBeverages (Name, Description, Category, Price, Availability, StockQuantity, ImageURL) VALUES (@name, @description, @category, @price, @availability, @stockQuantity, @imageURL)", connection);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@category", category);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@availability", availability);
                cmd.Parameters.AddWithValue("@stockQuantity", stockQuantity);
                cmd.Parameters.AddWithValue("@imageURL", imageURL);
                cmd.ExecuteNonQuery();
            }
        }


        // Placeholder method for deleting a food item from the database
        private void DeleteFoodItem(int itemID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM FoodAndBeverages WHERE ItemID=@itemID", connection);
                cmd.Parameters.AddWithValue("@itemID", itemID);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
