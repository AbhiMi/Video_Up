<%@ WebHandler Language="C#" Class="Upload" %>
 
using System;
using System.Web;
using System.IO;
using System.Data;
using RADBusinessLogicLayer;
using RADCommonServices;
 
public class Upload : IHttpHandler {
   
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        context.Response.Expires = -1;
        BusinessLogic objBusinessLogic = new BusinessLogic();
        int companyID = 0;
        string userName = HttpContext.Current.User.Identity.Name;
        string userId = objBusinessLogic.GetUserId(userName.ToLower());
        if (userId != "0")
        {
            Guid userGuid = Guid.Parse(userId);
            DataTable dtCompanies = objBusinessLogic.GetUserCompany(userGuid);
            if (dtCompanies != null && dtCompanies.Rows.Count > 0)
            {
                foreach (DataRow dr in dtCompanies.Rows)
                {
                    companyID = Convert.ToInt32(dr["CompanyID"]);
                }
            }
        }
        RADDataAccessLayer.MediaLibrary objMediaLibrary = new RADDataAccessLayer.MediaLibrary();
        try
        {
            HttpPostedFile postedFile = context.Request.Files["Filedata"];
           
            string savepath = "";
            string tempPath = "";
            tempPath = System.Configuration.ConfigurationManager.AppSettings["FolderPath"];
            savepath = context.Server.MapPath(tempPath);
            string filename = postedFile.FileName;
            if (!Directory.Exists(savepath))
                Directory.CreateDirectory(savepath);
 
            string fullPath = Path.GetFullPath(postedFile.FileName);
            string strfilename = Path.GetFileName(postedFile.FileName);
            string name = filename.Split('.')[0];
            
            objMediaLibrary.Description = filename;
            objMediaLibrary.UrlLocation = "http://" + context.Request.Url.Authority +"/Media/"+ filename;
            objMediaLibrary.PhysicalLocation = savepath + "\\" + filename;
            objMediaLibrary.MIMEType = postedFile.ContentType;
            objMediaLibrary.UploadedBy = HttpContext.Current.User.Identity.Name;
            objMediaLibrary.CompanyID = companyID;

            //retrieve the HttpPostedFile object
            byte[] buffer = new byte[postedFile.ContentLength];
            int bytesReaded = postedFile.InputStream.Read(buffer, 0,
            postedFile.ContentLength);

            objMediaLibrary.VideoBuffer = buffer;     

            objBusinessLogic.InsertMediaLibrary(objMediaLibrary); 

            postedFile.SaveAs(savepath + @"\" + filename);

            context.Response.Write(tempPath + "/" + filename);
            context.Response.StatusCode = 200;
        }
        catch (Exception ex)
        {
            context.Response.Write("Error: " + ex.Message);
        }
    }
    private byte[] StreamFile(string fileName)
    {
        // Open file
        FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        // ByteArray
        byte[] byteData = new byte[fs.Length];
        // Read block of bytes
        fs.Read(byteData, 0, System.Convert.ToInt32(fs.Length));
        // Close it
        fs.Close();
        // Return the byte data
        return byteData;
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
}