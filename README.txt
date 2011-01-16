1. Introduction
===============

News Viewer est un agr�gateur de nouvelles (flux d'actualit�) pour les plateformes Windows. Il prend en charge les formats RSS et ATOM.
L'application a une interface dans le m�me style que Thunderbird avec une section r�pertoriant tous les diff�rents fils d�actualit�s, 
et une autre section avec les titres des actualit�s. Un navigateur web permet de visualiser l�actualit�.
Cette interface permet de r�cup�rer de mani�re simple et rapide les actualit�s. Elle permet �galement de classer et d�organiser les actualit�s 
dans des r�pertoires.



2. Installation
===============

Syst�mes requis: 
	Windows XP SP3/ Windows Vista SP2/ Windows 7
	Microsoft .NET Framework 3.5 SP1

Pour installer News Viewer, il suffit de copier le r�pertoire bin\Release sur votre disque local. Double-cliquez sur le fichier 
"Insta.Project.LecteurRSS.exe" pour d�marrer l'application.


3. Hackers guide
================

News Viewer est �crit dans le langage C# pour la plateforme .NET. L'application n�cessite l'IDE Visual Studio 2008 pour ouvrir le projet.
Double-cliquez sur le fichier "Insta.Project.LecteurRSS.sln".

---------------------------
The source tree
---------------------------


/                        Root directory.
|
|-- Controller		 Composant permettant de r�aliser la liaison entre l'interface utilisateur et l�annuaire de flux RSS
|
|-- Model		 Composant principal de l�application se pr�sentant comme un annuaire de flux RSS
|	
|-- SyndicationParser	 Analyseur de fichier XML de flux RSS g�n�rique
|
|-- View                 Interface utilisateur (GUI) de l'application     