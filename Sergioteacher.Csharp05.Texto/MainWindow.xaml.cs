using System;
using System.Collections.Generic;
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
using System.IO;
using Microsoft.Win32;

namespace Sergioteacher.Csharp05.Texto
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private String titulo = "Mini Editor...";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Bdialogo_Click(object sender, RoutedEventArgs e)
        {

            if (ChOk.IsChecked == true)
            {
                SaveFileDialog ficherito = new SaveFileDialog();
                ficherito.Filter = "Text file (*.txt)|*.txt|C# file (*.cs)|*.cs|All files (*.*)|*.*";
                if (ficherito.ShowDialog() == true)
                {
                    File.WriteAllText(ficherito.FileName, Tedit.Text);
                }
                else
                {
                    MessageBox.Show(" Cancelado ", "Na de na", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            else
            {
                OpenFileDialog ficherito = new OpenFileDialog();
                ficherito.Filter = "Text file (*.txt)|*.txt|C# file (*.cs)|*.cs|All files (*.*)|*.*";
                if (ficherito.ShowDialog() == true)
                {
                    Tedit.Text = File.ReadAllText(ficherito.FileName);
                    WEdit.Title = titulo + "    " + ficherito.FileName.ToString();
                }
                else
                {
                    MessageBox.Show(" No se ha selecionado NADA", "Nada de nada", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            
        }

        private void ChOk_Click(object sender, RoutedEventArgs e)
        {
            if ( ChOk.IsChecked == true ) 
            {
                Bdialogo.Content = " Guardar ";
                ChOk.Foreground = Brushes.Indigo;
                Bdialogo.Foreground = Brushes.Indigo;
            }
            else
            {
                Bdialogo.Content = " Abrir ";
                ChOk.Foreground = Brushes.SeaGreen;
                Bdialogo.Foreground = Brushes.SeaGreen;
            }

        }

        private void Bnuevo_Click(object sender, RoutedEventArgs e)
        {
            Tedit.Text = "";
            WEdit.Title = titulo;
        }

        private void WEdit_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
            if ( Tedit.Text != "Cargando...") 
            {
                
                MessageBoxResult resultado = MessageBox.Show(" ¿Quieres guardar los cambios? ", " El texto fué cambiado ...", MessageBoxButton.YesNoCancel, MessageBoxImage.Question, MessageBoxResult.No);
                switch (resultado)
                {
                    case MessageBoxResult.Yes:
                        SaveFileDialog ficherito = new SaveFileDialog();
                        ficherito.Filter = "Text file (*.txt)|*.txt|C# file (*.cs)|*.cs|All files (*.*)|*.*";
                        if (ficherito.ShowDialog() == true)
                        {
                            File.WriteAllText(ficherito.FileName, Tedit.Text);
                        }
                        else
                        {
                            MessageBox.Show(" Cancelado ", "Na de na", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        }
                        e.Cancel = true;
                        break;
                    case MessageBoxResult.No:
                        //e.Cancel = true;
                        Application.Current.Shutdown();
                        break;
                    case MessageBoxResult.Cancel:
                        e.Cancel = true; //Capturo el evento de Salir!
                        break;
                }
                
                
            }
        }
    }
}
