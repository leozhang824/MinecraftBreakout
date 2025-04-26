using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIamond : MonoBehaviour
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
            if (collision.gameObject.GetComponent<Pickaxe>().level >= 2) {
                Manager.ScorePoints(7);
                Manager.OreIncrease(1, "Diamond");
                Destroy(this.gameObject);
            }
        }
    }  

}
