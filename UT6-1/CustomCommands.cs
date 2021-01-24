using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UT6_1
{
    class CustomCommands
    {
        public static readonly RoutedUICommand Nueva = new RoutedUICommand
            (
                "Nueva", //Etiqueta
                "Nueva", //Nombre
                typeof(CustomCommands), //Clase contenedora
                new InputGestureCollection()
                {
                    new KeyGesture(Key.N, ModifierKeys.Control) //Atajo
                }
                
            );

        public static readonly RoutedUICommand Guardar = new RoutedUICommand
            (
                "Guardar",
                "Guardar",
                typeof(CustomCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.G, ModifierKeys.Control)
                }
            );

        public static readonly RoutedUICommand Salir = new RoutedUICommand
           (
               "Salir",
               "Salir",
               typeof(CustomCommands),
               new InputGestureCollection()
               {
                    new KeyGesture(Key.S, ModifierKeys.Control)
               }
           );

        public static readonly RoutedUICommand Conexion = new RoutedUICommand
           (
               "Conexion",
               "Conexion",
               typeof(CustomCommands),
               new InputGestureCollection()
               {
                    new KeyGesture(Key.O, ModifierKeys.Control)
               }
           );
        public static readonly RoutedUICommand Enviar = new RoutedUICommand
            (
                "Enviar",
                "Enviar",
                typeof(CustomCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.U, ModifierKeys.Control)
                }
            );
    }
}
