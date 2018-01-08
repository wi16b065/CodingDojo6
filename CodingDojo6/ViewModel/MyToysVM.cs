using GalaSoft.MvvmLight;
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
        public ObservableCollection<ItemVm> MyToysCollection { get; set; }

        public MyToysVM()
        {
            //MyToysCollection = new ObservableCollection<ItemVm>();
            //MyToysCollection.Add(new ItemVm("Beach House", "5+", new BitmapImage(new Uri("../Images/playmobil1.jpg", UriKind.Relative))));
        }
    }
}
