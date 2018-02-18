using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

    [SerializeField]
    private float speed = 10f;

    private Animator myAnimator;

    protected Vector2 direction;

    //holds all current relevant non-movement inputs 
    protected List<KeyCode> inputs;

    private Rigidbody2D myRigidBody;

    protected bool isAttacking;
    

    public bool IsMoving
    {
        get
        {
            return direction.x != 0 || direction.y != 0;
        }
    }


    // Use this for initialization
    protected virtual void Start ()
    {
        myRigidBody = GetComponent <Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        inputs = new List<KeyCode>();

	}

    // Update is called once per frame on the users display, will run at FPS 
    protected virtual void Update()
    {
        HandleLayers();
    }

    // Update is called once per frame
    protected virtual void FixedUpdate () {
        Movement();
	}

    //Handles player movement
    public void Movement()
    {
        //Moves the player
        myRigidBody.velocity = direction.normalized * speed;
        // x =2, y = 2 /// Normalize = 1, 1
        
    }

    public void HandleLayers()
    {
        //Checks if player is moving
        if (IsMoving)
        {
            ActivateLayer("Walk_Layer");

            myAnimator.SetFloat("x", direction.x);
            myAnimator.SetFloat("y", direction.y);
        }
        else if (isAttacking)
        {
            ActivateLayer("Attack Layer");
        }
        else
        {
            ActivateLayer("Idle_Layer");
        }
    }

    public void ActivateLayer(string layername)
    {
        for (int i = 0; i < myAnimator.layerCount; i++)
        {
            myAnimator.SetLayerWeight(i, 0);
        }

        myAnimator.SetLayerWeight(myAnimator.GetLayerIndex(layername), 1);
    }
}
