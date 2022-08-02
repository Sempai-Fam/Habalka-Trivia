using System.Threading.Tasks;
using Trivia.Infrastructure.Application.Services.AssetProvider;
using UnityEngine;
using Zenject;

namespace Trivia.Infrastructure.Application.Factories.PrefabFactory
{
    public class CustomPrefabFactory
    {
        private readonly DiContainer _container;
        private readonly AssetProviderService _assetProviderService;

        public CustomPrefabFactory(DiContainer container,
            AssetProviderService assetProviderService)
        {
            _container = container;
            _assetProviderService = assetProviderService;
        }
        
        public T Create<T>(string folderPath, string fileName)
        {
            var prefab = _assetProviderService.Load<GameObject>(folderPath, fileName);
            return BindAndInstantiate<T>(prefab);
        }
        
        public T Create<T>(string folderPath, string fileName, Transform parent)
        {
            var prefab = _assetProviderService.Load<GameObject>(folderPath, fileName);
            return BindAndInstantiate<T>(prefab, parent);
        }
        
        public T Create<T>(string folderPath, string fileName, Vector3 position, Quaternion quaternion, Transform parent)
        {
            var prefab = _assetProviderService.Load<GameObject>(folderPath, fileName);
            return BindAndInstantiate<T>(prefab,position, quaternion, parent);
        }

        public async Task<T> CreateAsync<T>(string folderPath, string fileName)
        {
            var prefab = await _assetProviderService.LoadAsync<GameObject>(folderPath, fileName);
            return BindAndInstantiate<T>(prefab);
        }

        public async Task<T> CreateAsync<T>(string folderPath, string fileName, Transform parent)
        {
            var prefab = await _assetProviderService.LoadAsync<GameObject>(folderPath, fileName);
            return BindAndInstantiate<T>(prefab, parent);
        }

        public async Task<T> CreateAsync<T>(string folderPath, string fileName, Vector3 position, Quaternion quaternion, Transform parent)
        {
            var prefab = await _assetProviderService.LoadAsync<GameObject>(folderPath, fileName);
            return BindAndInstantiate<T>(prefab, position, quaternion, parent);
        }

        private  T BindAndInstantiate<T>(GameObject prefab)
        {
            _container.Unbind<T>();
            return _container.InstantiatePrefabForComponent<T>(prefab);
        }

        private  T BindAndInstantiate<T>(GameObject prefab, Transform parent)
        {
            _container.Unbind<T>();
            return _container.InstantiatePrefabForComponent<T>(prefab, parent);
        }

        private  T BindAndInstantiate<T>(GameObject prefab, Vector3 position, Quaternion quaternion, Transform parent)
        {
            _container.Unbind<T>();
            return _container.InstantiatePrefabForComponent<T>(prefab, position, quaternion, parent);
        }
    }
}