using ISWebApp.Models;

namespace ISWebApp.Storage
{
    public class StorageService
    {
        private readonly IStorage<PersonModel> _storage;

        public StorageService(IStorage<PersonModel> storage)
        {
            _storage = storage;
        }

        public string GetStorageType()
        {
            return _storage.StorageType;
        }

        public int GetNumberOfItems()
        {
            return _storage.All.Count;
        }
    }
}