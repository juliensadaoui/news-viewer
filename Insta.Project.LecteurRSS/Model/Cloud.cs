using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insta.Project.LecteurRSS.Model
{
    /// <summary>
    /// Un cloud est un service web qui supporte l'interface rssCloud interface 
    /// qui peut être implémentée en HTTP-POST, XML-RPC ou SOAP 1.1.
    /// 
    /// Un cloud est associé à un channel
    /// </summary>
    public class Cloud
    {
        /// <summary>
        /// nom de domain du service web
        /// </summary>
        private String _domain;

        /// <summary>
        /// port TCP/UDP du service web
        /// </summary>
        private int _port;

        /// <summary>
        /// chemin du service web
        /// </summary>
        private String _path;

        /// <summary>
        /// 
        /// </summary>
        private String _registerProcedure;

        /// <summary>
        /// protocole utilisé par le protocole (message)
        /// </summary>
        private String _protocol;

        #region Propriete

        public String Domain
        {
            get { return _domain; }
            set { _domain = value; }
        }

        public int Port
        {
            get { return _port; }
            set { _port = value; }
        }

        public String Path
        {
            get { return _path; }
            set { _path = value; }
        }

        public String RegisterProcedure
        {
            get { return _registerProcedure; }
            set { _registerProcedure = value; }
        }

        public String Protocol
        {
            get { return _protocol; }
            set { _protocol = value; }
        }

        #endregion

        #region Method

        /// <summary>
        /// Retourne la forme textuelle de l'objet
        /// </summary>
        /// <returns></returns>
        public String toSring()
        {
            StringBuilder str = new StringBuilder();

            str.Append("\n\tDomain: " + Domain);
            str.Append("\n\tPort: " + Port);
            str.Append("\n\tPath: " + Path);
            str.Append("\n\tRegisterProcedure: " + RegisterProcedure);
            str.Append("\n\tProtocol: " + Protocol);

            return str.ToString();
        }

        #endregion
    }
}
