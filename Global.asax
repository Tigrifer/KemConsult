<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Код, выполняемый при запуске приложения

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Код, выполняемый при завершении работы приложения

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        /*try
        {
            string path = string.Format("{0}{1}", Server.MapPath("\\Admin\\"), "log.html");
            if (!System.IO.File.Exists(path))
                using (System.IO.FileStream fs = System.IO.File.Create(path))
                {}
            Exception ex = Context.Server.GetLastError();
            string log = string.Format("<div><b style='color:#333333;'>{0}</b> <span style='color:darkred;'>{1}</span></div> <hr>",
                                DateTime.Now.ToUniversalTime().ToString("dd-MM-yyyy HH:mm:ss.ff"),
                                ex.ToString().Replace("<", "&lt;").Replace(">", "&gt;"));
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(path, true))
            {
                sw.Write(log);
            }
            
        }
        catch (Exception err)
        {
            Response.Write(err.ToString());
        }
        Response.Write(" Извините. На сайте возникла ошибка. Попробуйте повторить Ваш запрос позднее.");
        Response.End();*/
    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Код, выполняемый при запуске нового сеанса

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Код, выполняемый при запуске приложения. 
        // Примечание. Событие Session_End вызывается только в том случае, если для режима sessionstate
        // задано значение InProc в файле Web.config. Если для режима сеанса задано значение StateServer 
        // или SQLServer, событие не порождается.

    }
       
</script>
