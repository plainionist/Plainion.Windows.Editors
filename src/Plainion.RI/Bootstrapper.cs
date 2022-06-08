using System.Windows;
using System.Windows.Controls;
using Plainion.Prism.Interactivity;
using Plainion.Prism.Regions;
using Prism.Interactivity;
using Prism.Modularity;
using Prism.Regions;
using Prism.Regions.Behaviors;
using Prism.Unity;
using Unity;
using Unity.Lifetime;

namespace Plainion.RI
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            Application.Current.MainWindow = (Window)Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            ModuleCatalog.AddModule(new ModuleInfo(typeof(CoreModule).Name, typeof(CoreModule).AssemblyQualifiedName));
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterType<StackPanelRegionAdapter, StackPanelRegionAdapter>();
            Container.RegisterType<PopupWindowActionRegionAdapter, PopupWindowActionRegionAdapter>();
            Container.RegisterType<DelayedRegionCreationBehavior, KeepAliveDelayedRegionCreationBehavior>(new TransientLifetimeManager());
        }

        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            var mappings = base.ConfigureRegionAdapterMappings();

            mappings.RegisterMapping(typeof(StackPanel), Container.Resolve<StackPanelRegionAdapter>());
            mappings.RegisterMapping(typeof(PopupWindowAction), Container.Resolve<PopupWindowActionRegionAdapter>());

            return mappings;
        }

        public override void Run(bool runWithDefaultConfiguration)
        {
            base.Run(runWithDefaultConfiguration);

            Application.Current.Exit += OnShutdown;
        }

        protected virtual void OnShutdown(object sender, ExitEventArgs e)
        {
            Container.Dispose();
        }

    }
}
