using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleBlockSpawner : MonoBehaviour
{
    public GameObject Prefab;

    public int Axis;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = -9; i <= 9; i++){
            Vector2 spawn = new Vector2(i, Axis);
            Instantiate(Prefab, spawn, Quaternion.identity);
        }  
    }
}
