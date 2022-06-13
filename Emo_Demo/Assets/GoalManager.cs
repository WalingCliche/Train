using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
[ExecuteInEditMode]
public class GoalManager : MonoBehaviour
{
    public CircleColorState goal;
    private int goalNum;
    public RawImage goalImg;
    public TMP_Text goalText;
    private void Start()
    {
        goalNum = GameObject.FindGameObjectsWithTag("CircleArea").Length;
    }
    private void Update()
    {
        switch (goal)
        {
            case CircleColorState.CircleRed:
                goalImg.texture =(Texture2D)Resources.Load("Pics/HAPPY");
                break;
            case CircleColorState.CircleBlue:
                goalImg.texture = (Texture2D)Resources.Load("Pics/UNHAPPY");
                break;
            case CircleColorState.CircleWhite:
                goalImg.texture = (Texture2D)Resources.Load("Pics/NORMAL");
                break;
        }
        goalText.text ="X"+ goalNum;
    }
}
