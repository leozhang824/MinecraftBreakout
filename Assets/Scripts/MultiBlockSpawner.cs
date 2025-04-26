using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiBlockSpawner : MonoBehaviour
{
    public GameObject MainPrefab;

    public GameObject SubPrefab;

    public int subCount = 5;

    public int Axis;

    // Start is called before the first frame update
    void Start()
    {
         RandomGeneration();
    }

    private void RandomGeneration() 
    {
        List<int> prefabList = new List<int>();
        int mainCount = 19 - subCount;
        for (int i = 0; i < mainCount; i++) {
            prefabList.Add(0);
        }
        for (int i = 0; i < subCount; i++) {
            prefabList.Add(1);
        }

        for (int i = -9; i <= 9; i++){
            int prefabIndex = Random.Range(0, 19);
            int prefabType = prefabList[prefabIndex];

            if (subCount <= 0) {
                prefabType = 0;
            } else if (mainCount <= 0) {
                prefabType = 1;
            }
            
            Vector2 spawn = new Vector2(i, Axis);
            if (prefabType == 0) {
                Instantiate(MainPrefab, spawn, Quaternion.identity);
                mainCount--;
            } else {
                Instantiate(SubPrefab, spawn, Quaternion.identity);
                subCount--;
            }   
        } 
    }
}
