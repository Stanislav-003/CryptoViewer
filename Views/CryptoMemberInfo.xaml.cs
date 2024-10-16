using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Digital_Cloud_Technologies.Views
{  
    public partial class CryptoMemberInfo : UserControl
    {
        public CryptoCurrency Member
        {
            get { return (CryptoCurrency)GetValue(MemberProperty); }
            set { SetValue(MemberProperty, value); }
        }

        public static readonly DependencyProperty MemberProperty =
            DependencyProperty.Register("Member", typeof(CryptoCurrency), typeof(CryptoMemberInfo));



        public CryptoMemberInfo()
        {
            InitializeComponent();
        }
    }
}
