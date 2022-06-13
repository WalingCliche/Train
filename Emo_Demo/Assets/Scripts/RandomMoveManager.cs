using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMoveManager : MonoBehaviour
{
    public static RandomMoveManager _ins;


    
    public Color ballRed;
    public Color ballBlue;
    public Color ballWhite;

    public float speed;
    public float range;
    public float blueToWhite;
    public float whiteToRed;
    public float emotionValueRange;
    public float redAreaSpeed;
    public float blueAreaSpeed;
    public Material RedMat;
    public Material BlueMat;
    public float blueExplodeTime;
    public GameObject blueBallPref;
    // Start is called before the first frame update
    private void Awake()
    {
        _ins = this;

    }

}
