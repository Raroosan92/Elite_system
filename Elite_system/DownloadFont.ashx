<%@ WebHandler Language="C#" Class="DownloadFont" %>
using System;
using System.Web;
using System.IO;

 public class DownloadFont : IHttpHandler 
{
    public void ProcessRequest(HttpContext context)
    {   
            string file="fonts/IDAutomationC128XS.ttf";
            context.Response.Clear();
            context.Response.ContentType = "application/octet-stream";
            context.Response.AddHeader("content-disposition", "attachment;filename=" + Path.GetFileName(file));
            context.Response.WriteFile(context.Server.MapPath(file));

    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}