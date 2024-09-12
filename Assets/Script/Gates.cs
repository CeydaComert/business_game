using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates : MonoBehaviour
{

    // timer değerini değiştirecek scriptin referansını alıyoruz
    public Timer timerScript; // bu referansı Unity'de kapının Inspector penceresinden ayarlayın
    public float timeChangeAmount; // bu değeri pozitif (ekleme) veya negatif (çıkarma) yapabilirsiniz
    public TextMesh gateValueTextMesh; // Kapının üzerindeki TextMesh bileşeni için referans
    
    private void Start()
    {
        // Eğer TextMesh bileşeni atanmadıysa, otomatik bulmayı dene
        if (gateValueTextMesh == null)
        {
            gateValueTextMesh = GetComponentInChildren<TextMesh>(); // Alt objelerden TextMesh bileşenini bulmaya çalış
        }
        if (gateValueTextMesh != null) // TextMesh referansının atanıp atanmadığını kontrol ediyoruz
        {
        // kapının üstündeki yazıyı okuyarak timeChangeAmount ayarlasın
        string gateValueText = GetComponentInChildren<TextMesh>().text; // kapının üzerindeki TextMesh bileşeninden değeri alıyoruz
        if (float.TryParse(gateValueText, out float parsedValue))
        {
            timeChangeAmount = parsedValue; // eğer değer sayıya dönüştürülebiliyorsa timeChangeAmount olarak ayarlasın
        }
        else
        {
            Debug.LogWarning("Kapının üzerindeki değer geçerli bir sayı değil: " + gateValueText);
        }
        }
        else
        {
            Debug.LogError("TextMesh bileşeni atanmadı. Lütfen bileşeni script'te tanımlayın.");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // karakter kapıya çarptığında tetiklenecek işlem
        if (other.CompareTag("Player")) // "Player" tag'ine sahip olan objeyle çarpıştığında çalışır
        {
            timerScript.ChangeTime(timeChangeAmount); // Timer değerini değiştiriyoruz
        }
    }

}
