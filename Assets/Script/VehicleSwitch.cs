using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VehicleSwitch : MonoBehaviour
{
    
public GameObject vehicle;
//public GameObject player;

/*private void Start()
{
    vehicle.SetActive(true);
    //ilk başta aracı aktif olmayacak şekilde ayarlarız
}
*/

private void OnTriggerEnter(Collider other)
{
    if (other.gameObject.CompareTag("Vehicle"))
    {
        //çarpışma esnasına player objesinin kaybolması ve aracın belirmesi beklenir
       // player.SetActive(false);
       // vehicle.SetActive(true);
        //vehicle.GetComponent<VehicleController>().enabled = true;
        
        
        gameObject.SetActive(false);
        vehicle.GetComponent<VehicleController>().StartMoving();
        Debug.Log("Çarpışma gerçekleşti, Vehicle hareket etmeye başlamalı."); 
        
        //oyuncu yok oldu, platform üzerinde düz hareket devam etti ancak aracı sağ sol hareket ettirme özelliklerini tanımlamamız lazım
        
        
    }

}
    
}
