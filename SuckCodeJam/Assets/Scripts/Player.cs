using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Publics
    public float Speed;
    public float Jump;
    public LayerMask layermask;

    //Privates
    Rigidbody2D rb;
    Vector2 movement;
    bool Grounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Grounded = Physics2D.OverlapBox(transform.position , Vector2.one ,0 , layermask);

        float movex = Input.GetAxis("Horizontal");
        movement = new Vector2(movex * Speed, 0);

        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
        {
            Debug.Log("grounded");
            movement = new Vector2(0 , Jump);
        }

        rb.position = (rb.position +movement * Time.deltaTime);
    }

}
