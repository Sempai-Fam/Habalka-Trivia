using System.Threading.Tasks;
using UnityEngine;

namespace Trivia.Infrastructure.Application.Services.AssetProvider
{
    public class AssetProviderService
    {
        public T Load<T>(string folderPath, string fileName) where T : Object
        {
            string fullPath = $"{folderPath}/{fileName}";

            var tempAsset = Resources.Load<T>(fullPath);

            return tempAsset;
        }
        
        public Task<T> LoadAsync<T>(string folderPath, string fileName) where T : Object
        {
            string fullPath = $"{folderPath}/{fileName}";

            var tempAsset = Resources.LoadAsync<T>(fullPath);

            return Task.FromResult(tempAsset.asset as T);
        }
    }
}