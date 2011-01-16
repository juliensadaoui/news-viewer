using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insta.Project.LecteurRSS.Model
{
    /// <summary>
    /// Une image represente l'icone du site web associé à un channel.
    /// </summary>
    public class Image
    {
        /// <summary>
        /// l'URL d'une image GIF, JPEG ou PNG qui représente la canal. 
        /// </summary>
        private String _url;

        /// <summary>
        /// décrit l'image, il est utilisé par l'attribut ALT de la balise HTML <img> quand le canal est rendu en HTML. 
        /// </summary>
        private String _title;

        /// <summary>
        /// l'URL du site, quand le canal est affiché, l'image est un lien sur le site
        /// </summary>
        private String _link;

        /// <summary>
        /// nombre indiquant la hauteur de l'image en pixels.
        /// </summary>
        private int _height;

        /// <summary>
        /// nombre indiquant la largeur de l'image en pixels.
        /// </summary>
        private int _width;

        /// <summary>
        /// contenant le texte inclut dans l'attribut TITLE 
        ///  du lien formé autour de l'image dans le rendu HTML.
        /// </summary>
        private String _description;

        #region Constructeur

        /// <summary>
        /// Instancie une nouvelle image associé à un channel. Elle represente
        ///     l'icone du site web associé au channel.
        /// </summary>
        /// <param name="url"></param>
        public Image(String url)
        {
            _url = url;
        }

        #endregion

        #region Propriete

        public String Url
        {
            get { return _url; }
            set { _url = value; }
        }

        public String Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public String Link
        {
            get { return _link; }
            set { _link = value; }
        }

        public String Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        #endregion

        #region Method

        /// <summary>
        /// Retourne l'objet sous la forme textuelle
        /// </summary>
        /// <returns>forme textuelle de l'object</returns>
        public String toString()
        {
            StringBuilder str = new StringBuilder();

            str.Append("\n\tUrl: " + Url);
            str.Append("\n\tTitle: " + Title);
            str.Append("\n\tLink: " + Link);

            return str.ToString();
        }

        #endregion

    }
}
