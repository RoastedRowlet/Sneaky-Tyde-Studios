using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float speed = 10f;

    private Rigidbody2D rb2d;
    private Animator anim;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Movement();


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            // Destroy(other.gameObject);  <-- Probably more what we're looking for.
            other.gameObject.SetActive(false);

        }
    }


    //Handles player movement
    private void Movement()
    {

        if (Input.GetKeyDown("d"))
        {
            anim.SetTrigger("Walk");
        }
        else
        {
            anim.SetTrigger("Knight1_Idle");
        }


        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        //Move the player

        Vector3 translationX = Vector3.right * speed * horizontalInput * Time.deltaTime;
        Vector3 translationY = Vector3.up * speed * verticalInput * Time.deltaTime;

        transform.Translate(translationX + translationY, Space.World);
    }
    
}
