using System.Windows;
using System.Windows.Controls;

namespace Digital_Cloud_Technologies.Views;

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
