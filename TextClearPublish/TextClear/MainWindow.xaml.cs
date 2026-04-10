using System;
using System.Net; // 新增：用于解析 HTML 转义字符
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
        this.InitializeComponent();

        // 窗口视觉配置
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

    /// <summary>
    /// 核心联动逻辑：开启深度净化时，关闭其他基础选项
    /// </summary>
    private void DeepPurifyToggle_Toggled(object sender, RoutedEventArgs e)
    {
        if (DeepPurifyToggle.IsOn)
        {
            // 为了防止逻辑冲突并保证“极致纯净”，关闭其他两个开关
            TrimSpacesToggle.IsOn = false;
            RemoveEmptyLinesToggle.IsOn = false;
        }
    }

    private void CleanButton_Click(object sender, RoutedEventArgs e)
    {
        string text = InputTextArea.Text;
        if (string.IsNullOrWhiteSpace(text)) return;

        if (DeepPurifyToggle.IsOn)
        {
            // --- 深度净化模式 (杀掉所有 HTML 杂志) ---

            // 1. 剔除所有 <...> 标签
            text = Regex.Replace(text, "<[^>]*>", string.Empty);

            // 2. 将 HTML 转义字符还原 (例如 &nbsp; 变回空格，&lt; 变回 <)
            text = WebUtility.HtmlDecode(text);

            // 3. 极致空间压缩：将所有连续的空白符（空格、换行、制表符）压缩为单个空格
            text = Regex.Replace(text, @"\s+", " ").Trim();
        }
        else
        {
            // --- 普通处理模式 ---

            if (TrimSpacesToggle.IsOn)
            {
                text = text.Trim();
            }

            if (RemoveEmptyLinesToggle.IsOn)
            {
                // 合并多余空行逻辑
                text = Regex.Replace(text, @"(\r?\n)\s*\n", "$1");
            }
        }

        // 将净化后的文本回填并复制到剪贴板
        InputTextArea.Text = text;

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