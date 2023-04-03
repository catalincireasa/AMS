using Microsoft.AspNetCore.Mvc;
using AMS.Models;
using System.Data.SqlClient;

namespace AMS.Controllers
{
	public class AccountsController : Controller
	{
		SqlConnection con = new SqlConnection();
		SqlCommand com = new SqlCommand();
		SqlDataReader dr;

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		void connectionString()
		{
			con.ConnectionString = "data source=DESKTOP-7OILGIG; database=test; integrated security = SSPI;";
		}
		public ActionResult Verify(Accounts acc)
		{
			connectionString();
			con.Open();
			com.Connection = con;
			com.CommandText = "select * from tbl_login where username='"+acc.Name+"' and password='"+acc.Password+"'";
			dr = com.ExecuteReader();
			if(dr.Read())
			{
				con.Close();
				return View();
			}
			else
			{
				con.Close();
				return View();
			}

			
		}
	}
}
