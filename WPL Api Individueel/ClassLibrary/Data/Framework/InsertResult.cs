namespace ClassLibrary.Data.Framework
{
    public class InsertResult : BaseResult
    {
        //NewId wordt teruggegeven door SQL Server - Auto Increment
        public int NewId { get; set; }
    }
}
