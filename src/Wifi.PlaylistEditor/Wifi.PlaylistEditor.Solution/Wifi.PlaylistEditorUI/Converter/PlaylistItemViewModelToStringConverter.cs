using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;
using Wifi.PlaylistEditor.Types;
using Wifi.PlaylistEditorUI.ViewModel;

namespace Wifi.PlaylistEditorUI.Converter
{
    public class PlaylistItemViewModelToStringConverter : MarkupExtension, IValueConverter
    {
        private static PlaylistItemViewModelToStringConverter _converter;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _converter ?? (_converter = new PlaylistItemViewModelToStringConverter());
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IPlaylistItem item)
            {
                return item.ToString();
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
