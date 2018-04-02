using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Behaviour : MonoBehaviour {

    [Tooltip("Distance from corner to start movement.")]
    public float scrollZone = 30;
    [Tooltip("Camera speed")]
    public float scrollSpeed = 5;

    [Tooltip("Clamper to the right")]
    public float xMax = 8;
    [Tooltip("Clamper to the left")]
    public float xMin = 0;

    [Tooltip("Clamper up")]
    public float zMax = 8;
    [Tooltip("Clamper down")]
    public float zMin = 0;

    //for lerping
    private Vector3 desiredPosition;

	// Use this for initialization
	void Start () {
        desiredPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        float x = 0;
        float y = 0;
        float z = 0;

        float speed = scrollSpeed * Time.deltaTime;

        if (Input.mousePosition.x < scrollZone)
            x -= speed;
        else if (Input.mousePosition.x > Screen.width - scrollZone)
            x += speed;

        if (Input.mousePosition.y < scrollZone)
            z -= speed;
        else if (Input.mousePosition.y > Screen.height - scrollZone)
            z += speed;

        Vector3 move = new Vector3(x, y, z) + desiredPosition;
        move.x = Mathf.Clamp(move.x, xMin, xMax);
        move.z = Mathf.Clamp(move.z, zMin, zMax);

        desiredPosition = move;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, 0.2f);
    }
}
