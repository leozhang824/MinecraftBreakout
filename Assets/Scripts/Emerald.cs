using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emerald : MonoBehaviour
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
            if (collision.gameObject.GetComponent<Pickaxe>().level >= 3) {
                Manager.ScorePoints(10);   
                Destroy(this.gameObject);
            }
        }
    }  

    void OnBecameInvisible()
    {  
        Manager.End();
    }
}
