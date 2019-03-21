using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    float moveDir;
    public float speed;
    float jumpForce;
    public int jump;
    public float range;
    public GameObject rayOrigin;
    float lastScale;
    RaycastHit2D hit;
    float ogSpeed;
    bool ladder;
    public int ladderSpeed;
    public GameObject dashObject;
    public GameObject ladderGO;

    // Use this for initialization
    void Start()
    {
        lastScale = 1;
        ogSpeed = speed;
        dashObject.transform.localScale = new Vector2 (1, 1);

    }

    // Update is called once per frame
    void Update()
    {
        
        

        if(Input.GetButtonDown("Fire3"))
            speed = speed *1.3f;

        if (Input.GetButton("Fire3"))
        {
            if(Input.GetAxisRaw("Horizontal") != 0)
            {
                dashObject.GetComponent<Animator>().Play("Dash");
                dashObject.GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            { 
                dashObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        else
        {
            dashObject.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (Input.GetButtonUp("Fire3"))
            speed = ogSpeed;
    }

    private void FixedUpdate()
    {
        hit = Physics2D.Raycast(rayOrigin.transform.position,
              new Vector2(0, -1), range);

        if (ladder && hit.collider.tag.Equals("ladder"))
        {
            if (Input.GetButtonDown("Jump"))
            {
                StartCoroutine("ExitLadder");
                GetComponent<Rigidbody2D>().AddForce(new Vector2(Input.GetAxisRaw("Horizontal"), jump*20));
                GetComponent<Animator>().SetBool("Ladder", false);
                StartCoroutine("EnableLadder");
                ladderGO.GetComponent<Collider2D>().enabled = true;
            }

            GetComponent<Animator>().SetBool("Ladder", true);
                
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            StartCoroutine("Climb");

          

        }
        else
        {
            GetComponent<Animator>().SetBool("Ladder", false);
            GetComponent<Rigidbody2D>().isKinematic = false;
            if (Input.GetButtonDown("Jump"))
            {
                if (hit.collider != null)
                {
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jump));
                }
            }

            moveDir = Input.GetAxisRaw("Horizontal");

            if (moveDir != 0)
                lastScale = moveDir;

            this.transform.localScale = new Vector2(lastScale, 1);

            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime * moveDir,
                                             transform.position.y);
            GetComponent<Animator>().SetInteger("X", (int)moveDir);
        }
    }

    public void SetLadder(bool a)
    {
        ladder = a;
    }

    IEnumerator Climb()
    {
        GetComponent<Rigidbody2D>().isKinematic = true;
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            transform.position = new Vector2(transform.position.x,
                                        transform.position.y + ladderSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical"));
        }

        yield return null;
    }

    IEnumerator ExitLadder()
    {
        GetComponent<Rigidbody2D>().isKinematic = false;
        ladderGO.GetComponent<Collider2D>().enabled = false;

        yield return null;
    }

    IEnumerator EnableLadder()
    {
        yield return new WaitForSeconds(2);
        ladderGO.GetComponent<Collider2D>().enabled = true;

        yield return null;
    }
}
