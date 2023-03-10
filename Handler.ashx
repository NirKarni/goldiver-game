<%@ WebHandler Language="C#" Class="Handler" %>
using System;
using System.Web;
using System.Xml;
using Newtonsoft.Json;

public class Handler : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";

        string gameCode = context.Request["gameCode"]; //קוד המשחק שנשלח מאנימייט

        XmlDocument myDoc = new XmlDocument();
        myDoc.Load(context.Server.MapPath("Trees/XMLFile.xml")); //טעינת העץ שלכם

        XmlNode gameNode = myDoc.SelectSingleNode("//game[@code='" + gameCode + "']"); //שליפת הענף של המשחק המתאים
                                                                                       

        if (gameNode != null) //אם קיים משחק שתואם לקוד
        {
            //כאן תתבצע הבדיקה לפרסום


            string gameNodepublish = Convert.ToString(gameNode.Attributes["ispublished"].InnerText);

            //כאן תתבצע הבדיקה לפרסום
            if (gameNodepublish == "False" || gameNodepublish == "false") {
                context.Response.Write("notpublish");//שליחת תשובה שהמשחק לא פורסם
                
                  // var msg = string.Format(
                   // @"<script language='javascript'>alert('המשחק לא פורסם');</script>");
                //context.Response.Write(msg);
                    
            }
           else
           {
                //ההמרה לג'ייסון תתבצע רק אם המשחק קיים ומפורסם
                string jsonText = JsonConvert.SerializeXmlNode(gameNode); //המרת הענף מהעץ לטקסט במבנה של ג'ייסון
                context.Response.Write(jsonText); //שליחת המחרוזת אל אנימייט
            }
        }
        else //אם המשחק לא קיים
        {
            context.Response.Write("noGameFound"); //שליחת תשובה שלא נמצא משחק
        }
    }

    public bool IsReusable
    {
        get
        {
            return true;
        }
    }
}


