using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phraseur.Models
{

    /// <summary>
    /// Collection de mots
    /// </summary>
    public class WordCollection : ObservableCollection<WordDefinition>
    {
        /// <summary>
        /// Titre de la collection
        /// </summary>
        public string Title { get; set; }
    }

}
