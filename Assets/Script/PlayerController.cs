using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // İleri doğru hareket hızı
    public float slideSpeed = 10f; // Sağ-sol hareket hızı

    private Vector3 initialClickPosition; // Ekranda tıklanan ilk pozisyon
    private Vector3 initialPlayerPosition; // Tıklama anındaki oyuncu pozisyonu

    void Update()
    {
        MoveForward(); // Karakteri ileri doğru hareket ettir
        HandleSlideMovement(); // Sağa-sola hareketi kontrol et
    }

    private void MoveForward()
    {
        transform.position += Vector3.forward * Time.deltaTime * moveSpeed; // İleri hareket
    }

    private void HandleSlideMovement()
    {
        if (Input.GetMouseButtonDown(0)) // Ekrana ilk dokunulduğunda
        {
            initialClickPosition = Input.mousePosition; // Dokunulan pozisyonu kaydet
            initialPlayerPosition = transform.position; // Oyuncunun pozisyonunu kaydet
        }
        else if (Input.GetMouseButton(0)) // Dokunma devam ederken
        {
            float slideAmount = (Input.mousePosition.x - initialClickPosition.x) / Screen.width * slideSpeed; // Sağa-sola kaydırma hesapla
            Vector3 newPosition = initialPlayerPosition + Vector3.right * slideAmount; // Yeni pozisyonu hesapla
            transform.position = new Vector3(newPosition.x, transform.position.y, transform.position.z); // Yeni pozisyonu uygula
        }
    }
}