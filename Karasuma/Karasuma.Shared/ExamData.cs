using System;
using System.Collections.Generic;
using System.Text;
using Karasuma.Models;

namespace Karasuma
{
    class ExamData
    {
        public static List<SentenceDefinition> Sample = new List<SentenceDefinition>
        {
            new SentenceDefinition
            {
                KanjiKana = "清滝トンネルで肝試し",
                Kana = "きよたきとんねるできもだめし",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "地下鉄に乗るっ",
                Kana = "ちかてつにのるっ",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "帷子ノ辻で乗り換えよう",
                Kana = "かたびらのつじでのりかえよう",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "岡崎の大鳥居をくぐる",
                Kana = "おかざきのおおとりいをくぐる",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "出町柳の鴨川デルタ",
                Kana = "でまちやなぎのかもがわでるた",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "広沢池から見る鳥居形",
                Kana = "ひろさわのいけからみるとりいがた",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "死者も蘇る一条戻り橋",
                Kana = "ししゃもよみがえるいちじょうもどりばし",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "柊野別れで最期の別れ",
                Kana = "ひらぎのわかれでさいごのわかれ",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "北山のお洒落カフェ",
                Kana = "きたやまのおしゃれかふぇ",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "お土産は阿闍梨餅で",
                Kana = "おみやげはあじゃりもちで",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "丸 竹 夷 二 押 御池",
                Kana = "まるたけえびすにおしおいけ",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "姉 三 六角 蛸 錦",
                Kana = "あねさんろっかくたこにしき",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "鴨川ソーシャルディスタンス",
                Kana = "かもがわそーしゃるでぃすたんす",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "高瀬川で顔を洗う",
                Kana = "たかせがわでかおをあらう",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "京都駅から三十三間堂まで歩く",
                Kana = "きょうとえきからさんじゅうさんげんどうまであるく",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "哲学の道で思索にふける",
                Kana = "てつがくのみちでしさくにふける",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "清水の舞台から飛び降りる",
                Kana = "きよみずのぶたいからとびおりる",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "夜間拝観の見どころは紅葉のライトアップ",
                Kana = "やかんはいかんのみどころはもみじのらいとあっぷ",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "大原の里山に日本の原風景を感じる",
                Kana = "おおはらのさとやまににほんのげんふうけいをかんじる",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "若狭を目指せ周山街道",
                Kana = "わかさをめざせしゅうざんかいどう",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "歌舞練場から漏れ聞こえる稽古の音",
                Kana = "かぶれんじょうからもれきこえるけいこのおと",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "百万遍の立て看板",
                Kana = "ひゃくまんべんのたてかんばん",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "百井別れの切り返し",
                Kana = "ももいわかれのきりかえし",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "いつか行きたい貴船の川床",
                Kana = "いつかいきたいきぶねのかわどこ",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "鉄道博物館でディーゼル機関車を見よう",
                Kana = "てつどうはくぶつかんででぃーぜるきかんしゃをみよう",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "奈良線は京都だよ",
                Kana = "ならせんはきょうとだよ",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "仁和寺にある法師",
                Kana = "にんなじにあるほうし",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "京滋バイパス久御山ジャンクション",
                Kana = "けいじばいぱすくみやまじゃんくしょん",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "羽束師の運転免許試験場",
                Kana = "はづかしのうんてんめんきょしけんじょう",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "京都三条中京郵便局",
                Kana = "きょうとさんじょうなかぎょうゆうびんきょく",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "一乗寺のラーメン激戦区",
                Kana = "いちじょうじのらーめんげきせんく",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "広河原でスキーをしよう",
                Kana = "ひろがわらですきーをしよう",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "大文字焼と呼ばないで",
                Kana = "だいもんじやきとよばないで",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "先の祭りと後の祭り",
                Kana = "さきのまつりとあとのまつり",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "下鴨納涼古本まつり",
                Kana = "しもがものうりょうふるほんまつり",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "祇園精舎の鐘の声",
                Kana = "ぎおんしょうじゃのかねのこえ",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "東風吹かば匂いおこせよ梅の花",
                Kana = "こちふかばにおいおこせようめのはな",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "新緑まばゆい葵祭",
                Kana = "しんりょくまばゆいあおいまつり",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "時代祭の華やぐ歴史絵巻",
                Kana = "じだいまつりのはなやぐれきしえまき",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "コトコト歩く古都京都",
                Kana = "ことことあるくこときょうと",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "おばんざい食べ放題",
                Kana = "おばんざいたべほうだい",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "稲荷詣に愛宕詣",
                Kana = "いなりもうでにあたごもうで",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "ぶぶ漬けが出てきたら帰れの合図",
                Kana = "ぶぶづけがでてきたらかえれのあいず",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "嵐電太秦広隆寺",
                Kana = "らんでんうずまさこうりゅうじ",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "平等院鳳凰堂のシンメトリーな様式美",
                Kana = "びょうどういんほうおうどうのしんめとりーなようしきび",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "雪化粧の金閣寺",
                Kana = "ゆきげしょうのきんかくじ",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "みやこめっせでワンマンライブ",
                Kana = "みやこめっせでわんまんらいぶ",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "重森三玲のモダンな庭園",
                Kana = "しげもりみれいのもだんなていえん",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "琵琶湖疎水といえば水路閣とインクライン",
                Kana = "びわこそすいといえばすいろかくといんくらいん",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "めっちゃまっちゃな宇治抹茶",
                Kana = "めっちゃまっちゃなうじまっちゃ",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "四条烏丸西入ル鉾町生まれのお嬢さん",
                Kana = "しじょうからすまにしいるほこちょううまれのおじょうさん",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "秋は叡電もみじのトンネル",
                Kana = "あきはえいでんもみじのとんねる",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "春は嵐電さくらのトンネル",
                Kana = "はるはらんでんさくらのとんねる",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "三条京阪土下座像前で待ち合わせ",
                Kana = "さんじょうけいはんどげざぞうまえでまちあわせ",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "大階段駆け上がり競走",
                Kana = "だいかいだんかけあがりきょうそう",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "先斗町デートに使える人気のお店",
                Kana = "ぽんとちょうでーとにつかえるにんきのおみせ",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "小倉山から渡月橋を望む",
                Kana = "おぐらやまからとげつきょうをのぞむ",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "弘法さんと天神さん",
                Kana = "こうぼうさんとてんじんさん",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
            new SentenceDefinition
            {
                KanjiKana = "得体の知れない不吉な塊",
                Kana = "えたいのしれないふきつなかたまり",
                Category = Category.京都,
                Tags = new List<Tag>{}
            },
        };
    }
}
