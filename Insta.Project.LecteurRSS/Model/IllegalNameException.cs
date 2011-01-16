using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insta.Project.LecteurRSS.Model
{
    /// <summary>
    /// Exception levée lorsque le nom d'un repertoire ou 
    ///   d'un channel est incorrecte.
    /// </summary>
    public class IllegalNameException : Exception 
    {
        /// <summary>
        /// Instancie un nouvelle exception levée lorsque le nom
        ///     d'un repertoire ou d'un channel est inconrrecte
        /// </summary>
        /// <param name="message">message de l'exception</param>
        public IllegalNameException(String message)
            : base(message)
        { }
    }
}
