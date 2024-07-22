using System.ComponentModel.DataAnnotations.Schema;

namespace NZWalksAPI.Models.Domain
{
    public class Image
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string? FileDescription { get; set; }
        public string FileExtention { get; set; }
        public string FilePath { get; set; }
        public long FileSizeInBytes { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }
        
    }
}
