using System;
using context = System.Web.HttpContext;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;

/// <summary>
/// Summary description for ExceptionLogging
/// </summary>
public class ExceptionLogging
{
    public static void SendExcepToDB(Exception exdb)
    {
        string exepurl = string.Empty; ;
        try
        {
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            using (SqlConnection cn = new SqlConnection(constr))
            {
                cn.Open();
                exepurl = context.Current.Request.Url.ToString();
                SqlCommand com = new SqlCommand("ExceptionLoggingToDataBase", cn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ExceptionMsg", exdb.Message.ToString());
                com.Parameters.AddWithValue("@ExceptionType", exdb.GetType().Name.ToString());
                com.Parameters.AddWithValue("@ExceptionURL", exepurl);
                com.Parameters.AddWithValue("@ExceptionSource", exdb.StackTrace.ToString());
                com.ExecuteNonQuery();
            }
        }
        catch
        {
            AddtoLogFile(exdb, exepurl);
        }
    }

    public static void LogFile(Exception exLog, string uRL)
    {
        StreamWriter log;
        string fileName = "logfile.txt";
        string logFilepath = ConfigurationManager.AppSettings["LogFilePath"].ToString();
        string path = Path.Combine(logFilepath, fileName);
        if (!File.Exists(path))
        {
            File.Create(path);
            log = new StreamWriter(path);
        }
        else
        {
            log = File.AppendText(path);
        }
        log.WriteLine("********************************");
        log.WriteLine("Data Time:" + DateTime.Now);
        log.WriteLine("Exception Message:" + exLog.Message.ToString());
        log.WriteLine("Exception Type:" + exLog.GetType().Name.ToString());
        log.WriteLine("ExceptionURL:" + uRL);
        log.WriteLine("Exception Sourc:" + exLog.StackTrace.ToString());
        log.WriteLine("********************************");
        log.Close();
    }

    public static void AddtoLogFile(Exception exLog, string uRL)
    {
        string LogPath = ConfigurationManager.AppSettings["LogFilePath"].ToString();
        string filename = "Log_" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";
        string filepath = LogPath + filename;
        if (File.Exists(filepath))
        {
            using (StreamWriter writer = new StreamWriter(filepath, true))
            {
                writer.WriteLine("-------------------START-------------" + DateTime.Now);
                writer.WriteLine("Data Time:" + DateTime.Now);
                writer.WriteLine("Exception Message:" + exLog.Message.ToString());
                writer.WriteLine("Exception Type:" + exLog.GetType().Name.ToString());
                writer.WriteLine("ExceptionURL:" + uRL);
                writer.WriteLine("Exception Sourc:" + exLog.StackTrace.ToString());
                writer.WriteLine("-------------------END-------------" + DateTime.Now);
                writer.Close();
            }
        }
        else
        {
            using (StreamWriter writer = File.CreateText(filepath))
            {
                writer.WriteLine("-------------------START-------------" + DateTime.Now);
                writer.WriteLine("Data Time:" + DateTime.Now);
                writer.WriteLine("Exception Message:" + exLog.Message.ToString());
                writer.WriteLine("Exception Type:" + exLog.GetType().Name.ToString());
                writer.WriteLine("ExceptionURL:" + uRL);
                writer.WriteLine("Exception Sourc:" + exLog.StackTrace.ToString());
                writer.WriteLine("-------------------END-------------" + DateTime.Now);
                writer.Close();
            }
        }
    }
}