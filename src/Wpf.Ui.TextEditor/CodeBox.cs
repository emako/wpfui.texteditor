using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Wpf.Ui.TextEditor.Controls;

public class CodeBox : ICSharpCode.AvalonEdit.TextEditor
{
    /// <summary>
    /// Low performance, use <see cref="ICSharpCode.AvalonEdit.TextEditor.Text"/> instead.
    /// </summary>
    public string Code
    {
        get => Text;
        set => Text = value;
    }

    public static readonly DependencyProperty CodeProperty =
        DependencyProperty.Register(nameof(Code), typeof(string), typeof(CodeBox), new PropertyMetadata(string.Empty, OnTextChange));

    private static void OnTextChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is ICSharpCode.AvalonEdit.TextEditor editor)
        {
            editor.Text = (string)e.NewValue;
        }
    }

    public bool LineWrap
    {
        get => WordWrap;
        set
        {
            if (value)
            {
                WordWrap = true;
                HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
            }
            else
            {
                WordWrap = false;
                HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
            }
        }
    }

    public CodeBox()
    {
        ShowLineNumbers = true;
        TextArea.SelectionBrush = new SolidColorBrush(Color.FromRgb(0x26, 0x4F, 0x78));
        TextArea.SelectionBorder = new(Brushes.Transparent, 0d);
        TextArea.SelectionCornerRadius = 2d;
        TextArea.SelectionForeground = null!;
    }
}
