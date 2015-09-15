using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Configuration;

public partial class Admin_Password : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMessage.Text = "";
    }

    public void OnChange(object sender, EventArgs e)
    {
        Validate();
        if (IsValid)
        {
            if (txtNewPass.Text != txtNewPassRepeat.Text)
            {
                lblMessage.Text = "Ошибка изменения пароля. Новый пароль неверно повторен.";
                return;
            }

            Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
            AuthenticationSection auth;
            auth = config.GetSection("system.web/authentication") as AuthenticationSection;
            if (auth != null)
            {
                FormsAuthenticationUser user = auth.Forms.Credentials.Users["admin"];
                if (user.Password == txtOldPass.Text)
                {
                    user.Password = txtNewPass.Text;
                    config.Save();
                    lblMessage.Text = "Пароль успешно сохранен.";
                }
                else
                    lblMessage.Text = "Неправильно введен старый пароль.";
            }
        }
        else
            lblMessage.Text = "Ошибка изменения пароля. Условия не соблюдены.";
    }
}