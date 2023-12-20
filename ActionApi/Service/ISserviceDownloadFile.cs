namespace ActionApi.Service
{
    public interface ISserviceDownloadFile
    {
        string DownloadFile(string CID, string UID, string PID, string Image);
    }
}