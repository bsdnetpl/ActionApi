using System.Net;

namespace ActionApi.Service
{
    public class SserviceDownloadFile : ISserviceDownloadFile
    {

        //        Zdjęcia dostępne są pod adresem:

        //https://cdn.action.pl/File.aspx?CID=XXX&UID=YYY&PID=ZZZ&P=WWW

        //gdzie:

        //XXX - należy wpisać ID Państwa firmy w systemie Action

        //YYY - login konta, na którym będzie przebiegać operacja pobierania zdjęć(nie należy go poprzedzać identyfikatorem i kropką)

        //ZZZ - unikalny ciąg znaków dostępny wyżej w skecji "Unikalny klucz uwierzytelniający"

        //WWW - ścieżka zwracana przez pliki XML i WebService

        public string DownloadFile(string CID, string UID, string PID, string Image) //the image name we get from the DB while we put into the extraction process from the XML file
        {
            string url = $"https://cdn.action.pl/File.aspx?CID={CID}&UID={UID}&PIF={PID}&P={Image}"; //generate link , We can put CID, UID, PID into db and get them whenever we need 
            try
            {
                using (WebClient myWebClient = new WebClient())
                {
                    myWebClient.DownloadFile(url, Image.Substring(8)); // we get the file name in the format / Icecat / D1Q7D4n8e0H0M1o6I4J9J7V634H9h864.jpg, we have to cut out / Icecat / and leave the name only D1Q7D4n8e0H0M1o6I4J9J7V634H9h864.jpg
                }
                return Image;
            }
            catch (Exception ex)
            {
                // If there is an exception, msg
                return "We have the Problem ! " + ex.Message;
            }

        }
    }
}
