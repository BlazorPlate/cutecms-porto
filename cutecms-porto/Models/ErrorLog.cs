using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace cutecms_porto.Models
{
    /// <summary>
    /// Author : RSS Team
    /// this class used in logging
    /// </summary>
    public class ErrorLog
    {
        /// <summary>
        /// Author : RSS Team
        /// Write Error Log
        /// </summary>
        /// <param name="LogMessage"></param>
        /// <returns>bool</returns>
        public bool WriteErrorLog(string LogMessage)
        {
            bool Status = false;
            string LogDirectory = "c:/LogFiles";//ConfigurationManager.AppSettings["LogDirectory"].ToString();

            DateTime CurrentDateTime = DateTime.Now;
            string CurrentDateTimeString = CurrentDateTime.ToString();
            CheckCreateLogDirectory(LogDirectory);
          
            string logLine = BuildLogLine(CurrentDateTime, LogMessage);
            LogDirectory = (LogDirectory + "Log_" + LogFileName(DateTime.Now) + ".txt");

            lock (typeof(ErrorLog))
            {
                StreamWriter oStreamWriter = null;
                try
                {
                    oStreamWriter = new StreamWriter(LogDirectory, true);
                    oStreamWriter.WriteLine(logLine);
                    Status = true;
                }
                catch
                {
                    throw new Exception("Error log file");
                }
                finally
                {
                    if (oStreamWriter != null)
                    {
                        oStreamWriter.Close();
                    }
                }
            }
            return Status;
        }

        /// <summary>
        /// Author : RSS Team 
        /// Check Create Log Directory
        /// </summary>
        /// <param name="LogPath"></param>
        /// <returns>bool</returns>
        private bool CheckCreateLogDirectory(string LogPath)
        {
            bool loggingDirectoryExists = false;
            DirectoryInfo oDirectoryInfo = new DirectoryInfo(LogPath);
            if (oDirectoryInfo.Exists)
            {
                loggingDirectoryExists = true;
            }
            else
            {
                try
                {
                    Directory.CreateDirectory(LogPath);
                    loggingDirectoryExists = true;
                }
                catch
                {
                    throw new Exception();
                    // Logging failure
                }
            }
            return loggingDirectoryExists;
        }

        /// <summary>
        /// Author : RSS Team 
        /// Build Log Line
        /// </summary>
        /// <param name="CurrentDateTime"></param>
        /// <param name="LogMessage"></param>
        /// <returns>string</returns>
        private string BuildLogLine(DateTime CurrentDateTime, string LogMessage)
        {
            StringBuilder loglineStringBuilder = new StringBuilder();
            loglineStringBuilder.Append(LogFileEntryDateTime(CurrentDateTime));
            loglineStringBuilder.Append(" \t");
            loglineStringBuilder.Append(LogMessage);
            return loglineStringBuilder.ToString();
        }

        /// <summary>
        /// Log File Entry Date Time
        /// </summary>
        /// <param name="CurrentDateTime"></param>
        /// <returns>string</returns>
        public string LogFileEntryDateTime(DateTime CurrentDateTime)
        {
            return CurrentDateTime.ToString("dd-MM-yyyy HH:mm:ss");
        }

        /// <summary>
        /// Log File Name
        /// </summary>
        /// <param name="CurrentDateTime"></param>
        /// <returns>string</returns>
        private string LogFileName(DateTime CurrentDateTime)
        {
            return CurrentDateTime.ToString("dd_MM_yyyy");
        }
    }
}