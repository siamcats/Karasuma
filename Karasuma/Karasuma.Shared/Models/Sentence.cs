using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Karasuma.Models
{

    public class Sentence : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string KanjiKana { get; }

        public string Kana { get; }

        public List<Chunk> ChunkList { get; } = new List<Chunk>();

        public string Letters
        {
            get{ return string.Join("", ChunkList.Select(c => c.Letters)); }
        }

        public string TypedLetters
        {
            get { return typedLetters; }
            set
            {
                typedLetters = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Letters)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TypedLetters)));
            }
        }
        private string typedLetters = "";

        public bool IsTyped
        {
            get
            {
                if (typedLetters == Letters) return true;
                return false;
            }
        }

        public bool Type(string typedLetter)
        {
            if (IsTyped) return false;
            var chunk = ChunkList.Select(c => c).Where(c => !c.IsTyped).First();
            var result = chunk.Type(typedLetter);
            if (result) TypedLetters = TypedLetters + typedLetter;
            return result;
        }


        public Sentence(SentenceDefinition sd)
        {
            KanjiKana = sd.KanjiKana;
            Kana = sd.Kana;
            var charArray = Kana.ToCharArray();
            var charList = new List<char>(charArray);
            var strList = charList.Select(c => c.ToString()).ToList();

            var isSokuon = false;
            var from = 0;
            for (int i = 0; i < strList.Count(); i++)
            {

                if (i < strList.Count() - 1) //最終文字ならチャンク確定
                {
                    if (!isSokuon)
                    {
                        isSokuon = KanaUtils.IsSokuon(strList[i]);
                        if (isSokuon)
                        {
                            from--;
                            continue;
                        }
                    }

                    var chkStr = strList[i] + strList[i + 1];
                    if (KanaUtils.Henkan.ContainsKey(chkStr))
                    {
                        from--;
                        continue;
                    }
                }

                var chunkStr = "";
                for (int j = from; j < 1; j++)
                {
                    chunkStr = chunkStr + strList[i + j];
                };

                ChunkList.Add(new Chunk(chunkStr, isSokuon));
                isSokuon = false;
                from = 0;
            }
        }
    }
}
