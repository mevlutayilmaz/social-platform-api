# Social Platform API

SoMedia, kullanıcıların birbirleriyle etkileşim kurabileceği, gönderi paylaşabileceği, beğeni ve yorum yapabileceği, birbirlerini takip edebileceği ve hikaye paylaşabileceği bir sosyal medya platformunun backend'idir. Bu backend, modern yazılım mimarisi prensipleri izleyerek, Entity Framework Core ve Code First yaklaşımı ile PostgreSQL veritabanı kullanılarak geliştirilmiştir. API; paylaşımların, hikayelerin, beğenmelerin ve yorumların yönetimini sağlar ve kullanıcı kimlik doğrulaması için JWT (JSON Web Token) kullanır. Proje, Onion Architecture prensipleri doğrultusunda katmanlı bir yapıya sahiptir.

## Teknolojiler

- **.NET API**: Backend geliştirmesi için kullanılan ana framework.

- **Onion Architecture (Soğan Mimarisi)**: Projenin katmanlı yapısını düzenlemek için kullanılan mimari yaklaşım.

- **Repository Pattern**: Veri erişimini soyutlamak ve daha kolay yönetmek için kullanılan tasarım deseni.

  - **Read Repository**: Veri okuma işlemleri için.

  - **Write Repository**: Veri yazma, güncelleme ve silme işlemleri için.

- **CQRS (Command Query Responsibility Segregation) ve Mediator Pattern**: Komutları (yazma işlemleri) ve sorguları (okuma işlemleri) ayırmak için.

- **Entity Framework Core (EF Core)**: Veritabanı işlemleri için kullanılan ORM (Object-Relational Mapping) aracı.

- **Identity User**: Kullanıcı kimlik doğrulama ve yetkilendirme işlemleri için kullanılan .NET Identity.

- **Local Storage Service**: Gönderi ve hikaye resimlerini yerel diskte saklamak için kullanılan servis.

## Proje Mimarisi

Proje, bağımlılıkları yönetmek ve kodu daha düzenli hale getirmek için Onion Architecture prensipleri doğrultusunda katmanlı bir mimari kullanır. Her katman belirli bir sorumluluğa sahiptir ve sadece kendisinden daha düşük seviyeli katmanlara bağımlıdır.

### 1. Core Katmanı

Bu katman, uygulamanın iş mantığını ve kurallarını içerir. İki yapıdan oluşur:

- **Domain**:
  - Uygulamanın temel yapı taşlarını (Entities) tanımlar. Örneğin, `Story`, `Post`, `Comment`, `Follow` entity'leri burada bulunur.
  - İş kurallarını ve doğrulamalarını içerir.
  - Veritabanı veya diğer altyapı teknolojilerinden bağımsızdır.

- **Application**:
  - Use case'leri ve iş mantığının uygulanmasını içerir.
  - Domain katmanındaki entity'leri ve arayüzleri kullanarak iş operasyonlarını gerçekleştirir.
  - Veritabanı veya diğer altyapı teknolojilerinden bağımsızdır.
  - CQRS (Command Query Responsibility Segregation) desenini kullanarak komutları ve sorguları ayırır.

### 2. Infrastructure Katmanı

Bu katman, uygulamanın altyapısal bileşenlerini içerir. İki yapıdan oluşur:

- **Infrastructure**:
  - Uygulama genelinde kullanılan ortak altyapı bileşenlerini içerir.
  - Örneğin, token oluşturma, storage gibi işlemler için servisler burada bulunabilir.

- **Persistence**:
  - Veritabanı erişimini yönetir.
  - Entity Framework Core kullanarak veritabanı işlemlerini gerçekleştirir.
  - Repository desenini kullanarak veritabanı erişimini soyutlar.
  - Domain katmanındaki entity'leri veritabanı tablolarına eşler.

### 3. Presentation Katmanı

Bu katman, kullanıcı arayüzünü ve API'yi içerir. Tek bir yapıdan oluşur:

- **API (.NET Web API)**:
  - Uygulamanın dış dünyaya açılan kapısıdır.
  - HTTP isteklerini alır ve Application katmanındaki use case'leri çağırarak işler.
  - JSON formatında yanıtlar döndürür.
  - Kullanıcı kimlik doğrulaması ve yetkilendirme için JWT (JSON Web Token) kullanır.

## Kimlik Doğrulama ve Yetkilendirme

Proje, kullanıcı kimlik doğrulaması ve yetkilendirme için JWT (JSON Web Token) kullanır. Kullanıcılar, kullanıcı adı ve şifreleriyle giriş yaparak bir Access Token ve bir Refresh Token alırlar.

- **Access Token**: API'ye erişmek için kullanılır ve sınırlı bir geçerlilik süresine sahiptir.
- **Refresh Token**: Access Token'ın süresi dolduğunda yeni bir Access Token almak için kullanılır ve daha uzun bir geçerlilik süresine sahiptir.

## Proje Detayları

- **Post**: Kullanıcıların yaptığı paylaşımları temsil eder.
- **Story**:  Kullanıcıların hikayelerini temsil eder.
- **Comment**:  Paylaşımlara yapılan yorumları temsil eder.
- **Like**: Post ve Comment beğenilerini temsil eder.
- **Follow**: Kullanıcıların birbirleriyle takipleşme durumunu temsil eder.
- **AppUser**: Uygulama kullanıcılarını temsil eder.
- **AppRole**: Kullanıcı rollerini temsil eder.

## Kurulum ve Çalıştırma

1. **Projeyi klonlayın:**
   ```bash
   git clone https://github.com/mevlutayilmaz/social-platform-api.git
   ```

2. **`SocialPlatformAPI.API` klasörüne gidin.**

3. **`appsettings.json` dosyasında veritabanı bağlantı bilgilerini ayarlayın.**

4. **Paketleri yükleyin:**
   ```bash
   dotnet restore
   ```

5. **Veritabanını oluşturun ve migrate edin:**
   ```bash
   dotnet ef database update
   ```

6. **Projeyi çalıştırın:**
   ```bash
   dotnet run
   ```
## ER-Diagram

![Untitled](https://github.com/user-attachments/assets/8bf89a47-acc6-4b17-856b-2635203c7319)


## Sonuç

Bu proje, temiz bir mimari ve modern teknolojiler kullanarak geliştirilmiş, güvenli ve ölçeklenebilir bir e-ticaret API'sidir. Proje, katmanlı yapısı sayesinde bakımı ve geliştirilmesi kolaydır.

**Bu API'yi kullanan React projesi:** [Social Platform UI](https://github.com/mevlutayilmaz/social-platform-ui)
