using System.Globalization;

namespace SchoolManagment.Data.Common
{
    public class GenerateLocalizableEntity
    {

        public string Localize(string textAr, string textEn)
        {
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;
            if (culture.TwoLetterISOLanguageName.ToLower() == "ar")
                return textAr;

            return textEn;
        }
    }

}
