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
    public class ItemVm : ViewModelBase
    {
        public string Description { get; set; }

        public string AgeRecom { get; set; }
        public BitmapImage Image { get; set; }
        public ObservableCollection<ItemVm> ItemsInCategory { get; set; }

        public ItemVm(string description, string ageRecom, BitmapImage image)
        {
            Description = description;
            AgeRecom = ageRecom;
            Image = image;           
        }

        public ItemVm Clone(ItemVm item)
        {
            ItemVm itemCopy = new ItemVm(item.Description, item.AgeRecom, item.Image);
            return itemCopy;
        }

        public void AddItemToCategory(ItemVm item)
        {
            if (ItemsInCategory == null)
            {
                ItemsInCategory = new ObservableCollection<ItemVm>();
            }
            else
            {
                ItemsInCategory.Add(item);
            }
        }
    }
}
