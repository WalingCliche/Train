using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimeManager : MonoBehaviour
{
    public static TimeManager _ins;
    public TMP_Text timerText;
    public float gapTime;
    private float timer;
    private void Awake()
    {
        _ins = this;
    }
    public void Start()
    {
    }
    private void Update()
    {
        timer += Time.deltaTime;
        timerText.text = timer.ToString("0.00");

    }


}
