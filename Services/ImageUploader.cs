using Microsoft.AspNetCore.Components.Forms;

namespace UndecidedApp.Services
{
    public  class ImageUploader
    {
        private readonly string _imageFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "post");
        private readonly PostService _post;
        public ImageUploader(PostService post)
        {
            _post = post;
        }


        public  void DirectoryExists()
        {
            if (!System.IO.Directory.Exists(Directory.GetCurrentDirectory() + "/wwwroot/images"))
            {
                System.IO.Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/wwwroot/images");
            }
        }

        public async Task<string> UploadImage(IBrowserFile file)
        {
            
            if(file == null)
            {
                return null;
            }

            try
            {
                var filePath = Path.Combine(_imageFolder, file.Name);
                using var outputStream = new FileStream(filePath, FileMode.Create);
                await file.OpenReadStream().CopyToAsync(outputStream);

                var imagePath = $"images/post/{file.Name}";

                return imagePath;
            }
            catch(Exception ex)
            {
                return $"Error uploading the image. Reason:  {ex.Message}";

            }

        
        }

    }
}
