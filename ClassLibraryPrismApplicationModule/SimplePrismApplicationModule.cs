using ClassLibraryPrismApplicationModule.View;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace ClassLibraryPrismApplicationModule
{
    public class SimplePrismApplicationModule : IModule
    {
        private IRegionManager _regionManager;

        public SimplePrismApplicationModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("MainRegion", typeof(SimplePrismApplicationView));
        }
    }
}