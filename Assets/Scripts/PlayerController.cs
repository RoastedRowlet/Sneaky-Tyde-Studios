using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{
    [SerializeField]
    private Stats health;

    [SerializeField]
    private Stats mana;

    [SerializeField]
    private float initialHealth;

    [SerializeField]
    private float initialMana;

    protected override void Start()
    {
        health.Initialize(initialHealth, initialHealth);
        mana.Initialize(initialMana, initialMana);

        base.Start();
    }
    protected override void FixedUpdate()
    {
        GetInput();
        base.FixedUpdate();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            // Destroy(other.gameObject);  <-- Probably more what we're looking for.
            other.gameObject.SetActive(false);

        }
    }

    private void GetInput()
    {
        direction = Vector2.zero;

        ///DEBUG
        ///
        if(Input.GetKey(KeyCode.I))
        {
            health.MyCurrentValue -= 10;
            mana.MyCurrentValue -= 10;
        }
        if(Input.GetKey(KeyCode.O))
        {
            health.MyCurrentValue += 10;
            mana.MyCurrentValue += 10;
        }
        ///DEBUG
        ///

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
           direction += Vector2.right;
        }
    }
    
}
