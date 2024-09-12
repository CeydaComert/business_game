using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VehicleController : MonoBehaviour
{
    public float speed = 5f; // vehicle ileri dogru hızı
    public float slideSpeed = 5f;
    private bool isMoving = false; 
    // hareket durumu kontrolü yapiyorum ki obje platformda hareket halinde olmasin
    
    public float slideLimit = 2f;  //sınır koyalim
    
    private Vector3 initialClickPosition; // Ekranda tıklanan ilk pozisyon
    private Vector3 initialVehiclePosition; // Tıklama anındaki araç pozisyonu

    
   // private bool isDragging = false; // dokunma kontrol

    void Update()
    {
        // isMoving true olduğunda Vehicle hareket eder
        if (isMoving)
        {

            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            HandleSlideMovement(); 
        }
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime); // İleri hareket
    }

    private void HandleSlideMovement()
    {
        if (Input.GetMouseButtonDown(0)) //
        {
            initialClickPosition = Input.mousePosition; // dokunulan pozisyonu kaydet
            initialVehiclePosition = transform.position; // araç pozisyonunu kaydet
        }
        else if (Input.GetMouseButton(0)) // 
        {
            float slideAmount = (Input.mousePosition.x - initialClickPosition.x) / Screen.width * slideSpeed; // sağa-sola kaydırma hesabı
            float newXPosition = Mathf.Clamp(initialVehiclePosition.x + slideAmount, -slideLimit, slideLimit); 
            //önceki kodda kayma işlemi objeyi game ekranından çıkardığı için pozisyonu sınırlayalım
            transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z); 
        }
    }

    public  void StartMoving()
    {
        isMoving = true; // hareket başlasın
        Debug.Log("Vehicle");
    }
}



