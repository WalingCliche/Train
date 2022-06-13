using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anger : MonoBehaviour
{
    public float detectRadius;
    private Collider2D[] aroundBalls;

    void Update()
    {
        aroundBalls = Physics2D.OverlapCircleAll(transform.position, detectRadius);
        Explode(aroundBalls);
    }
    void Explode(Collider2D[] aroundBalls) {
        foreach(var ball in aroundBalls) 
        {
            if(ball.gameObject!=gameObject)
            Destroy(ball.gameObject);
        }
        
    }
}
