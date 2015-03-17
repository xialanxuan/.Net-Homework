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
    public partial class Default : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// check the validation of username and password
        /// username will be blocked if failed login is large than 3 times
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Submit_Click(object sender, EventArgs e)
        {   

            if (UsernameText.Value == "")
            {
                Response.Write("<script>alert('Username cannot be null!')</script>");
                return;
            }
            if (PasswordText.Value == "")
            {
                Response.Write("<script>alert('Password cannot be null!')</script>");
                return;
            }
            try
            {
                if(UsernameLockout(UsernameText.Value))
                    return;
                UserData.SelectParameters.Clear();
                UserData.SelectParameters.Add("Username", UsernameText.Value);
                UserData.Select(DataSourceSelectArguments.Empty);
                string user = UsernameText.Value;
                var myView = (DataView)UserData.Select(DataSourceSelectArguments.Empty);
                if (myView == null)
                    return;
                if (myView.Count == 1)
                {
                    var pass = myView[0]["Password"];
                    if (Session["Fail"] == null)
                    {
                        Session["Fail"] = new Dictionary<string, int>();
                    }
                    Dictionary<string, int> record = Session["Fail"] as Dictionary<string, int>;


                    if (!PasswordText.Value.Equals(pass.ToString()) || record.ContainsKey(user))
                    {
                        if (record.ContainsKey(user))
                        {
                            int count = record[user];
                            if (count == 2)
                            {
                                record.Remove(user);
                                Dictionary<string, DateTime> temp = (Dictionary<string, DateTime>)Session["Lockout"];
                                if (!temp.ContainsKey(user))
                                    temp.Add(user, DateTime.Now);
                                Session["Lockout"] = temp;
                            }
                            else
                            {
                                record[user] = count + 1;
                            }
                        }
                        else
                        {
                            record.Add(user, 1);
                            Session["Fail"] = record;
                        }

                        Response.Write("<script>alert('Login wrong! Please check your Password!')</script>");
                        return;

                    }
                    else
                    {
                        Session["Username"] = UsernameText.Value;
                        Response.Redirect("Main.aspx");                       
                    }
                }
                else
                {
                    Response.Write("<script>alert('Login wrong! Username doesnot exist')</script>");
                    return;
                }
            }
            catch (System.Data.SqlClient.SqlException sqlex1){
                Response.Write("<script>alert('Login wrong! Please check your Username and Password!')</script>");
                return;
            }

            

        }


        /// <summary>
        /// check if current username is locked
        /// unlock if it`s been an hour since last lock
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        protected bool UsernameLockout(string username)
        {
            if (Session["Lockout"] == null)
            {
                Session["Lockout"] = new Dictionary<string, DateTime>();
            }

            Dictionary<string, DateTime> current = Session["Lockout"] as Dictionary<string, DateTime>;
            if (current.Count == 0)
                return false;
            if (current.ContainsKey(username))
            {
                DateTime now = DateTime.Now;
                TimeSpan diff = now - current[username];
                if (diff.Minutes < 60)
                {
                    DateTime backtime = current[username].AddHours(1);
                    Response.Write("<script>alert('Login wrong! Becasue of too many failed login, your username has been locked! Please try again at " + backtime.ToLocalTime() + "')</script>");
                    return true;
                }
                else
                {
                    current.Remove(username);
                    Session["Lockout"] = current;
                }
               
            }
            else 
            {
                return false;
            }
            return false;
        }


        protected void UserData_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
          
        }
    }
}