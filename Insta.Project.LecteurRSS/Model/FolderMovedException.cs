using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insta.Project.LecteurRSS.Model
{
    /// <summary>
    /// Exception levée au monent de l'echec du deplacement d'un repertoire.
    /// </summary>
    public class FolderMovedException : Exception
    {
        /// <summary>
        ///  Instancie une nouvelle expcetion
        /// </summary>
        /// <param name="message">message de l'exception</param>
        public FolderMovedException(String message)
            : base(message)
        { }
    }
}
