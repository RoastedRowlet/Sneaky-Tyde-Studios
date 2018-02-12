using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{
    [SerializeField]
    private Stat health;

    [SerializeField]
    private Stat mana;

    private float initHealth = 100;
    private float initMana = 50;

    [SerializeField]
    private GameObject[] spellPrefab;

    [SerializeField]
    private Transform[] exitPoints;

    private int exitIndex =2;

    protected override void Start()
    {
        health.Initialize(initHealth, initHealth);
        mana.Initialize(initMana, initMana);

        base.Start();
    }


    // Update is called once per frame
    protected override void FixedUpdate()
    {
        //Executes the GetInput function
        GetInput();
        base.FixedUpdate();
    }

    /// Listen's to the players input
    private void GetInput()
    {
        direction = Vector2.zero;

        //Dbug
        //
        if (Input.GetKeyDown(KeyCode.I))
        {
            health.MyCurrentValue -= 10;
            mana.MyCurrentValue -= 10;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            health.MyCurrentValue += 10;
            mana.MyCurrentValue += 10;
        }

        if (Input.GetKey(KeyCode.W))
        {
            exitIndex = 0;
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            exitIndex = 3;
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            exitIndex = 2;
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            exitIndex = 1;
            direction += Vector2.right;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isAttacking && !IsMoving)
            {
                attackRoutine = StartCoroutine(Attack());
            }          
        }
    }

    private IEnumerator Attack()
    {
        isAttacking = true;
        myAnimator.SetBool("attack", isAttacking);
        yield return new WaitForSeconds(1); //Hardcoded Casttime for debug
        CastSpell();
        StopAttack();
    }

    public void CastSpell()
    {
        Instantiate(spellPrefab[0], exitPoints[exitIndex].position, Quaternion.identity);
    }

}