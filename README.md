
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
