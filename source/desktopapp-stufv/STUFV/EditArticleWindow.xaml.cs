using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
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
    /// Interaction logic for EditArticleWindow.xaml
    /// </summary>
    public partial class EditArticleWindow : Window
    {
        HttpClient client = new HttpClient();
        private Article article;
        private User loggedUser;

        public EditArticleWindow(Article article, User author, User loggedUser)
        {
            InitializeComponent();

            client.BaseAddress = new Uri("http://webapp-stufv20160511012914.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            this.loggedUser = loggedUser;
            this.article = article;
            titleTextBox.Text = article.Title;
            contentTextBox.Text = article.Content;
            authorBlock.Text = author.FirstName + " " + author.LastName;
            dateBlock.Text = article.DateTime.ToLongDateString();

            this.Closing += EditArticleWindow_Closing;
        }

        private async Task<bool> UpdateArticle(Article article)
        {
            processLabel.Content = "Bezig met verwerken...";

            var articleUrl = "/api/article/" + article.Id;
            HttpResponseMessage response = await client.PutAsJsonAsync(articleUrl, article);

            if (response.IsSuccessStatusCode)
            {
                SendMail(article);
                MessageBox.Show("Artikel succesvol aangepast!");
                processLabel.Content = "";
                return true;
            }
            else
            {
                processLabel.Content = "";
                return false;
            }
        }

        private void SendMail(Article article)
        {
            try
            {
                SmtpClient SmtpServer = new SmtpClient("smtp.live.com");
                var mail = new MailMessage();
                mail.From = new MailAddress("stufv.test@hotmail.com");
                mail.To.Add("stufv.test@hotmail.com");
                mail.Subject = "STUFV: Aanpassingen artikel met id " + article.Id;
                mail.Body = string.Format("De gebruiker, {0} {1}, heeft enkele aanpassingen gedaan in jouw artikel. Bekijk de desktopapp voor meer informatie", loggedUser.FirstName, loggedUser.LastName);
                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new NetworkCredential("stufv.test@hotmail.com", "paswoord123");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            }
            catch (SmtpException ex)
            {
                MessageBox.Show("Fout opgetreden: " + ex.Message);
            }
            
        }

        private async Task<bool> checkClose()
        {
            if (article.Title != titleTextBox.Text || article.Content != contentTextBox.Text)
            {
                MessageBoxResult result = MessageBox.Show("Wijzigingen opslaan?",
                    "Sluit venster", MessageBoxButton.YesNoCancel, MessageBoxImage.Exclamation);

                if (result == MessageBoxResult.Yes)
                {
                    article.Title = titleTextBox.Text;
                    article.Content = contentTextBox.Text;
                    return await UpdateArticle(article);
                }
                else if (result == MessageBoxResult.No)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        private async void SaveArticleButton_Click(object sender, RoutedEventArgs e)
        {
            if (article.Title != titleTextBox.Text || article.Content != contentTextBox.Text)
            {
                article.Title = titleTextBox.Text;
                article.Content = contentTextBox.Text;
                await UpdateArticle(article);
            }
        }

        private async void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            if (await checkClose())
            {
                Close();
            }
        }

        private async void EditArticleWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (await checkClose())
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
