using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int health,dmg,maxSpeed,xSpeed,ySpeed;
    public float speed;
    public GameObject target, anim, dead;
    Vector2 v, targetV, facing,speedV,velocity;
    RaycastHit2D hit;
    int dir;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        



        //targetV = new Vector2(target.transform.position.x, transform.position.y);
    }

    void FixedUpdate()
    {
        v = this.transform.position;
        if (GetComponent<SpriteRenderer>().flipX)
        {
            dir = 1;
        }
        else
        {
            dir = -1;
        }

        speedV = new Vector2(xSpeed * dir, ySpeed);
        this.transform.position = Vector2.SmoothDamp(transform.position, v + speedV,ref velocity,speed,maxSpeed,Time.deltaTime);
    }

    void OnCollisionEnter2D (Collision2D c)
    {
        if (c.collider.tag.Equals("Player"))
        {
            c.collider.SendMessage("TakeDamage", dmg);
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
        Destroy(this.gameObject);
        anim = Instantiate(dead, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity) as GameObject;
        anim.SetActive(true);
        Destroy(anim, anim.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }

    void PointDetect(string name)
    {
        if (name.Equals("Point1"))
        {
            GetComponent<SpriteRenderer>().flipX = true;


        }

        if (name.Equals("Point2"))
        {
            GetComponent<SpriteRenderer>().flipX = false;

        }
    }

}
