using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASMaIoP.Client.Models.Utilities
{
    internal class Strings
    {
        static public string cyr2lat(char ch)
        {
            switch (ch)
            {
                case 'А': return "A";
                case 'Б': return "B";
                case 'В': return "V";
                case 'Г': return "G";
                case 'Д': return "D";
                case 'Е': return "E";
                case 'Ё': return "JE";
                case 'Ж': return "ZH";
                case 'З': return "Z";
                case 'И': return "I";
                case 'Й': return "Y";
                case 'К': return "K";
                case 'Л': return "L";
                case 'М': return "M";
                case 'Н': return "N";
                case 'О': return "O";
                case 'П': return "P";
                case 'Р': return "R";
                case 'С': return "S";
                case 'Т': return "T";
                case 'У': return "U";
                case 'Ф': return "F";
                case 'Х': return "KH";
                case 'Ц': return "C";
                case 'Ч': return "CH";
                case 'Ш': return "SH";
                case 'Щ': return "JSH";
                case 'Ъ': return "HH";
                case 'Ы': return "IH";
                case 'Ь': return "JH";
                case 'Э': return "EH";
                case 'Ю': return "JU";
                case 'Я': return "JA";
                default:
                    return $"{ch}";
            }
        }

        public static string cyr2lat(string s)
        {
            string NewString = "";
            foreach(char c in s)
            {
                string Str = cyr2lat(c);
               NewString += Str;
            }
            return NewString;
        }
    }
}
