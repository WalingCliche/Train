using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum BallColor
{
    Red, Blue, White
}
public class RandomMove : MonoBehaviour
{   
    public bool areaEnter;
    public float ballEmotionValue, emotionValueRange;

    private bool finished;
    private float speed, range;
    private float blueToWhite, whiteToRed;
    // Start is called before the first frame update
    private Vector3 randomTar, randomPos;
    private Vector2 worldPosLeftBottom, worldPosTopRight;
    private SpriteRenderer sp;
    private TMP_Text emoValueText;
    private GameObject[] circleAreas;   
    public BallColor ballColor;
    private Color redBallColor, blueBallColor, whiteBallColor;
    private Material redmat,bluemat;
    private GameObject redMatSprite, blueMatSprite;
    private void Start()
    {
        redBallColor = RandomMoveManager._ins.ballRed;
        blueBallColor = RandomMoveManager._ins.ballBlue;
        whiteBallColor = RandomMoveManager._ins.ballWhite;
        range = RandomMoveManager._ins.range;
        finished = true;
        worldPosLeftBottom = Camera.main.ViewportToWorldPoint(Vector2.zero);
        worldPosTopRight = Camera.main.ViewportToWorldPoint(Vector2.one);
        sp = GetComponent<SpriteRenderer>();
        emoValueText = GetComponentInChildren<TMP_Text>();
        InitialzeColorSetting();
        InitialColorState(ballColor);
        float randomX = RandomCircleNumber();
        float randomY = RandomCircleNumber();
        randomPos = new Vector3(randomX, randomY, 0);
        randomTar = randomPos + transform.position;
        redmat = this.transform.GetChild(0).GetComponent<SpriteRenderer>().material;//redMatSprite
        bluemat = this.transform.GetChild(1).GetComponent<SpriteRenderer>().material;//blueMatSprite
    }
    void Update()
    {       
        speed = RandomMoveManager._ins.speed;
        circleAreas = GameObject.FindGameObjectsWithTag("CircleArea");
        emoValueText.text = ballEmotionValue.ToString("f2");
        EmotionColor();//emotional value change state
        ColorStateChange(ballColor, ballEmotionValue);// state change color
        ChangeWaterByValue(ballColor,ballEmotionValue);
        LimitBoarder();
        if (finished)
        {
            randomPos = new Vector3(Random.Range(-1f, 1f)* range, Random.Range(-1f, 1f)*range,0);
          //  Debug.Log(randomPos);
            randomTar = randomPos+transform.position;
            finished = false;      
        }
        
        if (Vector3.Distance(transform.position, randomTar) < 0.01f)
        {
            finished = true;
        }
        if (finished == true) 
        {
            float randomX = RandomCircleNumber();
            float randomY = RandomCircleNumber();
            randomPos = new Vector3(randomX, randomY, 0);
            randomTar = randomPos + transform.position;
            finished = false;
        }
        blueMoveAction(ballColor);
        transform.position = Vector3.MoveTowards(transform.position, randomTar, Time.deltaTime * speed);
    }



    void LimitBoarder() {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, worldPosLeftBottom.x, worldPosTopRight.x),
                                         Mathf.Clamp(transform.position.y, worldPosLeftBottom.y, worldPosTopRight.y),
                                         0);
        if (transform.position.x - worldPosLeftBottom.x < 0.01f|| worldPosTopRight.x-transform.position.x < 0.01f)
        { 

            finished = true;
        }
        if (transform.position.y - worldPosLeftBottom.y < 0.01f || worldPosTopRight.y - transform.position.y < 0.01f)
        {
            finished = true;
        }
        //if (randomTar.x - worldPosLeftBottom.x < 0.01f || worldPosTopRight.x - randomTar.x < 0.01f)
        //{
        //    randomTar = -1f * randomTar;
        //}
        //if (randomTar.y - worldPosLeftBottom.y < 0.01f || worldPosTopRight.y - randomTar.y < 0.01f)
        //{
        //    randomTar = -1f * randomTar;
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ball"))
        {
       //       finished = true;
            randomTar = -1f * randomTar;
      
        }
    }

    void EmotionColor() 
    {

        ballEmotionValue = Mathf.Clamp(ballEmotionValue, -1f* emotionValueRange, 1f*emotionValueRange);

        if (ballEmotionValue < blueToWhite)//blue
        {
            ballColor = BallColor.Blue;
        }

        if (ballEmotionValue > whiteToRed)//red
        {
            ballColor = BallColor.Red;
        }

        if (ballEmotionValue > blueToWhite && ballEmotionValue < whiteToRed)//white
        {
            ballColor = BallColor.White;
        }


    }
    void InitialzeColorSetting() {
        blueToWhite = RandomMoveManager._ins.blueToWhite;
        whiteToRed = RandomMoveManager._ins.whiteToRed;
        emotionValueRange = RandomMoveManager._ins.emotionValueRange;
    }

    void InitialColorState(BallColor color)
    {
        switch (color)
        {
            case BallColor.Red:
                sp.color = RandomMoveManager._ins.ballRed;
                ballEmotionValue = emotionValueRange;
                break;
            case BallColor.Blue:
                sp.color = RandomMoveManager._ins.ballBlue;
                ballEmotionValue = -emotionValueRange;
                break;
            case BallColor.White:
                sp.color = RandomMoveManager._ins.ballWhite;
                ballEmotionValue = 0f;
                break;
        }

    }
    void ColorStateChange(BallColor color,float emotionValue)
    {
        switch (color)
        {
            case BallColor.Red:
                float lerp = (emotionValue - whiteToRed) / (emotionValueRange - whiteToRed);
                sp.color = Color.Lerp(whiteBallColor, redBallColor, lerp);
                break;
            case BallColor.Blue:
                float lerpblue = (emotionValue + emotionValueRange) / (emotionValueRange - whiteToRed);
                sp.color = Color.Lerp(blueBallColor, whiteBallColor, lerpblue);
                break;
            case BallColor.White:
                sp.color = whiteBallColor;

                break;
        }

    }
    float RandomCircleNumber()
    {
        float Range = RandomMoveManager._ins.range;
        float randomX = Random.Range(-1f, 1f);
        if (randomX > 0) {
            randomX = randomX * (Range - 1)+1f;
        }
        if (randomX < 0)
        {
            randomX = randomX + (Range - 1)-1f;
        }
        if (randomX == 0)
        {
            randomX = 0;
        }
        return randomX;
    }
    void blueMoveAction(BallColor ballcolor) 
    {
        if (ballcolor == BallColor.Blue)
        { 
          GameObject closest = null;
           float distance = Mathf.Infinity;
          Vector3 position = transform.position;

          foreach (GameObject area in circleAreas)
          {
             Vector3 diff = area.transform.position - position;
              float curDistance = diff.sqrMagnitude;
              if (curDistance < distance)
              {
                 closest = area;
                 distance = curDistance;
               }
           }
            randomTar = closest.transform.position;
    }


 }




    //TODO Value change Material
    void ChangeWaterByValue(BallColor color,float value) {

        switch (color)
        {
            case BallColor.Red:
                value = (value - whiteToRed) / (emotionValueRange- whiteToRed);
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(false);
                redmat.SetFloat("_GrowUp", value);
                break;
            case BallColor.Blue:
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(true);
                value = (value * (-1f) + blueToWhite) / (blueToWhite + emotionValueRange);
                bluemat.SetFloat("_GrowUp", value);
                break;
            case BallColor.White:
                sp.color = whiteBallColor;
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(false);
                break;
        }








    }
    

}

