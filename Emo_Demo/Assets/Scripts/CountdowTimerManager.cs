using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CountdowTimerManager : MonoBehaviour
{
    public string text;
    public TMP_Text timerText;
    public float countTime;
    public float countDownSpeed;
    [HideInInspector]
    public float timer;
    public bool counting;
    // Start is called before the first frame update
    void Start()
    {
        timer = countTime;
        text = timer.ToString("f2").Replace(".", ":");
        counting = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (counting)
        {
            timer -= Time.deltaTime * countDownSpeed;
            timerText.text = timer.ToString("f2").Replace(".", ":");
            float lerp = 1f-timer / countTime;
            timerText.color = Color.Lerp(Color.white, Color.red, lerp);
        }
        if (timer<0) 
        {
     //       Time.timeScale = 0f;
            timer = 0;
            timerText.text ="0:00";
            counting = false;
        }
    }
}
