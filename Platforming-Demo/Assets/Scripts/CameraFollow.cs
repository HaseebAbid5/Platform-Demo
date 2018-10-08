using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject target;
    public float offset;
    

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if(this.transform.position.y < 1.25)
        {
            this.transform.position = new Vector3(this.transform.position.x, 1.25f, -10f);
        }
		
	}

    private void FixedUpdate()
    {
        this.transform.position = new Vector3(this.transform.position.x, target.transform.position.y + offset * Time.deltaTime,-10f);
    }
}
