
# Öznitelikler (Attributes)
C#’daki öznitelikler (attributes), köşeli parantezler [] ile tanımlanır ve genellikle özelliklerin (properties) veya metodların başına yerleştirilir. Öznitelikler, kodun okunabilirliğini artırır ve hangi API'lerin kimlik doğrulama (authentication) ve yetkilendirme (authorization) kontrolü yaptığını belirler. Bir isteğin işlenmesinden önce, özniteliklerin kodları çalışır; bu şartlar sağlandığında kontroller devreye girer.

# Authentication
Authentication, kimlik doğrulama işlemidir.

# SecuredOperation Attribute
SecuredOperation attribute’u, burada çoklu role karşı ayarlanmış bir özniteliktir. Bu öznitelik, belirli rollerin erişimini kontrol etmek için kullanılır.

# Serileştirme (Serialization) ve Deserileştirme (Deserialization)
Serileştirme (Serialize) ve deserileştirme (Deserialize), yazılım geliştirmede verilerin bir formattan diğerine dönüştürülmesi işlemleridir. Genellikle veri taşımak, depolamak veya iletmek için kullanılırlar.

# Serialize
C# nesnesini JSON formatına dönüştürme işlemidir.


```bash
User user = new User { Name = "Ali", Age = 30 };
string json = JsonSerializer.Serialize(user);
```
Deserialize
Serileştirilmiş verinin (örneğin, JSON veya XML) orijinal nesne formatına geri dönüştürülmesi işlemidir.

```bash
string json = "{\"Name\":\"Ali\",\"Age\":30}";
User user = JsonSerializer.Deserialize<User>(json);
```

DbContext ve Using Bloğu
DbContext ile birlikte using ifadesi, veritabanı bağlantılarının doğru bir şekilde yönetilmesini sağlamak için kullanılır. using bloğu, kaynağın otomatik olarak serbest bırakılmasını sağlar; yani işlem tamamlandığında bağlantı kapanır ve kaynaklar serbest bırakılır.

```bash
using (var context = new BaseDbContext())
{
    // Veritabanı işlemleri burada yapılır.
}
```
Bu kullanımın avantajları şunlardır:

-  Bellek sızıntılarını önler.
-  Veritabanı bağlantılarını etkin bir şekilde yönetir.
-  Uygulamanın performansını artırır.
Dolayısıyla, DbContext nesnesini using bloğu içinde kullanmak, kaynakların doğru ve güvenli bir şekilde yönetilmesini sağlar.

# Entity Type Configuration
# DeleteBehavior.Cascade
Ana tablodan bir kayıt silindiğinde, ilişkili alt tablo kayıtları otomatik olarak silinir.

# DeleteBehavior.Restrict
Ana tablodan bir kayıt silinmek istendiğinde, ilişkili alt tablo kayıtları varsa silme işlemi engellenir.

```csharp
 builder.HasOne(uoc => uoc.User)
        .WithMany()
        .HasForeignKey(uoc => uoc.UserId)
        .OnDelete(DeleteBehavior.Restrict);

 builder.HasOne(uoc => uoc.OperationClaim)
        .WithMany()
        .HasForeignKey(uoc => uoc.OperationClaimId)
        .OnDelete(DeleteBehavior.Restrict);

    // yada 
         .OnDelete(DeleteBehavior.Cascade); 
```

Bu ayarlar, veritabanı bütünlüğünü korumak ve veri silme işlemlerinin etkisini kontrol etmek için önemlidir.

# Global Exception Handling nedir ?
Global Exception Handling (Global Hata Yönetimi), bir uygulamada meydana gelen tüm hataları merkezi bir yerde yakalamak ve yönetmek için kullanılan bir tekniktir. Bu yöntem, özellikle büyük ve karmaşık projelerde, uygulamanın çeşitli bölümlerinde meydana gelebilecek hataları tutarlı bir şekilde ele almayı sağlar.

# Global Exception Handling Neden Gereklidir?
- Merkezi Yönetim: Hataların merkezi bir yerde yakalanması, farklı modüllerde farklı hata işleme mantıklarının kullanılmasını önler. Bu sayede uygulamanın hata yönetimi tutarlı hale gelir.

- Bakım Kolaylığı: Tüm hataların tek bir yerden yönetilmesi, uygulamanın bakımını kolaylaştırır. Eğer bir hata yönetimi politikası güncellenmek istenirse, bu sadece global hata yöneticisinde yapılır ve tüm uygulamayı etkiler.

