using System.Net;

namespace ActionApi.Models
{
    public class XmlAction
    {
        public bool DownloadFile(string url)
        {
            try
            {
                string fileName = System.IO.Path.GetFileName(url);
                using (WebClient myWebClient = new WebClient())
                {
                    myWebClient.DownloadFile(url, fileName);
                }
            }
            catch (Exception ex)
            {
                // If there is an exception, return false
                return false;
            }
            // If the download is successful, return true
            return true;
        }
    }
}
