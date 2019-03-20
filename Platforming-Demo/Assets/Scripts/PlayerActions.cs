using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour {

    Animator anim;
    RaycastHit2D ray;
    public GameObject t;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("Attack", true);
            ray = Physics2D.Raycast(t.transform.position, new Vector2(transform.localScale.x,0),0.5f);

            if (ray.collider.tag.Equals("Enemy"))
            {
                Debug.Log("Swag");
            }
        }
        else
        {
            anim.SetBool("Attack", false);
        }
	}
   
}
