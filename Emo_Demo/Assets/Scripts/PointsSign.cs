using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public enum PointsSignColor 
{ 
    red,blue
}
public class PointsSign : MonoBehaviour
{
    public  PointsSignColor pointColor;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,PointsManager._ins.destroyTime);
        if (pointColor == PointsSignColor.red)
            GetComponent<TMP_Text>().text = "+" + PointsManager._ins.redAddPoints;
        if (pointColor == PointsSignColor.blue)
            GetComponent<TMP_Text>().text = "-" + PointsManager._ins.blueMinusPoints;
    }

}
