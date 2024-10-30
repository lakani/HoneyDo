using System.ComponentModel;

namespace HoneyDo.Shared.Services
{
    public abstract class PhotoManager : IPhotoManager 
    {        
        public abstract Task<string> PickPhotoAsync();
        public abstract Task<string> TakePhotoAsync();
        protected static string GetImageString(Stream photoStream)
        {
            if (photoStream != null)
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    photoStream.CopyTo(memoryStream);
                    byte[] imageBytes = memoryStream.ToArray();

                    var imageSource = Convert.ToBase64String(imageBytes);
                    imageSource = string.Format("data:image/jpg;base64,{0}", imageSource);

                    return imageSource;
                }
            }
            return "";
        }
    }
}
