using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_player : MonoBehaviour {
    /// <summary>
    /// we use this to keep track of who we following.
    /// </summary>
    private GameObject following = null;
   
    /// <summary>
    /// offset of the indicator.
    /// </summary>
    private Vector3 offset;

    [Tooltip("upward offset of the indicator")]
    public float y;

    // Use this for initialization
    void Awake () {
         offset = new Vector3(0, y, 0);
    }
	
	// Update is called once per frame
	void Update () {
        offset =  following.transform.position;
        offset.y += y;
        transform.position = offset;
    }

    public void SetUnit(GameObject Transf)
    {
        following = Transf;
    }
}
