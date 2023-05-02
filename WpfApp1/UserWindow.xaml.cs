using System;
using System.Collections.Generic;
using System.Drawing;
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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public User User { get; private set; }
        public UserWindow(User user)
        {
            InitializeComponent();
            Button_Click_1(null, null);
            User = user;
            DataContext = User;
        }

        void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        public void Button_Click_1(object sender, RoutedEventArgs e)
        {
            QRCoder.QRCodeGenerator qr = new QRCoder.QRCodeGenerator();
            QRCoder.QRCodeData data = qr.CreateQrCode(txtQrCode.Text + age1.Text + email1.Text, QRCoder.QRCodeGenerator.ECCLevel.L); ;
            QRCoder.QRCode code = new QRCoder.QRCode(data);
            Bitmap bitmap = code.GetGraphic(100);
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();
                qrImageView.Source = bitmapimage;
            }



        }
    }
}
