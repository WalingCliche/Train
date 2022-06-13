using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
[ExecuteInEditMode]
public class SetTime : MonoBehaviour
{
    public GameObject TimeUI;
    public CountdowTimerManager countDown;
    private void Update()
    {
        if (GameManager._ins!=null&&!GameManager._ins.start)
        {
            TimeUI.GetComponent<TMP_Text>().text = countDown.countTime.ToString() + ":00";
        }
    }

}
