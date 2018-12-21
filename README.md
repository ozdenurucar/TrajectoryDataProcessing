# TrajectoryDataProcessing

Hareket eden nesnelerin gerçek zamanlı olarak konum bilgilerinin tespit edilmesi ve bu konumlar kullanılarak seyahat yollarının (trajectories) olusturulması günümüz teknolojisinin getirmiş olduğu imkanlardan biridir. Seyahat verilerinden bilgi çıkarımı için birçok ön işlemler yapılır. Gezinge verisi işleme projesinde de bu işlemlerden indirgeme ve sorgulama işlemleri kullanılmıştır. İndirgeme işlemi ile ham veri setindeki veri sayısı azaltılmıştır. İndirgeme işlemi için Douglas Peucker indirgeme (Data Reduction) algoritması kullanılmıştır. Sorgu işlemi için ise, indeksleme mantığı kullanılmıştır. Üzerinde sorgu yapılacak ham veya indirgenmiş veriler sunucuya gönderilerek sunucu tarafında kullanılan Quadtree yapısı ile indekslenerek, indekslenen veriler üzerinden sorgu yapılmıştır.



Proje sunucu ve istemci olarak iki taraflı geliştirilmiştir.
İstemci kısmı; Visual Studio ortamında C# programlama dili kullanarak geliştirilmiştir. Haritada gösterme işlemleri için Gmap.Net kütüphanesi kullanılmıştır.
Server kısmı ise Visual Studio ortamında ve Qt 5.10 versiyonu ile birlikte C++ programlama dili ile kodlanmıştır. Sunucu-istemci işlemleri için ise soket teknolojisi kullanılmıştır. Sunucu-istemci arasında veri alış-verişi için JSON formatı kullanılmıştır. Harita işlemleri için GoogleMap kullanılmıştır.
