using Phraseur.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phraseur.ViewModels
{
    /// <summary>
    /// Thème
    /// </summary>
    public class ThemeViewModel : BaseViewModel
    {
        public ThemeViewModel(ThemeDefinition theme)
        {
            Theme = theme ?? throw new ArgumentNullException(nameof(theme));
            Collections = new ObservableCollection<WordCollectionViewModel>();
            BuildModel();
        }

        void BuildModel()
        {
            int idx = 0;
            foreach (var collection in Theme.Collections)
            {
                Collections.Add(new WordCollectionViewModel(collection, idx++, this));
            }
        }

        public string GetCurrentPhrase()
        {
            StringBuilder result = new StringBuilder();
            foreach (var collection in Collections.Where(c => c.Selected != null))
            {
                result.Append(collection.Selected.Phrase).Append(" ");
            }
            return result.ToString().Trim();
        }

        internal void SelectedWordChanged(WordCollectionViewModel collection)
        {
            CurrentPhrase = GetCurrentPhrase();
        }

        public void Reset()
        {
            foreach (var collection in Collections)
                collection.Selected = null;
            CurrentPhrase = string.Empty;
        }

        /// <summary>
        /// Thème sous jacent
        /// </summary>
        public ThemeDefinition Theme { get; }

        /// <summary>
        /// Titre
        /// </summary>
        public string Title => Theme.Title;

        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<WordCollectionViewModel> Collections { get; }

        /// <summary>
        /// Phrase
        /// </summary>
        public string CurrentPhrase
        {
            get { return _currentPhrase; }
            set { Set(ref _currentPhrase, value); }
        }
        private string _currentPhrase;

    }
}
