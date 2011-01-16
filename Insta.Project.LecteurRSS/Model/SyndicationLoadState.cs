using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insta.Project.LecteurRSS.Model
{
    public enum SyndicationLoadState
    {
        /// <summary>
        /// Aucune action
        /// </summary>
        NONE,

        /// <summary>
        /// Changement en corus
        /// </summary>
        LOADING,

        /// <summary>
        /// Channel chargé
        /// </summary>
        LOADED,

        /// <summary>
        /// Erreur lors du chargement
        /// </summary>
        LOAD_FAILED,
    }
}
