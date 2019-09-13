using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phraseur.Models
{
    /// <summary>
    /// Définition d'un thème
    /// </summary>
    public class ThemeDefinition
    {
        /// <summary>
        /// Titre du thème
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Collections
        /// </summary>
        public ObservableCollection<WordCollection> Collections { get; } = new ObservableCollection<WordCollection>();
    }
}
