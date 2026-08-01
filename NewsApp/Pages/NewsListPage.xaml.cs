using NewsApp.Models;
using NewsApp.Services;

namespace NewsApp.Pages;

public partial class NewsListPage : ContentPage
{
    private readonly string categoryName;

    public List<Article> ArticleList = new List<Article>();

    public NewsListPage(string categoryName)
    {
        InitializeComponent();

        this.categoryName = categoryName;

        Title = categoryName;

        GetNews();
    }

    private async Task GetNews()
    {
        var apiService = new ApiService();

        var newsResult = await apiService.GetNews(categoryName);

        ArticleList.Clear();

        foreach (var article in newsResult.Articles)
        {
            ArticleList.Add(article);
        }

        CvNewsList.ItemsSource = ArticleList;
    }

    private async void CvNewsList_SelectionChanged(
        object sender,
        SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Article selectedArticle)
        {
            await Navigation.PushAsync(
                new NewsDetailPage(selectedArticle));

            CvNewsList.SelectedItem = null;
        }
    }
}