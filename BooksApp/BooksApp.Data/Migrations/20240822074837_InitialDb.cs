using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BooksApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    About = table.Column<string>(type: "TEXT", nullable: true),
                    PhotoUrl = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    IsHome = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Properties = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    Summary = table.Column<string>(type: "TEXT", nullable: true),
                    Stock = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "real", nullable: false),
                    PageCount = table.Column<int>(type: "INTEGER", nullable: false),
                    EditionYear = table.Column<int>(type: "INTEGER", nullable: false),
                    EditionNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    IsHome = table.Column<bool>(type: "INTEGER", nullable: false),
                    AuthorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookCategories",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategories", x => new { x.BookId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_BookCategories_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BookId = table.Column<int>(type: "INTEGER", nullable: false),
                    CartId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    BookId = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "About", "CreatedDate", "FirstName", "IsActive", "LastName", "ModifiedDate", "PhotoUrl" },
                values: new object[,]
                {
                    { 1, "Bu yazar, yazarı silinmiş kitaplar için kullanılmaktadır.", new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(3380), "Genel", false, "Yazar", new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(3410), "default-profile.jpg" },
                    { 2, "Charlotte Perkins Gilman, ya da Charlotte Perkıns Stetson, önde gelen Amerikalı feminist, sosyolog, romancı, kısa hikâye, şiir ve kurmaca olmayan metinler yazarı ve sosyal reform eğitmeni. Ütopik bir feministti ve alışılmışın dışındaki konsept ve yaşam tarzından dolayı gelecek nesillere örnek teşkil etti.", new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(3420), "Charlotte Parkins", false, "Gilman", new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(3420), "charlotte-parkins-gilman.jpg" },
                    { 3, "Herbert George Wells ya da daha çok tanındığı adla H. G. Wells, Dünyaların Savaşı, Görünmez Adam, Dr. Moreau'nun Adası ve Zaman Makinesi adlı bilimkurgu romanlarıyla tanınan ama neredeyse edebiyatın her dalında birçok eser vermiş olan İngiliz yazardır. Sosyalist olduğunu açıkça söyleyen H.G. Wells'in çoğu eserinde önemli ölçüde siyasi ve sosyal yorumlar bulunmaktadır. Jules Verne gibi gelecekteki teknolojik gelişmeleri anlattığı kitaplarıyla bilimkurgu dalının öncülerinden hatta yaratıcılarından sayılmaktadır.", new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(3420), "Herbert George", false, "Wells", new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(3420), "herbert-george-wells.jpg" },
                    { 4, "Okula Essex'de gitti. Cambridge'de St. Johns College'e devam ederken Footlights tiyatro kulübünde görev aldı. Pek çok iş denedi. Hastanede hizmetlilik, inşaat işçiliği, kümes temizlikçiliği, bir Arap aile için korumalık yaptı. Daha sonra BBC'de Dr. Who dizisinde yapımcılık ve senaryo editörlüğü yaptı. Dr. Who'nun üç bölümünü yazdı. Monty Pyton grubundan Graham Chapman ile birlikte çalıştı.\r\n\r\nBBC'de yayımlanan The Hitchhiker's Guide to the Galaxy (Otostopçunun Galaksi Rehberi) adlı radyo oyunu ile ünlü oldu. Oyun, kitap olarak da yayımlandı. Bu radyo oyunundan aynı adlı bir bilgisayar oyunu da üretti. Daha sonra Bureaucracy ve Starship Titanic adlı bilgisayar oyunları üzerinde de çalıştı. Starship Titanic sonradan bir kitap olarak da yayımlandı, ancak Adams'ın hem oyun hem de kitap üzerinde çalışacak zamanı olmadığından kitabı Terry Jones yazdı. İleri derecede bir Beatles hayranıydı.", new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(3420), "Douglas", false, "Adams", new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(3420), "douglas-adams.jpg" },
                    { 5, "Ray Douglas Bradbury korku ve bilimkurgu tarzlarında yazan Amerikalı bir yazardır. En çok bilinen kitapları 1950'de yazdığı kısa hikâyeler kitabı ve bir roman olan The Martian Chronicles ve 1953'te yazdığı başyapıtı olan Fahrenheit 451'dir. Los Angeles'ta 91 yaşında öldü.", new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(3420), "Ray Douglas", false, "Bradbury", new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(3420), "ray-douglas-bradbury.jpg" },
                    { 6, "Japon yazardır. Tsugaru Yarımadası’nın merkezi yakınlarında küçük bir kasaba olan Kanagi’de doğdu. Asıl adı Şuuci Tsuşima'dır. Ailedeki siyasetçi olma geleneğine karşı çıkarak, yazar olmaya karar verdi. Yirmi yaşında Tokyo Üniversitesi Fransız Edebiyatı Bölümü’ne kaydını yaptırdı. Hayatının büyük bölümünde esrarkeş, veremli, asabi, kavgacı ve alkolik biri olarak birkaç kez intihar etmeye kalkıştı. Dazai, 1948’de metresiyle birlikte suya atlayarak intihar etti. Ölümünün üzerinden bunca sene geçmesine rağmen, Japonya’da hâlâ ilgi gören bir yazardır. Eserlerinin çoğunluğunda yalnızlığı ele alır. Yalnızlık ön planda iken insanın arayış içinde olması ve insanın varoluşunu, içe dönüklüğünü yani temelde insanı ele alır.", new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(3430), "Osamu", false, "Dazai", new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(3430), "osamu-dazai.jpg" },
                    { 7, "Eric Arthur Blair veya daha bilinen takma adıyla George Orwell 20. yüzyıl İngiliz edebiyatının önde gelen kalemleri arasında yer alan İngiliz romancı, gazeteci ve eleştirmen. En çok, dünyaca ünlü Bin Dokuz Yüz Seksen Dört adlı romanı ve bu romanda yarattığı Big Brother kavramı ile tanınır. ", new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(3430), "George", false, "Orwell", new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(3430), "george-orwell.jpg" },
                    { 8, "Matt Haig bir İngiliz yazar ve gazetecidir. Çocuklar ve yetişkinler için, genellikle spekülatif kurgu türünde hem kurgu hem de kurgu olmayan kitaplar yazmıştır. Haig, çocuklar ve yetişkinler için hem kurgu hem de kurgu olmayan kitapların yazarıdır. Kurgusal olmayan çalışması Reasons to Stay Alive , Sunday Times'ın en çok satanlar listesinde bir numaraydı ve 46 hafta boyunca Birleşik Krallık'ta ilk 10'da yer aldı. En çok satan çocuk romanı 'Noel Baba ve Ben' şu anda filme uyarlanıyor, yapımcılığını StudioCanal ve Blueprint Pictures üstleniyor.", new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(3430), "Matt", false, "Haig", new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(3430), "matt-haig.jpeg" },
                    { 9, "Stephen William Hawking, İngiliz fizikçi, kozmolog, astronom, teorisyen ve yazar. Stephen Hawking, Einstein'dan bu yana dünyaya gelen en parlak teorik fizikçi olarak kabul edilmektedir. 12 onur derecesi almıştır. 1982'de CBE ile ödüllendirilmiş, bundan başka birçok madalya ve ödül almıştır. ", new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(3430), "Stephen William", false, "Hawking", new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(3430), "stephen-william-hawking.jpg" },
                    { 10, "Fyodor Mihayloviç Dostoyevski, Rus roman yazarıdır. Çocukluğunu sarhoş bir baba ve hasta bir anne arasında geçiren Dostoyevski, annesinin ölümünden sonra Petersburg'daki Mühendis Okulu'na girdi. Babasının ölüm haberini de burada aldı. Okulu başarıyla bitirdikten sonra istihkâm bölüğüne girdi.", new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(3430), "Fyodor", false, "Dostoyevski", new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(3440), "fyodor-dostoyevski.jpg" },
                    { 11, "Manon Steffan Ros, Galli bir romancı, oyun yazarı, oyun yazarı, senarist ve müzisyendir. Tamamı Galce olan yirmiden fazla çocuk kitabı ve yetişkinler için üç romanın yazarıdır. Ödüllü romanı Blasu, The Seasoning başlığı altında İngilizce'ye çevrildi.", new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(3440), "Manon Steffan", false, "Ros", new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(3440), "manon-steffan-ros.jpg" },
                    { 12, "Mustafa Kemal Atatürk, Türk asker ve devlet adamıdır. Türk Kurtuluş Savaşı'nın başkomutanı, Türkiye Cumhuriyeti'nin kurucusu ve ilk cumhurbaşkanıdır.Atatürk; çağdaş, ilerici ve laik bir ulus devlet kurmak için siyasal, ekonomik ve kültürel alanlarda sekülarist ve milliyetçi nitelikte yenilikler gerçekleştirdi. Yabancılara tanınan ekonomik ayrıcalıklar kaldırıldı ve onlara ait üretim araçları ve demir yolları millîleştirildi. Tevhîd-i Tedrîsât Kanunu ile eğitim, Türk hükûmetinin denetimine girdi. Seküler ve bilimsel eğitim esas alındı. Binlerce yeni okul yapıldı. İlköğretim ücretsiz ve zorunlu duruma getirildi. Yabancı okullar devlet denetimine alındı. Köylülerin sırtına yüklenen ağır vergiler azaltıldı. Erkeklerin serpuşlarında ve giysilerinde bazı değişiklikler yapıldı. Takvim, saat ve ölçülerde değişikliklere gidildi. Mecelle kaldırılarak yerine seküler Türk Kanunu Medenisi yürürlüğe konuldu. Kadınların sivil ve siyasal hakları pek çok Batı ülkesinden önce tanındı. Çok eşlilik yasaklandı. Kadınların tanıklığı ve miras hakkı, erkeklerinkiyle eşit duruma getirildi. Benzer olarak, dünyanın çoğu ülkesinden önce olarak Türkiye'de kadınlara ilkin yerel seçimlerde (1930), sonra genel seçimlerde (1934) seçme ve seçilme hakkı tanındı. Ceza ve borçlar hukukunda seküler yasalar yürürlüğe konuldu. Sanayi Teşvik Kanunu kabul edildi. Toprak reformu için çabalandı. Arap harfleri temelli Osmanlı alfabesinin yerine Latin harfleri temelli yeni Türk alfabesi kabul edildi. Halkı okuryazar kılmak için eğitim seferberliği başlatıldı. Üniversite Reformu gerçekleştirildi. Birinci Beş Yıllık Sanayi Planı yürürlüğe konuldu. Sınıf ve durum ayrımı gözeten lakap ve unvanlar kaldırıldı ve soyadları yürürlüğe konuldu. Bağdaşık ve birleşmiş bir ulus yaratılması için Türkleştirme siyaseti yürütüldü.", new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(3440), "Mustafa Kemal", false, "Atatürk", new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(3440), "mustafa-kemal-ataturk.jpg" },
                    { 13, "Yuval Noah Harari, İsrailli tarihçi ve yazardır. İsrailli bir kamu entelektüeli, tarihçi ve Kudüs İbrani Üniversitesi Tarih Bölümü'nde profesör. Popüler bilim en çok satan kitapları Sapiens: İnsanlığın Kısa Tarihi, Homo Deus: Yarının Kısa Tarihi ve 21.Yüzyıl İçin 21 Ders kitabının yazarıdır.", new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(3440), "Yuval Noah", false, "Harari", new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(3440), "yuval-noah-harari.jpg" },
                    { 14, "Rus yazar ve asker. Dünya tarihinin en iyi yazarlarından birisi olarak bilinmektedir. Tolstoy, zengin bir ailenin çocuğu olarak Rusya'nın Tula şehrindeki Yasnaya Polyana adlı bir konakta doğdu. Çok küçük yaşlarında önce annesini, sonra babasını kaybetti; yakınlarının elinde büyüdü. Çocukluğundan beri gerçekleri incelemeye karşı büyük bir ilgisi vardı. Fransızcasını ilerletmiş, Voltaire'i ve Jean-Jacques Rousseau'yu okumuş, bu iki yazarın kuvvetli etkisinde kalmıştı. Daha sonraları Yasnaya Polyana'ya dönen Tolstoy, yoksul köylülerin arasına katıldı. İlk eseri olan 'Çocukluk'u bu sıralarda yazdı.", new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(3440), "Lev Nikolayeviç", false, "Tolstoy", new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(3440), "lev-nikolayevic-tolstoy.jpg" },
                    { 15, "Afşin Kum Kimdir? Afşin Kum, 1972 İzmir doğumlu. Boğaziçi Üniversitesinde bilgisayar mühendisliği, Bilgi Üniversitesinde sinema-televizyon öğrenimi gördü. 1997'den bu yana çeşitli kurumlarda yazılımcı ve yönetici olarak çalıştı.", new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(3450), "Afşin", false, "Kum", new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(3450), "afsin-kum.jpg" },
                    { 16, "İlber Ortaylı, Türk tarihçi, akademisyen ve yazar. Türk Tarih Kurumu Şeref Üyesidir. Ortaylı, Uluslararası Osmanlı Etütleri Komitesi yönetim kurulu üyesi ve Avrupa İranoloji Cemiyeti ve Avusturya-Türk Bilimler Forumu üyesidir.", new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(3410), "İlber", false, "Ortaylı", new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(3410), "ilber-ortayli.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "IsHome", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(7060), "Genel kategorisine giren ve kategorisiz kalan kitaplar", true, true, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(7060), "Genel" },
                    { 2, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(7070), "Bilim Kurgu Kitapları", true, true, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(7070), "Bilim Kurgu" },
                    { 3, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(7070), "Bilim ve Mühendislik Kitapları", true, true, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(7070), "Bilim ve Mühendislik" },
                    { 4, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(7070), "Distopya Kitapları", true, true, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(7070), "Distopya" },
                    { 5, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(7070), "Dünya Tarihi Kitapları", true, true, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(7080), "Dünya Tarihi" },
                    { 6, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(7080), "Edebiyat Kitapları", true, false, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(7080), "Edebiyat" },
                    { 7, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(7080), "Fizik Kitapları", true, false, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(7080), "Fizik" },
                    { 8, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(7080), "İnsan ve Toplum Kitapları", true, false, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(7080), "İnsan ve Toplum" },
                    { 9, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(7080), "Kişisel Kitapları", true, false, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(7080), "Kişisel Gelişim" },
                    { 10, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(7090), "Popüler Bilim Kitapları", true, false, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(7090), "Popüler Bilim" },
                    { 11, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(7090), "Romanlar", true, false, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(7090), "Roman" },
                    { 12, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(7090), "Rus Edebiyatı Kitapları", true, false, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(7090), "Rus Edebiyatı" },
                    { 13, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(7090), "Söyleşi Kitapları", true, false, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(7090), "Söyleşi" },
                    { 14, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(7090), "Tarih Kitapları", true, false, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(7100), "Tarih" },
                    { 15, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(7100), "Türkiye Tarihi Kitapları", true, false, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(7100), "Türkiye Tarihi" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CreatedDate", "EditionNumber", "EditionYear", "ImageUrl", "IsActive", "IsHome", "ModifiedDate", "Name", "PageCount", "Price", "Properties", "Stock", "Summary" },
                values: new object[,]
                {
                    { 1, 6, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(6330), 4, 2022, "images/books/ogrenci-kiz.jpg", true, false, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(6340), "Öğrenci Kız", 439, 90m, "'… İyi geceler. Ben prensi olmayan bir Külkedisi’yim. Tokyo’nun neresinde olduğumu biliyor musunuz? Beni bir daha görmeyeceksiniz.'\r\n\r\nYirminci yüzyıl Japon edebiyatının önde gelen yazarlarından, sıradışı hayatıyla da meşhur Osamu Dazai, savaş sonrası Japonya’sının edebiyat çevrelerince tanınmasını sağlayan, kaleme aldığı ilk eserlerden Öğrenci Kız’da Tokyo’nun banliyösünde yaşayan bir genç kızın on iki saatini ironik ve hünerli bir üslupla kaleme alıyor.\r\n\r\nİsimsiz genç kızın, nefret ettiği sabahlardan birine gözlerini açmasıyla başlayıp gece yatağa yattığı anda biten kısa romanda Dazai, artık yitmiş bir dönemin yaygın toplumsal normlarına karşı bireyin duyduğu huzursuzluğu, gençliğin ilk buhranları ve asiliğiyle birleştiriyor. \r\n\r\nÖğrenci Kız, Dazai’nin sonraki çoğu eserinde yer bulacak aykırı kişiliklerin ilk örneklerinden birini görmeyi ve yazarın zihninin derinliklerine yakından bakmayı sağlayacak bir klasik.", 4, null },
                    { 2, 13, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(6350), 12, 2021, "images/books/homo-deus-yarinin-kisa-bir-tarihi.jpg", true, false, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(6350), "Homo Deus: Yarının Kısa Bir Tarihi", 308, 60m, "Hayvanlardan Tanrılara: Sapiens kitabıyla insan türünün dünyaya nasıl egemen olduğunu anlatan Harari, Homo Deus’ta çarpıcı öngörüleriyle yarınımızı ele alıyor. İnsanlığın ölümsüzlük, mutluluk ve tanrısallık peşindeki yolculuğunu bilim, tarih ve felsefe ışığında incelediği bu çalışmasında, insanın bambaşka bir türe, Homo deus’a evrildiği bir gelecek kurguluyor.\r\n\r\nYola *önemsiz bir hayvan* olarak çıkan Homo sapiens, tanrılar katına ulaşmak uğruna kendi sonunu mu hazırlıyor?\r\n\r\nHomo sapiens nasıl oldu da evrenin insan türünün etrafında döndüğünü iddia eden hümanist öğretiye inandı?\r\n\r\nBu öğreti gündelik yaşantımızı, sanatımızı ve en gizli tutkularımızı nasıl şekillendiriyor?\r\n\r\nİnsanı inekler, tavuklar, şempanzeler ve bilgisayar programlarının tümünden ayıran yüksek zekası ve kudreti dışında herhangi bir alametifarikası var mı?\r\n\r\nTarih boyunca benzeri görülmemiş kazanımlar elde etmemize rağmen mutluluk seviyemizde neden kayda değer bir artış olmadı?\r\n\r\n*Tüm bunları anlamak için tek yapmamız gereken geriye dönüp bakmak ve Homo sapiens’in aslında ne olduğunu, hümanizmin nasıl dünyaya hakim bir din hâline geldiğini ve hümanizm rüyasını gerçekleştirmeye çalışmanın aslında neden insanlığın kendi sonunu getireceğini incelemektir. İşte bu kitabın temel meselesi budur.*\r\n\r\n*Okurken hem eğlenecek hem de çok şaşıracaksınız. Her şeyin ötesinde, kendinizi daha önce hiç düşünmediğiniz şeyleri düşünürken bulacaksınız.*\r\n\r\n- Daniel Kahneman, Hızlı ve Yavaş Düşünme’nin yazarı\r\n\r\n*Homo Deus’u okuduğunuzda uzun ve zorlu bir yolculuğun ardından vardığınız bir uçurumun kenarında durduğunuzu hissedeceksiniz. Yolculuğun artık bir önemi kalmayacak, çünkü bir sonraki adımınızı engin bir boşluğa atacaksınız.*", 28, null },
                    { 3, 3, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(6360), 2, 2019, "images/books/efendi-uyaniyor.jpg", true, true, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(6360), "Efendi Uyanıyor", 417, 85m, "Edebiyat tarihinin ilk distopyası olan Efendi Uyanıyor bir 19. yy. centilmeni olan Graham’ın öyküsünü anlatıyor. Nadir görülen bir uykusuzluk hastalığından mustarip olan Graham en sonunda uyumayı başarır. Ne var ki bu kez 200 yıllık trans halinde bir uykuya dalacaktır. Uyandığında ise, banka hesabına işleyen faizler sayesinde dünyanın en zengin ve en güçlü adamı olduğunu öğrenir. O artık bambaşka ve hiç tanımadığı bir dünyada yaşamaktadır. Dünyanın tek efendisi ve sahibi odur! Graham uyuduğu sırada servetini idare eden Konsey, tüm gezegene hüküm süren son derece karanlık ve acımasız bir sistem kurmuştur. Oysa insanların bir kurtarıcı olarak gördüğü Graham’dan beklenen, toplumu bu korkunç despotlardan kurtarmasıdır. Bir distopya klasiği ve politik bilimkurgu türünün en iyi örneklerinden biri olan Wells’in bu başyapıtı, okuru fantastik bir maceraya sürüklüyor. Günümüzden 114 yıl önce yazılmış olmasına rağmen global şirketlerin yükselişi, uçakların seyahat amaçlı kullanımı ve birçok teknolojik gelişmeyi zamanının çok ötesinde başarılı bir şekilde tahmin etmiş olması şaşkınlık yaratıyor. Geleceğe dair yerinde tahminlerinin yanı sıra toplumsal adaletsizlikle boğuşan bir dünyayı tasvir eden Efendi Uyanıyor, distopya, bilim kurgu ve politik roman hayranları için mükemmel bir seçim. \"Wells’in en çarpıcı yönü, edebiyatın klişeleşmiş yanlarına yeni bir soluk getirip canlılık katması...\" -The Spectator- \"Politik bilim-kurgu ve distopya severler için kaçırılmaması gereken bir eser...\" -Times Literary Supplement-", 39, null },
                    { 4, 4, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(6360), 9, 2018, "images/books/evrenin-sonundaki-restoran.jpg", true, false, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(6360), "Evrenin Sonundaki Restoran", 444, 90m, "Milliways Öğlen Menüsü, editörünün iznini alarak, Otostopçunun Galaksi Rehberi’nden bir pasaj aktarmaktaydı. Pasaj şöyleydi: Belli başlı her galaktik uygarlığın tarihi üç ayrı ve fark edilebilir aşamadan geçme eğilimindedir. Bu aşamalar Hayatta Kalma, Sorgulama ve İncelikli Düşünmedir; bir başka deyişle Nasıl, Neden ve Nerede aşamaları olarak da bilinirler. Örneğin, ilk aşama Nasıl Yiyebiliriz? sorusuyla, ikinci aşama Neden Yiyoruz? sorusuyla, üçüncü aşamaysa Öğle Yemeğini Nerede Yiyelim? sorusuyla tanımlanmaktadır.\r\n\r\nMenü daha sonra Milliways’in, Evrenin Sonundaki Restoran’ın bu üçüncü soruya çok uygun ve seçkin bir cevap olduğunu söylüyordu.\r\n\r\nAltın Kalp’in yolcuları sabahtan itibaren altı tamamen imkânsız işi başarmışken, günü gerçekten layık olduğu bir şekilde taçlandırmaya karar vermişlerdi: Gidilebilecek en iyi restoranda, seyredilebilecek en iyi manzaraya karşı mükellef bir yemek.\r\n\r\nBu arada gidiyoruz, ama aranızda rezervasyon yaptıran oldu mu?", 13, null },
                    { 5, 6, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(6360), 4, 2022, "images/books/fahrenheit-451.jpg", true, true, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(6370), "Fahrenheit 451", 307, 60m, "Ray Bradbury sadece bilimkurgunun değil fantastik edebiyatın ve korkunun da yirminci yüzyıldaki ustalarından biri. Bilimkurgunun *iyi edebiyat* da olabileceğini kanıtlayan belki de ilk yazar. Yayımlandığı anda klasikleşen, distopya edebiyatının dört temel kitabından biri olan Fahrenheit 451 ise bir yirminci yüzyıl başyapıtı.\r\n\r\nGuy Montag bir itfaiyeciydi. Televizyonun hüküm sürdüğü bu dünyada kitaplar ise yok olmak üzereydi zira itfaiyeciler yangın söndürmek yerine ortalığı ateşe veriyordu. Montag’ın işi ise yasadışı olanların en tehlikelisini yakmaktı: Kitapları.\r\n\r\nMontag yaptığı işi tek bir gün dahi sorgulamamıştı ve tüm gününü televizyonla kaplı odalarda geçiren eşi Mildred’la beraber yaşıyordu. Ancak yeni komşusu Clarisse’le tanışmasıyla tüm hayatı değişti. Kitapların değerini kavramaya başlayan Montag artık tüm bildiklerini sorgulayacaktı.\r\n\r\nİnsanların uğruna canlarını feda etmeyi göze aldığı bu kitapların içinde ne vardı?\r\nGerçeklerin farkına vardıktan sonra bu karanlık toplumda artık yaşanabilir miydi?\r\n\r\nFahrenheit 451, yeryüzünde tek bir kitap kalacak olsa, o kitap olmaya aday.", 28, null },
                    { 6, 7, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(6370), 2, 2022, "images/books/bindokuzyuzseksendort-1984.jpg", true, true, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(6370), "1984", 485, 95m, "1984 kitabı, İngiliz filozof ve yazar George Orwell tarafından kaleme alınmış, 1984 kitap konusu olarak 20. yüzyılın en önemli distopya örneklerinden biri olmuştur. George Orwell, 1948 yılında tamamladığı ve geleceğe dair karamsar bir kurgu geliştirerek gelecek hakkında insanlığı uyarmayı amaçlamıştır. Egemen sınıfa dayalı, totaliter, baskıcı bir yönetim anlayışının benimsendiği üç ayrı devletin egemenliğindeki siyasal düzenden bahsetmektedir. 1984 kitabı, günümüz ile geçmiş arasında gerçekçi bir benzerliklere dayandıran, dönemin okurlarını düşündürtüp hayal güçlerinin sınırlarını zorlamayı sağlayan distopik, alegorik, politik bir romandır.", 16, null },
                    { 7, 3, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(6370), 6, 2021, "images/books/gorunmez-adam.jpg", true, false, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(6370), "Görünmez Adam", 139, 55m, "H. G. Wells, bilimkurgunun atası, türe adını altın harflerle yazdırmış en büyük yazarlardan. Yazdığı bilim fantazileri nesiller boyu yazarları etkilemiş, onlara yol göstermiş; ilk basıldıkları dönemden itibaren etkilerini yitirmeden okurların gönlünde taht kurmaya devam etmiştir. Görünmez Adam da Wells’in eserleri içinde en akılda kalıcı olanlardan biri.\r\n\r\nTuhaf görünüşlü yabancı, bir tipi sırasında Iping Köyü’ne gelir. Garip hareketleri, giyinişi, suratının tamamının bandajlar içinde olması ve gözlüklerini bir an olsun gözünden çıkarmaması köy sakinleri tarafından kimi zaman şüpheyle, kimi zaman düşmanca karşılanır. Kısa süre içerisinde hakkındaki dedikodular giderek yoldan çıkan bir dizi olaya neden olacaktır.", 19, null },
                    { 8, 7, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(6370), 14, 2021, "images/books/hayvan-ciftligi.jpg", false, true, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(6370), "Hayvan Çiftliği", 99, 45m, "Hayvan Çiftliği ya da orijinal ismiyle \"Animal Farm\", Eric Arthur Blair yani kitaplarını yazarken kullandığı ismiyle George Orwell’in mecazi bir dille kaleme aldığı ve ilk kez 1945 yılında Birleşik Krallık’ta yayımlan, 1996 tarihinde de Retro Hugo Ödülü’nü kazanan, fabl tarzındaki siyasi hiciv romanıdır. Stalinizmin eleştirildiği \"Hayvan Çiftliği\" romanı, SSCB’nin kuruluşundan itibaren meydana gelen önemli olayları kara mizah yoluyla anlatmaktadır. Yayımlandığında büyük bir ilgi uyandıran bu eser 1954 ve 1999 yıllarında filme uyarlanmış, Pink Floyd’un Animals albümüne ilham olmuştur. George Orwell’in tarihsel bir gerçeği eleştirdiği “Hayvan Çiftliği” eseri, Türkçeye ilk kez 1954 yılında çevrilmiştir.\r\n\r\nGeorge Orwell (25 Haziran 1903 - 21 Ocak 1950), asıl ismi Eric Arthur Blair olan ve oluşturduğu Big Brother (Büyük Birader) kavramı ile tanınan, gazetecilik ve eleştirmenlik de yapmış 20. yüzyıl İngiliz edebiyatının önde gelen yazarıdır. Kaleme aldığı eserleri birçok dile çevrilen, çağdaş klasikler arasında gösterilen George Orwell, “Hayvan Çiftliği” eserinde bir devrimin trajedisini dile getirmiştir.", 26, null },
                    { 9, 1, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(6380), 2, 2022, "images/books/insan-gelecegini-nasil-kurar.jpg", true, true, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(6380), "İnsan Geleceğini Nasıl Kurar", 420, 119m, "Bir hedef bulacaksınız, o uğurda çalışacaksınız, hedefinizi gerçekleştirmek için bir yol arayacaksınız, yol yoksa da o yolu yapacaksınız. Bir defa geçtiğiniz yoldan da bir daha geri dönmeyeceksiniz. Çünkü lüzumsuz geri dönüş başarısızlıktır, tekrara düşmektir, ufku kapatmaktır. Hedef bulmak, yol açmak ve aynı yoldan geri dönmemek… Hayattaki gayemiz budur.", 13, null },
                    { 10, 8, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(6390), 4, 2022, "images/books/insanlar.jpg", true, true, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(6390), "İnsanlar", 216, 75m, "*Bu satırları okuyanlarınızın büyük çoğunluğunun, insanların bir mitten ibaret olduğuna inandığını biliyorum ama ben size onların gerçekten var olduklarını bildirmek üzere buradayım. Bilmeyenler için söyleyeyim, insan dediğimiz şey orta zekâlı ve iki ayaklı bir yaşam formu; evrenin çok ıssız bir köşesinde yer alan küçük ve sulu bir gezegende, büyük ölçüde yanılsamalarla dolu bir varoluş sürdürüyor.*\r\n\r\nYağmurlu bir akşamda Profesör Andrew Martin, önce dünyanın en büyük matematik bilmecesini çözmeyi başarıyor, ardından sırra kadem basıyor. Nihayet bir yol kenarında çırılçıplak halde bulunduğunda, kıyafetsizlikten daha ciddi bir meselesi olduğu ortaya çıkıyor: Andrew Martin artık insanlardan tiksiniyor; görünüşlerinden de yiyip içtiklerinden de bitmeyen şiddet ve savaş arzularından da... Yabancı bir tür arasında kaybolmuş hissediyor kendini. Sevgi ve aile kavramları onda şaşırtıcı bir ilgi uyandırsa da tüm sakinlerinden nefret ediyor bu gezegenin. Newton hariç... Ama o da bir köpek işte...", 40, null },
                    { 11, 2, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(6390), 3, 2022, "images/books/kadinlar-ulkesi.jpg", true, true, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(6390), "Kadınlar Ülkesi", 315, 65m, "Charlotte Perkins Gilman yaşadığı dönemin önde gelen hümanistlerinden ve kadın hakları savunucularından biri olmasının yanında feminist edebiyatın en önemli erken dönem temsilcilerinden. Yazıldıktan yaklaşık 65 sene sonra kitap formatında yayımlanabilen Kadınlar Ülkesi ise feminist ütopyanın ilk örneklerinden.\r\n\r\nBirinci Dünya Savaşı’nın arifesinde üç Amerikalı erkek pek fazla insanın bulunmadığı, ücra bir yerde, tamamen kadınlardan oluşan bir topluluğa denk gelir. Gözlerine inanamayan kâşifler bu topraklarda erkeklerin de olması gerektiğine dair inançlarıyla araştırmalarına başlar.\r\n\r\nÇok geçmeden bu gizemli ülke ile ilgili gerçekler bir bir açığa çıksa da misafirlerin merakı giderilmenin aksine daha da artar ve Kadınlar Ülkesi’nin yönetim biçiminden inançlarına, kültüründen ekonomisine ve hatta anneliğe kadar pek çok konuda bilgi sahibi olmaya ve toplumsal cinsiyet rollerini sorgulamaya başlarlar.\r\n\r\nToplumsal roller cinsiyete göre belirlenebilir mi? Kadınlık ve erkeklik değişmez kavramlar mıdır?\r\n\r\nKadınlar Ülkesi, ataerkilliğe verilmiş nüktedan bir yanıt.", 25, null },
                    { 12, 6, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(6390), 4, 2022, "images/books/kara-delikler.jpg", false, false, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(6390), "Kara Delikler", 439, 90m, "2016 yılının BBC Reith derslerinde Stephen Hawking, bütün bir ömür süren araştırmalarını on beş dakika içinde aktarma gibi gerçekten zorlu bir meydan okumayı kabul etti. Bu çok kısa süren derslerde Hawking, evrenin gizemlerini ortaya sererken, kara delikleri anladığımız takdirde uzayzamanın sırlarına erişebileceğimizi vurguluyor.", 4, null },
                    { 13, 10, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(6400), 14, 2020, "images/books/kumarbaz.jpg", false, false, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(6400), "Kumarbaz", 417, 85m, "\"Kumarbaz\" tüm varlığını, gücünü, yeteneğini rulet masasına yatıran; bilinmeyene, tehlikeye özlem duyan; hem başkaldıran, hem korkan; içinde binbir türlü çelişki barındıran kumara tutkun bir adamın romanı. Kendisi de bir süre kumarın tutsağı olan Dostoyevski, belki hiçbir romanına kendi yaşamından bu kadar çok şey katmamıştır. Hiçbir şey yazmasaydı bile \"Kumarbaz\" onu Dostoyevski yapmaya yeterdi.", 10, null },
                    { 14, 11, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(6400), 12, 2021, "images/books/nebonun-mavi-kitabi.jpg", true, true, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(6400), "Nebo'nun Mavi Kitabı", 582, 115m, " “Son” denilen nükleer felaketten sonra anne ve oğul arasında kurulan geçmişi ve o günü kapsayan ancak sınırları olan bir ilişkinin kapısından içeri girerken; ilacın, elektriğin, kalabalığın, cep telefonlarının ve günümüze ait hiçbir gerecin olmadığı bir dünyaya adım atacaksınız. Hayatta kalma güdüsü, yalnızlık\r\nve ölüm temalarıyla öne çıkan, Galceye özgü akıcı ve güçlü tasvirlerle ilerleyen Nebo’nun Mavi Kitabı; günümüz insanının doğadan ne kadar kopuk yaşadığını da  gözler önüne seriyor.\r\n \r\nManon Steffan Ros “ekolojik distopya” temeline dayanan,\r\nödüllü ve çoksatan romanında, insanın hayatta kalma içgüdüsüyle birlikte, çağdaş dünya düzenini de sorguluyor.", 29, null },
                    { 15, 12, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(6410), 36, 2022, "images/books/nutuk.jpg", false, true, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(6410), "Nutuk", 332, 65m, "Ey Türk gençliği! Birinci görevin, Türk bağımsızlığını, Türk Cumhuriyeti’ni sonsuza kadar korumak ve savunmaktır. Varlığının ve geleceğinin tek temeli budur. Bu temel, senin en değerli hazinendir. Gelecekte de, seni bu hazineden yoksun bırakmak isteyecek iç ve dış düşmanların olacaktır. Bir gün, bağımsızlık ve cumhuriyeti savunma zorunluluğuna düşersen, göreve atılmak için, içinde bulunacağın durumun olanak ve koşullarını düşünmeyeceksin!", 34, null },
                    { 16, 13, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(6410), 11, 2022, "images/books/hayvanlardan-tanrilara-sapiens.jpg", true, true, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(6410), "Hayvanlardan Tanrılara Sapiens", 639, 160m, "Çoğu çalışma insanlığın serüvenini ya tarihi ya da biyolojik bir yaklaşımla ele alır, ancak Harari 70 bin yıl önce gerçekleşen Bilişsel Devrim’le başlattığı bu kitabında gelenekleri yerle bir ediyor. İnsanların küresel ekosistemde oynadıkları rolden imparatorlukların yükselişine ve modern dünyaya kadar pek çok konuyu irdeleyen Sapiens, tarihle bilimi bir araya getirerek kabul görmüş anlatıları yeniden ele alıyor. Harari ayrıca geleceğe bakmaya da zorluyor okuru. Yakın zamanda insanlar, dört milyar yıldır yaşama hükmeden doğal seçilim yasalarını esnetmeye başladılar. Artık sadece dünyayı değil, kendimizi ve diğer canlıları tasarlama becerisi de kazandık. Peki bu bizi nereye götürüyor, bizi neye dönüştürebilir?", 32, null },
                    { 17, 14, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(6410), 12, 2022, "images/books/savas-ve-baris.jpg", false, true, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(6410), "Savaş ve Barış", 239, 85m, "Savaş ve Barış, gençlere dünya klasiklerini tanıtarak, onları bu eserleri okumaya yönlendirmek amacıyla hazırladığımız Arkadaş Dünya Klasikleri Gençlik Özet Dizisi’nin üçüncü kitabıdır. Genç okurların kolayca anlayarak beğeniyle okuyabileceği yalın bir Türkçeyle orijinal metinden uyarlanmıştır.\r\n\r\nTolstoy’un başyapıtı olan Savaş ve Barış, dünya edebiyatının en önemli eserlerindendir ve Milli Eğitim Bakanlığınca 100 Temel eser kapsamında öğrencilere tavsiye edilmiştir.", 14, null },
                    { 18, 8, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(6420), 3, 2021, "images/books/zamani-durdurmanin-yollari.jpg", true, true, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(6420), "Zamanı Durdurmanın Yolları", 329, 80m, "Kaç Ömür Gerek, Yaşamayı Öğrenmek İçin?\r\n\r\nTom Hazard’ın tehlikeli bir sırrı var. 41 yaşında sıradan bir tarih öğretmeni gibi göru¨nse de nadir rastlanan bir hastalık yu¨zu¨nden aslında yu¨zyıllardır hayatta. Shakespeare’le aynı sahnede yer almış, Kaptan Cook’la açık denizleri fethetmiş, Fitzgerald’larla içki içmiş. Ama şimdi, tek istediği normal bir hayat su¨rmek. Kimliğini değiştirmeye devam ettiği su¨rece geçmişini geride bırakabilir ve hayatta kalabilir.\r\n\r\nYapmaması gereken tek bir şey var, aşık olmak.", 5, null },
                    { 19, 8, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(6420), 2, 2022, "images/books/gece-yarisi-kutuphanesi.jpg", true, true, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(6420), "Gece Yarısı Kütüphanesi", 512, 100m, "*Yaşamla ölüm arasında bir kütüphane var,* dedi. *Bu kütüphanedeki raflar sonsuza kadar gider.  Her kitap yaşamış olabileceğin başka bir hayatı yaşama şansını sunar sana. Farklı seçimler yapmış olsan, şu an nasıl bir hayatın olacağını görürsün…\r\nPişmanlıklarını telafi etme şansın olsaydı, bazı konularda farklı davranır mıydın?*\r\n\r\nNora Seed berbat halde. Kedisi öldü. İşinden kovuldu. Abisi onunla konuşmuyor. Kimsenin ona ihtiyacı yok. Art arda alınmış kötü kararların sonucunda bir kütüphanede buluyor kendini. Zamanın hiç akmadığı bir gece yarısı kütüphanesinde, sonsuz sayıda kitabın ortasında... Kitapların her birinde Nora’nın farklı bir hayatı yazılı. Başka kararlar verseydi yaşamış olabileceği hayatlar.\r\n\r\nFarklı kariyerler, farklı eşler, farklı arkadaşlar, farklı şehirler arasında gidip gelen Nora’nın aklı sorularla doluyor. Mutluluk sadece önemli sandığımız seçimlerde mi gizli? Yanlış giden her detayın sorumlusu gerçekten biz miyiz? Hayatı yaşanılır kılan ne? Yanlış bir karar insanın tüm hayatına mal olabilir mi?", 32, null },
                    { 20, 15, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(6420), 2, 2023, "images/books/sicak-kafa.jpg", true, true, new DateTime(2024, 8, 22, 10, 48, 37, 71, DateTimeKind.Local).AddTicks(6430), "Sıcak Kafa", 285, 90m, "Dünyayı pençesine almış bir delilik salgını...\r\n\r\nKonuşma yoluyla, zihinden zihne bulaşarak yayılan bir hastalık...\r\n\r\nYıkılmanın eşiğine gelmiş uygarlık...\r\n\r\nVaktiyle bu amansız hastalık üzerine çalışmış eski dilbilimci Murat Siyavuş, umutsuzluk içinde annesinin evine sığınmıştır. Acımasız bir devlet kurumunun peşine düştüğünü öğrenince, evden çıkıp hayata karışmak ve salgının dönüştürdüğü dünyayla yüzleşmek zorunda kalır.", 40, null }
                });

            migrationBuilder.InsertData(
                table: "BookCategories",
                columns: new[] { "BookId", "CategoryId" },
                values: new object[,]
                {
                    { 1, 5 },
                    { 1, 10 },
                    { 2, 4 },
                    { 2, 13 },
                    { 3, 1 },
                    { 3, 5 },
                    { 3, 10 },
                    { 4, 1 },
                    { 4, 5 },
                    { 4, 10 },
                    { 5, 3 },
                    { 5, 5 },
                    { 5, 10 },
                    { 6, 3 },
                    { 6, 5 },
                    { 6, 10 },
                    { 7, 1 },
                    { 7, 5 },
                    { 8, 3 },
                    { 8, 5 },
                    { 8, 10 },
                    { 9, 7 },
                    { 9, 8 },
                    { 9, 12 },
                    { 10, 1 },
                    { 10, 5 },
                    { 10, 10 },
                    { 11, 1 },
                    { 11, 5 },
                    { 11, 10 },
                    { 12, 2 },
                    { 12, 6 },
                    { 12, 9 },
                    { 13, 5 },
                    { 13, 10 },
                    { 13, 11 },
                    { 14, 1 },
                    { 14, 5 },
                    { 14, 10 },
                    { 15, 13 },
                    { 15, 14 },
                    { 16, 4 },
                    { 16, 13 },
                    { 17, 5 },
                    { 17, 10 },
                    { 18, 5 },
                    { 18, 10 },
                    { 19, 1 },
                    { 19, 5 },
                    { 19, 10 },
                    { 20, 1 },
                    { 20, 3 },
                    { 20, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookCategories_CategoryId",
                table: "BookCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_BookId",
                table: "CartItems",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_BookId",
                table: "OrderItems",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookCategories");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Author");
        }
    }
}
