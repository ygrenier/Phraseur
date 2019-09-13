using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Phraseur.ViewModels
{
    public class AppViewModel : BaseViewModel
    {
        readonly Services.ThemeRepository repository;

        public AppViewModel()
        {
            repository = new Services.ThemeRepository(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "datas"));
        }


        protected void LoadTheme(string file)
        {
            try
            {
                CurrentTheme = new ThemeViewModel(repository.LoadTheme(file));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Echec du chargement du thème");
                CurrentTheme = null;
            }
        }

        public void AddCurrentPhrase()
        {
            var phrase = CurrentTheme?.CurrentPhrase;
            if (!string.IsNullOrEmpty(phrase))
            {
                Result = Result + phrase + Environment.NewLine;
                CurrentTheme.Reset();
            }
        }

        public void LoadThemes()
        {
            var themes = repository.GetAllThemes();
            SelectedTheme = null;
            Themes.Clear();
            foreach (var kv in themes.OrderBy(t => t.Value))
            {
                Themes.Add(new ThemeInfos
                {
                    Title = kv.Value,
                    File = kv.Key
                });
            }
            SelectedTheme = Themes.FirstOrDefault();
        }

        public ObservableCollection<ThemeInfos> Themes { get; } = new ObservableCollection<ThemeInfos>();

        public ThemeInfos SelectedTheme
        {
            get { return _selectedTheme; }
            set
            {
                if (Set(ref _selectedTheme, value))
                {
                    if (SelectedTheme == null)
                    {
                        CurrentTheme = null;
                    }
                    else
                    {
                        LoadTheme(SelectedTheme.File);
                    }
                }
            }
        }
        private ThemeInfos _selectedTheme;

        public ThemeViewModel CurrentTheme
        {
            get { return _currentTheme; }
            private set { Set(ref _currentTheme, value); }
        }
        private ThemeViewModel _currentTheme;

        public string Result
        {
            get { return _result; }
            set { Set(ref _result, value); }
        }
        private string _result;

    }

    public class ThemeInfos
    {
        public string Title { get; set; }
        public string File { get; set; }
    }

}
