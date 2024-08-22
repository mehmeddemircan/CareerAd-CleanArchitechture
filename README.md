
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


User user = new User { Name = "Ali", Age = 30 };
string json = JsonSerializer.Serialize(user);
Deserialize
Serileştirilmiş verinin (örneğin, JSON veya XML) orijinal nesne formatına geri dönüştürülmesi işlemidir.


string json = "{\"Name\":\"Ali\",\"Age\":30}";
User user = JsonSerializer.Deserialize<User>(json);
DbContext ve Using Bloğu
DbContext ile birlikte using ifadesi, veritabanı bağlantılarının doğru bir şekilde yönetilmesini sağlamak için kullanılır. using bloğu, kaynağın otomatik olarak serbest bırakılmasını sağlar; yani işlem tamamlandığında bağlantı kapanır ve kaynaklar serbest bırakılır.


using (var context = new BaseDbContext())
{
    // Veritabanı işlemleri burada yapılır.
}
Bu kullanımın avantajları şunlardır:

1. Bellek sızıntılarını önler.
2. Veritabanı bağlantılarını etkin bir şekilde yönetir.
3. Uygulamanın performansını artırır.
Dolayısıyla, DbContext nesnesini using bloğu içinde kullanmak, kaynakların doğru ve güvenli bir şekilde yönetilmesini sağlar.

# Entity Type Configuration
# DeleteBehavior.Cascade
Ana tablodan bir kayıt silindiğinde, ilişkili alt tablo kayıtları otomatik olarak silinir.

# DeleteBehavior.Restrict
Ana tablodan bir kayıt silinmek istendiğinde, ilişkili alt tablo kayıtları varsa silme işlemi engellenir.

Bu ayarlar, veritabanı bütünlüğünü korumak ve veri silme işlemlerinin etkisini kontrol etmek için önemlidir.

