using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{

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


      /*  if (Input.GetKeyDown("d"))
        {
            anim.SetTrigger("Walk");
        }
        else
        {
            anim.SetTrigger("Knight1_Idle");
        } */
    }
    
}
