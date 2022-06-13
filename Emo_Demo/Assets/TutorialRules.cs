using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialRules : MonoBehaviour
{
    public GameObject[] circle;
    // Start is called before the first frame update
    void Start()
    {
        circle = GameObject.FindGameObjectsWithTag("CircleArea");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RandomMoveManager._ins.speed = 1f;
            foreach (GameObject x in circle) {
                x.GetComponent<CircleState>().blueExplodeTimer = 0;
            }
            RandomMoveManager._ins.blueExplodeTime = 6f;
            
        }
    }
}
