using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    private float changeTime;
    private float force;
    private Rigidbody2D rig;
    private void Start()
    {
        force = ShootManager._ins.force;
        changeTime = ShootManager._ins.changeTime;
        force = force * Random.Range(1f, 1.3f);
        rig = GetComponent<Rigidbody2D>();
        rig.AddForce(new Vector2(Random.Range(0.5f,1.5f), Random.Range(0.5f, 1.5f))*force);
       // StartCoroutine(Move(changeTime));
    }
    IEnumerator Move(float sec) { 
    yield return new WaitForSeconds(sec);
        GetComponent<RandomMove>().enabled = true;    
    }
}
