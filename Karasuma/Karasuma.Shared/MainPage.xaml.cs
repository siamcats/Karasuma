using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Popups;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Core;
using System.Diagnostics;
using Karasuma.Models;
using Uno;
using Windows.System;
using Karasuma.Helper;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Karasuma
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private MainPageViewModel vm = new MainPageViewModel();

        public MainPage()
        {
            this.InitializeComponent();

#if __WASM__
            TextBox1.Visibility = Visibility.Collapsed;
#endif
        }

        void UIElement_OnKeyDown(object sender, KeyRoutedEventArgs e)
        {
            e.Handled = true;
            Debug.WriteLine($"key down {e.Key}");

            //開始前
            if (vm.IsPause)
            {
                //スペースで開始
                if (e.Key == VirtualKey.Space)
                {
                    vm.SentenceList = ExamData.Sample.Select(sd => new Sentence(sd)).ToList();
                    vm.SentenceList.Shuffle();
                    vm.SentenceList = vm.SentenceList.Take(10).ToList();
                    vm.SentenceCurrent = vm.SentenceList[0];
                    vm.SentenceNext = vm.SentenceList[1];
                    vm.Take = 0;
                    vm.Mistake = 0;
                    vm.Count = 0;
                    vm.IsPause = false;
                }
                return;
            }

            //開始後
            var key = string.Empty;
            if (!KanaUtils.KeyHenkan.TryGetValue(e.Key, out key)) return;
            var result = vm.SentenceCurrent.Type(key);

            vm.Take++;

            //ミス
            if (!result)
            {
                vm.Mistake++;
#if __WASM__
                ErrorStoryboardWasm.Begin();
#else
                ErrorStoryboard.Begin();
#endif
                return;
            }

            //文字入力完了
            if (vm.SentenceCurrent.IsTyped)
            {
                vm.Count++;
                if (vm.Count < vm.SentenceList.Count)
                {
                    vm.SentenceCurrent = vm.SentenceList[vm.Count];
                    vm.SentenceNext = vm.Count < vm.SentenceList.Count - 1
                        ? vm.SentenceList?[vm.Count + 1]
                        : new Sentence(new SentenceDefinition { KanjiKana="",Kana="" });
                }
                //全文完了
                else
                {
                    vm.IsPause = true;
                    vm.SentenceList.Clear();
                    vm.SentenceCurrent = null;
                    vm.SentenceCurrent = null;
                    vm.Count = 0;
                }
            }
        }
    }
}
