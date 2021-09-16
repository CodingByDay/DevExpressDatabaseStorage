﻿using DevExpress.DashboardCommon;
using DevExpress.DashboardWeb;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Web;
using peptak.DatabaseStorage;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

namespace peptak
{
    public partial class index : System.Web.UI.Page
    {


        public static string ConnectionString = @"Data Source=10.100.100.25\SPLAHOST; Database=graphs;Application Name = Dashboard; Integrated Security = false; User ID = dashboards; Password=Cporje?%ofgGHH$984d4L";

        private List<String> strings = new List<string>();
        private string state;
        private SqlConnection conn;
        private SqlCommand cmd;
        private string role;

        protected void Page_Load(object sender, EventArgs e)
        {



                 authenticate();
                 ASPxDashboard3.SetConnectionStringsProvider(new ConfigFileConnectionStringsProvider());



                // Hide the back button.  
                HtmlAnchor admin = this.Master.FindControl("backButtonA") as HtmlAnchor;

                admin.Visible = false;
                var dataBaseDashboardStorage = new DataBaseEditableDashboardStorage(ConnectionString);

                ASPxDashboard3.SetDashboardStorage(dataBaseDashboardStorage);

                ASPxDashboard3.Visible = true;

                ASPxDashboard3.ColorScheme = ASPxDashboard.ColorSchemeGreenMist;

                ASPxDashboard3.ConfigureDataConnection += ASPxDashboard3_ConfigureDataConnection;  
            
                ASPxDashboard3.DataRequestOptions.ItemDataRequestMode = ItemDataRequestMode.BatchRequests;

                if (!IsPostBack)

                {

                 ASPxDashboard3.SetConnectionStringsProvider(new DevExpress.DataAccess.Web.ConfigFileConnectionStringsProvider());

                 ASPxDashboard3.WorkingMode = WorkingMode.Viewer;

                 HtmlInputCheckBox toggle = (HtmlInputCheckBox)Master.FindControl("togglebox");


                if (Request.Cookies.Get("state") is null)
                {

                    Response.Cookies["state"].Value = "light";

                }
                else
                {
                    state = Request.Cookies.Get("state").Value;

                    switch (state)
                    {
                        case "light":
                            ASPxDashboard3.ColorScheme = ASPxDashboard.ColorSchemeLight;
                            break;
                        case "dark":
                            ASPxDashboard3.ColorScheme = ASPxDashboard.ColorSchemeDarkMoon;
                            break;

                    }
                }




            }


        }


        private void authenticate()

        {
            conn = new SqlConnection("server=10.100.100.25\\SPLAHOST;Database=graphs;Integrated Security=false;User ID=dashboards;Password=Cporje?%ofgGHH$984d4L;");
            conn.Open();
            var username = HttpContext.Current.User.Identity.Name;
            // Create SqlCommand to select pwd field from users table given supplied userName.
            cmd = new SqlCommand($"select userRole from Users where uname='{username}';", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                role = (reader["userRole"].ToString());
            }
           



            if(role=="SuperAdmin")
            {

            } else
            {
                Response.Redirect("logon.aspx", true);
            }
        }




        private void ASPxDashboard3_ConfigureDataConnection(object sender, ConfigureDataConnectionWebEventArgs e)
        {
          

            ConnectionStringSettings conn = GetConnectionString();          
            CustomStringConnectionParameters parameters =
            (CustomStringConnectionParameters)e.ConnectionParameters;

            parameters.ConnectionString = conn.ConnectionString;
        }

        private ConnectionStringSettings GetConnectionString()
        {
            var ConnectionName = Session["conn"].ToString();
            ConnectionStringSettings stringFinal = ConfigurationManager.ConnectionStrings[ConnectionName];
            return stringFinal;
        }

       





    }
}