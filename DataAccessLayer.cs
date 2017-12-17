


namespace DA
{
sql connection
sqlcommand
cccc
dddd
    public class DataAccessLayer
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter dap;
        DataTable dt;

        public DataAccessLayer()
        {
		con=cmd new sqlconnection();
            con = new SqlConnection();
            cmd = new SqlCommand();
            dap = new SqlDataAdapter();
            cmd.Connection = con;
            dap.SelectCommand = cmd;
           
        }
        public void connect()
        {
            con.ConnectionString = "Data Source=.;Initial Catalog=ticket;Integrated Security=True";
            con.Open();
        }
        public void disconnect()
        {
            con.Close();
        }

        public DataTable select(string sql)
        {
            cmd.CommandText = sql;
            DataTable dt = new DataTable();
            dap.Fill(dt);
            return dt;
        }
        public void docommand(string sql)
        {
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }
    }
}
