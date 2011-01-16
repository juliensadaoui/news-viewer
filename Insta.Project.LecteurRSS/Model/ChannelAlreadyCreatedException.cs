using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insta.Project.LecteurRSS.Model
{
    /// <summary>
    /// Exception levée au monent de la creation d'un channel si un
    ///  channel avec le même nom existe déjà dans le repertoire.
    /// </summary>
    public class ChannelAlreadyCreatedException : Exception
    {
        /// <summary>
        /// Instancie une nouvelle Exception.
        /// </summary>
        /// <param name="message">message de l'exception</param>
        public ChannelAlreadyCreatedException(String message)
            : base(message)
        { }
    }
}
