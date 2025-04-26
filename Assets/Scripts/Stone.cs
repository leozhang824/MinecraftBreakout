using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
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
            if (collision.gameObject.GetComponent<Pickaxe>().level >= 0) {
                Manager.ScorePoints(1);
                Manager.OreIncrease(1, "Stone");
                Destroy(this.gameObject);     
            }
        }
    } 

}
