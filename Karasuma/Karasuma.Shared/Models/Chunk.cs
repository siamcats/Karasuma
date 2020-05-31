using Karasuma.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using Uno.Extensions;
using Uno.Extensions.Specialized;
using Windows.ApplicationModel.Store.Preview.InstallControl;
using Windows.Gaming.Input;
using Windows.System;
using Windows.UI.Text.Core;

namespace Karasuma
{

    public class Chunk
    {
        /// <summary>
        /// んた
        /// </summary>
        public string Kana { get; }


        /// <summary>
        /// nnta
        /// xnta
        /// nta
        /// </summary>
        public List<string> LettersListAll
        {
            get { return lettersListAll; }
        }
        private List<string> lettersListAll;

        /// <summary>
        /// nta
        /// nnta
        /// </summary>
        public List<string> LettersListAvailable
        {
            get
            {
                if (TypedLetters == string.Empty) return lettersListAll;
                return LettersListAll.Where(s => s.StartsWith(TypedLetters)).ToList();
            }
        }

        /// <summary>
        /// nta
        /// </summary>
        public string Letters
        {
            get
            {
                if (LettersListAvailable.Count == 0) return string.Empty;
                return LettersListAvailable.OrderBy(s => s.Length).First();
            }
        }

        /// <summary>
        /// n
        /// </summary>
        public string TypedLetters
        {
            get
            {
                return typedLetters;
            }
        }
        private string typedLetters = "";

        public bool IsTyped
        {
            get
            {
                if(LettersListAvailable.Any(s => s == typedLetters)) return true;
                return false;
            }
        }

        public bool Type(string typedLetter)
        {
            if (LettersListAvailable.Any(s => s.StartsWith(typedLetters + typedLetter)))
            {
                typedLetters = typedLetters + typedLetter;
                return true;
            }
            return false;
        }

        public Chunk(string kana, bool isSokuon)
        {
            Kana = kana;
            var charArray = kana.ToCharArray();
            var charList = new List<char>(charArray);
            var strList = charList.Select(c => c.ToString()).ToList();

            var letters = new List<string>();

            //1文字ずつのパターン
            var letterList = new List<string[]>();
            for (int i = 0; i < strList.Count; i++)
            {
                var result = new string[] { };
                KanaUtils.Henkan.TryGetValue(strList[i], out result);
                letterList.Add(result);
            }

            List<string[]> resultList = Combinations<string>.GetCombinations(letterList);
            foreach (var item in resultList)
            {
                letters.Add(String.Join("", item));
            }

            if (kana.Length == 2)
            {
                //促音チャンクの場合は先頭文字とそれ以外を分離
                if (isSokuon)
                {
                    if (kana[0] == 'ん')
                    {
                        if (KanaUtils.Henkan.ContainsKey(kana[1].ToString()))
                        {
                            var result = KanaUtils.Henkan[kana[1].ToString()];
                            foreach (var item in result)
                            {
                                if (item[0] != 'n')
                                {
                                    letters.Add("n" + item);
                                }
                            }
                        }
                    }
                    else if(kana[0] == 'っ')
                    {
                        if (KanaUtils.Henkan.ContainsKey(kana[1].ToString()))
                        {
                            var result = KanaUtils.Henkan[kana[1].ToString()];
                            foreach (var item in result)
                            {
                                letters.Add(item[0] + item);
                            }
                        }
                    }
                }
                else
                {
                    if (KanaUtils.Henkan.ContainsKey(kana))
                    {
                        var result = KanaUtils.Henkan[kana];
                        foreach (var item in result)
                        {
                            letters.Add(item);
                        }
                    }
                }
            }

            if (kana.Length == 3)
            {
                var str = kana.Substring(1);

                if (kana[0] == 'ん')
                {
                    if (KanaUtils.Henkan.ContainsKey(str))
                    {
                        var result = KanaUtils.Henkan[str];
                        foreach (var item in result)
                        {
                            if (item[0] != 'n')
                            {
                                letters.Add("n" + item);
                            }
                            var result2 = KanaUtils.Henkan["ん"];
                            foreach (var item2 in result2)
                            {
                                letters.Add(item2 + item);
                            }
                        }
                    }

                    //1文字ずつのパターン
                    letterList.RemoveAt(0);
                    foreach (var item in Combinations<string>.GetCombinations(letterList))
                    {
                        if (item[0][0] != 'n')
                        {
                            letters.Add("n" + String.Join("", item));
                        }
                    }
                }
                else if (kana[0] == 'っ')
                {
                    if (KanaUtils.Henkan.ContainsKey(str))
                    {
                        var result = KanaUtils.Henkan[str];
                        foreach (var item in result)
                        {
                            letters.Add(item[0] + item);
                        }
                    }

                    //1文字ずつのパターン
                    letterList.RemoveAt(0);
                    foreach (var item in Combinations<string>.GetCombinations(letterList))
                    {
                        letters.Add(item[0][0] + String.Join("", item));
                    }
                }
            }

            lettersListAll = letters;
        }
    }

