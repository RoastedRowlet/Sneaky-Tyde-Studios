using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

    [SerializeField]
    private float speed;
    protected Animator myAnimator;

    [SerializeField]
    protected Vector2 direction;

    private Rigidbody2D myRigidBody;

    protected bool isAttacking;

    protected Coroutine attackRoutine;

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
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
	}

    protected virtual void Update()
    {
        HandleLayers();
    }

	// Update is called once per frame
	protected virtual void FixedUpdate ()
    {
        Move();
	}

    public void Move()
    {
        myRigidBody.velocity = direction.normalized * speed;
    }

    public void HandleLayers()
    {
        if (IsMoving)
        {
            ActivateLayer("WalkLayer");

            //Sets the animation parameter so that he faces the correct direction
            myAnimator.SetFloat("x", direction.x);
            myAnimator.SetFloat("y", direction.y);

            StopAttack();
        }
        else if (isAttacking)
        {
            ActivateLayer("AttackLayer");
        }
        else
        {
            ActivateLayer("IdleLayer");
        }
    }

    public void ActivateLayer(string layerName)
    {
        for (int i = 0; i < myAnimator.layerCount; i++)
        {
            myAnimator.SetLayerWeight(i, 0);
        }

        myAnimator.SetLayerWeight(myAnimator.GetLayerIndex(layerName), 1);

    }

    public void StopAttack()
    {
        if (attackRoutine != null)
        {
            StopCoroutine(attackRoutine);
            isAttacking = false;
            myAnimator.SetBool("attack", isAttacking);
        }
    }

}
