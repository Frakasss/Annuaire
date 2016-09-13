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
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Annuaire());


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

        //contructeur
        public Fiche() { }

        public Fiche(String paramId, String paramNom, String paramPrenom, String paramAlias, 
                     String paramTel1, String paramTel2, String paramAdresse, String paramActivite, 
                     String paramRelation, String paramLienPhoto, String paramDetail)
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
        }
    }

    public class GlobalFunctions
    {
        /// <summary>
        /// Retourne le chemin, depuis la racine, de l'application
        /// </summary>
        /// <returns></returns>
        public string AppDrive()
        {
            return (AppDomain.CurrentDomain.BaseDirectory).Substring(0, 3).Replace("\\", "/");
        }
        
        /// <summary>
        /// Retourne le chemin, depuis la racine, de l'application
        /// </summary>
        /// <returns></returns>
        public string AppRootPath()
        {
            return (AppDomain.CurrentDomain.BaseDirectory).Replace("\\", "/");
        }

    }

    public class FunctionFiches
    {
        GlobalFunctions gfctn = new GlobalFunctions();

        #region CRUD
        /// <summary>
        /// Creation d'une nouvelle fiche
        /// </summary>
        /// <param name="Cassette"></param>
        /// <param name="Date"></param>
        /// <param name="Theme"></param>
        /// <param name="SousTheme"></param>
        /// <param name="Personne"></param>
        /// <param name="Description"></param>
        /// <param name="LienVideo"></param>
        /// <param name="TempsDebutSequence"></param>
        public void fnCreationFiche(String Nom, String Prenom, String Alias, String Tel1, String Tel2, String Adresse, String Activite, String Relation, String LienPhoto, String Details)
        {

            Int32 id = 0;
            Int32 tmpId = 0;
            //### calcul de l'Id ###
            XDocument xmlDoc = XDocument.Load(gfctn.AppRootPath() + "MyDB/MyXmlDB.xml");
            XElement collec = xmlDoc.Element("root");

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


            //### enregistrement fiche ###
            xmlDoc.Element("root").Add(new XElement("myFiche",
                                        new XElement("id", id.ToString()),
                                        new XElement("nom", Nom),
                                        new XElement("prenom", Prenom),
                                        new XElement("alias", Alias),
                                        new XElement("tel1", Tel1),
                                        new XElement("tel2", Tel2),
                                        new XElement("adresse", Adresse),
                                        new XElement("activite", Activite),
                                        new XElement("relation", Relation),
                                        new XElement("lienPhoto", LienPhoto),
                                        new XElement("details", Details)));

            xmlDoc.Save(gfctn.AppRootPath() + "MyDB/MyXmlDB.xml");
        }

        /// <summary>
        /// Modification d'une fiche existante
        /// </summary>
        /// <param name="nodeToUpdate"></param>
        /// <param name="Cassette"></param>
        /// <param name="Date"></param>
        /// <param name="Theme"></param>
        /// <param name="SousTheme"></param>
        /// <param name="Personne"></param>
        /// <param name="Description"></param>
        /// <param name="LienVideo"></param>
        /// <param name="TempsDebutSequence"></param>
        public void fnModificationFiche(Int32 nodeToUpdate, String Nom, String Prenom, String Alias, String Tel1, String Tel2, String Adresse, String Activite, String Relation, String LienPhoto, String Details)
        {
            XDocument xmlDoc = XDocument.Load(gfctn.AppRootPath() + "MyDB/MyXmlDB.xml");
            XElement collec = xmlDoc.Element("root");

            var records = from myCollection in collec.Elements("myFiche")
                            where (int)myCollection.Element("id") == nodeToUpdate
                            select myCollection;

            //Remove record
            records.Remove();

            //Insert Record
            xmlDoc.Element("root").Add(new XElement("myFiche",
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
                        new XElement("details", Details)));

            xmlDoc.Save(gfctn.AppRootPath() + "MyDB/MyXmlDB.xml");
        }

        /// <summary>
        /// Suppression d'une fiche
        /// </summary>
        /// <param name="nodeToDelete"></param>
        public void fnSuppressionFiche(int nodeToDelete)
        {
            XDocument xmlDoc = XDocument.Load(gfctn.AppRootPath() + "MyDB/MyXmlDB.xml");
            XElement collec = xmlDoc.Element("root");

            var records = from myCollection in collec.Elements("myFiche")
                            where (int)myCollection.Element("id") == nodeToDelete
                            select myCollection;

            //Remove record
            records.Remove();

            xmlDoc.Save(gfctn.AppRootPath() + "MyDB/MyXmlDB.xml");
        }
        #endregion

        #region Selection
        ///<summary>
        /// Selectionner une liste de fiche en fonction des parametres de filtre
        /// </summary>
        /// <returns></returns>
        public List<Fiche> fnSelection(String Nom, String Prenom, String Alias, String Tel, String Activite, String Relation, String Details)
        {
            List<Fiche> tabFiche = new List<Fiche>();
            XDocument xmlDoc = XDocument.Load(gfctn.AppRootPath() + "MyDB/MyXmlDB.xml");
            XElement collec = xmlDoc.Element("root");

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
                tabFiche.Add(new Fiche(var1, var2, var3, var4, var5, var6, var7, var8, var9, var10, var11));
            }

            return tabFiche;
        }

        /// <summary>
        /// Selectionner une seule fiche en fonction de son Id
        /// </summary>
        /// <param name="nodeToLoad"></param>
        /// <returns></returns>
        public Fiche fnSelection(int nodeToLoad)
        {
            Fiche myFiche = new Fiche();
            XDocument xmlDoc = XDocument.Load(gfctn.AppRootPath() + "MyDB/MyXmlDB.xml");
            XElement collec = xmlDoc.Element("root");

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
            }

            return myFiche;

        }
        #endregion
    }
}

