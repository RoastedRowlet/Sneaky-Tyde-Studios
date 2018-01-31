using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

    [SerializeField]
    private float speed = 10f;


    private Animator animator;

    protected Vector2 direction;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	protected virtual void FixedUpdate () {
        Movement();
	}

    //Handles player movement
    public void Movement()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        if(direction.x != 0 || direction.y != 0)
        {
            AnimateMovement(direction);
        }
        else
        {
            animator.SetLayerWeight(1, 0);
        }
        

    }

    public void AnimateMovement(Vector2 direction)
    {

        animator.SetLayerWeight(1, 1);

        animator.SetFloat("x", direction.x);
        animator.SetFloat("y", direction.y);
    }
}
