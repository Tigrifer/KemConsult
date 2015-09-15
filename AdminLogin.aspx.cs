using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Drawing;

public partial class AdminLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            if (!ucCapcha.IsValid)
            {
                lblError.Text = "Неправильно введен код защиты.";
                lblError.ForeColor = Color.Red;
                return;
            }
            if (FormsAuthentication.Authenticate(txtLogin.Text.Trim(), txtPass.Text.Trim()))
            {
                lblError.Text = "You are logged in!";
                lblError.ForeColor = Color.Green;
                FormsAuthentication.RedirectFromLoginPage(txtLogin.Text.Trim(), false);
            }
            else
            {
                lblError.Text = "Неверное имя пользователя или пароль.";
                lblError.ForeColor = Color.Red;
            }
        }
    }
}