using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //bunu eklemeden önce sliderı görmüyordu

public class Timer : MonoBehaviour
{

    public Slider timerSlider;
    public float gameTime;

    private bool stopTimer;
    private float elapsedTime; // toplam geçen zamanı tutmak için bir değişken

    void Start()
    {
        stopTimer = false;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
        elapsedTime = 0f; // zamanı başlatıyoruz

    }
    
    void Update()
    {
        if (stopTimer) return; // timer durduysa güncellemeye gerek yok
        
        //ekleme-çıkarma değerleri alacağı için time değerini güncelliyoruz
        elapsedTime += Time.deltaTime; // her frame'de geçen süreyi topluyoruz.
        float time = gameTime - elapsedTime;

        int minutes = Mathf.FloorToInt((time / 60));
        int seconds = Mathf.FloorToInt((time - minutes * 60f));
        
        if (time <= 0)
        {
            stopTimer = true;
            time = 0; // zaman sıfırlanmalı
        }
        timerSlider.value = time;
    }
    // timer'ı değiştirmek için olan fonksiyon
    public void ChangeTime(float amount)
    {
        gameTime += amount; // timer değerini değiştiriyoruz
        if (gameTime < 0) gameTime = 0; // timer negatif olmasın
        timerSlider.maxValue = gameTime; // slider'ın maksimum değerini güncellesin
    }
    
}