- Kapsamlı Hata Raporlama: Hataların kaydedilmesi, loglanması ve raporlanması işlemleri merkezi olarak yönetilebilir. Bu sayede uygulamanın her yerinden gelen hatalar tek bir yerden izlenebilir.

- Kullanıcı Deneyimi: Hatalar kullanıcıya düzgün bir şekilde bildirilebilir ve uygulamanın çökmesi veya beklenmeyen davranışlar sergilemesi önlenebilir. Kullanıcıya tutarlı hata mesajları sunulabilir.

# Dikkat Edilmesi Gerekenler
- Hataların Yakalanması ve Bildirilmesi: Hatalar yakalanmalı ve uygun bir loglama mekanizması ile kaydedilmelidir. Aynı zamanda, kullanıcıya anlamlı ve güvenli bir hata mesajı sunulmalıdır.

Global Exception Handling, uygulamanın güvenilirliğini artırır, hata yönetimini kolaylaştırır ve kullanıcı deneyimini iyileştirir. Hataların merkezi bir yerde ele alınması, uygulamanın her yerinde tutarlı bir hata yönetimi sağlar.

# Middleware Ne Yapar?
Middleware, gelen bir HTTP isteği sunucuya ulaştığında veya bir yanıt istemciye gönderilmeden önce, bu süreci keserek belirli işlemleri gerçekleştirebilir. Bu işlemler şunlar olabilir:

- Kimlik Doğrulama (Authentication): İstek sahibinin kimliğinin doğrulanması.
- Yetkilendirme (Authorization): İstek sahibinin belirli kaynaklara erişim yetkisinin kontrol edilmesi.
- Logging (Kayıt Tutma): İsteklerin ve yanıtların loglanması.
- Hata Yönetimi (Error Handling): Meydana gelen hataların yakalanması ve uygun şekilde yönetilmesi.
- Önbellekleme (Caching): Yanıtların önbelleğe alınması veya önbellekten sunulması.

örnek Kod 
```bash
public void Configure(IApplicationBuilder app)
{
    app.Use(async (context, next) =>
    {
        try
        {
            await next.Invoke(); // Sonraki middleware’e geçiş
        }
        catch (Exception ex)
        {
            // Hataları yakala ve yönet
            await context.Response.WriteAsync("An error occurred.");
        }
    });

    app.UseMiddleware<AuthenticationMiddleware>();
    app.UseMiddleware<LoggingMiddleware>();

    app.Run(async (context) =>
    {
        await context.Response.WriteAsync("Hello World!");
    });
}
```

# Middleware Nasıl Çalışır?
Middleware, genellikle bir zincir (pipeline) şeklinde çalışır. Bir HTTP isteği geldiğinde, bu zincirdeki her middleware sırasıyla çalışır. Her middleware, isteği değiştirebilir, işleyebilir veya başka bir middleware’e iletebilir. Sonunda, isteğe bir yanıt döndürüldüğünde, yine bu zincir üzerinden geriye doğru geçer.

Örneğin, bir web uygulamasında şu şekilde çalışabilir:

- Gelen istek → Kimlik doğrulama middleware’i isteği kontrol eder.
- Yetkilendirme → Kullanıcının yetkisi olup olmadığını kontrol eder.
- İşleme → İstek işlenir ve yanıt oluşturulur.
- Yanıt → Yanıt önbelleğe alınır.
- Loglama → İstek ve yanıt kaydedilir.
- Yanıt döndürülür.

# CQRS ve MediatR nedir Nasıl Çalışır ?

# CQRS (Command Query Responsibility Segregation)

CQRS (Command Query Responsibility Segregation), yazılım mimarisinde kullanılan bir tasarım desenidir. CQRS, veri okuma (sorgu) ve veri yazma (komut) işlemlerinin ayrı sorumluluklara sahip olacak şekilde birbirinden ayrılması prensibine dayanır. Bu desen, sistemin performansını, ölçeklenebilirliğini ve bakımını artırmak amacıyla uygulanır.

## CQRS Prensipleri

- **Komut Command (Yazma İşlemleri):** Sistemde veri ekleme, güncelleme veya silme gibi işlemleri kapsar. Komut işlemleri, veri üzerinde değişiklik yapar ve genellikle bir yan etki (side effect) üretir.

