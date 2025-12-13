using System.ComponentModel;
using System.Runtime.CompilerServices;
using BrandonTrackerApp.Resources.Styles;

namespace BrandonTrackerApp.ViewModels;

public class SettingsViewModel : INotifyPropertyChanged
{
    public SettingsViewModel()
    {
        var currentTheme = Application.Current.UserAppTheme;
        IsLightMode = currentTheme == AppTheme.Light;
        IsDarkMode = currentTheme == AppTheme.Dark;

        
        if (IsDarkMode)
            ApplyTheme(new DarkTheme());
        else
            ApplyTheme(new LightTheme());
    }

    private bool _isLightMode;
    public bool IsLightMode
    {
        get => _isLightMode;
        set
        {
            if (_isLightMode != value)
            {
                _isLightMode = value;
                OnPropertyChanged();
                if (value)
                {
                    IsDarkMode = false;
                    ApplyTheme(new LightTheme());
                }
            }
        }
    }

    private bool _isDarkMode;
    public bool IsDarkMode
    {
        get => _isDarkMode;
        set
        {
            if (_isDarkMode != value)
            {
                _isDarkMode = value;
                OnPropertyChanged();
                if (value)
                {
                    IsLightMode = false;
                    ApplyTheme(new DarkTheme());
                }
            }
        }
    }

    private void ApplyTheme(ResourceDictionary theme)
    {
        Application.Current.Resources.MergedDictionaries.Clear();
        Application.Current.Resources.MergedDictionaries.Add(theme);
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
