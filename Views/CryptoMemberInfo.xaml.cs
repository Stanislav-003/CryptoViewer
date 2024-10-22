using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace CryptoViewer.Views;

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

    private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
    {
        Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
        e.Handled = true;
    }
}
