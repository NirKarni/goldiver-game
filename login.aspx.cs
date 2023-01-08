using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        {
            // פאנל ההערות לא מוצג
            //labelFeedback.Visible = false;

            if (IsPostBack)
            {
                loginFail.Visible = true;
                loginDivers.Visible = false;
            }
            else
            {
                loginFail.Visible = false;
                loginDivers.Visible = true;
            }


        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        // אם שם המשתמש והסיסמה נכונים
        if (UserNameTxt.Text == "admin" && PasswordTxt.Text == "telem")
        {
            Response.Redirect("Default.aspx");
        }
        // אם שם המשתמש והסיסמה שגויים
        else if (UserNameTxt.Text != "admin" && PasswordTxt.Text != "telem")
        {
            labelFeedback.Visible = true;
            labelFeedback.Text = "שם משתמש וסיסמה שגויים";
        }
        // אם שם המשתמש שגוי
        else if (UserNameTxt.Text != "admin")
        {
            labelFeedback.Visible = true;
            labelFeedback.Text = "שם משתמש שגוי";
        }
        else //אם הסיסמה שגויה
        {
            labelFeedback.Visible = true;
            labelFeedback.Text = "סיסמה שגויה";
        }


    }
}