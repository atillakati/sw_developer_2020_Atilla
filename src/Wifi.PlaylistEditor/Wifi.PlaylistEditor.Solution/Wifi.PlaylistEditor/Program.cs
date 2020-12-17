using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Wifi.PlaylistEditor.Factories;
using Wifi.PlaylistEditor.PlaylistCreators;
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
            container.RegisterType<INewPlaylistCreator, DummyCreator>();
            container.RegisterType<IPlaylistItemFactory, PlaylistItemFactory>();
            
            Application.Run(container.Resolve<frm_main>());
        }
    }
}
