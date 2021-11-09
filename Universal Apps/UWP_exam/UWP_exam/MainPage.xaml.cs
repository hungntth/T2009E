using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel.Channels;
using UWP_exam.ADO;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP_exam
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        UsersController user;
        public MainPage()
        {
            this.InitializeComponent();
            user = new UsersController();
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernametxtBx.Text.Trim();
            string pasword = PasswordtxtBx.Text.Trim();

           if(user.Login(username, pasword))
            {
                Frame.Navigate(typeof(EmployeeList));
            }
           else
            {
                var message = new MessageDialog("Error");
                await message.ShowAsync();
            }    
        }
    }
}
