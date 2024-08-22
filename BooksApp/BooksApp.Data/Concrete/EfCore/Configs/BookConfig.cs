using BooksApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Data.Concrete.EfCore.Configs
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x=> x.Id);
            builder.Property(x=>x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Properties).HasMaxLength(1000);
            builder.Property(x => x.Price).HasColumnType("real");
            builder.Property(x => x.Summary).IsRequired(false);
            builder.ToTable("Books");
            builder.HasData(
                            new Book
                            {
                                Id = 1,
                                Name = "Öğrenci Kız",
                                Properties = "'… İyi geceler. Ben prensi olmayan bir Külkedisi’yim. Tokyo’nun neresinde olduğumu biliyor musunuz? Beni bir daha görmeyeceksiniz.'\r\n\r\nYirminci yüzyıl Japon edebiyatının önde gelen yazarlarından, sıradışı hayatıyla da meşhur Osamu Dazai, savaş sonrası Japonya’sının edebiyat çevrelerince tanınmasını sağlayan, kaleme aldığı ilk eserlerden Öğrenci Kız’da Tokyo’nun banliyösünde yaşayan bir genç kızın on iki saatini ironik ve hünerli bir üslupla kaleme alıyor.\r\n\r\nİsimsiz genç kızın, nefret ettiği sabahlardan birine gözlerini açmasıyla başlayıp gece yatağa yattığı anda biten kısa romanda Dazai, artık yitmiş bir dönemin yaygın toplumsal normlarına karşı bireyin duyduğu huzursuzluğu, gençliğin ilk buhranları ve asiliğiyle birleştiriyor. \r\n\r\nÖğrenci Kız, Dazai’nin sonraki çoğu eserinde yer bulacak aykırı kişiliklerin ilk örneklerinden birini görmeyi ve yazarın zihninin derinliklerine yakından bakmayı sağlayacak bir klasik.",
                                ImageUrl = "images/books/ogrenci-kiz.jpg",
                                Stock = 4,
                                Price = 90,
                                PageCount = 439,
                                EditionNumber = 4,
                                EditionYear = 2022,
                                IsActive = true,
                                IsHome = false,
                                AuthorId = 6,
                            },
                            new Book
                            {
                                Id = 2,
                                Name = "Homo Deus: Yarının Kısa Bir Tarihi",
                                Properties = "Hayvanlardan Tanrılara: Sapiens kitabıyla insan türünün dünyaya nasıl egemen olduğunu anlatan Harari, Homo Deus’ta çarpıcı öngörüleriyle yarınımızı ele alıyor. İnsanlığın ölümsüzlük, mutluluk ve tanrısallık peşindeki yolculuğunu bilim, tarih ve felsefe ışığında incelediği bu çalışmasında, insanın bambaşka bir türe, Homo deus’a evrildiği bir gelecek kurguluyor.\r\n\r\nYola *önemsiz bir hayvan* olarak çıkan Homo sapiens, tanrılar katına ulaşmak uğruna kendi sonunu mu hazırlıyor?\r\n\r\nHomo sapiens nasıl oldu da evrenin insan türünün etrafında döndüğünü iddia eden hümanist öğretiye inandı?\r\n\r\nBu öğreti gündelik yaşantımızı, sanatımızı ve en gizli tutkularımızı nasıl şekillendiriyor?\r\n\r\nİnsanı inekler, tavuklar, şempanzeler ve bilgisayar programlarının tümünden ayıran yüksek zekası ve kudreti dışında herhangi bir alametifarikası var mı?\r\n\r\nTarih boyunca benzeri görülmemiş kazanımlar elde etmemize rağmen mutluluk seviyemizde neden kayda değer bir artış olmadı?\r\n\r\n*Tüm bunları anlamak için tek yapmamız gereken geriye dönüp bakmak ve Homo sapiens’in aslında ne olduğunu, hümanizmin nasıl dünyaya hakim bir din hâline geldiğini ve hümanizm rüyasını gerçekleştirmeye çalışmanın aslında neden insanlığın kendi sonunu getireceğini incelemektir. İşte bu kitabın temel meselesi budur.*\r\n\r\n*Okurken hem eğlenecek hem de çok şaşıracaksınız. Her şeyin ötesinde, kendinizi daha önce hiç düşünmediğiniz şeyleri düşünürken bulacaksınız.*\r\n\r\n- Daniel Kahneman, Hızlı ve Yavaş Düşünme’nin yazarı\r\n\r\n*Homo Deus’u okuduğunuzda uzun ve zorlu bir yolculuğun ardından vardığınız bir uçurumun kenarında durduğunuzu hissedeceksiniz. Yolculuğun artık bir önemi kalmayacak, çünkü bir sonraki adımınızı engin bir boşluğa atacaksınız.*",
                                ImageUrl = "images/books/homo-deus-yarinin-kisa-bir-tarihi.jpg",
                                Stock = 28,
                                Price = 60,
                                PageCount = 308,
                                EditionNumber = 12,
                                EditionYear = 2021,
                                IsActive = true,
                                IsHome = false,
                                AuthorId = 13,
                            },
                            new Book
                            {
                                Id = 3,
                                Name = "Efendi Uyanıyor",
                                Properties = "Edebiyat tarihinin ilk distopyası olan Efendi Uyanıyor bir 19. yy. centilmeni olan Graham’ın öyküsünü anlatıyor. Nadir görülen bir uykusuzluk hastalığından mustarip olan Graham en sonunda uyumayı başarır. Ne var ki bu kez 200 yıllık trans halinde bir uykuya dalacaktır. Uyandığında ise, banka hesabına işleyen faizler sayesinde dünyanın en zengin ve en güçlü adamı olduğunu öğrenir. O artık bambaşka ve hiç tanımadığı bir dünyada yaşamaktadır. Dünyanın tek efendisi ve sahibi odur! Graham uyuduğu sırada servetini idare eden Konsey, tüm gezegene hüküm süren son derece karanlık ve acımasız bir sistem kurmuştur. Oysa insanların bir kurtarıcı olarak gördüğü Graham’dan beklenen, toplumu bu korkunç despotlardan kurtarmasıdır. Bir distopya klasiği ve politik bilimkurgu türünün en iyi örneklerinden biri olan Wells’in bu başyapıtı, okuru fantastik bir maceraya sürüklüyor. Günümüzden 114 yıl önce yazılmış olmasına rağmen global şirketlerin yükselişi, uçakların seyahat amaçlı kullanımı ve birçok teknolojik gelişmeyi zamanının çok ötesinde başarılı bir şekilde tahmin etmiş olması şaşkınlık yaratıyor. Geleceğe dair yerinde tahminlerinin yanı sıra toplumsal adaletsizlikle boğuşan bir dünyayı tasvir eden Efendi Uyanıyor, distopya, bilim kurgu ve politik roman hayranları için mükemmel bir seçim. \"Wells’in en çarpıcı yönü, edebiyatın klişeleşmiş yanlarına yeni bir soluk getirip canlılık katması...\" -The Spectator- \"Politik bilim-kurgu ve distopya severler için kaçırılmaması gereken bir eser...\" -Times Literary Supplement-",
                                ImageUrl = "images/books/efendi-uyaniyor.jpg",
                                Stock = 39,
                                Price = 85,
                                PageCount = 417,
                                EditionNumber = 2,
                                EditionYear = 2019,
                                IsActive = true,
                                IsHome = true,
                                AuthorId = 3,
                            },
                            new Book
                            {
                                Id = 4,
                                Name = "Evrenin Sonundaki Restoran",
                                Properties = "Milliways Öğlen Menüsü, editörünün iznini alarak, Otostopçunun Galaksi Rehberi’nden bir pasaj aktarmaktaydı. Pasaj şöyleydi: Belli başlı her galaktik uygarlığın tarihi üç ayrı ve fark edilebilir aşamadan geçme eğilimindedir. Bu aşamalar Hayatta Kalma, Sorgulama ve İncelikli Düşünmedir; bir başka deyişle Nasıl, Neden ve Nerede aşamaları olarak da bilinirler. Örneğin, ilk aşama Nasıl Yiyebiliriz? sorusuyla, ikinci aşama Neden Yiyoruz? sorusuyla, üçüncü aşamaysa Öğle Yemeğini Nerede Yiyelim? sorusuyla tanımlanmaktadır.\r\n\r\nMenü daha sonra Milliways’in, Evrenin Sonundaki Restoran’ın bu üçüncü soruya çok uygun ve seçkin bir cevap olduğunu söylüyordu.\r\n\r\nAltın Kalp’in yolcuları sabahtan itibaren altı tamamen imkânsız işi başarmışken, günü gerçekten layık olduğu bir şekilde taçlandırmaya karar vermişlerdi: Gidilebilecek en iyi restoranda, seyredilebilecek en iyi manzaraya karşı mükellef bir yemek.\r\n\r\nBu arada gidiyoruz, ama aranızda rezervasyon yaptıran oldu mu?",
                                ImageUrl = "images/books/evrenin-sonundaki-restoran.jpg",
                                Stock = 13,
                                Price = 90,
                                PageCount = 444,
                                EditionNumber = 9,
                                EditionYear = 2018,
                                IsActive = true,
                                IsHome = false,
                                AuthorId = 4,
                            },
                            new Book
                            {
                                Id = 5,
                                Name = "Fahrenheit 451",
                                Properties = "Ray Bradbury sadece bilimkurgunun değil fantastik edebiyatın ve korkunun da yirminci yüzyıldaki ustalarından biri. Bilimkurgunun *iyi edebiyat* da olabileceğini kanıtlayan belki de ilk yazar. Yayımlandığı anda klasikleşen, distopya edebiyatının dört temel kitabından biri olan Fahrenheit 451 ise bir yirminci yüzyıl başyapıtı.\r\n\r\nGuy Montag bir itfaiyeciydi. Televizyonun hüküm sürdüğü bu dünyada kitaplar ise yok olmak üzereydi zira itfaiyeciler yangın söndürmek yerine ortalığı ateşe veriyordu. Montag’ın işi ise yasadışı olanların en tehlikelisini yakmaktı: Kitapları.\r\n\r\nMontag yaptığı işi tek bir gün dahi sorgulamamıştı ve tüm gününü televizyonla kaplı odalarda geçiren eşi Mildred’la beraber yaşıyordu. Ancak yeni komşusu Clarisse’le tanışmasıyla tüm hayatı değişti. Kitapların değerini kavramaya başlayan Montag artık tüm bildiklerini sorgulayacaktı.\r\n\r\nİnsanların uğruna canlarını feda etmeyi göze aldığı bu kitapların içinde ne vardı?\r\nGerçeklerin farkına vardıktan sonra bu karanlık toplumda artık yaşanabilir miydi?\r\n\r\nFahrenheit 451, yeryüzünde tek bir kitap kalacak olsa, o kitap olmaya aday.",
                                ImageUrl = "images/books/fahrenheit-451.jpg",
                                Stock = 28,
                                Price = 60,
                                PageCount = 307,
                                EditionNumber = 4,
                                EditionYear = 2022,
                                IsActive = true,
                                IsHome = true,
                                AuthorId = 6,
                            },
                            new Book
                            {
                                Id = 6,
                                Name = "1984",
                                Properties = "1984 kitabı, İngiliz filozof ve yazar George Orwell tarafından kaleme alınmış, 1984 kitap konusu olarak 20. yüzyılın en önemli distopya örneklerinden biri olmuştur. George Orwell, 1948 yılında tamamladığı ve geleceğe dair karamsar bir kurgu geliştirerek gelecek hakkında insanlığı uyarmayı amaçlamıştır. Egemen sınıfa dayalı, totaliter, baskıcı bir yönetim anlayışının benimsendiği üç ayrı devletin egemenliğindeki siyasal düzenden bahsetmektedir. 1984 kitabı, günümüz ile geçmiş arasında gerçekçi bir benzerliklere dayandıran, dönemin okurlarını düşündürtüp hayal güçlerinin sınırlarını zorlamayı sağlayan distopik, alegorik, politik bir romandır.",
                                ImageUrl = "images/books/bindokuzyuzseksendort-1984.jpg",
                                Stock = 16,
                                Price = 95,
                                PageCount = 485,
                                EditionNumber = 2,
                                EditionYear = 2022,
                                IsActive = true,
                                IsHome = true,
                                AuthorId = 7,
                            },
                            new Book
                            {
                                Id = 7,
                                Name = "Görünmez Adam",
                                Properties = "H. G. Wells, bilimkurgunun atası, türe adını altın harflerle yazdırmış en büyük yazarlardan. Yazdığı bilim fantazileri nesiller boyu yazarları etkilemiş, onlara yol göstermiş; ilk basıldıkları dönemden itibaren etkilerini yitirmeden okurların gönlünde taht kurmaya devam etmiştir. Görünmez Adam da Wells’in eserleri içinde en akılda kalıcı olanlardan biri.\r\n\r\nTuhaf görünüşlü yabancı, bir tipi sırasında Iping Köyü’ne gelir. Garip hareketleri, giyinişi, suratının tamamının bandajlar içinde olması ve gözlüklerini bir an olsun gözünden çıkarmaması köy sakinleri tarafından kimi zaman şüpheyle, kimi zaman düşmanca karşılanır. Kısa süre içerisinde hakkındaki dedikodular giderek yoldan çıkan bir dizi olaya neden olacaktır.",
                                ImageUrl = "images/books/gorunmez-adam.jpg",
                                Stock = 19,
                                Price = 55,
                                PageCount = 139,
                                EditionNumber = 6,
                                EditionYear = 2021,
                                IsActive = true,
                                IsHome = false,
                                AuthorId = 3,
                            },
                            new Book
                            {
                                Id = 8,
                                Name = "Hayvan Çiftliği",
                                Properties = "Hayvan Çiftliği ya da orijinal ismiyle \"Animal Farm\", Eric Arthur Blair yani kitaplarını yazarken kullandığı ismiyle George Orwell’in mecazi bir dille kaleme aldığı ve ilk kez 1945 yılında Birleşik Krallık’ta yayımlan, 1996 tarihinde de Retro Hugo Ödülü’nü kazanan, fabl tarzındaki siyasi hiciv romanıdır. Stalinizmin eleştirildiği \"Hayvan Çiftliği\" romanı, SSCB’nin kuruluşundan itibaren meydana gelen önemli olayları kara mizah yoluyla anlatmaktadır. Yayımlandığında büyük bir ilgi uyandıran bu eser 1954 ve 1999 yıllarında filme uyarlanmış, Pink Floyd’un Animals albümüne ilham olmuştur. George Orwell’in tarihsel bir gerçeği eleştirdiği “Hayvan Çiftliği” eseri, Türkçeye ilk kez 1954 yılında çevrilmiştir.\r\n\r\nGeorge Orwell (25 Haziran 1903 - 21 Ocak 1950), asıl ismi Eric Arthur Blair olan ve oluşturduğu Big Brother (Büyük Birader) kavramı ile tanınan, gazetecilik ve eleştirmenlik de yapmış 20. yüzyıl İngiliz edebiyatının önde gelen yazarıdır. Kaleme aldığı eserleri birçok dile çevrilen, çağdaş klasikler arasında gösterilen George Orwell, “Hayvan Çiftliği” eserinde bir devrimin trajedisini dile getirmiştir.",
                                ImageUrl = "images/books/hayvan-ciftligi.jpg",
                                Stock = 26,
                                Price = 45,
                                PageCount = 99,
                                EditionNumber = 14,
                                EditionYear = 2021,
                                IsHome = true,
                                AuthorId = 7,
                            },
                            new Book
                            {
                                Id = 9,
                                Name = "İnsan Geleceğini Nasıl Kurar",
                                Properties = "Bir hedef bulacaksınız, o uğurda çalışacaksınız, hedefinizi gerçekleştirmek için bir yol arayacaksınız, yol yoksa da o yolu yapacaksınız. Bir defa geçtiğiniz yoldan da bir daha geri dönmeyeceksiniz. Çünkü lüzumsuz geri dönüş başarısızlıktır, tekrara düşmektir, ufku kapatmaktır. Hedef bulmak, yol açmak ve aynı yoldan geri dönmemek… Hayattaki gayemiz budur.",
                                ImageUrl = "images/books/insan-gelecegini-nasil-kurar.jpg",
                                Stock = 13,
                                Price = 119,
                                PageCount = 420,
                                EditionNumber = 2,
                                EditionYear = 2022,
                                IsActive = true,
                                IsHome = true,
                                AuthorId = 1,
                            },
                            new Book
                            {
                                Id = 10,
                                Name = "İnsanlar",
                                Properties = "*Bu satırları okuyanlarınızın büyük çoğunluğunun, insanların bir mitten ibaret olduğuna inandığını biliyorum ama ben size onların gerçekten var olduklarını bildirmek üzere buradayım. Bilmeyenler için söyleyeyim, insan dediğimiz şey orta zekâlı ve iki ayaklı bir yaşam formu; evrenin çok ıssız bir köşesinde yer alan küçük ve sulu bir gezegende, büyük ölçüde yanılsamalarla dolu bir varoluş sürdürüyor.*\r\n\r\nYağmurlu bir akşamda Profesör Andrew Martin, önce dünyanın en büyük matematik bilmecesini çözmeyi başarıyor, ardından sırra kadem basıyor. Nihayet bir yol kenarında çırılçıplak halde bulunduğunda, kıyafetsizlikten daha ciddi bir meselesi olduğu ortaya çıkıyor: Andrew Martin artık insanlardan tiksiniyor; görünüşlerinden de yiyip içtiklerinden de bitmeyen şiddet ve savaş arzularından da... Yabancı bir tür arasında kaybolmuş hissediyor kendini. Sevgi ve aile kavramları onda şaşırtıcı bir ilgi uyandırsa da tüm sakinlerinden nefret ediyor bu gezegenin. Newton hariç... Ama o da bir köpek işte...",
                                ImageUrl = "images/books/insanlar.jpg",
                                Stock = 40,
                                Price = 75,
                                PageCount = 216,
                                EditionNumber = 4,
                                EditionYear = 2022,
                                IsActive = true,
                                IsHome = true,
                                AuthorId = 8,
                            },
                            new Book
                            {
                                Id = 11,
                                Name = "Kadınlar Ülkesi",
                                Properties = "Charlotte Perkins Gilman yaşadığı dönemin önde gelen hümanistlerinden ve kadın hakları savunucularından biri olmasının yanında feminist edebiyatın en önemli erken dönem temsilcilerinden. Yazıldıktan yaklaşık 65 sene sonra kitap formatında yayımlanabilen Kadınlar Ülkesi ise feminist ütopyanın ilk örneklerinden.\r\n\r\nBirinci Dünya Savaşı’nın arifesinde üç Amerikalı erkek pek fazla insanın bulunmadığı, ücra bir yerde, tamamen kadınlardan oluşan bir topluluğa denk gelir. Gözlerine inanamayan kâşifler bu topraklarda erkeklerin de olması gerektiğine dair inançlarıyla araştırmalarına başlar.\r\n\r\nÇok geçmeden bu gizemli ülke ile ilgili gerçekler bir bir açığa çıksa da misafirlerin merakı giderilmenin aksine daha da artar ve Kadınlar Ülkesi’nin yönetim biçiminden inançlarına, kültüründen ekonomisine ve hatta anneliğe kadar pek çok konuda bilgi sahibi olmaya ve toplumsal cinsiyet rollerini sorgulamaya başlarlar.\r\n\r\nToplumsal roller cinsiyete göre belirlenebilir mi? Kadınlık ve erkeklik değişmez kavramlar mıdır?\r\n\r\nKadınlar Ülkesi, ataerkilliğe verilmiş nüktedan bir yanıt.",
                                ImageUrl = "images/books/kadinlar-ulkesi.jpg",
                                Stock = 25,
                                Price = 65,
                                PageCount = 315,
                                EditionNumber = 3,
                                EditionYear = 2022,
                                IsActive = true,
                                IsHome = true,
                                AuthorId = 2,
                            },
                            new Book
                            {
                                Id = 12,
                                Name = "Kara Delikler",
                                Properties = "2016 yılının BBC Reith derslerinde Stephen Hawking, bütün bir ömür süren araştırmalarını on beş dakika içinde aktarma gibi gerçekten zorlu bir meydan okumayı kabul etti. Bu çok kısa süren derslerde Hawking, evrenin gizemlerini ortaya sererken, kara delikleri anladığımız takdirde uzayzamanın sırlarına erişebileceğimizi vurguluyor.",
                                ImageUrl = "images/books/kara-delikler.jpg",
                                Stock = 4,
                                Price = 90,
                                PageCount = 439,
                                EditionNumber = 4,
                                EditionYear = 2022,
                                IsHome = false,
                                AuthorId = 6,
                            },
                            new Book
                            {
                                Id = 13,
                                Name = "Kumarbaz",
                                Properties = "\"Kumarbaz\" tüm varlığını, gücünü, yeteneğini rulet masasına yatıran; bilinmeyene, tehlikeye özlem duyan; hem başkaldıran, hem korkan; içinde binbir türlü çelişki barındıran kumara tutkun bir adamın romanı. Kendisi de bir süre kumarın tutsağı olan Dostoyevski, belki hiçbir romanına kendi yaşamından bu kadar çok şey katmamıştır. Hiçbir şey yazmasaydı bile \"Kumarbaz\" onu Dostoyevski yapmaya yeterdi.",
                                ImageUrl = "images/books/kumarbaz.jpg",
                                Stock = 10,
                                Price = 85,
                                PageCount = 417,
                                EditionNumber = 14,
                                EditionYear = 2020,
                                IsHome = false,
                                AuthorId = 10,
                            },
                            new Book
                            {
                                Id = 14,
                                Name = "Nebo'nun Mavi Kitabı",
                                Properties = " “Son” denilen nükleer felaketten sonra anne ve oğul arasında kurulan geçmişi ve o günü kapsayan ancak sınırları olan bir ilişkinin kapısından içeri girerken; ilacın, elektriğin, kalabalığın, cep telefonlarının ve günümüze ait hiçbir gerecin olmadığı bir dünyaya adım atacaksınız. Hayatta kalma güdüsü, yalnızlık\r\nve ölüm temalarıyla öne çıkan, Galceye özgü akıcı ve güçlü tasvirlerle ilerleyen Nebo’nun Mavi Kitabı; günümüz insanının doğadan ne kadar kopuk yaşadığını da  gözler önüne seriyor.\r\n \r\nManon Steffan Ros “ekolojik distopya” temeline dayanan,\r\nödüllü ve çoksatan romanında, insanın hayatta kalma içgüdüsüyle birlikte, çağdaş dünya düzenini de sorguluyor.",
                                ImageUrl = "images/books/nebonun-mavi-kitabi.jpg",
                                Stock = 29,
                                Price = 115,
                                PageCount = 582,
                                EditionNumber = 12,
                                EditionYear = 2021,
                                IsActive = true,
                                IsHome = true,
                                AuthorId = 11,
                            },
                            new Book
                            {
                                Id = 15,
                                Name = "Nutuk",
                                Properties = "Ey Türk gençliği! Birinci görevin, Türk bağımsızlığını, Türk Cumhuriyeti’ni sonsuza kadar korumak ve savunmaktır. Varlığının ve geleceğinin tek temeli budur. Bu temel, senin en değerli hazinendir. Gelecekte de, seni bu hazineden yoksun bırakmak isteyecek iç ve dış düşmanların olacaktır. Bir gün, bağımsızlık ve cumhuriyeti savunma zorunluluğuna düşersen, göreve atılmak için, içinde bulunacağın durumun olanak ve koşullarını düşünmeyeceksin!",
                                ImageUrl = "images/books/nutuk.jpg",
                                Stock = 34,
                                Price = 65,
                                PageCount = 332,
                                EditionNumber = 36,
                                EditionYear = 2022,
                                IsHome = true,
                                AuthorId = 12,
                            },
                            new Book
                            {
                                Id = 16,
                                Name = "Hayvanlardan Tanrılara Sapiens",
                                Properties = "Çoğu çalışma insanlığın serüvenini ya tarihi ya da biyolojik bir yaklaşımla ele alır, ancak Harari 70 bin yıl önce gerçekleşen Bilişsel Devrim’le başlattığı bu kitabında gelenekleri yerle bir ediyor. İnsanların küresel ekosistemde oynadıkları rolden imparatorlukların yükselişine ve modern dünyaya kadar pek çok konuyu irdeleyen Sapiens, tarihle bilimi bir araya getirerek kabul görmüş anlatıları yeniden ele alıyor. Harari ayrıca geleceğe bakmaya da zorluyor okuru. Yakın zamanda insanlar, dört milyar yıldır yaşama hükmeden doğal seçilim yasalarını esnetmeye başladılar. Artık sadece dünyayı değil, kendimizi ve diğer canlıları tasarlama becerisi de kazandık. Peki bu bizi nereye götürüyor, bizi neye dönüştürebilir?",
                                ImageUrl = "images/books/hayvanlardan-tanrilara-sapiens.jpg",
                                Stock = 32,
                                Price = 160,
                                PageCount = 639,
                                EditionNumber = 11,
                                EditionYear = 2022,
                                IsActive = true,
                                IsHome = true,
                                AuthorId = 13,
                            },
                            new Book
                            {
                                Id = 17,
                                Name = "Savaş ve Barış",
                                Properties = "Savaş ve Barış, gençlere dünya klasiklerini tanıtarak, onları bu eserleri okumaya yönlendirmek amacıyla hazırladığımız Arkadaş Dünya Klasikleri Gençlik Özet Dizisi’nin üçüncü kitabıdır. Genç okurların kolayca anlayarak beğeniyle okuyabileceği yalın bir Türkçeyle orijinal metinden uyarlanmıştır.\r\n\r\nTolstoy’un başyapıtı olan Savaş ve Barış, dünya edebiyatının en önemli eserlerindendir ve Milli Eğitim Bakanlığınca 100 Temel eser kapsamında öğrencilere tavsiye edilmiştir.",
                                ImageUrl = "images/books/savas-ve-baris.jpg",
                                Stock = 14,
                                Price = 85,
                                PageCount = 239,
                                EditionNumber = 12,
                                EditionYear = 2022,
                                IsHome = true,
                                AuthorId = 14,
                            },
                            new Book
                            {
                                Id = 18,
                                Name = "Zamanı Durdurmanın Yolları",
                                Properties = "Kaç Ömür Gerek, Yaşamayı Öğrenmek İçin?\r\n\r\nTom Hazard’ın tehlikeli bir sırrı var. 41 yaşında sıradan bir tarih öğretmeni gibi göru¨nse de nadir rastlanan bir hastalık yu¨zu¨nden aslında yu¨zyıllardır hayatta. Shakespeare’le aynı sahnede yer almış, Kaptan Cook’la açık denizleri fethetmiş, Fitzgerald’larla içki içmiş. Ama şimdi, tek istediği normal bir hayat su¨rmek. Kimliğini değiştirmeye devam ettiği su¨rece geçmişini geride bırakabilir ve hayatta kalabilir.\r\n\r\nYapmaması gereken tek bir şey var, aşık olmak.",
                                ImageUrl = "images/books/zamani-durdurmanin-yollari.jpg",
                                Stock = 5,
                                Price = 80,
                                PageCount = 329,
                                EditionNumber = 3,
                                EditionYear = 2021,
                                IsActive = true,
                                IsHome = true,
                                AuthorId = 8,
                            },
                            new Book
                            {
                                Id = 19,
                                Name = "Gece Yarısı Kütüphanesi",
                                Properties = "*Yaşamla ölüm arasında bir kütüphane var,* dedi. *Bu kütüphanedeki raflar sonsuza kadar gider.  Her kitap yaşamış olabileceğin başka bir hayatı yaşama şansını sunar sana. Farklı seçimler yapmış olsan, şu an nasıl bir hayatın olacağını görürsün…\r\nPişmanlıklarını telafi etme şansın olsaydı, bazı konularda farklı davranır mıydın?*\r\n\r\nNora Seed berbat halde. Kedisi öldü. İşinden kovuldu. Abisi onunla konuşmuyor. Kimsenin ona ihtiyacı yok. Art arda alınmış kötü kararların sonucunda bir kütüphanede buluyor kendini. Zamanın hiç akmadığı bir gece yarısı kütüphanesinde, sonsuz sayıda kitabın ortasında... Kitapların her birinde Nora’nın farklı bir hayatı yazılı. Başka kararlar verseydi yaşamış olabileceği hayatlar.\r\n\r\nFarklı kariyerler, farklı eşler, farklı arkadaşlar, farklı şehirler arasında gidip gelen Nora’nın aklı sorularla doluyor. Mutluluk sadece önemli sandığımız seçimlerde mi gizli? Yanlış giden her detayın sorumlusu gerçekten biz miyiz? Hayatı yaşanılır kılan ne? Yanlış bir karar insanın tüm hayatına mal olabilir mi?",
                                ImageUrl = "images/books/gece-yarisi-kutuphanesi.jpg",
                                Stock = 32,
                                Price = 100,
                                PageCount = 512,
                                EditionNumber = 2,
                                EditionYear = 2022,
                                IsActive = true,
                                IsHome = true,
                                AuthorId = 8,
                            },
                            new Book
                            {
                                Id = 20,
                                Name = "Sıcak Kafa",
                                Properties = "Dünyayı pençesine almış bir delilik salgını...\r\n\r\nKonuşma yoluyla, zihinden zihne bulaşarak yayılan bir hastalık...\r\n\r\nYıkılmanın eşiğine gelmiş uygarlık...\r\n\r\nVaktiyle bu amansız hastalık üzerine çalışmış eski dilbilimci Murat Siyavuş, umutsuzluk içinde annesinin evine sığınmıştır. Acımasız bir devlet kurumunun peşine düştüğünü öğrenince, evden çıkıp hayata karışmak ve salgının dönüştürdüğü dünyayla yüzleşmek zorunda kalır.",
                                ImageUrl = "images/books/sicak-kafa.jpg",
                                Stock = 40,
                                Price = 90,
                                PageCount = 285,
                                EditionNumber = 2,
                                EditionYear = 2023,
                                IsHome = true,
                                IsActive = true,
                                AuthorId = 15,
                            });


        }
    }
}
