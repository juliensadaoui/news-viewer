1. Introduction
===============

News Viewer est un agrégateur de nouvelles (flux d'actualité) pour les plateformes Windows. Il prend en charge les formats RSS et ATOM.
L'application a une interface dans le même style que Thunderbird avec une section répertoriant tous les différents fils d’actualités, 
et une autre section avec les titres des actualités. Un navigateur web permet de visualiser l’actualité.
Cette interface permet de récupérer de manière simple et rapide les actualités. Elle permet également de classer et d’organiser les actualités 
dans des répertoires.



2. Installation
===============

Systèmes requis: 
	Windows XP SP3/ Windows Vista SP2/ Windows 7
	Microsoft .NET Framework 3.5 SP1

Pour installer News Viewer, il suffit de copier le répertoire bin\Release sur votre disque local. Double-cliquez sur le fichier 
"Insta.Project.LecteurRSS.exe" pour démarrer l'application.


3. Hackers guide
================

News Viewer est écrit dans le langage C# pour la plateforme .NET. L'application nécessite l'IDE Visual Studio 2008 pour ouvrir le projet.
Double-cliquez sur le fichier "Insta.Project.LecteurRSS.sln".

---------------------------
The source tree
---------------------------


/                        Root directory.
|
|-- Controller		 Composant permettant de réaliser la liaison entre l'interface utilisateur et l’annuaire de flux RSS
|
|-- Model		 Composant principal de l’application se présentant comme un annuaire de flux RSS
|	
|-- SyndicationParser	 Analyseur de fichier XML de flux RSS générique
|
|-- View                 Interface utilisateur (GUI) de l'application     