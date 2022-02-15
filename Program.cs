using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System.Xml;
using System.Net;

namespace dayıbot
{


    class Program
    {

        public static void Main(string[] args)

        => new Program().MainAsync().GetAwaiter().GetResult();

        public DiscordSocketClient _client;
        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();
            _client.MessageReceived += CommandHandler;
            _client.Log += Log;


            var token = ("aldığınız tokeni buraya giriniz");
            // token gir

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            // program kapanana kadar çalış
            await Task.Delay(-1);
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }




        XmlDocument xDoc = new XmlDocument();



        private Task CommandHandler(SocketMessage message)
        {
            //değişkenler
            string command = "";
            int lengthOfCommand = -20;


            if (!message.Content.StartsWith("!")) // !tercihtir
                return Task.CompletedTask;

            if (message.Author.IsBot)
                return Task.CompletedTask;

            if (message.Content.Contains(' '))
                lengthOfCommand = message.Content.IndexOf(' ');
            else
                lengthOfCommand = message.Content.Length;

            command = message.Content.Substring(1, lengthOfCommand - 1).ToLower();

            //mesaj özelliği
            if (command.Equals("dayı"))
            {
                message.Channel.SendMessageAsync($@"buyur{message.Author.Mention}yeğen");
            }
            else if (command.Equals("hesap"))
            {
                message.Channel.SendMessageAsync($@"senin hesabın {message.Author.CreatedAt.DateTime} tarihinde kesildi kardeş");
            }


            else if (command.Equals("söz"))
            {
                message.Channel.SendMessageAsync($@"buyur{message.Author.Mention} yeğenim iyi dinle:");

                var r = new Random();

                string[] söz = { "Bazen hayat seni öyle zorlar ki yeğenim yolun başında kimdin unutursun.", "Güç gizden gelir yeğen!", "acı çekmiş hiç kimse, artık eskisi gibi değildir.", "Teslim olunmadan sadık olunmaz.", "Mesele ölmek değil yeğen asıl mesele iz bırakabilmektir.", "Hesap görmek hesap etmekten zordur yeğenim.", "Portakalı soymadan içinin iyi olup olmadığını anlayamazsın.", "Bir insan ne kadar merhametliyse o kadar kazık yer.", "Ben her şeyi olan ve kaybedeceği hiç bir şey olmayan inşanım.", "Cesurun bakışı korkağın kılıcından keskindir yeğen!", "Sadakat ya birine doğru koşmaktır ya birinden kaçmaktır.", "Değişmek zordur yeğenim ama bazen. Aynı adam olmak daha zordur.", "Dön bak arkana yeğen. Gitmez dediğin kaç kişi şimdi yanında.", "Oyunun sonuna geldiğinde, çoktan tükenmiştir gidecek olduğun yerlerin.", "Ölüm gibidir sadakat. Bir kere çizgiyi geçtin mi geri dönüş yoktur.", "Ağlaya ağlaya geldiğin dünyada, güle oynaya yaşayacağını mı sandın yeğen?", "Ne kadar değişirsen değiş nerede mutlu olduysan hep oraya çevirirsin kafanı.", "Çözemedim bazılarını. Uzaktan mı adamlar adamlıktan mı uzaklar?", "Seni önceden saçma sapan sevmişler Selma benimkisi ağır geldi tabi.", "Sevdiklerimize çok yakından bakarız. Bu yüzden kusurlarını görmeyiz.", "Mesele ölmek değil dost bildiğin en güvendiğin adamın eliyle ölmekmiş mesele.", "Sözler verilir sözler unutulur ama gün gelir ihanet eden sadakat ister.", "Öldürmek için gelen öldürmeden dönebilir ama ölmek için gelen. Ölmeden dönmez.", "Bazı insanları kırmak gerekir yeğen, aslında kim olduklarını görmek için…", "Ben senin için boşa kürek çektiğimi, sen bir başka bir gemiye bindiğinde de anladım.", "Bazen sırf hayatımızda kalmalarını istediğimiz için insanları affedersiniz", "İnanıyorum söylediğini candan söylediğine, ama bugünkü kadar yarın bozulur çok kez.", "Paran varsa insanlar seni tanır, eğer ki paran yoksa sen insanları tanırsın…", "Aynı sofradan yemek yemişti dostlar. Masada karnı doyan kalktı ve düşman oldu dostuna.", "Bir insanı yalanlarla kazanmak yerine, doğrularla kaybetmeyi tercih ederim.", "Kadere inanan insan tesadüfe inanmaz. Tesadüfe inanan adamsa kaderini kendi elinde tutamaz.", "Daha önce acı çekmiş biriyle birlikte olun. Çünkü onlar mutluluğun değerini daha iyi bilirler.", "Ara sıra kenara çekilip seyretmek lazım yeğen. Bakmak lazım kimde ne kadarız ve kim bizde ne kadar.", "Kendi kendimize verdiğimiz sözü tutmak en çabuk unuttuğumuz şeydir; ne yapsak! Üzülme!", "Ben hiç mutlu olamaya çalışmıyorum. Denk gelirse mutlu oluyorum, gelmezse canı sağolsun diyorum yeğen…", "Çaresizlik... aradığı çarenin belki tam önünde olması ama onu bulacak vaktin olmamasıdır çaresizlik.", "Eğer birisi seni aldatmışsa bu onun suçudur. Eğer o kişi seni pek çok kere aldatmışsa bu senin suçundur.", "Sadakat sevdiğinin kalbini tutup avucunda tutmaktır ama sadakat gerektiğinde o yüreği fırlatıp yere atmaktır.", "Sadakat endam değildir aslında sevgiden kör olmaktır hep kaçtığın şeye eninde sonunda yakalanmaktır sadakat. Bazen yaşamak için öldürmek zorundasın. Bazen yaşamak için içindeki sevgi seni öldürmeden sen onu öldürmek zorundasın.", "Bir gün sevginin bitmesine insan neden üzülsün. Aşk mı kaderi kovalar kader mi aşkı daha kimseler çözemedi bu bilmeceyi.", "Sevdiğini korumak için savaşman yetmezse eğer en karanlık çare onun sevgisini öldürmektir. Sevdiğini kurtarmak için en kötü ihtimal en son yol ona ihanet etmektir.", "Zorunu benden duy yeğenim herkese yalan söylemen yetmez artık. Bundan böyle bir başına kalsan da artık kendin olamazsın.", "Unutma! Bin kere dönsen o güne bin kere ihanet edecekler sana. Herkes doğasının gereğini yapar. Bin kere ihanet etseler sana çaresi yok bin kere gidersin yanlarına.", "Hayal ettiğin her şey bir gün bir ihtimal gerçek olabilir o ihtimali yok etmeden unutabilir misin gerçekten sevdiğin tek insanı.", "Sözler verilir sözler unutulur gün gelir ihanet eden sadakat ister. Sadaka gibi verilmez sadakat isteyen hepsini ister. Sevdiğine sadık kalan adam kendinden vazgeçebilen adamdır.", "Korkunçtur sonunda gördüğün gerçeğin en çıplak en gaddar en acımasız yüzü ama en korkuncu her şeye sahipken bile bir anının bir hayalin bir hayaletin peşinden koşmak.", "En iyi soygunlar girerken değil çıkarken bozulur yeğen. Haydutlar öyle iyi planlar ki girmeyi nasıl çıkacaklarını unuturlar. Çıkacaksan hemen çıkacaksın yeğen yoksa çekerler yoksa seni içeri.", "İkisi de akıntının içine doğru sürüklenirken kurbağa sorar akrebe niye yaptın akrep kardeş? Bak şimdi ikimiz de öleceğiz. Akrep döner ve şöyle der napayım benim huyum bu.", "bir kere ihanete uğradın mı anılar sana bataklık olur yeğen. Hatırladıkça çekerler seni içeri hatırladıkça affetmek istersin yeğen. Çünkü affetmek unutmak demek öncesini hatırladıkça sonrasını unutmak istersin çırpınma boşuna yeğen o hançer bir kere saplanınca çıkarmaya kalktıkça iyice kalbine gömersin.", "En karanlık gününde en çaresiz anında kendini ortaya atıyorsan eğer en umutsuz anında kendin için değil çocukların için kendini çare diye sunuyorsan eğer yüreğinde çocuğunun sevgisini tutan hiç kimse çaresiz değildir. Tüm kapılar üstüne kitlenmiş de olsa birinin kalbinde yer tutan hiç kimse tutsak değildir kendi kafesine. Çaresizlik aradığın çarenin belki tam önünde olması ama onu bulacak vaktin olmamasıdır çaresizlik. Çaresizlik cevapsız kurak bir ıssızlık değildir. Dışarıda devam edecek hayattır asıl engel. Asıl engel sana geçit vermeyen seni umursamayan seni yutan hayattır asıl engel.", "Elinden bir şey gelmeyince kabullenmek kolaydır. Asıl çaresizlik kendine elimden geleni yaptım mı diye sormaktır. Çünkü asıl çaresizlik çareyi geçirmişken eline avuçlarının içinden kaçırmaktır." };
                int sıra = r.Next(0, söz.Length);
                message.Channel.SendMessageAsync(Convert.ToString(söz[sıra]));
            }


            else if (command.Equals("dolar"))
            {
                string today = "http://www.tcmb.gov.tr/kurlar/today.xml";

                var xmlDoc = new XmlDocument();
                xmlDoc.Load(today);

                // Xml içinden tarihi alma - gerekli olabilir
                DateTime exchangeDate = Convert.ToDateTime(xmlDoc.SelectSingleNode("//Tarih_Date").Attributes["Tarih"].Value);


                string USD = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
                message.Channel.SendMessageAsync($@"{message.Author.Mention}""Dolar Kuru : " + USD);
            }


            else if (command.Equals("euro"))
            {
                string today = "http://www.tcmb.gov.tr/kurlar/today.xml";

                var xmlDoc = new XmlDocument();
                xmlDoc.Load(today);

                // Xml içinden tarihi alma - gerekli olabilir
                DateTime exchangeDate = Convert.ToDateTime(xmlDoc.SelectSingleNode("//Tarih_Date").Attributes["Tarih"].Value);

                string EURO = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
                message.Channel.SendMessageAsync($@"{message.Author.Mention}""euro Kuru : " + EURO);





            }


            else if (command.Equals("pound"))
            {
                string today = "http://www.tcmb.gov.tr/kurlar/today.xml";

                var xmlDoc = new XmlDocument();
                xmlDoc.Load(today);

                // Xml içinden tarihi alma - gerekli olabilir
                DateTime exchangeDate = Convert.ToDateTime(xmlDoc.SelectSingleNode("//Tarih_Date").Attributes["Tarih"].Value);

                string POUND = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='GBP']/BanknoteSelling").InnerXml;
                message.Channel.SendMessageAsync($@"{message.Author.Mention}""pound Kuru : " + POUND);
            }



            else if (command.Equals("şarkı"))
            {
                message.Channel.SendMessageAsync($@"{message.Author.Mention} bir ihtimal daha var o da ölmek mi dersin?""https://www.youtube.com/watch?v=WUpSh3GxS38");
            }





          



            return Task.CompletedTask;






        }



    }

}
