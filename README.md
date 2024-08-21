Attributes ( öznitelikler ) 
C#’daki attributes, köşeli parantezler [] ile tanımlanır ve genellikle özelliklerin (properties) veya metodların başına yerleştirilir.
Authentication kimlik doğrulama işlemidir
SecuredOperation attribute ise burada çoklu role karşı ayarlanmış bir attributedur
Bu Attributeler, Kod okunabilirginide ve hangi apilerimiz authentication ve authorization kontrolu yapmasını sağlar
İstek attırmaz önce attribute de ki kodlar çalışır attribute de ki şartlar sağlandıktan sonra kontroller çalışır

Serialize (Serileştirme) ve Deserialize (Deserileştirme), yazılım geliştirmede verilerin bir formattan diğerine dönüştürülmesi işlemleridir. Genellikle veri taşımak, depolamak veya iletmek için kullanılırlar.
 
Serialize : C# nesnesini JSON formatına dönüştürmek
User user = new User { Name = "Ali", Age = 30 };
 string json = JsonSerializer.Serialize(user);


Deserialize : serileştirilmiş verinin (örneğin, JSON veya XML) orijinal nesne formatına geri dönüştürülmesi işlemidir.

string json = "{\"Name\":\"Ali\",\"Age\":30}";
User user = JsonSerializer.Deserialize<User>(json)

DbContext de entityframework base repository de using blogu içinde kullanım amacı nedir ?

DbContext ile birlikte using ifadesi, veritabanı bağlantılarının doğru bir şekilde yönetilmesini sağlamak için kullanılır. using bloğu, kaynağın otomatik olarak serbest bırakılmasını sağlar, yani işiniz bittiğinde bağlantı kapanır ve kaynaklar serbest bırakılır.

using (var context = new BaseDbContext())
{
    // Veritabanı işlemleri yapılacak
}

1.	Bellek sızıntılarını önlersiniz.
2. Veritabanı bağlantılarını etkin bir şekilde yönetirsiniz.
 3.	Uygulamanızın performansını artırırsınız.

Bu yüzden, DbContext nesnesini using bloğu içinde kullanmak, kaynakların doğru ve güvenli bir şekilde yönetilmesini sağlar.

