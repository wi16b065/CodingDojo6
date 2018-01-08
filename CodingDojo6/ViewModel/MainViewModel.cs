using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;

namespace CodingDojo6.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        /// 
        private ViewModelBase currentVM;

        public ViewModelBase CurrentVM
        {
            get
            { return currentVM; }
            set
            {
                currentVM = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand OverviewBtnClickedCmd { get; set; }
        public RelayCommand MyToysBtnLClickedCmd { get; set; }

        public MainViewModel()
        {
            OverviewBtnClickedCmd = new RelayCommand(() =>
            {
                CurrentVM = SimpleIoc.Default.GetInstance<OverviewVM>();
            });
            MyToysBtnLClickedCmd = new RelayCommand(() =>
            {
                CurrentVM = SimpleIoc.Default.GetInstance<MyToysVM>();
            });
        }
    }
}