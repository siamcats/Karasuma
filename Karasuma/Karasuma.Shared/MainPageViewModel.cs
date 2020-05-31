using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Karasuma.Models;

namespace Karasuma
{
    public class MainPageViewModel : INotifyPropertyChanged // インターフェースを実装
    {

        public event PropertyChangedEventHandler PropertyChanged;

        Stopwatch sw = new Stopwatch();

        private int count = 0;
        public int Count
        {
            get => count;
            set
            {
                count = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Remaining)));
            }
        }

        public int Remaining
        {
            get
            {
                var result = SentenceList != null
                    ? SentenceList.Count - count
                    : 0;
                return result;
            }
        }

        private int mistake = 0;
        public int Mistake
        {
            get => mistake;
            set
            {
                mistake = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Mistake)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Accuracy)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Kpm)));
            }
        }

        private int take = 0;
        public int Take
        {
            get => take;
            set
            {
                take = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Take)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Accuracy)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Kpm)));
            }
        }

        public string Accuracy
        {
            get
            {
                var result = take != 0
                    ? ( take - mistake ) * 100 / (float)take
                    : 0;
                return string.Format("{0:f2}",result);
            }
        }

        public string Kpm
        {
            get
            {;
                var result = take != 0
                    ? 60 / sw.Elapsed.TotalSeconds * (take - mistake)
                    : 0;
                return string.Format("{0:f2}", result);
            }
        }

        private bool isPause = true;
        public bool IsPause
        {
            get => isPause;
            set
            {
                if (isPause && !value) sw.Restart(); //停止→稼働に切り替えるときに、ストップウォッチ開始
                if (!isPause && value) sw.Stop(); //稼働→停止に切り替えるときに、ストップウォッチ停止
                isPause = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsPause)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CanTweet)));
            }
        }

        public bool CanTweet
        {
            get
            {
                if (isPause && take > 0) return true;
                return false;
            }
        }

        private List<Sentence> sentenceList;
        public List<Sentence> SentenceList
        {
            get => sentenceList;
            set
            {
                sentenceList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SentenceList)));
            }
        }

        private Sentence sentenceCurrent;
        public Sentence SentenceCurrent
        {
            get => sentenceCurrent;
            set
            {
                sentenceCurrent = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SentenceCurrent)));
            }
        }

        private Sentence sentenceNext;
        public Sentence SentenceNext
        {
            get => sentenceNext;
            set
            {
                sentenceNext = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SentenceNext)));
            }
        }

        private string message = "Press SPACE to start \r\n If not, press TAB please";
        public string Message
        {
            get => message;
            set
            {
                message = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Message)));
            }
        }
    }
}
