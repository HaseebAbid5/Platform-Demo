﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour {

    public GameObject target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag.Equals("Player"))
        {
            target.GetComponent<PlayerMovement>().SetLadder(true);
        }    
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        target.GetComponent<PlayerMovement>().SetLadder(false);
    }
}
