using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MoviePlex
{
    public partial class UserProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Define your database connection string
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                // Replace this with the actual logged-in user's ID
                int loggedInUserID = 1; // Replace with the ID of the logged-in user

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Query to select user data by UserID
                    string query = "SELECT * FROM Users WHERE UserID = @UserID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", loggedInUserID);

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            lblUserID.Text = reader["UserID"].ToString();
                            lblUsername.Text = reader["Username"].ToString();
                            lblFullName.Text = reader["FullName"].ToString();
                            lblAge.Text = reader["Age"].ToString();
                            lblEmail.Text = reader["Email"].ToString();
                            lblPhoneNumber.Text = reader["PhoneNumber"].ToString();
                        }
                        reader.Close();
                    }
                }
            }
        }
    }
}
