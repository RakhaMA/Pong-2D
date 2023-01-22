using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;  
    private Animator anim;
    public string axis = "Vertical";

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Buat disable player 2 input klo lagi single player
        if(axis == "Vertical2" && GameData.instance.isSinglePlayer)
        {
            return;
        }


        // Ngambil variable dari axing yg udh di setting di unity input dengan output (-1 ,1)
        float v = SimpleInput.GetAxis(axis);
        rb.velocity = new Vector2(0, v) * speed;

        // Agar tdk keluar batas atas
        if (transform.position.y > 1f)
        {
            transform.position = new Vector2(transform.position.x, 1f);
        }

        // Agar tdk keluar batas bawah
        if (transform.position.y < -1f)
        {
            transform.position = new Vector2(transform.position.x, -1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            anim.SetTrigger("Shoot");
        }
    }
}
