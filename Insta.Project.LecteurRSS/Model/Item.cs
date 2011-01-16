using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insta.Project.LecteurRSS.Model
{
    /// <summary>
    /// Delagate de l'evenement signalant que l'article 
    ///  est marqué comme lu.
    /// </summary>
    public delegate void ItemReadChangedDelegate();

    /// <summary>
    /// Cette classe represente un article (actualité)
    ///   d'un canal de l'annuaire de flux RSS.
    /// </summary>
    public class Item
    {
        #region -- Attribut de l'article (Item) --

        /// <summary>
        /// titre de l'article
        /// </summary>
        private String _title;

        /// <summary>
        /// url de l'article
        /// </summary>
        private String _link;

        /// <summary>
        /// description de l'article
        /// </summary>
        private String _description;

        /// <summary>
        /// url de l'auteur de l'article
        /// </summary>
        private String _author;

        /// <summary>
        /// categorie de l'article
        /// </summary>
        private String _category;

        /// <summary>
        /// liste des contributeurs de l'article
        /// </summary>
        private List<String> _contributors;

        /// <summary>
        /// url de la page de commentaires de l'article.
        /// </summary>
        private String _comments;

        /// <summary>
        /// Numero unique identifiant l'article
        /// </summary>
        private String _guid;

        /// <summary>
        /// Date de publication de l'article
        /// </summary>
        private String _pubDate;

        /// <summary>
        /// Date de la derniere mise à jour de l'article
        /// </summary>
        private String _updated;

        /// <summary>
        /// channel de l'article
        /// </summary>
        private String _source;

        /// <summary>
        /// TRUE si l'utilisateur a lu l'article
        /// </summary>
        private bool isRead;

        /// <summary>
        /// Channel associé à l'article
        /// </summary>
        private Channel _parent;

        #endregion

        #region -- Event --

        /// <summary>
        /// Evenement declenché lorsque l'article est supprimé.
        /// </summary>
        public event DeleteRequestDelegate DeleteItemRequest;

        /// <summary>
        /// Evenement declenché lorsque l'article est lu.
        /// </summary>
        public event ItemReadChangedDelegate ItemReadChanged;

        #endregion

        #region Constructor

        /// <summary>
        ///  Instancie un nouveau article en spécifiant tous les parametres 
        /// </summary>
        /// <param name="parent">channel associé à l'article</param>
        /// <param name="title">titre de l'article</param>
        /// <param name="link">lien vers la page web de l'article</param>
        /// <param name="description">description de l'article</param>
        /// <param name="authors">liste des auteurs</param>
        /// <param name="categories">liste des categories associé à l'artcile</param>
        /// <param name="contributors">liste des contributors</param>
        /// <param name="guid">identifiant de l'article</param>
        /// <param name="source">lien vers la page web du channel associé</param>
        /// <param name="pubDate">date de publication</param>
        /// <param name="updated">date de mise à jour</param>
        /// <param name="comments">lien vers les commentaires de l'article</param>
        public Item(Channel parent,
                    String title,
                    String link,
                    String description,
                    String author,
                    String category,
                    List<String> contributors,
                    String guid,
                    String source,
                    String pubDate,
                    String updated,
                    String comments)
        {
            _parent = parent;
            _title = title;
            _link = link;
            _description = description;
            _author = author;
            _category = category;
            _contributors = new List<string>();
            if (contributors != null) _contributors = contributors;
            _guid = guid;
            _source = source;
            _pubDate = pubDate;
            _updated = updated;
            _comments = comments;
        }

        #endregion

        #region Propriete

        /// <summary>
        /// Retourne le channel associé à l'article
        /// </summary>
        public Channel Parent { get { return _parent; } }

        /// <summary>
        /// Retourne le titre de l'article
        /// </summary>
        public String Title { get { return _title; } }

        /// <summary>
        /// Retourne le lien vers la page web de l'article
        /// </summary>
        public String Link { get { return _link; } }

        /// <summary>
        /// Retourne la description de l'article
        /// </summary>
        public String Description { get { return _description; } }

        /// <summary>
        /// Retourne une enumeration des auteurs associés à l'article
        /// </summary>
        public String Author { get { return _author; } }

        /// <summary>
        /// Retourne la liste des contributeurs de l'article
        /// </summary>
        public IEnumerable<String> Contributors
        {
            get
            {
                foreach (String contributor in _contributors)
                {
                    yield return contributor;
                }
            }
        }

        /// <summary>
        /// Retourne la categorie associés à l'article
        /// </summary>
        public String Category { get { return _category; } }

        /// <summary>
        /// Retourne l'identifiant de l'article
        /// </summary>
        public String Guid { get { return _guid; } }

        /// <summary>
        /// Retourne la date de publication de l'article
        /// </summary>
        public String PubDate { get { return _pubDate; } }

        /// <summary>
        /// Retourne la date de la derniere mise à jour de l'article
        /// </summary>
        public String Updated { get { return _updated; } }

        /// <summary>
        /// Retourne l'adresse web ou le nom de la source de l'article.
        ///     La source est le channel associé à l'article
        /// </summary>
        public String Source { get { return _source; } }

        /// <summary>
        /// Retourne le lien vers la page des commentaires de l'article
        /// </summary>
        public String Comments { get { return _comments; } }

        public bool IsRead
        {
            get { return isRead; }
            set 
            { 
                // on declenché l'evenement signalant que 
                //  l'article est marqué comme lu
                if ((ItemReadChanged != null) && 
                        (!IsRead))
                {
                    ItemReadChanged();
                }
                isRead = value;
            }
        }

        #endregion

        #region -- Methode de la classe --

        /// <summary>
        /// Supprime l'article au channel associé
        /// </summary>
        public void Delete()
        {
            if (DeleteItemRequest != null) {
                DeleteItemRequest(Guid, Parent.Path);
            }
        }

        public override String ToString()
        {
            StringBuilder str = new StringBuilder();

            // titre de l'article
            str.Append("\n\tTitle: ");
            if (Title != null)
                str.Append(Title);
            else
                str.Append("<empty>");

            // lien web vers la page de l'article
            str.Append("\n\tLink: ");
            if (Link != null)
                str.Append(Link);
            else
                str.Append("<empty>");

            // description de l'article
            str.Append("\n\tDescription: ");
            if (Description != null)
                str.Append("\n\tDescription: " + Description);
            else
                str.Append("<empty>");

            // auteur de l'article
            str.Append("\n\tAuthor: ");
            if (Author != null)
                str.Append(Author);
            else
                str.Append("<empty>");

            // contributeurs de l'article
            str.Append("\n\tContributors: ");
            if (_contributors.Count != 0)
            {
                foreach (String contributor in Contributors)
                {
                    str.Append(contributor + " ");
                }
            }
            else
            {
                str.Append("<empty>");
            }

            // categorie de l'article
            str.Append("\n\tCategory: ");
            if (Category != null)
                str.Append(Category);
            else
                str.Append("<empty>");

            // identifiant de l'article
            str.Append("\n\tGuid: ");
            if (Guid != null)
                str.Append(Guid);
            else
                str.Append("<empty>");  
         
            // date de publication
            str.Append("\n\tPubDate: ");
            if (PubDate != null)
                str.Append(PubDate);
            else
                str.Append("<empty>");  

            // canal associé à l'article
            str.Append("\n\tSource: ");
            if (Source != null)
                str.Append(Source);
            else
                str.Append("<empty>");  

            // lien vers la page des commentaires de l'article
            str.Append("\n\tComments: ");
            if (Comments != null)
                str.Append(Comments);
            else
                str.Append("<empty>");  

            // derniere mise à jour de l'article
            str.Append("\n\tUpdated: ");
            if (Updated != null)
                str.Append(Updated);
            else
                str.Append("<empty>");

            // etat (lu on non lu)
            str.Append("\n\tIsReas: " + IsRead);

            return str.ToString();
        }

        #endregion
    }
}
