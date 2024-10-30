using System.Diagnostics;

namespace HoneyDo.Services
{
    public class PhotoManager : HoneyDo.Shared.Services.PhotoManager
    {
        public override async Task<string> PickPhotoAsync()
        {
            //MAUI abstracts the device specific code for us
            FileResult? photo = await MediaPicker.Default.PickPhotoAsync();
            return await SetPhoto(photo);
        }
        public override async Task<string> TakePhotoAsync()
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                try
                {
                    //MAUI abstracts the device specific code for us
                    FileResult? photo = await MediaPicker.Default.CapturePhotoAsync();
                    return await SetPhoto(photo);
                }
                catch (FileNotFoundException ex)
                {
                    //Capture is not supported or could not be completed.
                    Debug.WriteLine(ex);
                }
            }
            return "";
        }
        private async Task<string> SetPhoto(FileResult photo)
        {
            if (photo != null)
            {
                using Stream sourceStream = await photo.OpenReadAsync();

                //razor component needs a base64 encoded string so it can display the image in <img /> tag
                return GetImageString(sourceStream);
            }
            return "";
        }   
    }
}
