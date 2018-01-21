using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public float x;

    [SerializeField]
    private Vector3 offset;

    [SerializeField]
    Tilemap tilemap;

    private float tileOverHang = 0.10f;

    // Use this for initialization
    void Start () {

        offset = transform.position - player.transform.position;
        tilemap.CompressBounds();

    }
	
	// Update is called once per frame
	void LateUpdate () {

        Vector3 newPos = player.transform.position + offset;

        Camera cam = Camera.main;
        Vector3 tmSize = tilemap.size;
        float camHeight = cam.orthographicSize;
        float camWidth = camHeight * cam.aspect;

        if (newPos.x + camWidth > tmSize.x/2)
        {
            newPos.x = tmSize.x / 2 + camWidth;
        }
        else if (newPos.x - camWidth < -tmSize.x / 2)
        {
            newPos.x = -tmSize.x / 2 + camWidth;
        }

        if (newPos.y + camHeight > tmSize.y / 2)
        {
            newPos.y = tmSize.y / 2 - camHeight;
        }
        else if (newPos.y - camHeight < -tmSize.y / 2)
        {
            newPos.y = -tmSize.y / 2 + camHeight;
        }
        transform.position = newPos;
    }
}
