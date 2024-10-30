using Blazored.LocalStorage;

namespace HoneyDo.Web.Services
{
    public class LocalStorage : Shared.Services.LocalStorage
    {
        private ILocalStorageService LocalStorageService;

        public LocalStorage(ILocalStorageService _localStorageService)
        {
            LocalStorageService = _localStorageService;
        }

        protected override string ReadFromStorage()
        {
            ValueTask<string> task = LocalStorageService.GetItemAsync<string>(StorageKeyName);
            return task.GetAwaiter().GetResult();

        }

        protected override void SaveToStorage(string jsonString)
        {                
            LocalStorageService.SetItemAsync(StorageKeyName, jsonString);            
        }
    }
}
