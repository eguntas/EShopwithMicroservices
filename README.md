ASP.NET Core 6.0 ve Web API teknolojilerini kullanarak MultiShop E‑Commerce Microservice Projesidir. 
Bu proje, ana sayfa (default), admin ve kullanıcı (user) paneli içeren tam kapsamlı bir e-ticaret ve yönetim sistemidir.



## 🔥 Tech Stack

| Kategori          | Teknolojiler                                        | Kullanım Amacı                                                            |
| ----------------- | --------------------------------------------------- | ------------------------------------------------------------------------- |
| Backend Framework | .NET Core / .NET 6+                                 | Tüm mikroservislerin temeli, API'ler ve business logic                    |
| Veritabanları     | MongoDB, MSSQL, PostgreSQL, Redis                   | NoSQL (ürün katalogu), relational (siparişler), cache (sepet), mesajlaşma |
| ORM & Mapping     | Entity Framework Core, AutoMapper                   | Veritabanı işlemleri, DTO-entity dönüşümleri                              |
| API Gateway       | Ocelot                                              | Mikroservisleri tek giriş noktasında birleştirme                          |
| Authentication    | IdentityServer4/Duende IdentityServer, JWT          | Kullanıcı kimlik doğrulama ve yetkilendirme                               |
| Containerization  | Docker, Portainer                                   | Mikroservisleri container'larda çalıştırma ve yönetme                     |
| CQRS & Mediator   | MediatR                                             | Komut-sorgu ayrımı, order mikroservisi için                               |
| Mesajlaşma        | RabbitMQ, SignalR                                   | Asenkron iletişim, real-time bildirimler                                  |
| Frontend          | ASP.NET Core MVC, Razor Views, View Components      | UI katmanı, partial view'lar (header, carousel vb.)                       |
| Diğer             | Google Cloud Storage, RapidAPI, Localization (RESX) | Dosya depolama, harici API entegrasyonu, çok dilli destek                 |

<br><br>

## 🎯 Teknoloji Detayları
- 🔥 Backend Framework<br>
  ⚡ .NET Core (.NET 6.0)        (.csproj, Minimal APIs, Controllers)

- 🗄️ Veritabanları (Polyglot Persistence)<br>
  🟢 MongoDB                   (Catalog: Products/Categories/Images)<br>
  🟦 MSSQL Linux Container     (Order/Discount/Cargo/Comment)<br>
  🟣 PostgreSQL + PgAdmin      (Message microservice)<br>
  🔴 Redis Container           (Basket: Shopping cart cache)<br>

- ⚙️ Data Access & Mapping<br>
  📦 EntityFramework Core      (Code-first migrations)<br>
  🔄 AutoMapper                (Profile-based DTO mapping)<br>
  🗂️ Generic Repository        (Cargo servisi)<br>

- 🏗️ Architecture & Patterns<br>
  🧅 Onion Architecture        (Order: Domain/Application/Infrastructure)<br>
  ⚡ MediatR + CQRS             (Command/Query handlers)<br>
  🧩 Mediator Pattern          (Behavior pipeline)<br>

- 🌐 API Gateway & Auth<br>
  🚪 Ocelot Gateway            (JSON routing, Service Discovery)<br>
  🛡️ IdentityServer4           (OIDC/OAuth2, Duende package)<br>
  🔑 JSON Web Tokens (JWT)     (Bearer auth headers)<br>
  👤 Client Credentials Flow   (Service-to-service)<br>
  🔐 Resource Owner Password   (User login flow)<br>

- 🐳 DevOps & Containerization<br>
  🐳 Docker Compose            (Multi-container: DB + Services)<br>
  📊 Portainer CE              (Web UI container manager)<br>
  📦 Docker Volumes            (Data persistence)<br>
  🐛 DBeaver                   (DB visualization)<br>

- 📨 Communication & Real-time<br>
  🐰 RabbitMQ + Erlang         (Producer/Consumer, Direct Exchange)<br>
  ⚡ SignalR Hubs              (Admin notifications, Comment counts)<br>
  📧 SMTP Mail (Gmail)         (Contact form, Order confirmation)<br>

- 🎨 Frontend & UI/UX<br>
  🌐 ASP.NET Core MVC Areas    (Admin/User/Public layouts)<br>
  ✂️ Razor View Components     (Header, Carousel, ProductCard)<br>
  🎭 Partial Views             (ShoppingCart, ProductSlider)<br>
  🌈 Font Awesome Icons        (UI enhancements)<br>
  🎠 Bootstrap + Custom CSS    (Responsive design)<br>

- ☁️ Cloud & 3rd Party Integrations<br>
  📤 Google Cloud Storage      (Product images, JSON service account)<br>
  🌩️ RapidAPI                 (Weather, USD/EUR rates, E-commerce APIs)<br>
  🌍 RESX Localization         (Turkish/English support)<br>
  📊 Swagger + Postman         (API documentation/testing)<br>

- 🔒 Security & Best Practices<br>
  🛡️ CORS Policies             (SignalR cross-origin)<br>
  🍪 Cookie Configuration      (Secure session handling)<br>
  🔒 Authorize Attributes      ([Authorize(Policy="Manager")])<br>

---

Aşağıdaki tabloda projede yer alan tüm mikroservisler ve temel sorumlulukları özetlenmiştir:

| Mikroservis | Açıklama | Kullanılan Teknolojiler |
|------------|---------|-------------------------|
| **Catalog** | Ürün, kategori, slider, brand, feature yönetimi | ASP.NET Core, MongoDB |
| **Discount** | Kupon & indirim işlemleri | ASP.NET Core, MSSQL |
| **Order** | Sipariş ve adres yönetimi | ASP.NET Core, MSSQL, CQRS |
| **Basket** | Kullanıcı sepet işlemleri | ASP.NET Core, Redis |
| **Cargo** | Kargo & gönderim süreçleri | ASP.NET Core, MSSQL |
| **Comment** | Ürün yorumları & puanlama | ASP.NET Core, MSSQL |
| **Message** | Kullanıcı mesajlaşma sistemi | ASP.NET Core, PostgreSQL |
| **Identity** | Kimlik doğrulama & yetkilendirme | IdentityServer, JWT |
| **Gateway** | Merkezi API yönlendirme | Ocelot |



