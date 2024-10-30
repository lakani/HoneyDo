using Blazored.LocalStorage;

namespace HoneyDo.Web.Client.Services
{
    public class LocalStorage : Shared.Services.LocalStorage
    {
        private ISyncLocalStorageService LocalStorageService;

        public LocalStorage(ISyncLocalStorageService _localStorageService)
        {
            LocalStorageService = _localStorageService;
        }

        protected override string ReadFromStorage()
        {            
             return LocalStorageService.GetItem<string>(StorageKeyName);
        }

        protected override void SaveToStorage(string jsonString)
        {                
            LocalStorageService.SetItem(StorageKeyName, jsonString);            
        }
    }
}
