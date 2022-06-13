using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    public static SystemManager _ins;

    private void Awake()
    {
        _ins = this;
    }
    
}
