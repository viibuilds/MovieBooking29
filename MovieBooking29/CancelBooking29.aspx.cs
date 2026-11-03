using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MovieBooking29
{
    public partial class CancelBooking29 : System.Web.UI.Page
    {
        private string GetConnection29()
        {
            return ConfigurationManager.ConnectionStrings["MovieBookingConnection29"].ConnectionString;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID29"] == null)
            {
                Response.Redirect("Login29.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadBookings29();
            }
        }

        private void LoadBookings29()
        {
            using (SqlConnection con = new SqlConnection(GetConnection29()))
            {
                string query = @"SELECT b.booking_ID29, m.Movie_name29
                                 FROM Tbl_Booking29 b
                                 INNER JOIN Tbl_Movie29 m ON b.Movie_ID29 = m.Movie_ID29
                                 WHERE b.User_ID29 = @UserID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID29"]));

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        DropDownBooking29.DataSource = dt;
                        DropDownBooking29.DataTextField = "booking_ID29";
                        DropDownBooking29.DataValueField = "booking_ID29";
                        DropDownBooking29.DataBind();

                        DropDownBooking29.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Select Booking --", ""));

                        BtnCancel29.Enabled = dt.Rows.Count > 0;
                    }
                }
            }
        }

        protected void BtnCancel29_Click(object sender, EventArgs e)
        {
            int bookingId;

            if (!int.TryParse(DropDownBooking29.SelectedValue, out bookingId))
            {
                LblMessage29.Text = "Please select a booking.";
                return;
            }

            using (SqlConnection con = new SqlConnection(GetConnection29()))
            {
                string query = @"DELETE FROM Tbl_Booking29
                                 WHERE booking_ID29 = @BookingID
                                 AND User_ID29 = @UserID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@BookingID", bookingId);
                    cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID29"]));

                    con.Open();

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        LoadBookings29();
                        LblMessage29.Text = "Booking cancelled successfully.";
                    }
                    else
                    {
                        LblMessage29.Text = "Booking not found.";
                    }
                }
            }
        }
    }
}