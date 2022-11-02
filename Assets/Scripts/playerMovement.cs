using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    CircleCollider2D collider;
    SpriteRenderer sprite;
    public float speed = 100;
    public float rotationSpeed = 100;
    public GameObject bala;
    public GameObject puntoicial;
    public GameObject ParticleMuerte;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        collider = GetComponent<CircleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        if(vertical >0)
        {
            rb.AddForce(transform.up * vertical * speed * Time.deltaTime);
            anim.SetBool("impulsing", true);
        }
        else
        {
            anim.SetBool("impulsing", false);
        }

        float horizontal = Input.GetAxis("Horizontal");
        transform.eulerAngles = transform.eulerAngles + new Vector3(0, 0, horizontal * rotationSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump")) 
        {
           GameObject temp = Instantiate(bala , puntoicial.transform.position, transform.rotation);
            Destroy(temp, 2.5f);
        }

        
    }
    public void Muerte()
    {
        GameObject temp = Instantiate(ParticleMuerte, transform.position, transform.rotation);
        Destroy(temp, 2.5f);

        StartCoroutine(Respawne_Coroutine());

        

    }
   

    IEnumerator Respawne_Coroutine()
    {
        collider.enabled = false;
        sprite.enabled = false;
        yield return new WaitForSeconds(2);
        collider.enabled = true;
        sprite.enabled = true;
        gamemanager.instance.vida -= 1;
        transform.position = new Vector3(0, 0, 0);
        rb.velocity = new Vector2(0, 0);



        if (gamemanager.instance.vida <= 0)
        {

            Destroy(gameObject);
            Time.timeScale = 0;
        }
    }


}