- **Sorgu Query  (Okuma İşlemleri):** Veri üzerinde sadece okuma işlemi gerçekleştirir. Sorgu işlemleri herhangi bir yan etki üretmez ve sadece veri döndürür.

Bu prensip, veri akışını daha iyi yönetmek ve performansı artırmak için okuma ve yazma işlemlerini ayrı sorumluluklara ayırır. Böylece, veri okuma ve yazma işlemleri için farklı modeller ve veritabanları kullanılabilir.

## CQRS ve .NET Core

.NET Core'da CQRS mimarisi genellikle MediatR gibi bir kütüphane kullanılarak uygulanır. MediatR, uygulama içindeki istekleri ve bu isteklere karşılık gelen işleyicileri birbirinden ayırarak CQRS prensiplerini kolayca uygulamanıza olanak tanır.
## CQRS'in Avantajları
- **Böl ve Yönet**: Uygulamanın karmaşıklığını azaltır, okuma ve yazma işlemlerini farklı sorumluluklara ayırır.
- **Performans**: Okuma ve yazma işlemleri farklı şekilde optimize edilebilir.
- **Esneklik**: Uygulamanın bir tarafında değişiklik yaparken diğer tarafı etkilemez.
- **Test Edilebilirlik**: Komut ve sorgu işleyicileri ayrı birimler olduğu için kolayca test edilebilir.

## Dependency Injection Nedir ? 


Dependency Injection (DI), bir yazılım tasarım deseni olup, sınıflar arasındaki bağımlılıkların gevşek bir şekilde ilişkilendirilmesini sağlar. Bu desen, bir sınıfın ihtiyaç duyduğu bağımlılıkları (genellikle diğer sınıfların örnekleri) doğrudan yaratmak yerine, bu bağımlılıkların dışarıdan sağlanması prensibine dayanır. DI, nesnelerin yönetimini kolaylaştırır, test edilebilirliği artırır ve kodun esnekliğini sağlar.

## Neden Dependency Injection?

- **Gevşek Bağlılık:** Sınıflar arasında sıkı bağlılıkların azaltılmasına yardımcı olur, böylece bir sınıfta yapılan değişiklikler diğer sınıfları minimum düzeyde etkiler.
- **Test Edilebilirlik:** Bağımlılıklar dışarıdan sağlandığı için, birim testlerde kolayca sahte (mock) nesneler kullanılabilir.
- **Bakım ve Geliştirme:** Bağımlılıkların merkezi bir yerden yönetilmesi, kodun daha kolay anlaşılmasını ve genişletilmesini sağlar.

## Dependency Injection Türleri , ( 3 tür bulunmaktadır ) 

### 1. Constructor Injection 

Bağımlılıklar, constructor'a parametre olarak geçirilir. Bu, **en yaygın** kullanılan DI türüdür.

**Örnek:**

```csharp
public class MyClass
{
    private readonly IMyDependency _myDependency;

    public MyClass(IMyDependency myDependency)
    {
        _myDependency = myDependency;
    }

    public void DoWork()
    {
        _myDependency.Execute();
    }
}
```
### 2. Property Injection
Bağımlılıklar, sınıfın özellikleri (properties) üzerinden enjekte edilir.

```csharp
public class MyClass
{
    public IMyDependency MyDependency { get; set; }

    public void DoWork()
    {
        MyDependency.Execute();
    }
}
```

### 3. Method Injection
Bağımlılıklar, metodun parametreleri aracılığıyla sağlanır.
```csharp
public class MyClass
{
    public void DoWork(IMyDependency myDependency)
    {
        myDependency.Execute();
    }
}
```
## Dependency Injection da kullanılan Servis Türleri 

- **AddSingleton**: Uygulama ömrü boyunca **(genellikle uygulama başlatıldığında)** tek bir örnek oluşturur.
- **AddScoped**: HTTP isteği boyunca tek bir örnek oluşturur. Her HTTP isteğinde MyService sınıfının yeni bir örneği oluşturulur ve bu örnek, o istek boyunca kullanılır.
- **AddTransient**: Her talepte yeni bir örnek oluşturur. Hafif nesneler için veya her kullanımda yeni bir örneğe ihtiyaç duyulduğunda kullanılır.

Bu farklı dependency injection  servis türleri, ASP.NET Core uygulamanızın performansını ve kaynak yönetimini optimize etmek için önemlidir.

## FluentAPI nedir ( Entity Type Configuration )

