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
                case 'а': return "а";
                case 'Б': return "B";
                case 'б': return "b";
                case 'В': return "V";
                case 'в': return "v";
                case 'Г': return "G";
                case 'г': return "g";
                case 'Д': return "D";
                case 'д': return "d";
                case 'Е': return "E";
                case 'е': return "e";
                case 'Ё': return "JE";
                case 'ё': return "je";
                case 'Ж': return "ZH";
                case 'ж': return "zh";
                case 'З': return "Z";
                case 'з': return "z";
                case 'И': return "I";
                case 'и': return "i";
                case 'Й': return "Y";
                case 'й': return "y";
                case 'К': return "K";
                case 'к': return "k";
                case 'Л': return "L";
                case 'л': return "l";
                case 'М': return "M";
                case 'м': return "m";
                case 'Н': return "N";
                case 'н': return "n";
                case 'О': return "O";
                case 'о': return "o";
                case 'П': return "P";
                case 'п': return "p";
                case 'Р': return "R";
                case 'р': return "r";
                case 'С': return "S";
                case 'с': return "s";
                case 'Т': return "T";
                case 'т': return "t";
                case 'У': return "U";
                case 'у': return "u";
                case 'Ф': return "F";
                case 'ф': return "f";
                case 'Х': return "KH";
                case 'х': return "kh";
                case 'Ц': return "C";
                case 'ц': return "c";
                case 'Ч': return "CH";
                case 'ч': return "ch";
                case 'Ш': return "SH";
                case 'ш': return "sh";
                case 'Щ': return "JSH";
                case 'щ': return "jsh";
                case 'Ъ': return "HH";
                case 'ъ': return "hh";
                case 'Ы': return "IH";
                case 'ы': return "ih";
                case 'Ь': return "JH";
                case 'ь': return "jh";
                case 'Э': return "EH";
                case 'э': return "eh";
                case 'Ю': return "JU";
                case 'ю': return "ju";
                case 'Я': return "JA";
                case 'я': return "ja";
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
