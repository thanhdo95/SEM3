using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using static Exam.MainPage;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Exam
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Search : Page
    {
        string path;
        SQLite.Net.SQLiteConnection conn;
        public Search()
        {
            this.InitializeComponent();
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "database.sqlite"); //tên file,phía trc là đường dẫn
            conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var query = conn.Table<PhoneNumber>();
                string name = "";
                string phone = "";
                foreach (var message in query)
                {

                    name = name + " " + message.Name;
                    phone = phone + " " + message.Phone;
                }
                if (String.Compare(textBoxName1.Text, name, true) == 0 && String.Compare(textBoxPhone1.Text, phone, true) == 0)
                {
                    TextBlockShow.Text = "\nName: " + name + "\nPhoneNumber: " + phone;
                }
            }
            catch
            {

            }
        }
    }
}
