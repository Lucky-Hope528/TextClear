using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using WinRT.Interop;
using Windows.ApplicationModel.DataTransfer;

namespace TextClear;

public sealed partial class MainWindow : Window
{
    public MainWindow()
    {
        // 确保初始化引导，防止崩溃
        
        this.InitializeComponent();

        this.SystemBackdrop = new MicaBackdrop();
        this.ExtendsContentIntoTitleBar = true;
        this.SetTitleBar(AppTitleBar);

        ConfigureWindow();
    }

    private void ConfigureWindow()
    {
        IntPtr hWnd = WindowNative.GetWindowHandle(this);
        WindowId windowId = Win32Interop.GetWindowIdFromWindow(hWnd);
        AppWindow appWindow = AppWindow.GetFromWindowId(windowId);

        if (appWindow != null)
        {
            appWindow.Title = "TextClear";
            string iconPath = System.IO.Path.Combine(AppContext.BaseDirectory, "icon.ico");
            if (System.IO.File.Exists(iconPath))
            {
                appWindow.SetIcon(iconPath);
            }
        }
    }

    private void CleanButton_Click(object sender, RoutedEventArgs e)
    {
        string text = InputTextArea.Text;
        if (string.IsNullOrWhiteSpace(text)) return;

        if (TrimSpacesToggle.IsOn)
        {
            text = text.Trim();
        }

        if (RemoveEmptyLinesToggle.IsOn)
        {
            text = Regex.Replace(text, @"(\r?\n)\s*\n", "$1");
        }

        var dataPackage = new DataPackage();
        dataPackage.SetText(text);
        Clipboard.SetContent(dataPackage);

        ShowSuccessFeedback();
    }

    private async void ShowSuccessFeedback()
    {
        ResultInfoBar.IsOpen = true;
        await Task.Delay(2000);
        ResultInfoBar.IsOpen = false;
    }
}