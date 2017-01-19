using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml;

namespace cutecms_porto.Helpers
{
    public static class GeoIPHelper
    {
        #region Methods
        public static DataTable GetLocation(string strIPAddress)
        {
            //Create a WebRequest with the current Ip
            WebRequest _objWebRequest = WebRequest.Create("http://freegeoip.net/xml/" + strIPAddress);
            //Create a Web Proxy
            WebProxy _objWebProxy = new WebProxy("http://freegeoip.net/xml/" + strIPAddress, true);
            //Assign the proxy to the WebRequest
            _objWebRequest.Proxy = _objWebProxy;
            //Set the timeout in Seconds for the WebRequest
            _objWebRequest.Timeout = 2000;
            try
            {
                //Get the WebResponse
                WebResponse _objWebResponse = _objWebRequest.GetResponse();
                //Read the Response in a XMLTextReader
                XmlTextReader _objXmlTextReader
                    = new XmlTextReader(_objWebResponse.GetResponseStream());
                //Create a new DataSet
                DataSet _objDataSet = new DataSet();
                //Read the Response into the DataSet
                _objDataSet.ReadXml(_objXmlTextReader);
                return _objDataSet.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        #endregion Methods
    }
}