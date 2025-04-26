using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickaxe : MonoBehaviour
{
    public float Speed = 5f; 

    public float maxY = 6.5f;

    public Sprite[] spriteSheet;

    public static Pickaxe Singleton;

    public int level = 0;

    public AudioClip Upgrade;

    private AudioSource audioSource;

    public static void SpriteUpdate(int increase)
    {
        Singleton.SpriteUpdateInternal(increase);
    }

    private Rigidbody2D PickaxeBody;
    private SpriteRenderer PickaxeSprite;
    
    void Start()
    {   
        Singleton = this;
        PickaxeBody = GetComponent<Rigidbody2D>();
        PickaxeSprite = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        PickaxeBody.velocity = Vector2.down * Speed;
    }

    void Update()
    {
        if (transform.position.y > maxY) {
            transform.position = new Vector2(0, 2);
            Manager.LivesLeft(1);
            PickaxeBody.velocity = Vector2.down * Speed;
        }
        if (PickaxeBody.velocity.magnitude != Speed) {
            PickaxeBody.velocity = Vector3.ClampMagnitude(PickaxeBody.velocity, Speed);
        }
    }

    private void SpriteUpdateInternal(int increase) {
        level += increase;
        PickaxeSprite.sprite = spriteSheet[level];
        if (audioSource != null) {
            audioSource.PlayOneShot(Upgrade);
        } 
    }

}
