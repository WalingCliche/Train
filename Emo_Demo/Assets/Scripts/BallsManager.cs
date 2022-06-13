using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsManager : MonoBehaviour
{
    public Sprite happy;
    public Sprite sad;
    public Sprite normal;
    public static BallsManager _ins;
    public float changeCDTime;
    // Start is called before the first frame update
    private void Awake()
    {
        _ins = this;
    }
}
