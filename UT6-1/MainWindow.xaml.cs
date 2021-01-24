using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UT6_1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Mensaje> chatList = new ObservableCollection<Mensaje>();
        public MainWindow()
        {
            InitializeComponent();  
            mensajesListBox.DataContext = chatList;
        }

        private void CommandBinding_Nueva(object sender, ExecutedRoutedEventArgs e)
        {
            chatList.Clear();
        }

        private void CommandBinding_CanExecute_Nueva(object sender, CanExecuteRoutedEventArgs e)
        {
            if (chatList != null && chatList.Count > 0)
            {
                e.CanExecute = true;

            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void CommandBinding_Guardar(object sender, ExecutedRoutedEventArgs e)
        {
            string texto = "";
            foreach (Mensaje msg in chatList) {
                texto = texto + msg.Nombre +" : " + msg.Texto + "\n";
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "*.txt|*.txt";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, texto);
            }
        }

        private void CommandBinding_CanExecute_Guardar(object sender, CanExecuteRoutedEventArgs e)
        {
            if (chatList != null && chatList.Count != 0)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            } 
        }

        private void CommandBinding_Salir(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void CommandBinding_Conexion(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Conexión correcta con el servidor del Bot", "Comprobar Conexión", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        private void CommandBinding_Enviar(object sender, ExecutedRoutedEventArgs e)
        {
            Mensaje usuario = new Mensaje("Usuario",mensajeTextBox.Text);
            Mensaje bot = new Mensaje("Robot", "Lo siento, estoy un poco ocupado para hablar.");
            chatList.Add(usuario);
            chatList.Add(bot);
            mensajeTextBox.Clear();
        }

        private void CommandBinding_CanExecute_Enviar(object sender, CanExecuteRoutedEventArgs e)
        {
            if (mensajesListBox != null && mensajeTextBox.Text.Length != 0)
            {
                e.CanExecute = true;

            }
            else
            {
                e.CanExecute = false;
            }
        }

        //Apuntes para la 2ºparte------->
        //En la nueva ventana
        //---------------------------
        //para el sexo hacer una lista hombre mujer y meterla en el combo box con el .itemssource=;
        //para la ventana de config fondo_combobox .itemssource = typeof(colors)getproperties();
        //en el boton aceptar DialogResult = true; <- antes de esto definir el codigo que queremos hacer, porque se cerrara la ventana.
        //En la clase de la nueva ventana : public string FondoColor{get;set;} -> Sexo = (string)sexoComboBox.SelectedItem <- Antes de afirmar dialogresult -->
        //---> pero esto lo podemos hacer con bindings para ahorrar codigo ... <ComboBox x:name=sexo selectedvalue=binding path = sexo> --->
        //--> en la nueva ventana this.DataContext=this;
        //podemos definir las variables de la ventana en la config del proyecto Properties.Settings.Default.sexo = ventana.Sexo
        //antes de abrir la ventana Properties.Settings.Default.fondoColor = ventana.fondoColor;
        //<itemscontrol background="{binding source={x:static properties.settings.default}. path=fondoColor
        /*
            en la clase main if ventana.ShowDialog() == true{MessageBox.Show(ventana.Sexo);}
         */
    }
}
