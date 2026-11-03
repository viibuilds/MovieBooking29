using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MovieBooking29
{
    public partial class MyBookings29 : System.Web.UI.Page
    {
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
            string connectionString = ConfigurationManager.ConnectionStrings["MovieBookingConnection29"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"SELECT b.booking_ID29, m.Movie_name29, c.Cat_Type29,
                                b.no_of_Tickets29, b.amount29
                                FROM Tbl_Booking29 b
                                INNER JOIN Tbl_Movie29 m ON b.Movie_ID29 = m.Movie_ID29
                                INNER JOIN Tbl_Movie_Category29 c ON b.Cat_ID29 = c.Cat_ID29
                                WHERE b.User_ID29 = @UserID
                                ORDER BY b.booking_ID29 DESC";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID29"]));

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        GridViewBookings29.DataSource = dt;
                        GridViewBookings29.DataBind();

                        if (dt.Rows.Count == 0)
                        {
                            LblMessage29.Text = "You have not booked any tickets yet.";
                        }
                        else
                        {
                            LblMessage29.Text = "";
                        }
                    }
                }
            }
        }
    }
}