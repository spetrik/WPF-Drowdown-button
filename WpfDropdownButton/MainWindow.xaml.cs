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

    private void DropDownButton_OnChecked(object sender, RoutedEventArgs e)
    {
      if (sender is ToggleButton button && Equals(button.IsChecked, true))
      {
        var items = button.Resources["items"];
        if (items is ContextMenu)
        {
          var cm = (ContextMenu) items;
          if (cm.PlacementTarget == null)
          {
            cm.PlacementTarget = button;
            cm.Placement = PlacementMode.Bottom;
            cm.Closed += (senderClosed, eClosed) => ((ToggleButton)sender).IsChecked = false;
          }
          cm.IsOpen = true;
        } else if (items is Popup)
        {
          var popup = (Popup)items;
          if (popup.PlacementTarget == null)
          {
            popup.PlacementTarget = button;
            popup.Placement = PlacementMode.Bottom;
            popup.Closed += (senderClosed, eClosed) => ((ToggleButton)sender).IsChecked = false;
          }
          popup.IsOpen = true;
        }
      }
    }

    private void popup_Click(object sender, RoutedEventArgs e)
    {
      if (sender is Popup popup)
        popup.IsOpen = false;
    }
  }
}
