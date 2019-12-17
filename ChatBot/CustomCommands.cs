using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChatBot
{
    public static class CustomCommands
    {
        public static readonly RoutedUICommand Exit = new RoutedUICommand(
                "Exit",
                "Exit",
                typeof(CustomCommands),
                new InputGestureCollection() { new KeyGesture(Key.S, ModifierKeys.Control) }
        );

        public static readonly RoutedUICommand Save = new RoutedUICommand(
                "Save",
                "Save",
                typeof(CustomCommands),
                new InputGestureCollection() { new KeyGesture(Key.G, ModifierKeys.Control) }
        );

        public static readonly RoutedUICommand Config = new RoutedUICommand(
                "Config",
                "Config",
                typeof(CustomCommands),
                new InputGestureCollection() { new KeyGesture(Key.C, ModifierKeys.Control) }
        );

        public static readonly RoutedUICommand Submit = new RoutedUICommand(
                "Submit",
                "Submit",
                typeof(CustomCommands),
                new InputGestureCollection() { new KeyGesture(Key.Enter ) }
        );

        public static readonly RoutedUICommand Conex = new RoutedUICommand(
                "Conex",
                "Conex",
                typeof(CustomCommands),
                new InputGestureCollection() { new KeyGesture(Key.O, ModifierKeys.Control) }
        );
    }
}
