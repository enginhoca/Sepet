1) Katmanlı mimari yapısına göre projelerimizi oluşturuyoruz:
    * dotnet new webapi --use-controllers -o BooksApp.Api
    * dotnet new classlib -o BooksApp.Service
    * dotnet new classlib -o BooksApp.Data
    * dotnet new classlib -o BooksApp.Entity
2) Aşağıdaki komutu kullanarak dotnet ef tool'unu yüklüyoruz.
    * dotnet tool install --global dotnet-ef
    Not: Bu komutu 'dotnet-ef' ya da 'dotnet ef' şeklinde kullanabileceğiz.
3) Data katmanında aşağıdaki komutu vererek migration yaratıyoruz:
    * dotnet ef migrations add InitialDb --startup-project ../BooksApp.Api
    * dotnet ef database update -s ../BooksApp.Api

4) Veri tabanımızdaki tabloları temsil eden classlara Entity diyoruz.
    Tüm veri tabanı yapısı ile ilgili bilgileri barındaran classa DbContext diyoruz.
    Bu yapılarda meydana gelen değişiklikleri veri tabanına yansıtma sürecimiz:
    * 1) dotnet ef migrations add <MigName>
    * 2) dotnet ef database update
