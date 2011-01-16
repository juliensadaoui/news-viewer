using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insta.Project.LecteurRSS
{
    class from_Browser_Controller
    {
        private Stack<string> _adresses = new Stack<string>();
        

        public Stack<string> Adresses
        {
            get { return _adresses; }
            set { _adresses = value; }
        }


        public void OnDocumentLoaded(string documentUrl)
        {
            _adresses.Push(documentUrl);
        }

        public void GoBack()
        {
            
        }

        public void GoForward()
        {

        }





        private frm_Browser _view;

        /// <summary>
        /// La vue
        /// </summary>
        public frm_Browser View
        {
            get { return _view; }
            set { _view = value; }
        }

        public from_Browser_Controller(frm_Browser view)
        {
            _view = view;
        }

    }
}
