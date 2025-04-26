using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iron : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Pickaxe")) {
            if (collision.gameObject.GetComponent<Pickaxe>().level >= 1) {
                Manager.ScorePoints(3);
                Manager.OreIncrease(1, "Iron");
                Destroy(this.gameObject);
            }
        }
    }  

}
