using System;
using System.Windows;

namespace FileHash
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


        private void TextBlockDrop_PreviewDragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(System.Windows.DataFormats.FileDrop, true))
            {
                e.Effects = System.Windows.DragDropEffects.Copy;
            }
            else
            {
                e.Effects = System.Windows.DragDropEffects.None;
            }
            e.Handled = true;
        }

        private void TextBlockDrop_Drop(object sender, DragEventArgs e)
        {
            if (!(e.Data.GetData(DataFormats.FileDrop) is string[] dropFiles)) return;

            this.TextBlockLog.Text = "";
            foreach (String filePath in dropFiles)
            {
                var fileinfo = new System.IO.FileInfo(filePath);
                DateTime dt;
                TimeSpan ts;
                String hash;


                this.TextBlockLog.Text += "\n";
                this.TextBlockLog.Text += string.Format("FIle : {0} ({1:#,0})\n", filePath, fileinfo.Length);

                dt = DateTime.Now;
                hash = this.CalcFileMD5(filePath);
                ts = DateTime.Now - dt;
                this.TextBlockLog.Text += string.Format("  MD5    : {0:0.000} sec, {1}\n", ts.TotalSeconds,  hash);

                dt = DateTime.Now;
                hash = this.CalcFileSHA1(filePath);
                ts = DateTime.Now - dt;
                this.TextBlockLog.Text += string.Format("  SHA1   : {0:0.000} sec, {1}\n", ts.TotalSeconds, hash);

                dt = DateTime.Now;
                hash = this.CalcFileSHA256(filePath);
                ts = DateTime.Now - dt;
                this.TextBlockLog.Text += string.Format("  SHA256 : {0:0.000} sec, {1}\n", ts.TotalSeconds, hash);
            }


        }

        private string CalcFileMD5(String filePath)
        {
            string result = null;
            using (var fs = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite))
            {
                var md5 = System.Security.Cryptography.MD5.Create();
                var md5Hash = md5.ComputeHash(fs);
                result = System.BitConverter.ToString(md5Hash);
            }
            return result;
        }
        private string CalcFileSHA1(String filePath)
        {
            string result = null;
            using (var fs = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite))
            {
                var sha1 = System.Security.Cryptography.SHA1.Create();
                var sha1Hash = sha1.ComputeHash(fs);
                result = System.BitConverter.ToString(sha1Hash);
            }
            return result;
        }
        private string CalcFileSHA256(String filePath)
        {
            string result = null;
            using (var fs = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite))
            {
                var sha256 = System.Security.Cryptography.SHA256.Create();
                var sha256Hash = sha256.ComputeHash(fs);
                result = System.BitConverter.ToString(sha256Hash);
            }
            return result;
        }
    }
}
