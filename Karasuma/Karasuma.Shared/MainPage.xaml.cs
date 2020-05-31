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
using Windows.UI.Input;

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

            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown; //Wasm非対応
            //Dispatcher.AcceleratorKeyActivated += Dispatcher_AccelaratorKeyActivated;
        }

        private void CoreWindow_KeyDown(CoreWindow sender, KeyEventArgs e)
        {
            Debug.WriteLine("CoreWindow");
            e.Handled = true;
            Keystroke(e.VirtualKey);
        }

        private void Dispatcher_AccelaratorKeyActivated(CoreDispatcher sender, AcceleratorKeyEventArgs e)
        {
            Debug.WriteLine("Dispatcher_AccelaratorKeyActivated");
        }

        private void UIElement_OnKeyDown(object sender, KeyRoutedEventArgs e)
        {
            Debug.WriteLine("UIElement");
            e.Handled = true;
#if __WASM__
            Keystroke(e.Key);
#endif
        }


        private void Keystroke(VirtualKey key)
        {
            //開始前
            if (vm.IsPause)
            {
                //スペースで開始
                if (key == VirtualKey.Space)
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
            var strKey = string.Empty;
            if (!KanaUtils.KeyHenkan.TryGetValue(key, out strKey)) return;
            var result = vm.SentenceCurrent.Type(strKey);

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
                        : new Sentence(new SentenceDefinition { KanjiKana = "", Kana = "" });
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

        private async void TweetButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var text = "あなたのタイピング速度は " + vm.Kpm + " KPMです。";
            var url = "https://typeratta.azurewebsites.net";
            var hashtag = "UnoPlatform";
            var intent = Uri.EscapeUriString("https://twitter.com/intent/tweet?text="+ text +"&url=" + url + "&hashtags=" + hashtag);
            await Launcher.LaunchUriAsync(new Uri(intent));
        }
    }
}
