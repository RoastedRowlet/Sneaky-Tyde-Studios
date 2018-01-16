using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public float x;

    [SerializeField]
    private Vector3 offset;


	// Use this for initialization
	void Start () {

        offset = transform.position - player.transform.position;

	}
	
	// Update is called once per frame
	void LateUpdate () {

        transform.position = player.transform.position + offset;

        Camera cam = Camera.main;
        float y = cam.orthographicSize;
    }
}
