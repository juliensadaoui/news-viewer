using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Insta.Project.LecteurRSS.Model;
using System.Windows.Forms;

namespace Insta.Project.LecteurRSS.Controller
{
    /// <summary>
    /// Delegate pour l'evenement signalant le deplacement d'un element
    /// </summary>
    /// <param name="channel"></param>
    public delegate void ElemMovedDelegate();

    /// <summary>
    /// Controller de la frame (vue) pour deplacer un channel ou 
    ///     un repertoire. La frame pour deplacer un element est 
    ///     un composant permettant de saisir le nouveau emplacement
    ///     de l'element.
    /// </summary>
    public class frmDeplacerController
    {
        #region -- Model de l'application --

        /// <summary>
        /// Model de l'application. Le model de l'application
        /// contient tous les données de l'application.
        /// </summary>
        private SyndicationManager _manager;

        /// <summary>
        /// Retourne ou modifie le model de l'application
        /// </summary>
        public SyndicationManager Manager
        {
            get { return _manager; }
            set { _manager = value; }
        }

        #endregion

        #region -- Vue associé à ce controller --

        /// <summary>
        /// La vue est le composant graphique permettant la 
        ///  saisie des informations sur le nouveau emplacement
        ///  de l'element.
        /// </summary>
        private frmDeplacer _view;

        /// <summary>
        /// Vue associé à ce controller
        /// </summary>
        public frmDeplacer View
        {
            get { return _view; }
            set { _view = value; }
        }

        #endregion

        #region -- Element à deplacer --

        /// <summary>
        /// Element à deplacer
        /// </summary>
        private Object _elem;

        /// <summary>
        /// Retourne l'element à deplacer
        /// </summary>
        public Object Elem
        { 
            get { return _elem; } 
            set { _elem = value; }
        }

        #endregion

        #region -- Event --
        
        public event ElemMovedDelegate ElemMoved;

        #endregion

        #region -- Constructor --

        /// <summary>
        /// Controller de la frame (vue) pour deplacer un channel ou 
        ///     un repertoire. La frame pour deplacer un element est 
        ///     un composant permettant de saisir le nouveau emplacement
        ///     de l'element.
        /// </summary>
        /// <param name="manager">model de l'application</param>
        /// <param name="view">frame associé au controller</param>
        /// <param name="elem">element à deplacer</param>
        public frmDeplacerController(SyndicationManager manager, frmDeplacer view, Object elem)
        {
            _elem = elem;
            _view = view;
            _manager = manager;
        }

        #endregion

        #region -- Methode pour déplacer un canal --

        /// <summary>
        /// Deplace l'element dans le chemin spécifié en parametre.
        /// </summary>
        /// <param name="path">nouveau chemin de l'element</param>
        public void MoveElem(String path)
        {
            // INIT 
            Channel channel;
            SyndicationFolder folder;

            try
            {
                // deplace l'element
                if (Elem is Channel)
                {
                    channel = Elem as Channel;
                    channel.Move(path);
                }
                else if (Elem is SyndicationFolder)
                {
                    folder = Elem as SyndicationFolder;
                    folder.Move(path);
                }

                // declenché l'evenement indiquant
                //    le deplacement de l'element
                ElemMoved();

                // ferme la frame
                View.Dispose();
            }
            catch (FolderMovedException exception1)
            {
                MessageBox.Show(exception1.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ChannelMovedException exception2)
            {
                MessageBox.Show(exception2.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
