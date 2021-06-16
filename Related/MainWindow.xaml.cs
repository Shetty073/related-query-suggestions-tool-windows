using HelperLibrary;
using HelperLibrary.models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Related
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string Keyword;
        private string Lang;
        private string Country;
        private List<Suggestion> Data;

        public MainWindow()
        {
            InitializeComponent();
            progressBar.Visibility = Visibility.Hidden;
            PopulateComboBoxes();
            ApiHelper.InitializeClient();
        }

        private class ComboData
        {
            public string Id { get; set; }
            public string Value { get; set; }
        }

        private void PopulateComboBoxes()
        {
            // for language combobox
            List<ComboData> LangListData = new List<ComboData>();
            LangListData.Add(new ComboData { Id = "en", Value = "English" });

            languageComboBox.ItemsSource = LangListData;
            languageComboBox.DisplayMemberPath = "Value";
            languageComboBox.SelectedValuePath = "Id";

            languageComboBox.SelectedValue = "en";

            // for country combobox
            List<ComboData> CountryListData = new List<ComboData>();
            CountryListData.Add(new ComboData { Id = "in", Value = "India" });
            CountryListData.Add(new ComboData { Id = "us", Value = "USA" });
            CountryListData.Add(new ComboData { Id = "uk", Value = "Uk" });

            countryComboBox.ItemsSource = CountryListData;
            countryComboBox.DisplayMemberPath = "Value";
            countryComboBox.SelectedValuePath = "Id";

            countryComboBox.SelectedValue = "in";

        }

        private void PopulateResults()
        {
            string Results = "";
            string CurrQuestionTag = Data[0].QuestionTag;
            string PrevQuestionTag = Data[0].QuestionTag;

            for (int i = 0; i < Data.Count; i++)
            {
                CurrQuestionTag = Data[i].QuestionTag;

                if (CurrQuestionTag != PrevQuestionTag)
                {
                    Results += "\n\n";
                }

                Results += Data[i].Query + "\n";

                PrevQuestionTag = CurrQuestionTag;
            }

            resultsScrollViewer.Content = Results;
        }

        private async Task GetSuggestions()
        {
            Data = await SuggestionProcessor.GetData(Keyword, Lang, Country);

            progressBar.Visibility = Visibility.Hidden;

            if (Data.Count > 0)
            {
                PopulateResults();
            }
            else
            {
                resultsScrollViewer.Content = "SORRY, NO RESULTS FOUND.";
            }
        }

        private async void handleSearch(object sender, RoutedEventArgs e)
        {
            resultsScrollViewer.Content = "";
            progressBar.Visibility = Visibility.Visible;

            Keyword = HttpUtility.UrlEncode(keywordTextBox.Text, Encoding.UTF8);
            Lang = languageComboBox.SelectedValue.ToString();
            Country = countryComboBox.SelectedValue.ToString();

            await GetSuggestions();
        }
    }
}
