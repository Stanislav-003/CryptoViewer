using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Digital_Cloud_Technologies
{
    public partial class MainWindow : Window
    {
        public string ResponseContent
        {
            get { return (string)GetValue(ResponseContentProperty); }
            set { SetValue(ResponseContentProperty, value); }
        }

        public static readonly DependencyProperty ResponseContentProperty =
            DependencyProperty.Register("ResponseContent", typeof(string), typeof(MainWindow));

        public ObservableCollection<CryptoCurrency> Members { get; set; } = new ObservableCollection<CryptoCurrency>();

        public MainWindow()
        {
            InitializeComponent();
            MakeRequest();
        }

        private async void MakeRequest()
        {
            ResponseContent = "Загрузка...";

            //await Task.Yield();

            var cryptoResponse = await Utilities.FetchCryptoCoinInfo();

            if (cryptoResponse != null)
            {
                ResponseContent = Utilities.FormatCryptoResponse(cryptoResponse);
            }
            else
            {
                ResponseContent = "Не удалось получить данные.";
            }

            Members.Clear();
            foreach (var m in cryptoResponse!.Response)
            {
                Members.Add(m);
            }
        }

        private void btnRefreshRequest_Click(object sender, RoutedEventArgs e)
        {
            MakeRequest();
        }
    }
}