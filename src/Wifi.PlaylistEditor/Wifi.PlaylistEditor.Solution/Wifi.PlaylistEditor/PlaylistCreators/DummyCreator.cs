﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditor.PlaylistCreators
{
    public class DummyCreator : INewPlaylistCreator
    {
        public string Author => "Gandalf der Weise";

        public string Title => "Superplaylist Charts 2020";

        public bool StartDialog()
        {
            return true;
        }
    }
}
