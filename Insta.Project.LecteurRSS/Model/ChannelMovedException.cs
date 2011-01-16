using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insta.Project.LecteurRSS.Model
{
    /// <summary>
    /// Exception levée au monent de l'echec du deplacement d'un channel.
    /// </summary>
    public class ChannelMovedException : Exception
    {
        /// <summary>
        ///  Instancie une nouvelle expcetion
        /// </summary>
        /// <param name="message">message de l'exception</param>
        public ChannelMovedException(String message)
            : base(message)
        { }
    }
}
