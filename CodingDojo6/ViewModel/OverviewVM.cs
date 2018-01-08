using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CodingDojo6.ViewModel
{
    public class OverviewVM : ViewModelBase
    {
        private ItemVm selectedCategory;

        public ItemVm SelectedCategory
        {
            get
            {
                return selectedCategory;
            }
            set
            {
                selectedCategory = value;
                RaisePropertyChanged();
            }
        }


        private RelayCommand<ItemVm> buyBtnClickedCmd;

        public RelayCommand<ItemVm> BuyBtnClickedCmd
        {
            get
            {
                return buyBtnClickedCmd;
            }
            set
            {
                buyBtnClickedCmd = value;
                RaisePropertyChanged();
            }
        }
        public ObservableCollection<ItemVm> Category { get; set; }

        public ObservableCollection<ItemVm> Cart { get; set; }

        public OverviewVM()
        {

            Category = new ObservableCollection<ItemVm>();
            Cart = new ObservableCollection<ItemVm>();
            BuyBtnClickedCmd = new RelayCommand<ItemVm>((itemOfPurchase) =>
            {
                Cart.Add(itemOfPurchase);
                foreach (var item in Cart)
                {
                    Console.WriteLine(item.Description);
                }
            });

            GenerateDemoData();
        }

        private void GenerateDemoData()
        {
            //generate Categories
            Category.Add(new ItemVm("My LEGO", "", new BitmapImage(new Uri("Images/lego1.jpg", UriKind.Relative))));
            Category.Add(new ItemVm("My Playmobil", "", new BitmapImage(new Uri("Images/playmobil1.jpg", UriKind.Relative))));

            //Add lego items to category
            Category[0].AddItemToCategory(new ItemVm("Helicopter", "10+", new BitmapImage(new Uri("../Images/lego4.jpg", UriKind.Relative))));
            Category[0].AddItemToCategory(new ItemVm("Digger", "12+", new BitmapImage(new Uri("../Images/lego2.jpg", UriKind.Relative))));
            Category[0].AddItemToCategory(new ItemVm("Chain Loader", "14+", new BitmapImage(new Uri("../Images/lego3.jpg", UriKind.Relative))));
            Category[0].AddItemToCategory(new ItemVm("Crawler Crane", "12+", new BitmapImage(new Uri("../Images/lego4.jpg", UriKind.Relative))));

            //Add playmobile items to category
            Category[1].AddItemToCategory(new ItemVm("Beach House", "5+", new BitmapImage(new Uri("../Images/playmobil1.jpg", UriKind.Relative))));
            Category[1].AddItemToCategory(new ItemVm("House", "8+", new BitmapImage(new Uri("../Images/playmobil2.jpg", UriKind.Relative))));
            Category[1].AddItemToCategory(new ItemVm("3 Knights", "8+", new BitmapImage(new Uri("../Images/playmobil3.jpg", UriKind.Relative))));
            Category[1].AddItemToCategory(new ItemVm("House 1", "10+", new BitmapImage(new Uri("../Images/playmobil2.jpg", UriKind.Relative))));
            Category[1].AddItemToCategory(new ItemVm("5 Knights", "8+", new BitmapImage(new Uri("../Images/playmobil3.jpg", UriKind.Relative))));
            Category[1].AddItemToCategory(new ItemVm("House 2", "12+", new BitmapImage(new Uri("../Images/playmobil2.jpg", UriKind.Relative))));
            Category[1].AddItemToCategory(new ItemVm("7 Knights", "8+", new BitmapImage(new Uri("../Images/playmobil3.jpg", UriKind.Relative))));

            //Testitem for Cart
            //Cart.Add(new ItemVm("Crawler Crane", "12+", new BitmapImage(new Uri("../Images/lego4.jpg", UriKind.Relative))));
            //Cart.Add(new ItemVm("Digger", "12+", new BitmapImage(new Uri("../Images/lego2.jpg", UriKind.Relative))));
        }
    }
}
