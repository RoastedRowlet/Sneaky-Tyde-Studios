using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour {

    private Rigidbody2D spellRigidBody;

    [SerializeField]
    private float speed;

    private Vector2 direction;
    

	// Use this for initialization
	void Start ()
    {
        Camera camera = Camera.main;

        spellRigidBody = GetComponent<Rigidbody2D>();

        Vector3 mouseLocation = (Vector3)camera.ScreenToWorldPoint(Input.mousePosition);

        direction = mouseLocation - transform.position;
        spellRigidBody.velocity = direction.normalized * speed;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

    public void Fire()
    {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        
    }
}
