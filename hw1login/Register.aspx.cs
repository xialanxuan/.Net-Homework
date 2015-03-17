using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace hw1login
{


    public partial class Register : System.Web.UI.Page
    {
        /// <summary>
        /// set hits if previous registeration was failed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                string UsernameRequire = "Username must be at least 4 characters and at most 20 characters";
                string PasswordRequire = "Password must contain at least 6 characters including a number and a sepcial symbol and at most 20 characters";
                LabelUsername.Text = UsernameRequire;
                LabelPassword.Text = PasswordRequire;
                return;
            }
        }


        /// <summary>
        /// check the validation of password and username
        /// insert into the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Submit_Click(object sender, EventArgs e) 
        {
            //check validation of username and password
            if (UsernameText == null || PasswordText == null)
            {
                return;
            }
            if (!Check_Username_Valid(UsernameText.Value))
            {
                return;
            }
            else if (!Check_Password_Valid(PasswordText.Value))
            {
                return;
            }
            else
            {
                UserData.InsertParameters.Clear();
                UserData.InsertParameters.Add("Username", UsernameText.Value);
                UserData.InsertParameters.Add("Password", PasswordText.Value);
                try 
                {
                    UserData.Insert();
                    Response.Redirect("Default.aspx");
                }
                catch(System.Data.SqlClient.SqlException sqlex)
                {
                    Response.Write("<script>alert('user already exists!')</script>");
                }
                
                
                //this is a way I tried to check the existence of username. I think it`s right but not graceful

               /* UserData.SelectParameters.Clear();
                UserData.SelectParameters.Add("Username", UsernameText.Value);
                UserData.Select(DataSourceSelectArguments.Empty); ;


                var myView = (DataView)UserData.Select(DataSourceSelectArguments.Empty);

                if (myView == null || myView.Count == 0)
                {
                    UserData.InsertParameters.Clear();
                    UserData.InsertParameters.Add("Username", UsernameText.Value);
                    UserData.InsertParameters.Add("Password", PasswordText.Value);
                    UserData.Insert();
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    Response.Write("<script>alert('user already exists!')</script>");
                }
                */


            }
        }

        protected void UserData_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        /// <summary>
        /// check if username is valid
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool Check_Username_Valid(String username)
        {
            if (username == null || username.Length > 20 || username.Length < 4)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        /// <summary>
        /// check if password is valid
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Check_Password_Valid(String password)
        {
            if (password == null || password.Length > 20 || password.Length < 6)
            {
                return false;
            }
            else
            {
                bool gotNum = false;
                bool gotSpecial = false;
                foreach (char c in password)
                {
                    if (char.IsNumber(c))
                        gotNum = true;
                    if (!char.IsLetterOrDigit(c))
                        gotSpecial = true;
                    if (gotNum == true && gotSpecial == true)
                        return true;
                }
            }
            return false;
        }

    }
}