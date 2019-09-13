using Phraseur.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Phraseur.Services
{
    /// <summary>
    /// Gestion des fichiers
    /// </summary>
    public class ThemeRepository
    {
        /// <summary>
        /// Création d'un nouveau service
        /// </summary>
        /// <param name="folder"></param>
        public ThemeRepository(string folder)
        {
            Folder = folder ?? string.Empty;
        }

        public ThemeDefinition LoadTheme(string file)
        {
            if (!File.Exists(file)) return null;
            using (var reader = new StreamReader(file))
            {
                ThemeDefinition result = new ThemeDefinition()
                {
                    Title = Path.GetFileName(file)
                };
                WordCollection collection = null;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();

                    // On passe les lignes vides
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    // Si la ligne commence par un ';' c'est un commentaire, on passe
                    if (line.StartsWith(";")) continue;

                    // Si la ligne commence par un '@' alors c'est le titre du thème
                    if (line.StartsWith("@"))
                    {
                        result.Title = line.Substring(1).Trim();
                    }
                    // Si la ligne commence par un '#' alors c'est une nouvelle collection de mot
                    else if (line.StartsWith("#"))
                    {
                        collection = new WordCollection
                        {
                            Title = line.Substring(1).Trim()
                        };
                        result.Collections.Add(collection);
                        if (string.IsNullOrWhiteSpace(collection.Title))
                            collection.Title = $"Collection #{result.Collections.Count}";
                    }
                    // Sinon c'est une définition de mot
                    else
                    {
                        // On a une collection ?
                        if (collection == null)
                        {
                            collection = new WordCollection
                            {
                                Title = $"Collection #{result.Collections.Count + 1}"
                            };
                            result.Collections.Add(collection);
                        }
                        // Détermine le format de la ligne
                        int idx = line.IndexOf("=");
                        WordDefinition word;
                        if (idx < 0)
                        {
                            word = new WordDefinition { Phrase = line };
                        }
                        else
                        {
                            word = new WordDefinition
                            {
                                Word = line.Substring(0, idx).Trim(),
                                Phrase = line.Substring(idx + 1).Trim()
                            };
                        }
                        collection.Add(word);
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Lecture de tous les termes
        /// </summary>
        public Dictionary<string, string> GetAllThemes()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            if (Directory.Exists(Folder))
            {
                foreach (var file in System.IO.Directory.EnumerateFiles(Folder, "*.txt"))
                {
                    var theme = LoadTheme(file);
                    if (theme != null)
                        result.Add(file, theme.Title);
                }
            }
            return result;
        }

        /// <summary>
        /// Dossier où trouver les fichiers de données
        /// </summary>
        public string Folder { get; }
    }
}
