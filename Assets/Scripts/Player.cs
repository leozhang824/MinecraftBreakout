using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D PlayerBody;

    public float Speed = 7.5f;

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {   
        cam = Camera.main;
        PlayerBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Start();
        Vector3 screen = cam.WorldToViewportPoint(transform.position);
        screen.x = Mathf.Clamp(screen.x, 0f, 1f);
        transform.position = cam.ViewportToWorldPoint(screen);
        
        Movement();
        
    }    

    void Movement()
    {
        float horizon = Input.GetAxis("Horizontal");
        float x = horizon * Speed * Time.deltaTime;
        transform.Translate(x, 0, 0);
    }
}
