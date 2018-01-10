using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CodingDojo6.ViewModel
{
    public class MyToysVM : ViewModelBase
    {
        private Messenger msg = SimpleIoc.Default.GetInstance<Messenger>();

        private ObservableCollection<ItemVm> myToysCollection = new ObservableCollection<ItemVm>();

        public ObservableCollection<ItemVm> MyToysCollection
        {
            get { return myToysCollection; }
            set
            {
                myToysCollection = value;
                RaisePropertyChanged();
            }
        }


        public MyToysVM()
        {
            //MyToysCollection = new ObservableCollection<ItemVm>();
            //MyToysCollection.Add(new ItemVm("Beach House", "5+", new BitmapImage(new Uri("../Images/playmobil1.jpg", UriKind.Relative))));
            //this = object received
            msg.Register<PropertyChangedMessage<ItemVm>>(this, "Write", receivingMsg);

        }

        private void receivingMsg(PropertyChangedMessage<ItemVm> obj)
        {
            MyToysCollection.Add(obj.NewValue);
        }
    }
}
