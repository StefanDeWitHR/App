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
        public static Organisations Organisation = Organisations.PropertyNL;

        public static string Logo = LogoHelper();
        public static string Menu = MenuHelper();
        public static string Color = ColorHelper();
        public static string ArrowNavRight = ArrowNavigationRightImgHelper();
        public static string ArrowNavLeft = ArrowNavigationLeftImgHelper();
        public static string BackButton = BackButtonHelper();


        // Helpers
        public static string Language = (Organisation == Organisations.PropertyEU) ? "EN" : "NL";

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
