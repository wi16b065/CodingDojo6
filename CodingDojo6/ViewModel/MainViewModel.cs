using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;

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

        private Messenger msg = SimpleIoc.Default.GetInstance<Messenger>();

        DispatcherTimer timer = new DispatcherTimer();

        private string infoMsg = "";

        private BitmapImage msgImage;

        private bool isInfo = false;

        //private Visibility showBorder = Visibility.Hidden;

        //public Visibility ShowBorder
        //{
        //    get { return showBorder; }
        //    set
        //    {
        //        showBorder = value;
        //        RaisePropertyChanged();
        //    }
        //}


        public bool IsInfo
        {
            get { return isInfo; }
            set
            {
                isInfo = value;
                RaisePropertyChanged();
            }
        }

        public BitmapImage MsgImage
        {
            get { return msgImage; }
            set
            {
                msgImage = value;
                RaisePropertyChanged();
            }
        }


        public string InfoMsg
        {
            get { return infoMsg; }
            set {

                infoMsg = value;
                RaisePropertyChanged();
            }
        }


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
            //register is needed to receive sent messages
            msg.Register<PropertyChangedMessage<string>>(this, "InfoMsg", generateInfo);

            OverviewBtnClickedCmd = new RelayCommand(() =>
            {
                CurrentVM = SimpleIoc.Default.GetInstance<OverviewVM>();
            });
            MyToysBtnLClickedCmd = new RelayCommand(() =>
            {
                CurrentVM = SimpleIoc.Default.GetInstance<MyToysVM>();
            });
            
            //initialize default view
            CurrentVM = SimpleIoc.Default.GetInstance<OverviewVM>();

        }

        private void generateInfo(PropertyChangedMessage<string> obj)
        {
            //obj.NewValue -> message sent from OverviewVM
            MsgImage = new BitmapImage(new Uri(obj.NewValue.Split(';')[0],UriKind.Relative));
            InfoMsg = obj.NewValue.Split(';')[1];
            IsInfo = true;
            //ShowBorder = Visibility.Visible; 
            timer.Interval = new TimeSpan(0, 0, 2);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            IsInfo = false;
            //ShowBorder = Visibility.Hidden;
            InfoMsg = "";
            MsgImage = null;
            timer.Stop();
        }
    }
}