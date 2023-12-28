using FluentFTP;
using System.Net;

namespace ActionApi.Service
{
    public class ServiceFTP : IServiceFTP
    {
        public void UploadFileToServer(string fileName)
        {
            FtpClient client = new FtpClient();
            client.Host = "10.0.0.15";
            client.Credentials = new NetworkCredential("user", "pass");
            client.Connect();
            client.UploadFile(fileName, fileName);//download the file by name and upload the file to the server with the same name. The file name will be generated based on the guid, a unique name

        }
    }
}
