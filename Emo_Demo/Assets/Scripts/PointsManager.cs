using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsManager : MonoBehaviour
{
    public static PointsManager _ins;
    public TMP_Text pointsText;
    public int points;
    public int redAddPoints;
    public int blueMinusPoints;
    public int pointsCheckTimer;
    public float destroyTime;
    public float maxPoint;
    public GameObject redPointIcon;
    public GameObject bluePointIcon;
    public GameObject redPointPos,bluePointPos;
    // Start is called before the first frame update
    private void Awake()
    {
        _ins = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text = points.ToString();
        float lerp = points / maxPoint + 0.5f;
        pointsText.color = Color.Lerp(Color.blue, Color.red, lerp);

 //       Camera.main.backgroundColor = Color.Lerp(Color.blue, Color.red, lerp);
    }
}
