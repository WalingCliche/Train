using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trains : MonoBehaviour
{
    [Header("泥头车Setting")]
    public Transform[] pos;
    public float trainSpeed;
    public float accerlateSpeed;
    private float startSpeed;
    private Transform targetPos;
    private Vector3 startPos;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        startPos = transform.position;
        startSpeed = trainSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        targetPos = pos[index];
        Vector3 v = (targetPos.position - transform.position).normalized;
        transform.right = v;
        trainSpeed += Time.deltaTime* accerlateSpeed;
        transform.position = Vector2.MoveTowards(transform.position, targetPos.position, Time.deltaTime * trainSpeed);
        if (Vector2.Distance(transform.position, pos[index].position) < 0.02f)
        {
            if (index < pos.Length - 1)
                index++;
        }

        if (Vector2.Distance(transform.position, pos[index].position) < 0.02f && index == pos.Length - 1)
        {
            // Destroy(gameObject);
            TrainReset();
            int x = Random.Range(0, TrainManager._ins.trains.Length);
            while (gameObject == TrainManager._ins.trains[x])
                x = Random.Range(0, TrainManager._ins.trains.Length);
            TrainManager._ins.trains[x].SetActive(true);
        }






    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Destroy(collision.gameObject);
        }
    }
    void TrainReset()
    {
        index = 0;
        gameObject.transform.position = startPos;
        trainSpeed = startSpeed;
        gameObject.SetActive(false);
    }


}