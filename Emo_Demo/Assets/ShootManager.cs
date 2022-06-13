using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour
{
    public static ShootManager _ins;
    public GameObject ShootBall;
    public float shootTime;
    public float changeTime;
    public float force;
    private GameObject redBall, blueBall, whiteBall;
    private void Awake()
    {
        _ins = this;
    }
    private void Start()
    {
        ShootBall.SetActive(false);
        StartCoroutine(Shoot(shootTime));
    }
    private void Update()
    {
        redBall = (GameObject)Resources.Load("Prefabs/Balls/Red");
        blueBall = (GameObject)Resources.Load("Prefabs/Balls/Blue");
        whiteBall = (GameObject)Resources.Load("Prefabs/Balls/White");
        if (Input.GetKeyDown(KeyCode.Space)) { 
       // GameObject.Instantiate()
        }
    }
    IEnumerator Shoot(float time) {
        yield return new WaitForSeconds(time);
        ShootBall.SetActive(true);
        for (int i = 0; i < ShootBall.transform.childCount; i++)
        {
            ShootBall.transform.GetChild(i).gameObject.AddComponent<ShootBullet>();
           // ShootBall.transform.GetChild(i).gameObject.GetComponent<RandomMove>().enabled = false;
        }
    }
}
