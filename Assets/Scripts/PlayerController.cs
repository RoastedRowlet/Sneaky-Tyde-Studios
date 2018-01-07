using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class PlayerController : MonoBehaviour {

    public float speed;
=======
public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float speed = 10f;

>>>>>>> master
    private Rigidbody2D rb2d;
    private Animator anim;

    void Start()
    {
<<<<<<< HEAD
        rb2d = GetComponent<Rigidbody2D> ();
=======
        rb2d = GetComponent<Rigidbody2D>();
>>>>>>> master
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
<<<<<<< HEAD
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (moveHorizontal > 0)
        {
            moveHorizontal = 1;
        }
        else if(moveHorizontal < 0)
        {
            moveHorizontal = -1;
        }


        Vector2 movement = new Vector2(moveHorizontal, moveVertical);


        rb2d.AddForce(movement * speed);

        if(Input.GetKeyDown("d"))
=======
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
>>>>>>> master
        {
            anim.SetTrigger("Walk");
        }
        else
        {
            anim.SetTrigger("Knight1_Idle");
        }
<<<<<<< HEAD
       

    }
   
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
           // Destroy(other.gameObject);  <-- Probably more what we're looking for.
            other.gameObject.SetActive(false);

        }
    }
=======


        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        //Move the player

        Vector3 translationX = Vector3.right * speed * horizontalInput * Time.deltaTime;
        Vector3 translationY = Vector3.up * speed * verticalInput * Time.deltaTime;

        transform.Translate(translationX + translationY, Space.World);
    }
    
>>>>>>> master
}
