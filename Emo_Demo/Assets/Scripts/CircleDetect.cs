using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class CircleDetect : MonoBehaviour
{
    public int red;
    public int blue;
    public int white;
    public int count;
    private float detectRadius;
    [HideInInspector]
    public  Collider2D[] areaBall;
    private SpriteRenderer sp;
    private TMP_Text circleText;
    private bool oneTime;
    void Start()
    {
        detectRadius = transform.localScale.x * 0.5f;
        sp = GetComponent<SpriteRenderer>();
        circleText = GetComponentInChildren<TMP_Text>(); 
    }

    void Update()
    {
        areaBall=Physics2D.OverlapCircleAll(transform.position, detectRadius);
        CountColor(areaBall);
        count = red - blue;
        circleText.text = "Red:" + red + "\n" +
                            "Blue:" + blue + "\n" +
                          //  "White:" + white + "\n" +
                            "Count:" +count;

    }
    //void CountColor(Collider2D[] balls) 
    //{ 
    //    red = CountColor(areaBall).x;
    //    blue = CountColor(areaBall).y;
    //    white = CountColor(areaBall).z;

    //    if (oneTime)
    //    {
    //        if (blue > red)
    //        {
    //            areaBall = Physics2D.OverlapCircleAll(transform.position, detectRadius);
    //            foreach (Collider2D ball in areaBall)
    //            {

    //                ball.GetComponent<SpriteRenderer>().color = Color.blue;
    //                ball.GetComponent<RandomMove>().ballColor = BallColor.Blue;
    //            }
    //        }
    //        if (red > blue)
    //        {
    //            areaBall = Physics2D.OverlapCircleAll(transform.position, detectRadius);
    //            foreach (Collider2D ball in areaBall)
    //            {
    //                ball.GetComponent<SpriteRenderer>().color = Color.red;
    //                ball.GetComponent<RandomMove>().ballColor = BallColor.Red;
    //            }
    //        }
    //        oneTime = false;
    //    }
    //}
    void CountColor(Collider2D[] balls)
    {
        int redtemp = 0;
        int bluetemp = 0;
        int whitetemp = 0;
        foreach (Collider2D ball in areaBall)
        {
            if (ball.gameObject.TryGetComponent<RandomMove>(out RandomMove x)) 
            {
                if (x.ballColor == BallColor.Red)

                {
                    redtemp++;
                }
                if (x.ballColor == BallColor.Blue)
                {
                    bluetemp++;
                }
                if (x.ballColor == BallColor.White)
                {
                    whitetemp++;
                }
            }
        }
        red = redtemp;
        blue = bluetemp;
        white = whitetemp;
    }
}



