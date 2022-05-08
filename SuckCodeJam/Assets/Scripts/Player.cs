using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //Privates
    Rigidbody2D rb;
    Vector2 movement;
    Variables vars;
    bool Grounded;

    //Publics

    // Start is called before the first frame update
    void Start()
    {
        //Decleration
        rb = GetComponent<Rigidbody2D>();
        vars = FindObjectOfType<Variables>();

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (!rb)
        {
            return;
        }

        float movex = Input.GetAxis("Horizontal");
        movement = new Vector2(movex * vars.Speed , 0);

        Grounded = Physics2D.OverlapBox(transform.position, Vector2.one, 0, vars.GroundLayermask);
        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
        {
            movement = new Vector2(0 , vars.Jump);
        }

        rb.position = (rb.position + movement * Time.deltaTime);
    }

}