Fluent API, genellikle Entity Framework Core'da kullanılan bir yapılandırma yöntemidir. Fluent API, C# dilindeki lambda ifadeleri ve metod zincirleme (method chaining) tekniğini kullanarak, veri modellemelerinin ve ilişkilerinin daha esnek ve okunabilir bir şekilde tanımlanmasını sağlar. Bu yapılandırmalar, genellikle OnModelCreating metodu içinde yapılır.

Veri modellemelerini ve ilişkilerini çok daha detaylı ve esnek bir şekilde tanımlayabilirsiniz. Fluent API, genellikle veri anotasyonları (data annotations) ile yapılamayan daha karmaşık yapılandırmaları sağlar.

örnek kod

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Primary key tanımlama
        modelBuilder.Entity<Product>()
            .HasKey(p => p.ProductId);

        // Property için maksimum uzunluk belirleme
        modelBuilder.Entity<Product>()
            .Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired();
    }
```
## Fluent API ile Yapılabilecek Bazı Yapılandırmalar

- Primary Key, Foreign Key ve Index tanımlamaları
- Tablo ve kolon isimlendirmeleri
- İlişkiler (One-to-One, One-to-Many, Many-to-Many)
- Veri kısıtlamaları (Unique, Required, MaxLength)
- Veri türü ve varsayılan değer atamaları
  
## Fluent API ile Veri Anotasyonları Arasındaki Fark

Veri anotasyonları (data annotations), doğrudan model sınıflarının üzerine eklenirken, Fluent API yapılandırmaları DbContext sınıfı içinde merkezi olarak tanımlanır. Fluent API, özellikle karmaşık ve gelişmiş yapılandırmalar için tercih edilir.

## DTO (Data Transfer Object) Nedir?
DTO, bir uygulama katmanından diğerine veri taşımak için kullanılan basit veri nesneleridir. DTO'lar, sadece veri taşımak amacıyla tasarlandıkları için genellikle iş mantığı veya davranış içermezler. Amaçları, veri transferi sırasında gereksiz verilerin taşınmasını engellemek ve veri güvenliğini artırmaktır.

### Özellikleri:
- Sadece veri içerir; iş mantığı (business logic )  içermez.
- Veri taşıma sırasında gereksiz bilgilerden arındırılmıştır.
- Genellikle veri doğrulama, güvenlik ve performans gibi sebeplerle kullanılır.

```csharp
public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    
    // Kategori adını içeren property
    public string CategoryName { get; set; } //önemli olan kısım burasıdır 
}
```

## Entity Nedir?
Entity, genellikle veritabanında bir tabloyu temsil eden, alanları (properties) olan sınıflardır. Entity sınıfları, iş mantığı (business logic) ve veritabanı arasındaki ilişkiyi sağlar. Entity, veritabanındaki tablo yapısını yansıtır ve bu sınıflar, Entity Framework gibi ORM araçları tarafından kullanılır.

### Özellikleri:

- Veritabanındaki tabloyu temsil eder.
- Veri tutarlılığı ve ilişkileri yönetir.
- CRUD (Create, Read, Update, Delete) işlemleri için kullanılır.

## Automapper nedir ? 
AutoMapper, bir nesneyi diğerine kolayca ve otomatik olarak eşlemek (map) için kullanılan bir kütüphanedir. Genellikle Entity sınıflarını DTO'lara veya tam tersi şekilde dönüştürmek için kullanılır. AutoMapper, kod tekrarını azaltır ve veri eşleştirme işlemlerini basitleştirir.

### Özellikleri : 

- Bir nesnenin özelliklerini diğerine otomatik olarak eşler.
- Kod tekrarını önler.
- Veri transferi süreçlerini hızlandırır.

## DTO, Entity ve AutoMapper Arasındaki İlişki

- **Entity**, veritabanı tablolarını temsil eder ve veri yönetimi için kullanılır.
- **DTO**, bu verileri dış dünyaya veya diğer katmanlara taşımak için kullanılır.
- **AutoMapper** ise Entity ile DTO arasında veri eşlemesini kolaylaştırır

## Business Rules nedir Neden önemlidir ?

Business Rules (İş Kuralları), bir iş sürecinin nasıl işleyeceğini ve iş mantığının nasıl uygulanacağını belirleyen kurallardır. İş kuralları, organizasyonların ve iş süreçlerinin nasıl yönetileceğini, hangi koşullar altında ne tür işlemler yapılacağını ve hangi kriterlerin sağlanması gerektiğini tanımlar.

- **Kuralların Tanımlanması**: İş kuralları, organizasyonun hedeflerine ulaşmasını desteklemek için iş süreçlerini nasıl yöneteceğini belirler. Örneğin, bir kredi başvurusunun onaylanabilmesi için belirli kriterlerin sağlanması gerektiğini tanımlayabilir.

- **Koşullar ve Eylemler**: İş kuralları genellikle belirli koşulları ve bu koşullar sağlandığında yapılması gereken eylemleri tanımlar. Örneğin, bir müşteri hesabının kapatılabilmesi için borcunun sıfırlanmış olması gerektiğini belirtebilir.

- **Karmaşıklık ve Mantık**: İş kuralları, organizasyonun iş süreçlerindeki karmaşıklığı yönetir. Kurallar genellikle iş mantığını kapsar ve çeşitli durumları ele alacak şekilde tasarlanır.

örnek kodda burada bir kullanıcı aynı role iki kere sahip olmasını engelleyen bir iş kuralıdır , x Kişisini 2 kere aynı rolden tabloya  kayıt attırmayacaktır 
```csharp
  public async Task UserOperationClaimCanNotBeDuplicatedWhenInsertedForUser(int operationClaimId, int userId)
  {
      IPaginate<UserOperationClaim> result = await _useroperationclaimRepository.GetListAsync(b => b.OperationClaimId == operationClaimId && b.UserId == userId);
      if (result.Items.Any())
      {
          throw new BusinessException(ExceptionMessages.UserOperationClaimNameExists);
      }
  }
