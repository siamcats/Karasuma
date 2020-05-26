using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Karasuma.Models;

namespace Karasuma
{
    public class MainPageViewModel : INotifyPropertyChanged // インターフェースを実装
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private int count = 0;
        public int Count
        {
            get => count;
            set
            {
                count = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
            }
        }

        private bool isPause = true;
        public bool IsPause
        {
            get => isPause;
            set
            {
                isPause = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsPause)));
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

        private string message = "スペースキーを押して開始（反応しない場合はタブキーを押してください）";
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
