﻿using System;
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
        private User author;
        HomeWindow scherm = (HomeWindow)Application.Current.MainWindow;

        public EditArticleWindow(Article article, User author, User loggedUser)
        {
            InitializeComponent();

            client.BaseAddress = new Uri("http://webapp-stufv20160527104738.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            this.author = author;
            this.article = article;
            titleTextBox.Text = article.Title;
            contentTextBox.Text = article.Content;
            authorBlock.Text = author.FirstName + " " + author.LastName;
            dateBlock.Text = article.DateTime.ToLongDateString();
            urlAfbeelding.Text = article.imgLink;

            this.Closing += EditArticleWindow_Closing;
        }

        private async Task<bool> UpdateArticle(Article article)
        {
            processLabel.Content = "Bezig met verwerken...";

            try
            {
                var articleUrl = "/api/article/" + article.Id;
                HttpResponseMessage response = await client.PutAsJsonAsync(articleUrl, article);

                if (response.IsSuccessStatusCode)
                {
                    if (scherm.user.Email != author.Email)
                    {
                        SendMail(article);
                    }
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
            catch (HttpRequestException)
            {
                MessageBox.Show("Verbinding met de server verbroken. Probeer later opnieuw. U zal worden doorverwezen naar het loginscherm.",
                    "Serverfout", MessageBoxButton.OK, MessageBoxImage.Error);
                LoginWindow window = new LoginWindow();
                window.Show();
                Close();
                scherm.Close();
            }
            return false;
        }

        private void SendMail(Article article)
        {
            try
            {
                SmtpClient SmtpServer = new SmtpClient("smtp.live.com");
                var mail = new MailMessage();
                mail.From = new MailAddress("stufv.test@hotmail.com");
                mail.To.Add(author.Email);
                mail.Subject = "STUFV: Aanpassingen artikel met id " + article.Id;
                mail.Body = string.Format("De administrator, {0} {1}, heeft enkele aanpassingen gedaan in jouw artikel. Bekijk de desktopapp voor meer informatie", scherm.user.FirstName, scherm.user.LastName);
                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new NetworkCredential("stufv.test@hotmail.com", "paswoord123");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            }
            catch (SmtpException ex)
            {
                MessageBox.Show("Kon mail niet verzenden: " + ex.Message);
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

        private async Task<bool> CheckClose()
        {
            if (article.Title != titleTextBox.Text || article.Content != contentTextBox.Text || article.imgLink != urlAfbeelding.Text)
            {
                MessageBoxResult result = MessageBox.Show("Wijzigingen opslaan?",
                    "Sluit venster", MessageBoxButton.YesNoCancel, MessageBoxImage.Exclamation);

                if (result == MessageBoxResult.Yes)
                {
                    article.Title = titleTextBox.Text;
                    article.Content = contentTextBox.Text;
                    article.imgLink = urlAfbeelding.Text;
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
            if (article.Title != titleTextBox.Text || article.Content != contentTextBox.Text || article.imgLink != urlAfbeelding.Text)
            {
                article.Title = titleTextBox.Text;
                article.Content = contentTextBox.Text;
                article.imgLink = urlAfbeelding.Text;
                await UpdateArticle(article);
            }
        }

        private async void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            if (await CheckClose())
            {
                Close();
            }
        }

        private async void EditArticleWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (await CheckClose())
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
