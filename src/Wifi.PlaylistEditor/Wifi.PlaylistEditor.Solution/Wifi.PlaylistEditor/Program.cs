using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Wifi.PlaylistEditor.Factories;
using Wifi.PlaylistEditor.PlaylistCreators;
using Wifi.PlaylistEditor.Repositories.MongoDb;
using Wifi.PlaylistEditor.Repositories.MongoDb.Core;
using Wifi.PlaylistEditor.Repositories.MongoDb.UI;
using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //applikation start
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var container = new UnityContainer();

            //Typen registrieren
            container.RegisterType<INewPlaylistCreator, frm_newPlaylist>();
            container.RegisterType<IPlaylistItemFactory, PlaylistItemFactory>();
            container.RegisterType<IRepositoryFactory, RepositoryFactory>();
            container.RegisterType<IDatabaseRepository, MongoDbRepository>();
            container.RegisterType<IDatabaseLoadDialog, frm_databaseLoad>();
            
            Application.Run(container.Resolve<frm_main>());
        }
    }
}
