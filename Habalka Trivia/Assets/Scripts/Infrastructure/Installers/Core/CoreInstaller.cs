using Trivia.Infrastructure.Core.Data.ConfigData.CoreMainPrefabsConfig;
using Trivia.Infrastructure.Core.MonoModels.MapCell;
using UnityEngine;
using Zenject;

public class CoreInstaller : MonoInstaller
{
    [SerializeField] private CoreMainPrefabsConfigContainer _coreMainPrefabsConfig = null;
    
    public override void InstallBindings()
    {
        BindFactories();
    }

    private void BindFactories()
    {
        Container
            .BindFactory<Vector3, CellCategoryViewModel, CellCategoryViewModel.Factory>()
            .FromComponentInNewPrefab(_coreMainPrefabsConfig.CellCategoryPrefab)
            .WithGameObjectName("Category_Cell");
    }

    private void BindCoreBuilders()
    {
        
    }
}