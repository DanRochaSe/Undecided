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

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.Name);
            var filePath = Path.Combine(_imageFolder, fileName);


            try
            {

                using var outputStream = new FileStream(filePath, FileMode.Create);
                await file.OpenReadStream().CopyToAsync(outputStream);

                //using var reader = new StreamReader(file.OpenReadStream());
                //var content = await reader.ReadToEndAsync();

                //await File.WriteAllBytesAsync(filePath, Convert.FromBase64String(content));
                var imagePath = $"images/post/{fileName}";

                return imagePath;
            }
            catch(Exception ex)
            {
                return $"Error uploading the image. Reason:  {ex.Message}";

            }

            //try
            //{
            //    await file.CopyToAsync(new FileStream(filePath, FileMode.Create));


            //    var imagePath = $"images/post/{fileName}";


            //    return imagePath;

            //}catch(Exception ex)
            //{
            //    return $"Error uploading the image. Reason:  {ex.Message}";
            //}
        }

    }
}
