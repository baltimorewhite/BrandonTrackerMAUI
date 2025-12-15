namespace BrandonTrackerApp.Pages;

public partial class HomePage : ContentPage
{
    public string CurrentDate => DateTime.Today.ToString("dd/MM/yyyy");

    // I need to change it by real bins requested 
    public int Bin100L => 3;
    public int Bin240L => 5;
    public int BinCorporate => 2;
    public int BinArchive => 1;
    public int BinSmall => 4;
    public int BinLocked => 0;

    public HomePage()
    {
        InitializeComponent();
        BindingContext = this;
    }
}

