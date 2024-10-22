using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace CryptoViewer.Views;

public partial class MainWindow : Window, INotifyPropertyChanged
{
    public ObservableCollection<CryptoCurrency> Members { get; set; } = new ObservableCollection<CryptoCurrency>();
    private ObservableCollection<CryptoCurrency> _allMembers = new ObservableCollection<CryptoCurrency>();
    private ObservableCollection<CryptoCurrency> _filteredMembers = new ObservableCollection<CryptoCurrency>();

    public string ResponseContent
    {
        get { return (string)GetValue(ResponseContentProperty); }
        set { SetValue(ResponseContentProperty, value); }
    }

    public static readonly DependencyProperty ResponseContentProperty =
        DependencyProperty.Register("ResponseContent", typeof(string), typeof(MainWindow));


    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
        MakeRequest();
        SelectedRecord = "10";
        UpdatePagedMembers();
    }

    private async void MakeRequest()
    {
        ResponseContent = "Loading...";

        //await Task.Yield();

        var cryptoResponse = await Utilities.FetchCryptoCoinInfo();

        if (cryptoResponse != null)
        {
            ResponseContent = Utilities.FormatCryptoResponse(cryptoResponse);

            _allMembers.Clear();
            foreach (var m in cryptoResponse.Response)
            {
                _allMembers.Add(m);
            }
            FilterMembers();
            CurrentPage = 1;
            UpdatePagination();
        }
        else
        {
            ResponseContent = "Failed to retrieve data.";
        }
    }

    private void btnRefreshRequest_Click(object sender, RoutedEventArgs e)
    {
        MakeRequest();
    }

    private string _searchText = string.Empty;
    public string SearchText
    {
        get { return _searchText; }
        set
        {
            _searchText = value;
            OnPropertyChanged(nameof(SearchText));
            FilterMembers();
        }
    }

    private void FilterMembers()
    {
        if (string.IsNullOrWhiteSpace(SearchText))
        {
            _filteredMembers = new ObservableCollection<CryptoCurrency>(_allMembers);
        }
        else
        {
            _filteredMembers = new ObservableCollection<CryptoCurrency>(
                _allMembers.Where(m => m.Name.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0)
            );
        }
        UpdatePagination();
    }

    private void UpdatePagination()
    {
        int pageSize = int.Parse(SelectedRecord);
        NumberOfPages = (_filteredMembers.Count + pageSize - 1) / pageSize;
        CurrentPage = Math.Min(CurrentPage, NumberOfPages);
        UpdatePagedMembers();
    }

    private void UpdatePagedMembers()
    {
        int pageSize = int.Parse(SelectedRecord);
        int startIndex = (CurrentPage - 1) * pageSize;
        Members.Clear();
        if (_filteredMembers.Any())
        {
            foreach (var member in _filteredMembers.Skip(startIndex).Take(pageSize))
            {
                Members.Add(member);
            }
        }
    }

    private int _currentPage = 1; 

    public int CurrentPage
    {
        get { return _currentPage; }

        set 
        {
            _currentPage = value;
            OnPropertyChanged(nameof(CurrentPage));
            UpdatePagedMembers();
        }
    }

    private int _numberOfPages = 10;

    public int NumberOfPages
    {
        get { return _numberOfPages; }

        set
        {
            _numberOfPages = value;
            OnPropertyChanged(nameof(NumberOfPages));
        }
    }

    private string _selectedRecord = "10";

    public string SelectedRecord
    { 
        get { return _selectedRecord; }
        set 
        {
            _selectedRecord = value;
            OnPropertyChanged(nameof(SelectedRecord));
            UpdatePagination();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void btnFirstPage_Click(object sender, RoutedEventArgs e)
    {
        CurrentPage = 1;
    }

    private void btnPreviousPage_Click(object sender, RoutedEventArgs e)
    {
        if (CurrentPage > 1)
            CurrentPage--;
    }

    private void btnNextPage_Click(object sender, RoutedEventArgs e)
    {
        if (CurrentPage < NumberOfPages)
            CurrentPage++;
    }

    private void btnLastPage_Click(object sender, RoutedEventArgs e)
    {
        CurrentPage = NumberOfPages;
    }
}