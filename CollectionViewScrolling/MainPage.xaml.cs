using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CollectionViewScrolling;

public partial class MainPage : ContentPage
{
    private ObservableCollection<string> _items;
    public ObservableCollection<string> Items
    {
        get { return _items; }
        set { _items = value; OnPropertyChanged(nameof(Items)); }
    }

    private bool _isLoading;
    public bool IsLoading
    {
        get { return _isLoading; }
        set { _isLoading = value; OnPropertyChanged(nameof(IsLoading)); }
    }

    private ICommand _refreshCommand;
    public ICommand RefreshCommand
    {
        get { return _refreshCommand; }
        set { _refreshCommand = value; OnPropertyChanged(nameof(RefreshCommand)); }
    }

    private int count;

    public MainPage()
    {
        InitializeComponent();

        BindingContext = this;

        RefreshCommand = new Command(AddItems);

        Items = new ObservableCollection<string>();

        AddItems();
    }

    private void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        IsLoading = true;
    }

    private void AddItems()
    {
        foreach (int value in Enumerable.Range(count, 25))
        {
            Items.Add(value.ToString());
        }

        count += 20;

        IsLoading = false;
    }
}