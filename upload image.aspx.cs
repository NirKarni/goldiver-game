using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class upload_image : System.Web.UI.Page
{

    string imagesLibPath = "uploadedFiles/";

    protected void Page_Load(object sender, EventArgs e)
    {

    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        string fileType = FileUpload1.PostedFile.ContentType;        if (fileType.Contains("image"))        {
            //שמירת הנתיב המלא של הקובץ             
            string fileName = FileUpload1.PostedFile.FileName;
            // הסיומת של הקובץ             
            string endOfFileName = fileName.Substring(fileName.LastIndexOf("."));
            //מתן זמן לתמונה למניעת כפילות             
            string myTime = DateTime.Now.ToString("dd_MM_yy-HH_mm_ss_ffff");
            // חיבור השם החדש עם הזמן והסיומת של הקובץ             
            string imageNewName = "imageNewName" + myTime + endOfFileName;
            //שמירה של הקובץ לספרייה בשם החדש שלו             
            FileUpload1.PostedFile.SaveAs(Server.MapPath(imagesLibPath) + imageNewName);
            Image1.ImageUrl = imagesLibPath + imageNewName;

        }
        else
        {
            Label1.Text = "הקובץ אינו תמונה ולכן לא ניתן להעלות אותו";
        }
    }
}