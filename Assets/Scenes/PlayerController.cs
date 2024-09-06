using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   [Header("Setting")] [SerializeField] private float moveSpeed;
   [Header("Control")] [SerializeField] private float slidSpeed;
   private Vector3 clickScreenPosition;
   private Vector3 clickPlayerPosition;
   private void Start()
   {
      
   }

   private void Update()
   {
      MoveSpeedForward();
      ManageControl();
   }

   private void MoveSpeedForward()
   {
      transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
   }

   private void ManageControl()
   {
      if (Input.GetMouseButtonDown(0))
      {
         clickScreenPosition = Input.mousePosition;
         clickPlayerPosition = transform.position;
      }
      else if (Input.GetMouseButton(0))
      {
         float xScreenDifference = Input.mousePosition.x - clickScreenPosition.x;

         xScreenDifference /= Screen.width;
         xScreenDifference *= slidSpeed;

         Vector3 pos = transform.position;
         pos.x = clickPlayerPosition.x + xScreenDifference;
         transform.position = pos;
         
        // transform.position = clickPlayerPosition + Vector3.right * xScreenDifference;
      }
   }
}
