using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insta.Project.LecteurRSS.Model
{
    /// <summary>
    /// Exception levée le channel n'est pas trouvé dans 
    ///  l'arbre des repertoires
    /// </summary>
    public class ChannelNotFoundException : Exception
    {
        /// <summary>
        /// Instancie une nouvelle exception levée lorsque le channel
        ///  n'est pas trouvé dans l'arbre des repertoires.
        /// </summary>
        /// <param name="message"></param>
        public ChannelNotFoundException(String message)
            : base(message) {
        }
    }
}
