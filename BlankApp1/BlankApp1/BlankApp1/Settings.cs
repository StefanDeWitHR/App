using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public enum Organisations{
        Ventu,
        PropertyNL,
        PropertyEU
    }

    public static class Settings
    {
        // The only setting that is required to switch content
        public static Organisations Organisation = Organisations.PropertyEU;

        public static string Logo = LogoHelper();
        public static string Menu = MenuHelper();
        public static string Color = ColorHelper();
        public static string ArrowNavRight = ArrowNavigationRightImgHelper();
        public static string ArrowNavLeft = ArrowNavigationLeftImgHelper();
        public static string BackButton = BackButtonHelper();
        public static string SocialMediaFB = SocialMediaFBHelper();
        public static string SocialMediaMail = SocialMediaMailHelper();
        public static string SocialMediaPhone= SocialMediaPhoneHelper();

        //******************* Helpers *********************************//

        // Language
        public static string Language = (Organisation == Organisations.PropertyEU) ? "EN" : "NL";

        // Social media
        public static string SocialMediaPhoneHelper()
        {
            string url = "";
            if (Organisation == Organisations.PropertyEU)
            {
                url = " +31(0)88 776 73 78";

            }
            else if (Organisation == Organisations.PropertyNL)
            {
                url = "+31(0)88 776 73 78";
            }
            else if (Organisation == Organisations.Ventu)
            {
                url = "+31(0)88 776 73 78";
            }
            return url;
        }

        public static string SocialMediaFBHelper()
        {
            string url = "";
            if (Organisation == Organisations.PropertyEU)
            {
                url = "387348521312268";

            }
            else if (Organisation == Organisations.PropertyNL)
            {
                url = "943580452350442";
            }
            else if (Organisation == Organisations.Ventu)
            {
                url = "";
            }
            return url;
        }

        public static string SocialMediaMailHelper()
        {
            string url = "";
            if (Organisation == Organisations.PropertyEU)
            {
                url = "mailto:editor@propertyeu.info";

            }
            else if (Organisation == Organisations.PropertyNL)
            {
                url = "mailto:redactie@propertynl.com";
            }
            else if (Organisation == Organisations.Ventu)
            {
                url = "mailto:service@ventu.nl";
            }
            return url;
        }
        // Design
        public static string LogoHelper()
        {
            string logo = "";
            if (Organisation == Organisations.PropertyEU)
            {
                logo = "logo_EU.png";

            }
            else if (Organisation == Organisations.PropertyNL)
            {
                logo = "logo_NL.png";
            }
            else if (Organisation == Organisations.Ventu)
            {
                logo = "logo_Ventu.png";
            }
            return logo;
        }

        public static string MenuHelper()
        {
            string menu = "";
            if (Organisation == Organisations.PropertyEU)
            {
                menu = "menu_EU.png";

            }
            else if (Organisation == Organisations.PropertyNL)
            {
                menu = "menu_NL.png";
            }
            else if (Organisation == Organisations.Ventu)
            {
                menu = "menu_Ventu.png";
            }
            return menu;
        }

        public static string ColorHelper()
        {
            string color = "";
            if (Organisation == Organisations.PropertyEU)
            {
                color = "#005a84";

            }
            else if (Organisation == Organisations.PropertyNL)
            {
                color = "#e20413";
            }
            else if (Organisation == Organisations.Ventu)
            {
                color = ""; // not implemented yet
            }
            return color;
        }

        public static string ArrowNavigationRightImgHelper()
        {
            string img = "";
            if (Organisation == Organisations.PropertyEU)
            {
                img = "right_arrow_EU.png";

            }
            else if (Organisation == Organisations.PropertyNL)
            {
                img = "right_arrow_NL.png";
            }
            else if (Organisation == Organisations.Ventu)
            {
                img = ""; // not implemented yet
            }
            return img;
        }

        public static string ArrowNavigationLeftImgHelper()
        {
            string img = "";
            if (Organisation == Organisations.PropertyEU)
            {
                img = "left_arrow_EU.png";

            }
            else if (Organisation == Organisations.PropertyNL)
            {
                img = "left_arrow_NL.png";
            }
            else if (Organisation == Organisations.Ventu)
            {
                img = ""; // not implemented yet
            }
            return img;
        }

        public static string BackButtonHelper()
        {
            string img = "";
            if (Organisation == Organisations.PropertyEU)
            {
                img = "navigate_back_EU.png";

            }
            else if (Organisation == Organisations.PropertyNL)
            {
                img = "navigate_back_NL.png";
            }
            else if (Organisation == Organisations.Ventu)
            {
                img = ""; // not implemented yet
            }
            return img;
        }
    }
}
