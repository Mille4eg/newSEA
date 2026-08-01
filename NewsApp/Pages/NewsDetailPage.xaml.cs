using Microsoft.Maui.Controls;
using NewsApp.Models;

namespace NewsApp.Pages;

public partial class NewsDetailPage : ContentPage
{
    private readonly Article selectedArticle;

    public NewsDetailPage(Article article)
    {
        InitializeComponent();

        selectedArticle = article;

        NewsImage.Source = selectedArticle.Image;
        NewsTitle.Text = selectedArticle.Title;
        NewsContent.Text = selectedArticle.Content;
    }
}