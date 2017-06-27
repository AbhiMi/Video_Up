using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RADBusinessLogicLayer;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Configuration;

public partial class Pages_Create_CreateThumbnail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string innerHTML = string.Empty;
        DataTable dtMedia = GetSelectedVideo(12);
        if (dtMedia != null && dtMedia.Rows.Count > 0)
        {
            foreach (DataRow dr in dtMedia.Rows)
            {
                innerHTML = "<source src='" + dr["UrlLocation"].ToString() + "'></source>";
                //WebControl control = (WebControl)e.Row.Cells[4].FindControl("ctrlVideo");
                myVideo.InnerHtml = innerHTML;
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>getCurTime();</script>", false);
            Process process = new Process();
            process.StartInfo.FileName = ConfigurationManager.AppSettings["ffmpegLocation"];
            //process.StartInfo.FileName = @"C:\Users\srprasad\Perforce\srikant_VideoUp\Video_Up\RADVupTiles\Bin\ffmpeg.exe";
            string imglocation = ConfigurationManager.AppSettings["imageLocation"];
            string filepath = string.Empty;//@"C:\Users\srprasad\Perforce\srikant_VideoUp\Video_Up\RADVupTiles\Media";
            string filename = string.Empty;
            double time;
            DataTable dtMedia = GetSelectedVideo(12);
            if (dtMedia != null && dtMedia.Rows.Count > 0)
            {
                foreach (DataRow dr in dtMedia.Rows)
                {
                    filepath = dr["PhysicalLocation"].ToString();
                    filename = Path.GetFileNameWithoutExtension(filepath);
                    // Prepare a temporary file for ommandline usage
                    string tmpFileName = imglocation + filename + ".png";
                    //if (tmpFileName.Contains(' '))
                    //    tmpFileName = "\"" + tmpFileName + "\"";
                    time = Convert.ToDouble(inpHide.Value);
                    TimeSpan position = TimeSpan.FromSeconds(time);
                    string cmdParams = String.Format("-hide_banner -ss {0} -i {1} -r 1 -t 1 -f image2 {2}", position, filepath, tmpFileName);
                    process.StartInfo.Arguments = cmdParams;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.Start();
                    // Synchronously read the standard output of the spawned process. 
                    StreamReader reader = process.StandardOutput;
                    string output = reader.ReadToEnd();
                    // Write the redirected output to this application's window.
                    Console.WriteLine(output);
                    process.WaitForExit();
                    process.Close();
                }
            }
        }
        catch (Exception ex)
        { }
    }

    public DataTable GetSelectedVideo(int videoID)
    {
        BusinessLogic objBusinessLogic = new BusinessLogic();
        DataTable dtVideo = objBusinessLogic.GetMediaFromID(videoID);

        return dtVideo;
    }
}