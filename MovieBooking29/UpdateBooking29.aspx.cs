using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MovieBooking29
{
    public partial class UpdateBooking29 : System.Web.UI.Page
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

                        if (dt.Rows.Count > 0)
                        {
                            LoadBookingDetails29();
                        }
                        else
                        {
                            LblMessage29.Text = "No bookings available.";
                        }
                    }
                }
            }
        }

        private void LoadBookingDetails29()
        {
            if (DropDownBooking29.SelectedValue == "")
            {
                return;
            }

            using (SqlConnection con = new SqlConnection(GetConnection29()))
            {
                string query = @"SELECT m.Movie_name29, b.no_of_Tickets29
                                 FROM Tbl_Booking29 b
                                 INNER JOIN Tbl_Movie29 m ON b.Movie_ID29 = m.Movie_ID29
                                 WHERE b.booking_ID29 = @BookingID AND b.User_ID29 = @UserID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@BookingID", Convert.ToInt32(DropDownBooking29.SelectedValue));
                    cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID29"]));

                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            TxtMovie29.Text = reader["Movie_name29"].ToString();
                            TxtTickets29.Text = reader["no_of_Tickets29"].ToString();
                        }
                    }
                }
            }
        }

        protected void DropDownBooking29_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBookingDetails29();
            LblMessage29.Text = "";
        }

        protected void BtnUpdate29_Click(object sender, EventArgs e)
        {
            int bookingId;
            int tickets;

            if (!int.TryParse(DropDownBooking29.SelectedValue, out bookingId))
            {
                LblMessage29.Text = "Please select a booking.";
                return;
            }

            if (!int.TryParse(TxtTickets29.Text, out tickets) || tickets <= 0)
            {
                LblMessage29.Text = "Please enter a valid number of tickets.";
                return;
            }

            using (SqlConnection con = new SqlConnection(GetConnection29()))
            {
                string query = @"UPDATE Tbl_Booking29
                                 SET no_of_Tickets29 = @Tickets,
                                     amount29 = @Amount
                                 WHERE booking_ID29 = @BookingID
                                 AND User_ID29 = @UserID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Tickets", tickets);
                    cmd.Parameters.AddWithValue("@BookingID", bookingId);
                    cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID29"]));

                    con.Open();

                    string rateQuery = @"SELECT m.rate29
                                         FROM Tbl_Booking29 b
                                         INNER JOIN Tbl_Movie29 m ON b.Movie_ID29 = m.Movie_ID29
                                         WHERE b.booking_ID29 = @BookingID
                                         AND b.User_ID29 = @UserID";

                    decimal rate;

                    using (SqlCommand rateCmd = new SqlCommand(rateQuery, con))
                    {
                        rateCmd.Parameters.AddWithValue("@BookingID", bookingId);
                        rateCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID29"]));

                        object result = rateCmd.ExecuteScalar();

                        if (result == null)
                        {
                            LblMessage29.Text = "Booking not found.";
                            return;
                        }

                        rate = Convert.ToDecimal(result);
                    }

                    cmd.Parameters.AddWithValue("@Amount", rate * tickets);

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        LblMessage29.Text = "Booking updated successfully. Total Amount: " + (rate * tickets).ToString("N2");
                    }
                    else
                    {
                        LblMessage29.Text = "Booking could not be updated.";
                    }
                }
            }
        }
    }
}