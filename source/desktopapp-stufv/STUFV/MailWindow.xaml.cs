using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Net.Mime;
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

namespace STUFV
{
    /// <summary>
    /// Interaction logic for MailWindow.xaml
    /// </summary>
    public partial class MailWindow : Window
    {
        HomeWindow scherm = (HomeWindow)Application.Current.MainWindow;
        List<string> attachments = new List<string>();

        public MailWindow(string email)
        {
            InitializeComponent();

            toMailBox.Text = email;
            Closing += MailWindow_Closing;
        }

        private void AddAttachmentButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = "C:\\";
            dialog.Filter = "All files (*.*)|*.*";
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == true)
            {
                string filePath = dialog.FileName;
                attachments.Add(filePath);
                string file = filePath.Substring(filePath.LastIndexOf('\\') + 1);
                attachmentBox.Text = attachmentBox.Text + file + "; ";
            }
        }

        private void ClearAttachmentsButton_Click(object sender, RoutedEventArgs e)
        {
            attachments.Clear();
            attachmentBox.Text = "";
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            if (subjectBox.Text != "")
            {
                try
                {
                    SmtpClient SmtpServer = new SmtpClient("smtp.live.com");
                    var mail = new MailMessage();
                    mail.From = new MailAddress("stufv.test@hotmail.com");
                    mail.To.Add(toMailBox.Text);
                    mail.Subject = subjectBox.Text;
                    mail.Body = contentTextBox.Text;
                    foreach (string file in attachments)
                    {
                        Attachment data = new Attachment(file, MediaTypeNames.Application.Octet);
                        mail.Attachments.Add(data);
                    }
                    SmtpServer.Port = 587;
                    SmtpServer.UseDefaultCredentials = false;
                    SmtpServer.Credentials = new NetworkCredential("stufv.test@hotmail.com", "paswoord123");
                    SmtpServer.EnableSsl = true;
                    SmtpServer.Send(mail);
                    MessageBox.Show("Mail verzonden!");
                    subjectBox.Text = "";
                    contentTextBox.Text = "";
                    attachmentBox.Text = "";
                    Close();
                }
                catch (SmtpException ex)
                {
                    MessageBox.Show("Kon mail niet verzenden: " + ex.Message);
                    processLabel.Content = "";
                }
                catch (HttpRequestException)
                {
                    MessageBox.Show("Verbinding met de server verbroken. Probeer later opnieuw. U zal worden doorverwezen naar het loginscherm.",
                        "Serverfout", MessageBoxButton.OK, MessageBoxImage.Error);
                    LoginWindow window = new LoginWindow();
                    window.Show();
                    Close();
                    scherm.Close();
                }
            }
            else
            {
                MessageBox.Show("Je dient een onderwerp mee te geven!");
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Ben je zeker dat je deze mail wilt annuleren? Alle wijzigingen zullen verloren gaan", "Sluit venster",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Close();
            }
        }

        private void MailWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (subjectBox.Text != "" && contentTextBox.Text != "")
            {
                if (MessageBox.Show("Ben je zeker dat je deze mail wilt annuleren? Alle wijzigingen zullen verloren gaan", "Sluit venster",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = false;
            }  
        }
    }
}
