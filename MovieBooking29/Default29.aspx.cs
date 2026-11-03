
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI.WebControls;

namespace MovieBooking29
{
    public partial class Default29 : System.Web.UI.Page
    {
        private string GetConnection29()
        {
            return ConfigurationManager.ConnectionStrings["MovieBookingConnection29"].ConnectionString;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories29();
                LoadMovies29(0);
                LoadBookingMovies29();
            }
        }

        private void LoadCategories29()
        {
            using (SqlConnection con = new SqlConnection(GetConnection29()))
            {
                string query = "SELECT Cat_ID29, Cat_Type29 FROM Tbl_Movie_Category29 ORDER BY Cat_Type29";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();

                da.Fill(dt);

                DropDownCategory29.DataSource = dt;
                DropDownCategory29.DataTextField = "Cat_Type29";
                DropDownCategory29.DataValueField = "Cat_ID29";
                DropDownCategory29.DataBind();

                DropDownCategory29.Items.Insert(0, new ListItem("All Categories", "0"));

                DropDownMovieCategory29.DataSource = dt;
                DropDownMovieCategory29.DataTextField = "Cat_Type29";
                DropDownMovieCategory29.DataValueField = "Cat_ID29";
                DropDownMovieCategory29.DataBind();

                DropDownBookingCategory29.DataSource = dt;
                DropDownBookingCategory29.DataTextField = "Cat_Type29";
                DropDownBookingCategory29.DataValueField = "Cat_ID29";
                DropDownBookingCategory29.DataBind();
            }
        }

        private void LoadMovies29(int categoryId)
        {
            using (SqlConnection con = new SqlConnection(GetConnection29()))
            {
                string query = "SELECT Movie_ID29, Movie_name29, Release_Date29, rate29 FROM Tbl_Movie29";

                if (categoryId != 0)
                {
                    query += " WHERE Cat_ID29 = @Cat_ID29";
                }

                SqlCommand cmd = new SqlCommand(query, con);

                if (categoryId != 0)
                {
                    cmd.Parameters.AddWithValue("@Cat_ID29", categoryId);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                GridViewMovie29.DataSource = dt;
                GridViewMovie29.DataBind();
            }
        }

        private void LoadBookingMovies29()
        {
            using (SqlConnection con = new SqlConnection(GetConnection29()))
            {
                string query = "SELECT Movie_ID29, Movie_name29 FROM Tbl_Movie29 WHERE Cat_ID29 = @Category";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Category", DropDownBookingCategory29.SelectedValue);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                DropDownBookingMovie29.DataSource = dt;
                DropDownBookingMovie29.DataTextField = "Movie_name29";
                DropDownBookingMovie29.DataValueField = "Movie_ID29";
                DropDownBookingMovie29.DataBind();
            }

            LblAmount29.Text = "0";
        }

        private decimal GetMovieRate29()
        {
            using (SqlConnection con = new SqlConnection(GetConnection29()))
            {
                string query = "SELECT rate29 FROM Tbl_Movie29 WHERE Movie_ID29 = @MovieID";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@MovieID", DropDownBookingMovie29.SelectedValue);

                con.Open();

                object result = cmd.ExecuteScalar();

                if (result == null || result == DBNull.Value)
                    return 0;

                return Convert.ToDecimal(result);
            }
        }

        private void CalculateAmount29()
        {
            int tickets;
            decimal rate;

            if (DropDownBookingMovie29.Items.Count == 0)
            {
                LblAmount29.Text = "0";
                return;
            }

            if (!int.TryParse(TxtTickets29.Text, out tickets) || tickets <= 0)
            {
                LblAmount29.Text = "Enter valid ticket quantity";
                return;
            }

            rate = GetMovieRate29();

            decimal amount = rate * tickets;

            LblAmount29.Text = amount.ToString("0.00");
        }

        protected void DropDownBookingCategory29_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBookingMovies29();
        }

