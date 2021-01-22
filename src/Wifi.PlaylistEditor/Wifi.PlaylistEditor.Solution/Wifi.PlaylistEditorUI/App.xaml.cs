using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;
using Wifi.PlaylistEditor.Factories;
using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditorUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var container = new UnityContainer();

            //Typen registrieren
            container.RegisterType<INewPlaylistCreator, DummyCreator>();
            container.RegisterType<IPlaylistItemFactory, PlaylistItemFactory>();
            container.RegisterType<IRepositoryFactory, RepositoryFactory>();

            base.OnStartup(e);
            var window = container.Resolve<MainWindow>();

            window.Show();
        }
    }
}
