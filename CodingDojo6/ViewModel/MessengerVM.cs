using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CodingDojo6.ViewModel
{
    public class MessengerVM : ViewModelBase
    {
        private BitmapImage statusImage;

        public BitmapImage StatusImage
        {
            get { return statusImage; }
            set
            {
                statusImage = value;
                RaisePropertyChanged();
            }
        }

        private string statusMessage;

        public string StatusMessage
        {
            get { return statusMessage; }
            set
            {
                statusMessage = value;
                RaisePropertyChanged();
            }
        }


        public void ShowMessage(string msg)
        {
            
        }

    }
}
