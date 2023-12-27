namespace mvcGames.Models
{
    public static class FileModelExtensions
    {
        public static async Task<FileModel?> ConvertToFileModelAsync(this IFormFile file)
        {
            if (file == null || file.Length <= 0)
            {
                return null;
            }
            //var fileModel = new FileModel();
            //fileModel.FileName = file.FileName;
            //fileModel.ContentType = file.ContentType;

            var fileModel = new FileModel
            {
                FileName = file.FileName,
                ContentType = file.ContentType
            };

            fileModel.Content = await GetContentAsync(file);

            return fileModel;

        }
        //using statement here used to clear the data variable onces the code block is finished
        //this is to prevent memory leaks
        public static async Task<byte[]> GetContentAsync(this IFormFile file)
        {
            using (var data = new MemoryStream())
            {
                await file.CopyToAsync(data);
                byte[] dataArray = data.ToArray();
                return dataArray;

            }
        }
    }
}
