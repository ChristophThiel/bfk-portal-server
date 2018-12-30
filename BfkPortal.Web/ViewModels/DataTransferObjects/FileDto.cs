namespace BfkPortal.Web.ViewModels.DataTransferObjects
{
    public class FileDto : EntityDto
    {
        public string FileName { get; set; }

        public string Path { get; set; }

        public string LastModified { get; set; }

        public string Created { get; set; }

        public int OwnerId { get; set; }
    }
}
