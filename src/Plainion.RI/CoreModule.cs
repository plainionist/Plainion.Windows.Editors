using Plainion.RI.Editors;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Plainion.RI
{
    class CoreModule : IModule
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion( RegionNames.Editors, typeof( XmlEditorView ) );
        }
    }
}
