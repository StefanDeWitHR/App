using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Translate
    {
        //Homepage
        public static string lblReadMore = (Settings.Language == "NL") ? "> Lees verder" : " > Read more";

        // Menu items
        public static string lblHomepage = (Settings.Language == "NL") ? "Homepagina" : "Homepage";
        public static string lblNewsArticles = (Settings.Language == "NL") ? "Nieuwsartikelen" : "Newsarticles";
        public static string lblAboutUs = (Settings.Language == "NL") ? "Over ons" : "About us";
        public static string lblRequestTrial = (Settings.Language == "NL") ? "Proeflidmaatschap aanvragen" : "Request a trial";
        public static string lblLogin = (Settings.Language == "NL") ? "Inloggen" : "Log in";
        public static string lblLogOff = (Settings.Language == "NL") ? "Uitloggen" : "Log out";

        // Menu header
        public static string lblLoggedInAs = (Settings.Language == "NL") ? "Inloggen als: " : "Logged in as: ";

        // Trial page
        public static string lblFemale = (Settings.Language == "NL") ? "Vrouw" : "Female";
        public static string lblMale = (Settings.Language == "NL") ? "Man" : "Vrouw";
        public static string lblFirstName = (Settings.Language == "NL") ? "Voornaam" : "First name";
        public static string lblSecondName = (Settings.Language == "NL") ? "Tussenvoegsel" : "Second name";
        public static string lblLastName = (Settings.Language == "NL") ? "Achternaam" : "Last name";
        public static string lblCompanyName = (Settings.Language == "NL") ? "Bedrijfsnaam" : "Company name";
        public static string lblPhoneNum = (Settings.Language == "NL") ? "Telefoonnummer" : "Phone number";
        public static string lblToRequest = (Settings.Language == "NL") ? "Aanvragen" : "Request";

        //Contact us page
        public static string lblVisitingAdres = (Settings.Language == "NL") ? "Bezoekadres" : "Address";
        public static string lblGeneral = (Settings.Language == "NL") ? "Algemeen" : "General";

        //Login page
        public static string lblUsername = (Settings.Language == "NL") ? "Gebruikersnaam" : "Username";
        public static string lblPassword = (Settings.Language == "NL") ? "Wachtwoord" : "Password";

        // Search filter
        public static string lblSearch = (Settings.Language == "NL") ? "Zoeken" : "Search";
        public static string lblCategory = (Settings.Language == "NL") ? "Categorie" : "Category";

        // More info newsarticle
        public static string lblViews = (Settings.Language == "NL") ? "Bekeken" : "Views";
        public static string lblShare = (Settings.Language == "NL") ? "Deel dit artikel" : "Share this article";
        public static string lblPlacedBy = (Settings.Language == "NL") ? "Geplaats door: " : "Placed by:";
        public static string lblProfile = (Settings.Language == "NL") ? "Profiel " : "Profile";
        
    }
}
