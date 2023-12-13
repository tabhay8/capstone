using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MoviePlex
{
    public partial class SeatMatrix : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Retrieve values from query parameters
                string selectedTheaterId = Request.QueryString["theaterId"];
                string selectedShowTiming = Request.QueryString["showTiming"];
                string selectedAuditorium = Request.QueryString["auditorium"];
                string selectedDate = Request.QueryString["selectedDate"];
                string theaterName = Request.QueryString["theaterName"];

                // Display the values on the page as needed
                lblTheater.Text = $"Selected Theater: {selectedTheaterId}";
                lblShowTiming.Text = $"Selected Show Timing: {selectedShowTiming}";
                lblAuditorium.Text = $"Selected Auditorium: {selectedAuditorium}";
                lblDate.Text = $"Selected Date: {selectedDate}";
                lblTheaterName.Text = $"Selected Theater: {theaterName}";

            }
        }
        protected void toggleButtonClick(object sender, EventArgs e)
        {
            // Toggle the selected state of the button
            var toggleButton = (System.Web.UI.WebControls.Button)sender;
            toggleButton.CssClass = toggleButton.CssClass.Contains("selected") ? "" : "selected";
        }

        protected void goToNextPage(object sender, EventArgs e)
        {
            // Retrieve selected toggle buttons
            string selectedButtons = "";

            for (int i = 1; i <= 30; i++)
            {
                var button = (Button)form1.FindControl("toggleButton" + i);
                if (button != null && button.CssClass.Contains("selected"))
                {
                    selectedButtons += "Seat " + i + ", ";
                }
            }

            selectedButtons = selectedButtons.TrimEnd(',', ' ');

            // Retrieve other parameters
            string selectedTheaterId = Request.QueryString["theaterId"];
            string selectedShowTiming = Request.QueryString["showTiming"];
            string selectedAuditorium = Request.QueryString["auditorium"];
            string selectedDate = Request.QueryString["selectedDate"];
            string theaterName = Request.QueryString["theaterName"];

            // Redirect to CartPage.aspx with all parameters
            Response.Redirect($"CartPage.aspx?selectedButtons={selectedButtons}&theaterId={selectedTheaterId}&showTiming={selectedShowTiming}&auditorium={selectedAuditorium}&selectedDate={selectedDate}&theaterName={theaterName}");
        }
    }
}