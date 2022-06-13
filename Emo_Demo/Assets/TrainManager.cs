using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainManager : MonoBehaviour
{
    public GameObject[] trains;
    public static TrainManager _ins;
    // Start is called before the first frame update
    private void Awake()
    {
        _ins = this;
    }
    void Start()
    {
        trains = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            trains[i] = transform.GetChild(i).GetChild(0).gameObject;
            if (i != 0)
                trains[i].SetActive(false);
        }
    }
}