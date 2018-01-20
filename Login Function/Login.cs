using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Function
{
    class Login
    {
        #region Declarations

        string connectionString = ConfigurationManager.ConnectionStrings["myConString"].ConnectionString; //Gets the connectionString from the App.Config file
        SqlDataAdapter command = new SqlDataAdapter();


        public string pass;                 // String that stores the password input when trying to logon.  
        public string user;                 // String that stores the username input when trying to logon.

        public string reguser;              // String that stores the password input when trying to register. 
        public string regpass;              // String that stores the password input when trying to register.

        string[] register = new string[1]; // Array that stores the username and password when registering.
        #endregion

        #region Constructors
        public Login (string username, string password) //Constructer that passes 2 strings (username & password) into the Login class to be used.
        {
            this.pass = password; // Sets this object's string pass to be the same as the string declared when calling this constructor.
            this.user = username; // Sets this object's string user to be the same as the string declared when calling this constructor.
        }

        public Login (List<string> input)
        {
            this.reguser = input[0];
            this.regpass = input[1];
        }
        #endregion

        #region Methods

        public void CheckLogin()
        {
            MessageBox.Show(pass + user);
            SqlConnection myConnection = new SqlConnection(connectionString);
            SqlCommand login = new SqlCommand("SELECT Username, Password FROM Accounts WHERE Username=@user AND Password=@pass", myConnection);
            login.Parameters.Add("@user", SqlDbType.VarChar).Value = user;
            login.Parameters.Add("@pass", SqlDbType.VarChar).Value = pass;
            try
            {
                myConnection.Open();
                SqlDataReader reader = login.ExecuteReader();
                if(reader.Read())
                {
                    MessageBox.Show("LOGIN SUCCESFUL");
                }
                else
                {
                    MessageBox.Show("Try logging in again!");
                }
            }
            finally
            {
                myConnection.Close();
            }
        }

        public void CheckRegister()
        {
            SqlConnection connecthong = new SqlConnection(connectionString);
            MessageBox.Show(reguser+regpass);
            SqlCommand register = new SqlCommand("INSERT INTO Accounts (Username, Password) VALUES (@username, @password)", connecthong);
            register.Parameters.Add("@username", SqlDbType.VarChar).Value = reguser;
            register.Parameters.Add("@password", SqlDbType.VarChar).Value = regpass;
            try
            {
                connecthong.Open();
                register.ExecuteNonQuery();
            }
            finally
            {
                connecthong.Close();
            }
        }
        #endregion

    }
}
