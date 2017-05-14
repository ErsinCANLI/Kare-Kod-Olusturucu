using System;
using System.Drawing;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using MessagingToolkit.QRCode.Codec.Data;
using MessagingToolkit.QRCode.Codec;

namespace Kare_Kod_Oluşturucu
{
    //lütficansay.com
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnKareKod_Click(object sender, EventArgs e)
        {
            StringBuilder bld = new StringBuilder();
            if (textBox1.Text != "")
            {
                bld.Append(textBox1.Text);
                bld.AppendLine();
            }
            if (textBox2.Text != "")
            {
                bld.Append(textBox2.Text);
                bld.AppendLine();
            }
            if (textBox3.Text != "")
            {
                bld.Append(textBox3.Text);
                bld.AppendLine();
            }
            if (textBox4.Text != "")
            {
                bld.Append(textBox4.Text);
                bld.AppendLine();
            }
            if (textBox5.Text != "")
            {
                bld.Append(textBox5.Text);
            }
            pctQRResim.Image = QrCodeCreate(bld.ToString());
        }

        public Image QrCodeCreate(String CevrilecekOlan)
        {
            QRCodeEncoder encoder = new QRCodeEncoder();
            Image img = encoder.Encode(CevrilecekOlan);
            return img;
        }

        private void btnResimKayit_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.InitialDirectory = Application.ExecutablePath;
            saveDialog.Title = "Kare Kod";
            saveDialog.Filter = "PNG Dosyaları(*.png)|*.png|JPEG dosyaları(*.jpg)|*.jpg|BMP dosyaları(*.bmp)|*.bmp";
            saveDialog.DefaultExt = "*.png";
            saveDialog.FileName = DateTime.Now.ToString("yyyy.MM.dd_hh.mm.ss");

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                pctQRResim.Image.Save(saveDialog.FileName);
                Process.Start(saveDialog.FileName);
            }
        }

        private void btnQrOku_Click(object sender, EventArgs e)
        {
            QRCodeDecoder decoder = new QRCodeDecoder();
            Bitmap bmp = (Bitmap)pctQRResim.Image;
            MessageBox.Show(decoder.decode(new QRCodeBitmapImage(bmp)));
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            pctQRResim.Image = pctQRResim.InitialImage;
        }

        private void barHeaderItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
        }
    }
}
