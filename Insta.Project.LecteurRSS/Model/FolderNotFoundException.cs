using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insta.Project.LecteurRSS.Model
{
    /// <summary>
    /// Exception levée lorsque le repertoire n'est pas trouvé
    ///  dans l'arbre des repertoires de l'application.
    /// </summary>
    public class FolderNotFoundException : Exception
    {
        public FolderNotFoundException(String message) :
            base(message) {
        }
    }
}
