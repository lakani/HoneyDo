namespace HoneyDo.Web.Services
{
    public class PhotoManager : Shared.Services.PhotoManager
    {       
        public override Task<string> PickPhotoAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<string> TakePhotoAsync()
        {
            throw new NotImplementedException();
        }
    }
}
