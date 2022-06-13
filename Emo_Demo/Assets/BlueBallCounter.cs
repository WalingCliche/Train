using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BlueBallCounter : MonoBehaviour
{
    public int blueCount;
    public TMP_Text blueCountUI;
    private string UIText;
    private GameObject[] balls;
    // Start is called before the first frame update
    void Start()
    {
        UIText = blueCountUI.text;
    }

    // Update is called once per frame
    void Update()
    {
        balls = GameObject.FindGameObjectsWithTag("Ball");
        int temp = 0;
        foreach (GameObject x in balls) {
            if (x.GetComponent<RandomMove>().ballColor == BallColor.Blue)
            {
                temp++;
            }
            blueCount = temp;
            
        }
        blueCountUI.text = UIText+blueCount;
    }
}
