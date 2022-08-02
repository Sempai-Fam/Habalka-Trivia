using System.Collections.Generic;
using System.Linq;
using Trivia.Infrastructure.Application.Constants.Resource;
using UnityEngine;
using UnityEngine.U2D;

namespace Trivia.Infrastructure.Application.Services.SpriteLoader
{
    public class SpriteLoaderService
    {
        private readonly ResourcesConstants _resourcesConstants;
        private SpriteAtlas _cachedAtlas = null;

        public SpriteLoaderService(ResourcesConstants resourcesConstants)
        {
            _resourcesConstants = resourcesConstants;
        }

        public Sprite GetSpriteByPath(string atlasPath, string spriteName)
        {
            _cachedAtlas = LoadAtlas(atlasPath);

            Sprite tempSprite = _cachedAtlas.GetSprite(spriteName);
            
            UnloadAtlas();
            
            return tempSprite;
        }

        public List<Sprite> GetSpritesByPath(string atlasPath)
        {
            _cachedAtlas = LoadAtlas(atlasPath);
            Sprite[] tempSpritesArray = new Sprite[]{};
            _cachedAtlas.GetSprites(tempSpritesArray);

            UnloadAtlas();
            
            return tempSpritesArray.ToList();
        }

        public List<Sprite> GetSpritesByPath(string atlasPath, params string[] spriteNames)
        {
            _cachedAtlas = LoadAtlas(atlasPath);
            List<Sprite> tempSpritesList = new List<Sprite>();

            foreach (string name in spriteNames)
            {
                Sprite tempSprite = _cachedAtlas.GetSprite(name);
                tempSpritesList.Add(tempSprite);
            }
            
            UnloadAtlas();
            
            return tempSpritesList;
        }

        private SpriteAtlas LoadAtlas(string atlasPath)
        {
            string atlasFullPath = $"{_resourcesConstants.ATLAS_ROOT_FOLDER_PATH}/{atlasPath}";

            SpriteAtlas tempAtlas = Resources.Load<SpriteAtlas>(atlasFullPath);

            return tempAtlas;
        }

        private void UnloadAtlas()
        {
            if (_cachedAtlas != null)
            {
                Resources.UnloadAsset(_cachedAtlas);
                _cachedAtlas = null;
            }
        }
    }
}