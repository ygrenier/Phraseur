using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phraseur.Models;

namespace Phraseur.ViewModels
{
    public class WordCollectionViewModel : BaseViewModel
    {
        private readonly ThemeViewModel themeViewModel;

        public WordCollectionViewModel(WordCollection collection, int index, ThemeViewModel theme)
        {
            Words = collection ?? throw new ArgumentNullException(nameof(collection));
            this.themeViewModel = theme ?? throw new ArgumentNullException(nameof(theme));
            Index = index;
        }

        public int Index { get; }

        public string Title => Words.Title;

        public WordCollection Words { get; }

        public WordDefinition Selected
        {
            get { return _selected; }
            set
            {
                if (Set(ref _selected, value))
                {
                    themeViewModel.SelectedWordChanged(this);
                }
            }
        }
        private WordDefinition _selected;

    }
}
