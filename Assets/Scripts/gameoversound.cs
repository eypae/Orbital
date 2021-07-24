using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameoversound : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
