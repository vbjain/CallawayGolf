using Demo.Common;
using Demo.WPFApp.Classes;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Demo.WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private ObservableCollection<Category> _categories;

        public ObservableCollection<Category> Categories
        {
            get
            {
                return _categories;
            }
            set
            {
                _categories = value;
                if(PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Categories"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void btnUpload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = ".json";
            openFileDialog.Filter = "JSON(.json)| *.json";
            var res = openFileDialog.ShowDialog();
            if(res != null && res.HasValue && res.Value)
            {
                using (var file = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    var streamReader = new StreamReader(file);
                    var fileData = streamReader.ReadToEnd();
                    var categories = JsonConvert.DeserializeObject<List<Category>>(fileData);
                    categories = categories.OrderBy(c => c.SortOrder).ToList();
                    Parallel.ForEach(categories, c =>
                    {
                        c.Models = c.Models.OrderBy(m => m.SortOrder).ToList();
                        Parallel.ForEach(c.Models, m =>
                        {
                            m.Products = m.Products.OrderBy(p => p.Hand).ThenBy(p => p.Gender).ThenBy(p => p.SortOrder).ThenBy(p => p.Description).ToList();
                        });
                    });

                    PopulateImageUrls(categories);

                    this.Categories = new ObservableCollection<Category>(categories);

                    file.Close();
                }
            }
        }

        private void btnUploadExtra_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = ".json";
            openFileDialog.Filter = "JSON(.json)| *.json";
            var res = openFileDialog.ShowDialog();
            if (res != null && res.HasValue && res.Value)
            {
                using (var file = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    var streamReader = new StreamReader(file);
                    var fileData = streamReader.ReadToEnd();
                    var categories = JsonConvert.DeserializeObject<List<Category>>(fileData);
                    categories = categories.OrderBy(c => c.SortOrder).ToList();
                    Parallel.ForEach(categories, c =>
                    {
                        c.Models = c.Models.OrderBy(m => m.SortOrder).ToList();
                        Parallel.ForEach(c.Models, m =>
                        {
                            m.Products = m.Products.OrderBy(p => p.Hand).ThenBy(p => p.Gender).ThenBy(p => p.SortOrder).ThenBy(p => p.Description).ToList();
                        });
                    });

                    PopulateImageUrls(categories);
                    
                    Parallel.ForEach(categories, c =>
                    {
                        Parallel.ForEach(c.Models, async m =>
                        {
                            await Demo.ExtraService.InventoryAssignService.Instance.RandomAssignInventory(m.Products);
                        });
                    });

                    this.Categories = new ObservableCollection<Category>(categories);

                    file.Close();
                }
            }
        }


        private string GoogleImageSearchUrl
        {
            get
            {
                return "https://www.googleapis.com/customsearch/v1?q={0}&searchType=image&fileType=png&key=AIzaSyA30aiGp300gu4cLJhlH77LR0yueNhmHrA&cx=002692538317433306665:ytlo9nbpavy";
            }
        }

        private void PopulateImageUrls(List<Category> categories)
        {
            Parallel.ForEach(categories, c =>
            {
                try
                {
                    var url = string.Format(GoogleImageSearchUrl, c.Name);
                    var restClient = new RestSharp.RestClient(url);
                    var restRequest = new RestSharp.RestRequest(RestSharp.Method.GET);
                    var result = restClient.ExecuteAsGet<GoogleResult>(restRequest, "GET");
                    if (result != null &&
                            result.Data != null &&
                            result.Data.Items != null &&
                            result.Data.Items.Count > 0)
                    {
                        c.ImageUrl = result.Data.Items[0].Link;
                    }
                }
                catch
                {

                }
            });
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            var tagValue = "";

            if (e.Source is System.Windows.Controls.Image)
            {
                tagValue = ((System.Windows.Controls.Image)e.Source).Tag.ToString();
            }
            if (e.Source is System.Windows.Controls.TextBlock)
            {
                tagValue = ((System.Windows.Controls.TextBlock)e.Source).Tag.ToString();
            }

            var panel = FindVisualChildren<ItemsControl>(this).Where(s => s.Tag != null && s.Tag.ToString() == tagValue).FirstOrDefault();
            if(panel != null)
            {
                panel.BringIntoView();
            }
        }

    }
}
