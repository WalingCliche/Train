using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum CircleColorState 
{
CircleRed,CircleBlue,CircleWhite
}
public class CircleState : MonoBehaviour
{
    public Sprite areaRed;
    public Sprite areaBlue;
    public Sprite areaWhite;
    private Collider2D[] areaBall;
    private float blueSpeed;
    private float redSpeed;
    public CircleColorState state;
    private SpriteRenderer sp;
    private Animator ani;
    private float redPointsTimer;
    private float bluePointsTimer;
    public float blueExplodeTimer;
    private Material mat;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        blueSpeed = RandomMoveManager._ins.blueAreaSpeed;
        redSpeed = RandomMoveManager._ins.redAreaSpeed;
        sp = transform.GetComponent<SpriteRenderer>();
        mat = this.GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        areaBall = GetComponent<CircleDetect>().areaBall;
        changeCircleAreaColor(transform.GetComponent<CircleDetect>().count);
        ColorState(state);
        blueExplode();
      //  ColorPointsTimer(state);

    }

    void ColorState(CircleColorState color)
    {
        switch (color) 
        {
            case CircleColorState.CircleRed:
                foreach (Collider2D ball in areaBall)
                {
                    blueExplodeTimer = 0;
                    sp.sprite = areaRed;
                    if(ball.TryGetComponent<RandomMove>(out RandomMove x))
                    x.ballEmotionValue += Time.deltaTime* redSpeed;
                }                
                break;
            case CircleColorState.CircleBlue:
                blueExplodeTimer += Time.deltaTime;
                foreach (Collider2D ball in areaBall)
                {
                    sp.sprite = areaBlue;
                    if (ball.TryGetComponent<RandomMove>(out RandomMove x))
                        x.ballEmotionValue -= Time.deltaTime*blueSpeed;
                }
                break;
            case CircleColorState.CircleWhite:
                {
                    blueExplodeTimer = 0;
                    sp.sprite = areaWhite;
                }
                break;
        }
    }
    void changeCircleAreaColor(int count)
    {
        if (count > 0)//TurnRed
        {
            transform.GetComponent<CircleState>().state = CircleColorState.CircleRed;
            ani.SetBool("HappyToNormal", false);
         //   ani.SetBool("SadToNormal", false);
            ani.SetBool("NormalToHappy", true);
            mat.SetFloat("LiquidUV_DistanceX_1", 0);
            mat.SetFloat("LiquidUV_DistanceY_1", 0);

        }
        if (count == 0)
        {
            transform.GetComponent<CircleState>().state = CircleColorState.CircleWhite;
            ani.SetBool("NormalToHappy", false);
            ani.SetBool("NormalToSad", false);
            ani.SetBool("HappyToNormal", true);
            ani.SetBool("SadToNormal", true);
            mat.SetFloat("LiquidUV_DistanceX_1", 0);
            mat.SetFloat("LiquidUV_DistanceY_1", 0);
        }
        if (count < 0)
        {
            transform.GetComponent<CircleState>().state = CircleColorState.CircleBlue;
          //  ani.SetBool("HappyToNormal", false);
            ani.SetBool("SadToNormal", false);
            ani.SetBool("NormalToSad", true);
            mat.SetFloat("LiquidUV_DistanceX_1", 0.3f);
            mat.SetFloat("LiquidUV_DistanceY_1", 0.3f);

        }
    }

    void ColorPointsTimer(CircleColorState color) 
    {
        switch (color)
        {
            case CircleColorState.CircleRed:
                redPointsTimer += Time.deltaTime;
                break;
            case CircleColorState.CircleBlue:
                bluePointsTimer += Time.deltaTime;
                break;
            case CircleColorState.CircleWhite:
                break;
        }
        if (redPointsTimer > PointsManager._ins.pointsCheckTimer) 
        {
            PointsManager._ins.points += PointsManager._ins.redAddPoints;
            //GameObject.Instantiate(PointsManager._ins.redPointIcon).transform.position =
            //new Vector3(transform.position.x + Random.Range(-1, 1) * transform.localScale.x * 0.2f,
            //                     transform.position.y + Random.Range(-1, 1) * transform.localScale.x * 0.2f,
            //                     0);
            GameObject x = GameObject.Instantiate(PointsManager._ins.redPointIcon);

            x.transform.localPosition = PointsManager._ins.redPointPos.transform.position;
            x.transform.SetParent(PointsManager._ins.redPointPos.transform.parent);
            redPointsTimer = 0;
        }
        if (bluePointsTimer > PointsManager._ins.pointsCheckTimer)
        {
            PointsManager._ins.points -= PointsManager._ins.blueMinusPoints;
            //GameObject.Instantiate(PointsManager._ins.bluePointIcon).transform.position =
            //new Vector3(transform.position.x + Random.Range(-1, 1) * transform.localScale.x*0.2f,
            //                     transform.position.y + Random.Range(-1, 1) * transform.localScale.x*0.2f,
            //                     0);
            GameObject x = GameObject.Instantiate(PointsManager._ins.bluePointIcon);
            x.transform.localPosition = PointsManager._ins.bluePointPos.transform.position;
            x.transform.SetParent(PointsManager._ins.bluePointPos.transform.parent);
            bluePointsTimer = 0;
        }

    }
    void blueExplode() {
        float x = blueExplodeTimer / RandomMoveManager._ins.blueExplodeTime;//0-1
        if (x > 0.3f)
        {
            mat.SetFloat("LiquidUV_WaveX_1", x * 3f);
            mat.SetFloat("LiquidUV_WaveY_1", x * 3f);
        }
        else
        {
            mat.SetFloat("LiquidUV_WaveX_1", 0);
            mat.SetFloat("LiquidUV_WaveY_1", 0);
        }
        if (blueExplodeTimer > RandomMoveManager._ins.blueExplodeTime) 
        {
            GameObject.Instantiate(RandomMoveManager._ins.blueBallPref).transform.position = transform.position;
            GameObject.Instantiate(RandomMoveManager._ins.blueBallPref).transform.position = transform.position + new Vector3(0.1f,0.1f,0);
            GameObject.Instantiate(RandomMoveManager._ins.blueBallPref).transform.position = transform.position - new Vector3(0.1f, 0.1f, 0);
            GameManager._ins.gameState = GameState.lose;
            blueExplodeTimer = 0;
            Destroy(gameObject);
        }
    }

}

