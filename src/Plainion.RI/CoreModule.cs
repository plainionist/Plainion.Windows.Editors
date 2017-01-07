using System.ComponentModel.Composition;
using Plainion.RI.Editors;
using Prism.Mef.Modularity;
using Prism.Modularity;
using Prism.Regions;

namespace Plainion.RI
{
    [ModuleExport( typeof( CoreModule ) )]
    class CoreModule : IModule
    {
        [Import]
        public IRegionManager RegionManager { get; private set; }

        public void Initialize()
        {
            RegionManager.RegisterViewWithRegion( RegionNames.Editors, typeof( XmlEditorView ) );
        }
    }
}
