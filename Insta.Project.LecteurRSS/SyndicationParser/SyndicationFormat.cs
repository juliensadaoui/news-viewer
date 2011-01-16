using System;
using System.Collections.Generic;
using System.Text;

// ressources de l'analyseur de fichier XML
using System.Xml;

// ressources du canal
using Insta.Project.LecteurRSS.Model;

namespace Insta.Project.LecteurRSS.SyndicationParser
{
    /// <summary>
    /// 
    /// </summary>
    public enum SyndicationFormat
    {
        /// <summary>
        /// valeur par défaut significative. 
        /// </summary>
        NONE,

        /// <summary>
        /// Syndication Format : RSS 0.91
        /// </summary>
        RSS_0_91,

        /// <summary>
        /// Syndication Format : RSS 0.92
        /// </summary>
        RSS_0_92,

        /// <summary>
        /// Syndication Format : RSS 2.0
        /// </summary>
        RSS_2_0,

        /// <summary>
        /// Syndication Format : ATOM 1.0
        /// </summary>
        ATOM_1_0,
    }
}
