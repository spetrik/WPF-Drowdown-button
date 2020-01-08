using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace WpfDropdownButton
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void MyVersion_OnChecked(object sender, RoutedEventArgs e)
    {
      if (sender is ToggleButton button && Equals(button.IsChecked, true))
      {
        var cm = button.Resources["cm"] as ContextMenu;
        if (cm.PlacementTarget == null)
        {
          cm.PlacementTarget = button;
          cm.Placement = PlacementMode.Bottom;
          cm.Closed += (senderClosed, eClosed) => ((ToggleButton)sender).IsChecked = false;
        }
        cm.IsOpen = true;
      }
    }

    private void MyVersion2_OnChecked(object sender, RoutedEventArgs e)
    {
      if (sender is ToggleButton button && Equals(button.IsChecked, true))
      {
        var cm = button.Resources["cm"] as Popup;
        if (cm.PlacementTarget == null)
        {
          cm.PlacementTarget = button;
          cm.Placement = PlacementMode.Bottom;
          cm.Closed += (senderClosed, eClosed) => ((ToggleButton)sender).IsChecked = false;
        }
        cm.IsOpen = true;
      }
    }

    private void popup_Click(object sender, RoutedEventArgs e)
    {
      if (sender is Popup popup)
        popup.IsOpen = false;
    }
  }
}