```

## JWT'nin Çalışma Prensibi nasıldır ? 

JWT ( Json web token )  web uygulamaları arasında güvenli veri iletimi için kullanılan bir açık standarttır. JWT, genellikle kimlik doğrulama ve yetkilendirme amacıyla kullanılır. JSON formatında kodlanmış bir tokendır 

1. **Token Oluşturma:**
   - Kullanıcı giriş yaptıktan sonra, kimlik doğrulama işlemi başarılı olursa sunucu, bir JWT oluşturur. Bu token, kullanıcı bilgilerini ve yetkilendirme bilgilerini içerir.
   - Token, başlık, yük ve imzadan oluşur ve Base64Url ile kodlanır.

2. **Token'ın İletilmesi:**
   - JWT, genellikle HTTP başlıklarında (örneğin, `Authorization: Bearer <token>`) veya çerezlerde (`cookies`) gönderilir.

3. **Token'ın Doğrulanması:**
   - Sunucu, token'ı aldığında önce imzayı doğrular. Eğer imza geçerliyse, token'ın içeriği (payload) okunur ve geçerlilik süresi kontrol edilir.
   - Token geçerli ve süresi dolmamışsa, kullanıcının kimliği doğrulanmış ve gerekli yetkilendirme yapılmış olur.

4. **Kullanıcı Erişimi:**
   - Kullanıcı JWT'yi kullanarak çeşitli API'lere erişebilir. Sunucu, her istekte JWT'yi doğrular ve kullanıcının yetkilerini kontrol eder.

## Örnek JWT

Bir JWT'nin yapısı genellikle şu şekildedir:
```csharp
eyJhbGciOiAiSFMyNTYiLCAidHlwIjogIkpXVCJ9.eyJzdWIiOiAiMTIzNDU2Nzg5MCIsICJuYW1lIjogIkpvaG4gRG9lIiwgImFkbWluIjogdHJ1ZX0.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c
```
- **İlk Kısım (Header):** `eyJhbGciOiAiSFMyNTYiLCAidHlwIjogIkpXVCJ9`
- **İkinci Kısım (Payload):** `eyJzdWIiOiAiMTIzNDU2Nzg5MCIsICJuYW1lIjogIkpvaG4gRG9lIiwgImFkbWluIjogdHJ1ZX0`
- **Üçüncü Kısım (Signature):** `SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c`

## Özet

- **JWT**, JSON formatında kodlanmış, güvenli veri iletimi sağlayan bir token'dır.
- **Header**, **Payload** ve **Signature** bileşenlerinden oluşur.
- **Kimlik doğrulama** ve **yetkilendirme** işlemleri için yaygın olarak kullanılır.
- **Token oluşturma**, **iletişim** ve **doğrulama** süreçleri ile güvenli veri aktarımı sağlar.
