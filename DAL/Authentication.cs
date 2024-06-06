using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class Authentication
    {
        public static string DecryptLicenseKey(string cipherText,string GetType)
        {
            string PlainText = "";
            try
            {
                string LicenseValidity = "";
                string SchoolName = "";
                string LicenseType = "";
                Dictionary<char, string> passPhrase = new Dictionary<char, string>();

                passPhrase.Add('q', "a"); passPhrase.Add('t', "b"); passPhrase.Add('p', "c"); passPhrase.Add('o', "d");
                passPhrase.Add('u', "e"); passPhrase.Add('r', "f"); passPhrase.Add('s', "g"); passPhrase.Add('w', "h");
                passPhrase.Add('g', "i"); passPhrase.Add('h', "j"); passPhrase.Add('i', "k"); passPhrase.Add('x', "l");
                passPhrase.Add('j', "m"); passPhrase.Add('k', "n"); passPhrase.Add('v', "o"); passPhrase.Add('y', "p");
                passPhrase.Add('f', "q"); passPhrase.Add('e', "r"); passPhrase.Add('d', "s"); passPhrase.Add('c', "t");
                passPhrase.Add('b', "u"); passPhrase.Add('a', "v"); passPhrase.Add('m', "w"); passPhrase.Add('n', "x");
                passPhrase.Add('z', "y"); passPhrase.Add('l', "z");

                Dictionary<string, char> specialPhrase = new Dictionary<string, char>();
                specialPhrase.Add("xxz", '0');
                specialPhrase.Add("xxy", '1');
                specialPhrase.Add("xxx", '2');
                specialPhrase.Add("xxw", '3');
                specialPhrase.Add("xxv", '4');
                specialPhrase.Add("xxu", '5');
                specialPhrase.Add("xxt", '6');
                specialPhrase.Add("xxs", '7');
                specialPhrase.Add("xxr", '8');
                specialPhrase.Add("xxq", '9');

                string[] CipherParts = cipherText.ToLower().Split(new string[] { "axzqugaxz" }, StringSplitOptions.None);

                if (CipherParts.Length != 4)
                    return "Invalid License key_failure";

                for (int i = 0; i < CipherParts[0].Length; i += 3)
                {
                    LicenseValidity += specialPhrase[CipherParts[0].Substring(i, 3)];
                }
                LicenseValidity += "-";
                for (int i = 0; i < CipherParts[1].Length; i += 3)
                {
                    LicenseValidity += specialPhrase[CipherParts[1].Substring(i, 3)];
                }

                foreach (char c in CipherParts[2])
                {
                    SchoolName += passPhrase[c];
                }
                foreach (char c in CipherParts[3])
                {
                    LicenseType += passPhrase[c];
                }
                
                switch (GetType)
                {
                    case "LicenseType":
                        PlainText = LicenseType.ToUpper();
                        break;
                    case "LicenseValidity":
                        PlainText = LicenseValidity;
                        break;
                    case "SchoolName":
                        PlainText = SchoolName;
                        break;
                    default:
                        PlainText = "";
                        break;
                }   
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
            }
            return PlainText;
        }
        public static bool IsLicenseKeyValid(string cipherText) 
        {
            try
            {
                string[] CipherParts = cipherText.ToLower().Split(new string[] { "axzqugaxz" }, StringSplitOptions.None);

                if (CipherParts.Length != 4)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return false;
            }
        }
        public static string DecryptActivationKey(string cipherText)
        {
            try
            {
                string initialPlain = "";
                string finalPlain = "";

                Dictionary<char, char> passPhrase = new Dictionary<char, char>();
                passPhrase.Add('q', 'a'); passPhrase.Add('t', 'b'); passPhrase.Add('p', 'c'); passPhrase.Add('o', 'd');
                passPhrase.Add('u', 'e'); passPhrase.Add('r', 'f'); passPhrase.Add('s', 'g'); passPhrase.Add('w', 'h');
                passPhrase.Add('g', 'i'); passPhrase.Add('h', 'j'); passPhrase.Add('i', 'k'); passPhrase.Add('x', 'l');
                passPhrase.Add('j', 'm'); passPhrase.Add('k', 'n'); passPhrase.Add('v', 'o'); passPhrase.Add('y', 'p');
                passPhrase.Add('f', 'q'); passPhrase.Add('e', 'r'); passPhrase.Add('d', 's'); passPhrase.Add('c', 't');
                passPhrase.Add('b', 'u'); passPhrase.Add('a', 'v'); passPhrase.Add('m', 'w'); passPhrase.Add('n', 'x');
                passPhrase.Add('z', 'y'); passPhrase.Add('l', 'z');


                foreach (char chr in cipherText.ToLower())
                {
                    initialPlain += passPhrase[chr];
                }
                foreach (char chr in initialPlain)
                {
                    finalPlain += passPhrase[chr];
                }
                return finalPlain;
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return string.Empty;
            }
        }
        public static string ManipulateString(string initialString)
        {
            try
            {
                string finalString = "";
                finalString = initialString.Replace(" ", "");
                finalString = System.Text.RegularExpressions.Regex.Replace(finalString, "[0-9]", "");  //remove Numbers
                finalString = System.Text.RegularExpressions.Regex.Replace(finalString, "[^a-zA-Z0-9]", ""); //remove Spactial characters

                finalString = finalString.Substring(0, Math.Min(finalString.Length, 16)); //Only get 16 character from string 

                return finalString.ToLower();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return string.Empty;
            }
        }
        public static bool IsProductActive()
        {
            try
            {
                if (new SchoolInfoRepository().GetSschoolInfo().ActivationKey == null)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return false;
            }
        }
    }
}
