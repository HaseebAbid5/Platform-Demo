using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour {

    Animator anim;
    RaycastHit2D ray;
    public GameObject t;
    public int damage, health;
    Vector2 InPos;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        InPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("Attack", true);
            ray = Physics2D.Raycast(t.transform.position, new Vector2(transform.localScale.x,0),0.7f);

            if (ray.collider.tag.Equals("Enemy"))
            {

                ray.collider.SendMessage("TakeDamage", damage);
            }
        }
        else
        {
            anim.SetBool("Attack", false);
        }
	}

    public void TakeDamage(int dmg)
    {
        health = health - dmg;

        if(health <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        this.transform.position = InPos;
    }
   
}
