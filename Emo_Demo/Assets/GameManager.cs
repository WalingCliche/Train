using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public enum GameState{indle,win,lose}
public class GameManager : MonoBehaviour
{
    
    public static GameManager _ins;
    public GameState gameState;
    public GameObject winUI, loseUI,winingtimerUI;
    public CountdowTimerManager time;
    public GoalManager goal;
    private GameObject[] areas;
    public float winTime;
    private float wintimer;
    private bool winning;
    public bool losing;
    public bool start;
    private void Awake()
    {
        _ins = this;
        start = true;
    }
    private void Start()
    {
        areas = GameObject.FindGameObjectsWithTag("CircleArea");
        winUI.SetActive(false);
        loseUI.SetActive(false);
    }
    private void Update()
    {

        areas = GameObject.FindGameObjectsWithTag("CircleArea");
  //      CountColor(areas);
        Result();
        if (losing)
        {
            gameState = GameState.lose;
        }
        if (gameState == GameState.indle)
        {
            if (time.timer == 0f )
            {
                gameState = GameState.lose;
                return;
            }

           int  wincount = 0;
            foreach (var item in areas)
            {
                if (item.GetComponent<CircleState>().state != goal.goal)
                    wincount++;
            }
            if (wincount == 0)
                winning = true;
            else
            {
                winning = false;
                wintimer = 0;
            }

            if (winning)
                wintimer += Time.deltaTime;
            else
                wintimer = 0;
            if (wintimer > winTime)
            {
                gameState = GameState.win;
            }
        }

        if (winingtimerUI != null&&wintimer != 0)
        {
            winingtimerUI.SetActive(true);
            winingtimerUI.GetComponent<TMP_Text>().text = ((int)(winTime-wintimer)+1).ToString();
        }
        else
            winingtimerUI.SetActive(false);

    }

    void Result() {
        if (gameState == GameState.win)
        {
            Destroy(winingtimerUI);
            winUI.SetActive(true);
            time.counting = false;
            foreach (var item in areas)
            {
                item.GetComponent<CircleState>().enabled = false;
            }
        }
        if (gameState == GameState.lose) 
        {
            winingtimerUI.SetActive(false);
            loseUI.SetActive(true);
         //   Time.timeScale = 0;
            foreach (var item in areas)
            {
                item.GetComponent<CircleState>().enabled = false;
            }
        }
    }
    private void OnDisable()
    {
        start = false;
    }
    //void CountColor(GameObject[] balls)
    //{
    //    int redtemp = 0;
    //    int bluetemp = 0;
    //    int whitetemp = 0;
    //    foreach (var color in balls)
    //    {
    //        if (color.TryGetComponent<CircleState>(out CircleState x))
    //        {
    //            if (x.state == CircleColorState.CircleRed)

    //            {
    //                redtemp++;
    //            }
    //            if (x.state == CircleColorState.CircleBlue)
    //            {
    //                bluetemp++;
    //            }
    //            if (x.state == CircleColorState.CircleWhite)
    //            {
    //                whitetemp++;
    //            }
    //        }
    //    }
    //    red = redtemp;
    //    blue = bluetemp;
    //    white = whitetemp;
    //}


}
