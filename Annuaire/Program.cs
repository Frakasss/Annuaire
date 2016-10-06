using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace Annuaire
{
    static class Program
    {
        //The main entry point for the application.
        [STAThread]
        static void Main()
        {
            Check isValid = new Check();

            isValid.setup();

            bool check = true;
            check = isValid.checkActivite(check);
            check = isValid.checkRelations(check);
            check = isValid.checkAnnuaire(check);
            if (check)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Annuaire());
            }
            else
            {
                MessageBox.Show("Le fichier Base de Données est corrompu");
            }


        }
    }

    public class Fiche
    {
        public string Id;
        public string Nom;
        public string Prenom;
        public string Alias;
        public string Tel1;
        public string Tel2;
        public string Adresse;
        public string Activite;
        public string Relation;
        public string LienPhoto;
        public string Detail;
        public string DateAnniversaire;

        //contructeur
        public Fiche() { }

        public Fiche(String paramId, String paramNom, String paramPrenom, String paramAlias, 
                     String paramTel1, String paramTel2, String paramAdresse, String paramActivite, 
                     String paramRelation, String paramLienPhoto, String paramDetail, String paramDateAnniv)
        {
            this.Id = paramId;
            this.Nom = paramNom;
            this.Prenom = paramPrenom;
            this.Alias = paramAlias;
            this.Tel1 = paramTel1;
            this.Tel2 = paramTel2;
            this.Adresse = paramAdresse;
            this.Activite = paramActivite;
            this.Relation = paramRelation;
            this.LienPhoto = paramLienPhoto;
            this.Detail = paramDetail;
            this.DateAnniversaire = paramDateAnniv;
        }
    }

    public class GlobalFunctions
    {
        //Retourne le chemin, depuis la racine, de l'application
        public string AppDrive()
        {
            return (AppDomain.CurrentDomain.BaseDirectory).Substring(0, 3).Replace("\\", "/");
        }
        
        // Retourne le chemin, depuis la racine, de l'application
        public string AppRootPath()
        {
            return (AppDomain.CurrentDomain.BaseDirectory).Replace("\\", "/");
        }
    }

    public class ConfigFunctions {
        GlobalFunctions globalfn = new GlobalFunctions();

        //renvoie la db enregistrée dans appConfig
        public string currentAnnuaire()
        {
            string fichier = "";
            string appConfigPath = globalfn.AppRootPath() + "Annuaires/Configuration/AppConfig.xml";
            XDocument xmlDoc = XDocument.Load(appConfigPath);
            XElement collec = xmlDoc.Element("root").Element("fichiers");

            var records = from myTheme in collec.Elements("annuaire") select myTheme;

            foreach (string myData in records)
            {
                fichier = myData;
            }
            return fichier;
        }

        //renvoie le chemin de la base de donnees
        public string getDBPath(string dbName)
        {
            string toBeReturned = "";
            switch (dbName)
            {
                case "Annuaire":
                    toBeReturned = globalfn.AppRootPath() + "Annuaires/BasesDeDonnees/" + currentAnnuaire();
                    break;
                default:
                    toBeReturned = globalfn.AppRootPath() + "Annuaires/BasesDeDonnees/" + dbName;
                    break;
            }

            return toBeReturned;
        }

        //enregistre le changement de fichier
        public void saveAnnuaire(string fileName) {
            string appConfigPath = globalfn.AppRootPath() + "Annuaires/Configuration/AppConfig.xml";
            XDocument xmlDoc = XDocument.Load(appConfigPath);
            XElement couleurApp = xmlDoc.Element("root");

            var records = from myTheme in couleurApp.Elements("fichiers").Elements("annuaire") select myTheme;
            records.Remove();

            xmlDoc.Element("root").Element("fichiers").Add(new XElement("annuaire", fileName));
            xmlDoc.Save(appConfigPath);
        }
    } 

    public class WriteAccess
    {
        #region Global
        ConfigFunctions configfn = new ConfigFunctions();
        ReadAccess read = new ReadAccess();
        #endregion

        #region Create
        /// Creation d'une nouvelle fiche
        public string fnCreationFiche(String Nom, String Prenom, String Alias, String Tel1, String Tel2, String Adresse, String Activite, String Relation, String LienPhoto, String Details, String DateAnniversaire)
        {
            string id = read.generateId();
            string myXmlDb = configfn.getDBPath("Annuaire");
            XDocument xmlDoc = XDocument.Load(myXmlDb);

            //### enregistrement fiche ###
            xmlDoc.Element("root").Element("annuaire").Add(new XElement("myFiche",
                                                            new XElement("id", id),
                                                            new XElement("nom", Nom),
                                                            new XElement("prenom", Prenom),
                                                            new XElement("alias", Alias),
                                                            new XElement("tel1", Tel1),
                                                            new XElement("tel2", Tel2),
                                                            new XElement("adresse", Adresse),
                                                            new XElement("activite", Activite),
                                                            new XElement("relation", Relation),
                                                            new XElement("lienPhoto", LienPhoto),
                                                            new XElement("details", Details),
                                                            new XElement("dateAnniversaire", DateAnniversaire)));

            xmlDoc.Save(myXmlDb);
            return id.ToString();
        }

        public void fnCreationActivite(String actName) {
            string myXmlDb = configfn.getDBPath("Annuaire");
            XDocument xmlDoc = XDocument.Load(myXmlDb);
            xmlDoc.Element("root").Element("activites").Add(new XElement("activite",new XElement("name", actName)));
            xmlDoc.Save(myXmlDb);
        }

        public void fnCreationRelation(String relName) {
            string myXmlDb = configfn.getDBPath("Annuaire");
            XDocument xmlDoc = XDocument.Load(myXmlDb);
            xmlDoc.Element("root").Element("relations").Add(new XElement("relation", new XElement("name", relName)));
            xmlDoc.Save(myXmlDb);
        }
        #endregion

        #region Update
        /// Modification d'une fiche existante
        public void fnModificationFiche(Int32 nodeToUpdate, String Nom, String Prenom, String Alias, String Tel1, String Tel2, String Adresse, String Activite, String Relation, String LienPhoto, String Details, String DateAnniversaire)
        {
            string myXmlDb = configfn.getDBPath("Annuaire");
            XDocument xmlDoc = XDocument.Load(myXmlDb);
            XElement collec = xmlDoc.Element("root").Element("annuaire");

            var records = from myCollection in collec.Elements("myFiche")
                            where (int)myCollection.Element("id") == nodeToUpdate
                            select myCollection;

            //Remove record
            records.Remove();

            //Insert Record
            xmlDoc.Element("root").Element("annuaire").Add(new XElement("myFiche",
                        new XElement("id", nodeToUpdate.ToString()),
                        new XElement("nom", Nom),
                        new XElement("prenom", Prenom),
                        new XElement("alias", Alias),
                        new XElement("tel1", Tel1),
                        new XElement("tel2", Tel2),
                        new XElement("adresse", Adresse),
                        new XElement("activite", Activite),
                        new XElement("relation", Relation),
                        new XElement("lienPhoto", LienPhoto),
                        new XElement("details", Details),
                        new XElement("dateAnniversaire", DateAnniversaire)));

            xmlDoc.Save(myXmlDb);
        }

        public void fnModificationActivite(string actToUpdate, string actUpdated) {
            foreach (Fiche item in read.fnSelectionFiche("", "", "", "", actToUpdate, "", ""))
            {
                fnModificationFiche(Convert.ToInt32(item.Id), item.Nom, item.Prenom, item.Alias, item.Tel1, item.Tel2, item.Adresse, actUpdated, item.Relation, item.LienPhoto, item.Detail, item.DateAnniversaire);
            }       
        }

        public void fnModificationRelation(string relToUpdate, string relUpdated) {
            foreach (Fiche item in read.fnSelectionFiche("", "", "", "", "", relToUpdate, ""))
            {
                fnModificationFiche(Convert.ToInt32(item.Id), item.Nom, item.Prenom, item.Alias, item.Tel1, item.Tel2, item.Adresse, item.Activite, relUpdated, item.LienPhoto, item.Detail, item.DateAnniversaire);
            }  
        }
        #endregion

        #region Delete
        /// Suppression d'une fiche
        public void fnSuppressionFiche(int nodeToDelete)
        {
            string myXmlDb = configfn.getDBPath("Annuaire");
            XDocument xmlDoc = XDocument.Load(myXmlDb);
            XElement collec = xmlDoc.Element("root").Element("annuaire");

            var records = from myCollection in collec.Elements("myFiche")
                            where (int)myCollection.Element("id") == nodeToDelete
                            select myCollection;

            //Remove record
            records.Remove();

            xmlDoc.Save(myXmlDb);
        }

        public void fnSuppressionActivite(string actToDelete)
        {
            string myXmlDb = configfn.getDBPath("Annuaire");
            XDocument xmlDoc = XDocument.Load(myXmlDb);
            XElement collec = xmlDoc.Element("root").Element("activites");

            var records = from myCollection in collec.Elements("activite")
                          where myCollection.Element("name").Value == actToDelete
                          select myCollection;
            records.Remove();

            xmlDoc.Save(myXmlDb);
        }

        public void fnSuppressionRelation(string relToDelete)
        {
            string myXmlDb = configfn.getDBPath("Annuaire");
            XDocument xmlDoc = XDocument.Load(myXmlDb);
            XElement collec = xmlDoc.Element("root").Element("relations");

            var records = from myCollection in collec.Elements("relation")
                          where myCollection.Element("name").Value == relToDelete
                          select myCollection;
            records.Remove();

            xmlDoc.Save(myXmlDb);
        }
        #endregion

        #region Import
        public void importActivites(string createdFile)
        {
            foreach (string item in read.fnSelectActivites())
            {
                string myXmlDb = configfn.getDBPath(createdFile);
                XDocument xmlDoc = XDocument.Load(myXmlDb);
                xmlDoc.Element("root").Element("activites").Add(new XElement("activite", new XElement("name", item)));
                xmlDoc.Save(myXmlDb);
            }

        }

        public void importRelations(string createdFile)
        {
            foreach (string item in read.fnSelectRelations())
            {
                string myXmlDb = configfn.getDBPath(createdFile);
                XDocument xmlDoc = XDocument.Load(myXmlDb);
                xmlDoc.Element("root").Element("relations").Add(new XElement("relation", new XElement("name", item)));
                xmlDoc.Save(myXmlDb);
            }

        }

        public void importCurrentAnnuaire(String createdFile, String txtRechNom, String txtRechPrenom, String txtRechAlias, String txtRechTelephone, String cbxRechActivite, String cbxRechRelation, String txtRechDetails)
        {
            string myXmlDb = configfn.getDBPath(createdFile);
            XDocument xmlDoc = XDocument.Load(myXmlDb);
            foreach (Fiche myFiche in read.fnSelectionFiche(txtRechNom, txtRechPrenom, txtRechAlias, txtRechTelephone, cbxRechActivite, cbxRechRelation, txtRechDetails))
            {
                xmlDoc.Element("root").Element("annuaire").Add(new XElement("myFiche",
                                                                new XElement("id", read.generateId()),
                                                                new XElement("nom", myFiche.Nom),
                                                                new XElement("prenom", myFiche.Prenom),
                                                                new XElement("alias", myFiche.Alias),
                                                                new XElement("dateAnniversaire", myFiche.DateAnniversaire),
                                                                new XElement("tel1",  myFiche.Tel1),
                                                                new XElement("tel2", myFiche.Tel2),
                                                                new XElement("adresse", myFiche.Adresse),
                                                                new XElement("activite", myFiche.Activite),
                                                                new XElement("relation", myFiche.Relation),
                                                                new XElement("lienPhoto", myFiche.LienPhoto),
                                                                new XElement("details", myFiche.Detail),
                                                                new XElement("dateAnniversaire", myFiche.DateAnniversaire)));
            }
            xmlDoc.Save(myXmlDb);
        }
        #endregion
    }

    public class ReadAccess
    {
        #region Global
        ConfigFunctions configfn = new ConfigFunctions();
        #endregion

        // Generer un nouvel Id dans l'annuaire
        public string generateId() {
            Int32 id = 0;
            Int32 tmpId = 0;
            string myXmlDb = configfn.getDBPath("Annuaire");
            
            XDocument xmlDoc = XDocument.Load(myXmlDb);
            XElement collec = xmlDoc.Element("root").Element("annuaire");

            var records = from myCollec in collec.Elements("myFiche")
                          orderby (int)myCollec.Element("id")
                          select myCollec;

            foreach (var myCollection in records)
            {
                tmpId = tmpId + 1;
                if (myCollection.Element("id").Value != tmpId.ToString())
                {
                    id = tmpId;
                    break;
                }
            }
            if (id == 0) { id = tmpId + 1; }
            return id.ToString();
        }

        // Selectionner une liste de fiche en fonction des parametres de filtre
        public List<Fiche> fnSelectionFiche(String Nom, String Prenom, String Alias, String Tel, String Activite, String Relation, String Details)
        {
            List<Fiche> tabFiche = new List<Fiche>();
            string myXmlDb = configfn.getDBPath("Annuaire");
            XDocument xmlDoc = XDocument.Load(myXmlDb);
            XElement collec = xmlDoc.Element("root").Element("annuaire");

            var records = from myCollection in collec.Elements("myFiche")
                          select myCollection;

            if (Nom != string.Empty)
            {
                records = from myCollection in records
                          where myCollection.Element("nom").Value.ToLower().Contains(Nom.ToLower())
                          select myCollection;
            }

            if (Prenom != string.Empty)
            {
                records = from myCollection in records
                          where myCollection.Element("prenom").Value.ToLower().Replace("ç", "c").Replace("é", "e").Replace("è", "e").Replace("ê", "e").Replace("ë", "e").Contains(Prenom.ToLower().Replace("ç", "c").Replace("é", "e").Replace("è", "e").Replace("ê", "e").Replace("ë", "e"))
                          select myCollection;
            }

            if (Alias != string.Empty)
            {
                records = from myCollection in records
                          where myCollection.Element("alias").Value.ToLower().Replace("ç", "c").Replace("é", "e").Replace("è", "e").Replace("ê", "e").Replace("ë", "e").Contains(Alias.ToLower().Replace("ç", "c").Replace("é", "e").Replace("è", "e").Replace("ê", "e").Replace("ë", "e"))
                          select myCollection;
            }

            if (Tel != string.Empty)
            {
                records = from myCollection in records
                          where myCollection.Element("tel1").Value == Tel || myCollection.Element("tel2").Value == Tel
                          select myCollection;
            }

            if (Activite != string.Empty)
            {
                records = from myCollection in records
                          where myCollection.Element("activite").Value.ToLower().Replace("ç", "c").Replace("é", "e").Replace("è", "e").Replace("ê", "e").Replace("ë", "e").Contains(Activite.ToLower().Replace("ç", "c").Replace("é", "e").Replace("è", "e").Replace("ê", "e").Replace("ë", "e"))
                          select myCollection;
            }

            if (Relation != string.Empty)
            {
                records = from myCollection in records
                          where myCollection.Element("relation").Value.ToLower().Replace("ç", "c").Replace("é", "e").Replace("è", "e").Replace("ê", "e").Replace("ë", "e").Contains(Relation.ToLower().Replace("ç", "c").Replace("é", "e").Replace("è", "e").Replace("ê", "e").Replace("ë", "e"))
                          select myCollection;
            }

            if (Details != string.Empty)
            {
                records = from myCollection in records
                          where myCollection.Element("detail").Value.ToLower().Replace("ç", "c").Replace("é", "e").Replace("è", "e").Replace("ê", "e").Replace("ë", "e").Contains(Details.ToLower().Replace("ç", "c").Replace("é", "e").Replace("è", "e").Replace("ê", "e").Replace("ë", "e"))
                          select myCollection;
            }

            records = from myCollection in records
                      orderby myCollection.Element("prenom").Value
                      orderby myCollection.Element("nom").Value
                      select myCollection;

            foreach (var myData in records)
            {
                String var1 = myData.Element("id").Value;
                String var2 = myData.Element("nom").Value;
                String var3 = myData.Element("prenom").Value;
                String var4 = myData.Element("alias").Value;
                String var5 = myData.Element("tel1").Value;
                String var6 = myData.Element("tel2").Value;
                String var7 = myData.Element("adresse").Value;
                String var8 = myData.Element("activite").Value;
                String var9 = myData.Element("relation").Value;
                String var10 = myData.Element("lienPhoto").Value;
                String var11 = myData.Element("details").Value;
                String var12 = myData.Element("dateAnniversaire").Value;
                tabFiche.Add(new Fiche(var1, var2, var3, var4, var5, var6, var7, var8, var9, var10, var11, var12));
            }

            return tabFiche;
        }

        /// Selectionner une seule fiche en fonction de son Id
        public Fiche fnSelectionFiche(int nodeToLoad)
        {
            Fiche myFiche = new Fiche();
            string myXmlDb = configfn.getDBPath("Annuaire");
            XDocument xmlDoc = XDocument.Load(myXmlDb);
            XElement collec = xmlDoc.Element("root").Element("annuaire");

            var records = from myCollection in collec.Elements("myFiche")
                          where (int)myCollection.Element("id") == nodeToLoad
                          select myCollection;

            foreach (var myData in records)
            {
                myFiche.Id = myData.Element("id").Value;
                myFiche.Nom = myData.Element("nom").Value;
                myFiche.Prenom = myData.Element("prenom").Value;
                myFiche.Alias = myData.Element("alias").Value;
                myFiche.Tel1 = myData.Element("tel1").Value;
                myFiche.Tel2 = myData.Element("tel2").Value;
                myFiche.Adresse = myData.Element("adresse").Value;
                myFiche.Activite = myData.Element("activite").Value;
                myFiche.Relation = myData.Element("relation").Value;
                myFiche.Detail = myData.Element("details").Value;
                myFiche.DateAnniversaire = myData.Element("dateAnniversaire").Value;
            }

            return myFiche;

        }

        // compter le nombre de records classé dans une activité
        public int fnCountActivite(string act) {
            int cpt = 0;

            string myXmlDb = configfn.getDBPath("Annuaire");
            XDocument xmlDoc = XDocument.Load(myXmlDb);
            XElement collec = xmlDoc.Element("root").Element("annuaire");

            var records = from myCollection in collec.Elements("myFiche")
                          where myCollection.Element("activite").Value == act
                          select myCollection;

            foreach (var myData in records) { cpt = cpt + 1; }
            return cpt;
        }

        // compter le nombre de records placés dans une relation
        public int fnCountRelation(string rel) {
            int cpt = 0;

            string myXmlDb = configfn.getDBPath("Annuaire");
            XDocument xmlDoc = XDocument.Load(myXmlDb);
            XElement collec = xmlDoc.Element("root").Element("annuaire");

            var records = from myCollection in collec.Elements("myFiche")
                          where myCollection.Element("relation").Value == rel
                          select myCollection;

            foreach (var myData in records) { cpt = cpt + 1; }
            return cpt;
        }


        // Selectionner la liste des Activites
        public List<String> fnSelectActivites() {
            List<String> listActivite = new List<String>();
            string myXmlDb = configfn.getDBPath("Annuaire");
            XDocument xmlDoc = XDocument.Load(myXmlDb);
            XElement collec = xmlDoc.Element("root").Element("activites");

            var records = from myCollection in collec.Elements("activite")
                          orderby myCollection.Element("name").Value
                          select myCollection;

            foreach (var myData in records)
            {
                listActivite.Add(myData.Element("name").Value);
            }
            
            return listActivite;
        }
        
        // Selectionner la liste des Activites
        public List<String> fnSelectRelations()
        {
            List<String> listActivite = new List<String>();
            string myXmlDb = configfn.getDBPath("Annuaire");
            XDocument xmlDoc = XDocument.Load(myXmlDb);
            XElement collec = xmlDoc.Element("root").Element("relations");

            var records = from myCollection in collec.Elements("relation")
                          orderby myCollection.Element("name").Value
                          select myCollection;

            foreach (var myData in records)
            {
                listActivite.Add(myData.Element("name").Value);
            }

            return listActivite;
        }


    }

    public class Check
    {
        #region Global
        ConfigFunctions configfn = new ConfigFunctions();
        GlobalFunctions globalfn = new GlobalFunctions();
        #endregion

        #region check fichiers
        public void setup()
        {
            string folderToCheck = globalfn.AppRootPath() + "Annuaires/";
            if (!System.IO.Directory.Exists(folderToCheck ))
            {
                System.IO.Directory.CreateDirectory(folderToCheck);  
            }
            checkFolder(folderToCheck + "Configuration/");
            setupConfigurationFile(folderToCheck + "Configuration/AppConfig.xml");

            checkFolder(folderToCheck + "BasesDeDonnees/");
            setupDefaultDbFile(folderToCheck + "BasesDeDonnees/" + configfn.currentAnnuaire());
        }

        public void checkFolder(string configFolder) {
            if (!System.IO.Directory.Exists(configFolder)){
                System.IO.Directory.CreateDirectory(configFolder);
            }
            
        }

        public void setupConfigurationFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                StreamWriter writer = new StreamWriter(fileName);  
                writer.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                writer.WriteLine("<root>");
                writer.WriteLine("<couleurApp>");
                writer.WriteLine("<couleurSelectionnee>Standard</couleurSelectionnee>");
                writer.WriteLine("</couleurApp>");
                writer.WriteLine("<fichiers>");
                writer.WriteLine("<annuaire>myXmlDb.xml</annuaire>");
                writer.WriteLine("</fichiers>");
                writer.WriteLine("</root>");
                writer.Close();
            }
        }

        public void setupDefaultDbFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                StreamWriter writer = new StreamWriter(fileName);
                writer.WriteLine("<root>");
                writer.WriteLine("<activites>");
                writer.WriteLine("</activites>");
                writer.WriteLine("<relations>");
                writer.WriteLine("</relations>");
                writer.WriteLine("<annuaire>");
                writer.WriteLine("</annuaire>");
                writer.WriteLine("</root>");
                writer.Close();
            }
        }

        #endregion

        #region check database
        // Verifie que le bloc Activites est bien formaté
        public bool checkActivite(bool isFileWellFormatted)
        {
            if (isFileWellFormatted)
            {
                try
                {
                    string useless;
                    string myXmlDb = configfn.getDBPath("Annuaire");
                    XDocument xmlDoc = XDocument.Load(myXmlDb);
                    XElement collec = xmlDoc.Element("root").Element("activites");

                    var records = from myCollection in collec.Elements("activite")
                                  select myCollection;

                    foreach (var myData in records) { useless = myData.Element("name").Value; }
                }
                catch
                {
                    isFileWellFormatted = false;
                }
            }
            return isFileWellFormatted;
        }

        public bool checkRelations(bool isFileWellFormatted)
        {
            if (isFileWellFormatted)
            {
                try
                {
                    string useless;
                    string myXmlDb = configfn.getDBPath("Annuaire");
                    XDocument xmlDoc = XDocument.Load(myXmlDb);
                    XElement collec = xmlDoc.Element("root").Element("relations");

                    var records = from myCollection in collec.Elements("relation")
                                  select myCollection;

                    foreach (var myData in records) { useless = myData.Element("name").Value; }
                }
                catch
                {
                    isFileWellFormatted = false;
                }
            }
            return isFileWellFormatted;
        }

        public bool checkAnnuaire(bool isFileWellFormatted)
        {
            if (isFileWellFormatted)
            {
                try
                {
                    string useless;
                    string myXmlDb = configfn.getDBPath("Annuaire");
                    XDocument xmlDoc = XDocument.Load(myXmlDb);
                    XElement collec = xmlDoc.Element("root").Element("annuaire");

                    var records = from myCollection in collec.Elements("myFiche")
                                  select myCollection;

                    foreach (var myData in records) { 
                        useless = myData.Element("id").Value; 
                        useless = myData.Element("nom").Value; 
                        useless = myData.Element("prenom").Value; 
                        useless = myData.Element("alias").Value; 
                        useless = myData.Element("tel1").Value; 
                        useless = myData.Element("tel2").Value; 
                        useless = myData.Element("adresse").Value; 
                        useless = myData.Element("activite").Value; 
                        useless = myData.Element("relation").Value; 
                        useless = myData.Element("lienPhoto").Value; 
                        useless = myData.Element("details").Value;
                        useless = myData.Element("dateAnniversaire").Value; 
                    }
                }
                catch
                {
                    isFileWellFormatted = false;
                }
            }
            return isFileWellFormatted;
        }
        #endregion
    }
}

