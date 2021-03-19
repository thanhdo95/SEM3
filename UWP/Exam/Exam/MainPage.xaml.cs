using SQLite.Net.Attributes;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Exam
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        string path;
        SQLite.Net.SQLiteConnection conn;
        public MainPage()
        {
            this.InitializeComponent();
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "database.sqlite"); ;//tên file,phía trc là đường dẫn
            conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);//tạo ra 1 form sqlite theo window
            conn.CreateTable<PhoneNumber>();//tên bảng customer
        }
        public class PhoneNumber
        {
            [PrimaryKey]
            public string Phone { get; set; }
            public string Name { get; set; }
          
            //prop ra nhanh+tab+tab
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var phone = conn.Insert(new PhoneNumber()
                {
                    Name = textBoxName.Text,
                    Phone = textBoxPhone.Text,
                   // Phone = (Int32.Parse(textBoxPhone.Text)),
                });
            }
            catch
            {
                Console.WriteLine("Số điện thoại bị đã có");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var query = conn.Table<PhoneNumber>();
         
            string name = "";
            string Phone = "";
            foreach (var message in query)
            {
               
                name = name + " " + message.Name;
                Phone = Phone+ " " + message.Phone;
            }
            textBoxShow.Text = "\nName: " + name + "\nPhone: " + Phone;
        }
    }
}