    public static class KanaUtils
    {
        static KanaUtils()
        {

            Sokuon = new string[]
            {
                "ん","っ"
            };

            Henkan = new Dictionary<string, string[]>
            {
                {"ぁ", new string[]{ "xa","la" } },
                {"あ", new string[]{ "a" } },
                {"ぃ", new string[]{ "xi","li","xyi","lyi" } },
                {"い", new string[]{ "i","yi" } },
                {"いぇ", new string[]{ "ye" } },
                {"ぅ", new string[]{ "xu","lu" } },
                {"う", new string[]{ "u","whu","wu" } },
                {"うぁ", new string[]{ "wha" } },
                {"うぃ", new string[]{ "whi","wi" } },
                {"うぇ", new string[]{ "whe" } },
                {"うぉ", new string[]{ "who" } },
                {"ぇ", new string[]{ "xe","le","xye","lye" } },
                {"え", new string[]{ "e" } },
                {"ぉ", new string[]{ "xo","lo" } },
                {"お", new string[]{ "o" } },
                {"か", new string[]{ "ka","ca" } },
                {"が", new string[]{ "ga" } },
                {"き", new string[]{ "ki" } },
                {"きぃ", new string[]{ "kyi" } },
                {"きぇ", new string[]{ "kye" } },
                {"きゃ", new string[]{ "kya" } },
                {"きゅ", new string[]{ "kyu" } },
                {"きょ", new string[]{ "kyo" } },
                {"ぎ", new string[]{ "gi" } },
                {"ぎぃ", new string[]{ "gyi" } },
                {"ぎぇ", new string[]{ "gye" } },
                {"ぎゃ", new string[]{ "gya" } },
                {"ぎゅ", new string[]{ "gyu" } },
                {"ぎょ", new string[]{ "gyo" } },
                {"く", new string[]{ "ku","cu","qu" } },
                {"くぁ", new string[]{ "kwa","qa","qwa" } },
                {"くぃ", new string[]{ "qi","qwi","qyi" } },
                {"くぅ", new string[]{ "qwu" } },
                {"くぇ", new string[]{ "qe","qwe","qye" } },
                {"くぉ", new string[]{ "qo","qwo" } },
                {"くゃ", new string[]{ "qya" } },
                {"くゅ", new string[]{ "qyu" } },
                {"くょ", new string[]{ "qyo" } },
                {"ぐ", new string[]{ "gu" } },
                {"ぐぁ", new string[]{ "gwa" } },
                {"ぐぃ", new string[]{ "gwi" } },
                {"ぐぅ", new string[]{ "gwu" } },
                {"ぐぇ", new string[]{ "gwe" } },
                {"ぐぉ", new string[]{ "gwo" } },
                {"け", new string[]{ "ke" } },
                {"げ", new string[]{ "ge" } },
                {"こ", new string[]{ "ko","co" } },
                {"ご", new string[]{ "go" } },
                {"さ", new string[]{ "sa" } },
                {"ざ", new string[]{ "za" } },
                {"し", new string[]{ "si","shi","ci" } },
                {"しぃ", new string[]{ "syi" } },
                {"しぇ", new string[]{ "she","sye" } },
                {"しゃ", new string[]{ "sha","sya" } },
                {"しゅ", new string[]{ "shu","syu" } },
                {"しょ", new string[]{ "sho","syo" } },
                {"じ", new string[]{ "ji","zi" } },
                {"じぃ", new string[]{ "jyi","zyi" } },
                {"じぇ", new string[]{ "jye", "zye" } },
                {"じゃ", new string[]{ "ja","jya","zya" } },
                {"じゅ", new string[]{ "ju","jya","zyu" } },
                {"じょ", new string[]{ "jo","jyo","zyo" } },
                {"す", new string[]{ "su" } },
                {"すぁ", new string[]{ "swa" } },
                {"すぃ", new string[]{ "swi" } },
                {"すぅ", new string[]{ "swu" } },
                {"すぇ", new string[]{ "swe" } },
                {"すぉ", new string[]{ "swo" } },
                {"ず", new string[]{ "zu" } },
                {"せ", new string[]{ "se","ce" } },
                {"ぜ", new string[]{ "ze" } },
                {"そ", new string[]{ "so" } },
                {"ぞ", new string[]{ "zo" } },
                {"た", new string[]{ "ta" } },
                {"だ", new string[]{ "da" } },
                {"ち", new string[]{ "chi","ti" } },
                {"ちぃ", new string[]{ "cyi","tyi" } },
                {"ちぇ", new string[]{ "che","cye","tye" } },
                {"ちゃ", new string[]{ "cha","cya","tya" } },
                {"ちゅ", new string[]{ "chu","cyu","tyu" } },
                {"ちょ", new string[]{ "cho","cyo","tyo" } },
                {"ぢ", new string[]{ "di" } },
                {"ぢぃ", new string[]{ "dyi" } },
                {"ぢぇ", new string[]{ "dye" } },
                {"ぢゃ", new string[]{ "dya" } },
                {"ぢゅ", new string[]{ "dyu" } },
                {"ぢょ", new string[]{ "dyo" } },
                {"っ", new string[]{ "xtu","xtsu","ltu","ltsu" } },
                {"つ", new string[]{ "tu","tsu" } },
                {"つぁ", new string[]{ "tsa" } },
                {"つぃ", new string[]{ "tsi" } },
                {"つぇ", new string[]{ "tse" } },
                {"つぉ", new string[]{ "tso" } },
                {"づ", new string[]{ "du" } },
                {"て", new string[]{ "te" } },
                {"てぃ", new string[]{ "thi" } },
                {"てぇ", new string[]{ "the" } },
                {"てゃ", new string[]{ "tha" } },
                {"てゅ", new string[]{ "thu" } },
                {"てょ", new string[]{ "tho" } },
                {"で", new string[]{ "de" } },
                {"でぃ", new string[]{ "dhi" } },
                {"でぇ", new string[]{ "dhe" } },
                {"でゃ", new string[]{ "dha" } },
                {"でゅ", new string[]{ "dhu" } },
                {"でょ", new string[]{ "dho" } },
                {"と", new string[]{ "to" } },
                {"とぁ", new string[]{ "twa" } },
                {"とぃ", new string[]{ "twi" } },
                {"とぅ", new string[]{ "twu" } },
                {"とぇ", new string[]{ "twe" } },
                {"とぉ", new string[]{ "two" } },
                {"ど", new string[]{ "do" } },
                {"どぁ", new string[]{ "dwa" } },
                {"どぃ", new string[]{ "dwi" } },
                {"どぅ", new string[]{ "dwu" } },
                {"どぇ", new string[]{ "dwe" } },
                {"どぉ", new string[]{ "dwo" } },
                {"な", new string[]{ "na" } },
                {"に", new string[]{ "ni" } },
                {"にぃ", new string[]{ "nyi" } },
                {"にぇ", new string[]{ "nye" } },
                {"にゃ", new string[]{ "nya" } },
                {"にゅ", new string[]{ "nyu" } },
                {"にょ", new string[]{ "nyo" } },
                {"ぬ", new string[]{ "nu" } },
                {"ね", new string[]{ "ne" } },
                {"の", new string[]{ "no" } },
                {"は", new string[]{ "ha" } },
                {"ば", new string[]{ "ba" } },
                {"ぱ", new string[]{ "pa" } },
                {"ひ", new string[]{ "hi" } },
                {"ひぃ", new string[]{ "hyi" } },
                {"ひぇ", new string[]{ "hye" } },
                {"ひゃ", new string[]{ "hya" } },
                {"ひゅ", new string[]{ "hyu" } },
                {"ひょ", new string[]{ "hyo" } },
                {"び", new string[]{ "bi" } },
                {"びぃ", new string[]{ "byi" } },
                {"びぇ", new string[]{ "bye" } },
                {"びゃ", new string[]{ "bya" } },
                {"びゅ", new string[]{ "byu" } },
                {"びょ", new string[]{ "byo" } },
                {"ぴ", new string[]{ "pi" } },
                {"ぴぃ", new string[]{ "pyi" } },
                {"ぴぇ", new string[]{ "pye" } },
                {"ぴゃ", new string[]{ "pya" } },
                {"ぴゅ", new string[]{ "pyu" } },
                {"ぴょ", new string[]{ "pyo" } },
                {"ふ", new string[]{ "fu","hu" } },
                {"ふぁ", new string[]{ "fa","fwa" } },
                {"ふぃ", new string[]{ "fi","fwi","fyi" } },
                {"ふぅ", new string[]{ "fwu" } },
                {"ふぇ", new string[]{ "fe","fwe","fye" } },
                {"ふぉ", new string[]{ "fo","fwp" } },
                {"ふゃ", new string[]{ "fya" } },
                {"ふゅ", new string[]{ "fyu" } },
                {"ふょ", new string[]{ "fyo" } },
                {"ぶ", new string[]{ "bu" } },
                {"ぷ", new string[]{ "pu" } },
                {"へ", new string[]{ "he" } },
                {"べ", new string[]{ "be" } },
                {"ぺ", new string[]{ "pe" } },
                {"ほ", new string[]{ "ho" } },
                {"ぼ", new string[]{ "bo" } },
                {"ぽ", new string[]{ "po" } },
                {"ま", new string[]{ "ma" } },
                {"み", new string[]{ "mi" } },
                {"みぃ", new string[]{ "myi" } },
                {"みぇ", new string[]{ "mye" } },
                {"みゃ", new string[]{ "mya" } },
                {"みゅ", new string[]{ "myu" } },
                {"みょ", new string[]{ "myo" } },
                {"む", new string[]{ "mu" } },
                {"め", new string[]{ "me" } },
                {"も", new string[]{ "mo" } },
                {"ゃ", new string[]{ "xya","lya" } },
                {"や", new string[]{ "ya" } },
                {"ゅ", new string[]{ "xyu","lyu" } },
                {"ゆ", new string[]{ "yu" } },
                {"ょ", new string[]{ "xyo","lyo" } },
                {"よ", new string[]{ "yo" } },
                {"ら", new string[]{ "ra" } },
                {"り", new string[]{ "ri" } },
                {"りぃ", new string[]{ "ryi" } },
                {"りぇ", new string[]{ "rye" } },
                {"りゃ", new string[]{ "rya" } },
                {"りゅ", new string[]{ "ryu" } },
                {"りょ", new string[]{ "ryo" } },
                {"る", new string[]{ "ru" } },
                {"れ", new string[]{ "re" } },
                {"ろ", new string[]{ "ro" } },
                {"ゎ", new string[]{ "xwa","lwa" } },
                {"わ", new string[]{ "wa" } },
                {"ゐ", new string[]{ "wyi" } },
                {"ゑ", new string[]{ "wye" } },
                {"を", new string[]{ "wo" } },
                {"ん", new string[]{ "nn","xn" } },
                {"ゔ", new string[]{ "vu" } },
                {"ゔぁ", new string[]{ "va" } },
                {"ゔぃ", new string[]{ "vi" } },
                {"ゔぇ", new string[]{ "ve","vye" } },
                {"ゔぉ", new string[]{ "vo" } },
                {"ゔゃ", new string[]{ "vya" } },
                {"ゔゅ", new string[]{ "vyu" } },
                {"ゔょ", new string[]{ "vyo" } },
                {"ゕ", new string[]{ "xka","lka" } },
                {"ゖ", new string[]{ "xke","lke" } },
                {"ー", new string[]{ "-" } },
            };

            KeyHenkan = new Dictionary<VirtualKey, string>
            {
                { VirtualKey.A, "a"},
                { VirtualKey.B, "b"},
                { VirtualKey.C, "c"},
                { VirtualKey.D, "d"},
                { VirtualKey.E, "e"},
                { VirtualKey.F, "f"},
                { VirtualKey.G, "g"},
                { VirtualKey.H, "h"},
                { VirtualKey.I, "i"},
                { VirtualKey.J, "j"},
                { VirtualKey.K, "k"},
                { VirtualKey.L, "l"},
                { VirtualKey.M, "m"},
                { VirtualKey.N, "n"},
                { VirtualKey.O, "o"},
                { VirtualKey.P, "p"},
                { VirtualKey.Q, "q"},
                { VirtualKey.R, "r"},
                { VirtualKey.S, "s"},
                { VirtualKey.T, "t"},
                { VirtualKey.U, "u"},
                { VirtualKey.V, "v"},
                { VirtualKey.W, "w"},
                { VirtualKey.X, "x"},
                { VirtualKey.Y, "y"},
                { VirtualKey.Z, "z"},
                { VirtualKey.Add, "+"},
                { VirtualKey.Subtract, "-"},
                { VirtualKey.Multiply, "*"},
                { VirtualKey.Divide, "/"},
                { (VirtualKey)189, "-"},
            };
        }

        public static Dictionary<string, string[]> Henkan;

        public static Dictionary<VirtualKey, string> KeyHenkan;

        public static string[] Sokuon;

        public static string[] Youon;

        public static bool IsSokuon(string str)
        {
            return Sokuon.IndexOf(str) != -1;
        }

        
    }
}