        protected void DropDownBookingMovie29_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateAmount29();
        }

        protected void TxtTickets29_TextChanged(object sender, EventArgs e)
        {
            CalculateAmount29();
        }

        protected void BtnAddCategory29_Click(object sender, EventArgs e)
        {
            string category = TxtCategory29.Text.Trim();

            if (category == "")
            {
                LblCategoryMessage29.Text = "Please enter category name.";
                return;
            }

            using (SqlConnection con = new SqlConnection(GetConnection29()))
            {
                con.Open();

                string checkQuery = "SELECT COUNT(*) FROM Tbl_Movie_Category29 WHERE Cat_Type29 = @Category";

                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                checkCmd.Parameters.AddWithValue("@Category", category);

                if (Convert.ToInt32(checkCmd.ExecuteScalar()) > 0)
                {
                    LblCategoryMessage29.Text = "Category already exists.";
                    return;
                }

                string query = "INSERT INTO Tbl_Movie_Category29 (Cat_Type29) VALUES (@Category)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Category", category);
                cmd.ExecuteNonQuery();
            }

            TxtCategory29.Text = "";
            LoadCategories29();
            LoadBookingMovies29();
            LoadMovies29(0);

            LblCategoryMessage29.Text = "Category added successfully.";
        }

        protected void BtnAddMovie29_Click(object sender, EventArgs e)
        {
            string movieName = TxtMovieName29.Text.Trim();
            string releaseDate = TxtReleaseDate29.Text.Trim();
            string rateText = TxtRate29.Text.Trim();

            DateTime date;
            decimal rate;

            if (movieName == "" || releaseDate == "" || rateText == "")
            {
                LblMovieMessage29.Text = "All fields are required.";
                return;
            }

            if (!DateTime.TryParseExact(releaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                LblMovieMessage29.Text = "Enter date in YYYY-MM-DD format.";
                return;
            }

            if (!decimal.TryParse(rateText, out rate) || rate <= 0)
            {
                LblMovieMessage29.Text = "Enter a valid ticket rate.";
                return;
            }

            int categoryId = Convert.ToInt32(DropDownMovieCategory29.SelectedValue);

            using (SqlConnection con = new SqlConnection(GetConnection29()))
            {
                string query = "INSERT INTO Tbl_Movie29 (Movie_name29, Release_Date29, Cat_ID29, rate29) VALUES (@Name, @Date, @Category, @Rate)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Name", movieName);
                cmd.Parameters.AddWithValue("@Date", date);
                cmd.Parameters.AddWithValue("@Category", categoryId);
                cmd.Parameters.AddWithValue("@Rate", rate);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            TxtMovieName29.Text = "";
            TxtReleaseDate29.Text = "";
            TxtRate29.Text = "";

            LoadCategories29();
            LoadBookingMovies29();
            LoadMovies29(0);

            LblMovieMessage29.Text = "Movie added successfully.";
        }

        protected void DropDownCategory29_SelectedIndexChanged(object sender, EventArgs e)
        {
            int categoryId = Convert.ToInt32(DropDownCategory29.SelectedValue);
            LoadMovies29(categoryId);
        }

        protected void GridViewMovie29_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int movieId = Convert.ToInt32(GridViewMovie29.DataKeys[e.RowIndex].Value);

            try
            {
                using (SqlConnection con = new SqlConnection(GetConnection29()))
                {
                    string query = "DELETE FROM Tbl_Movie29 WHERE Movie_ID29 = @Movie_ID29";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Movie_ID29", movieId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                LblDeleteMessage29.Text = "Movie deleted successfully.";
            }
            catch (SqlException)
            {
                LblDeleteMessage29.Text = "Movie cannot be deleted because a booking may exist.";
            }

            LoadMovies29(Convert.ToInt32(DropDownCategory29.SelectedValue));
            LoadBookingMovies29();

            e.Cancel = true;
        }

        protected void BtnBook29_Click(object sender, EventArgs e)
        {
            if (Session["UserID29"] == null)
            {
                LblBookingMessage29.Text = "Please login before booking tickets.";
                return;
            }

            int tickets;
            int movieId;
            int categoryId;

            if (!int.TryParse(TxtTickets29.Text, out tickets) || tickets <= 0)
            {
                LblBookingMessage29.Text = "Enter a valid number of tickets.";
                return;
            }

            if (DropDownBookingMovie29.Items.Count == 0)
            {
                LblBookingMessage29.Text = "Please select a movie.";
                return;
            }

            movieId = Convert.ToInt32(DropDownBookingMovie29.SelectedValue);
            categoryId = Convert.ToInt32(DropDownBookingCategory29.SelectedValue);

            using (SqlConnection con = new SqlConnection(GetConnection29()))
            {
                con.Open();

                string rateQuery = "SELECT rate29 FROM Tbl_Movie29 WHERE Movie_ID29 = @MovieID AND Cat_ID29 = @CategoryID";

                SqlCommand rateCmd = new SqlCommand(rateQuery, con);
                rateCmd.Parameters.AddWithValue("@MovieID", movieId);
                rateCmd.Parameters.AddWithValue("@CategoryID", categoryId);

                object rateResult = rateCmd.ExecuteScalar();

                if (rateResult == null || rateResult == DBNull.Value)
                {
                    LblBookingMessage29.Text = "Selected movie is not available.";
                    return;
                }

                decimal rate = Convert.ToDecimal(rateResult);
                decimal amount = rate * tickets;

                string query = "INSERT INTO Tbl_Booking29 (User_ID29, Cat_ID29, Movie_ID29, no_of_Tickets29, amount29) VALUES (@UserID, @CategoryID, @MovieID, @Tickets, @Amount)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@UserID", Session["UserID29"]);
                cmd.Parameters.AddWithValue("@CategoryID", categoryId);
                cmd.Parameters.AddWithValue("@MovieID", movieId);
                cmd.Parameters.AddWithValue("@Tickets", tickets);
                cmd.Parameters.AddWithValue("@Amount", amount);

                cmd.ExecuteNonQuery();

                LblAmount29.Text = amount.ToString("0.00");
                LblBookingMessage29.Text = "Tickets booked successfully. Total Amount: " + amount.ToString("0.00");
            }
        }
    }
}
