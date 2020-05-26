using System;
using System.Collections.Generic;
using System.Text;

namespace Karasuma.Models
{
    public class SentenceDefinition
    {
        public string KanjiKana { get; set; }

        public string Kana { get; set; }

        public Category Category { get; set; }

        public List<Tag> Tags { get; set; }
    }


    public enum Category
    {
        京都
    }

    public enum Tag
    {
        右手小指,右手薬指,左手小指,左手薬指,記号,促音,撥音
    }

}
