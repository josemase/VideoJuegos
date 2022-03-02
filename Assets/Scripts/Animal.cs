using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    bool direccion=true;
    Rigidbody2D myBody;
    [SerializeField] float speed;
    float minX, maxX, minY, maxY;
    [SerializeField] float vida;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 esqInfIzq = (Camera.main).ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 esqSupDer = (Camera.main).ViewportToWorldPoint(new Vector2(1, 1));
        minX = esqInfIzq.x;
        maxX = esqSupDer.x;
        minY = esqInfIzq.y;
        maxY = esqSupDer.y;

        myBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector2(
           Mathf.Clamp(transform.position.x, minX, maxX),
           Mathf.Clamp(transform.position.y, minY, maxY)
           );
        if(transform.position.x>8.8)
        {
            direccion = false;
        }
        if (transform.position.x < -8.8)
        {
            direccion = true;
        }

        //Debug.Log("transform es");
        //Debug.Log(transform.position.x);



    }


    private void FixedUpdate()
    {
        if(direccion)
        {
            myBody.velocity = new Vector2(speed, myBody.velocity.y);
        }
        else
        {
            myBody.velocity = new Vector2(-1*speed, myBody.velocity.y);
        }

        
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colisionando con:");
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name.Equals("bullet(Clone)")) 
        {   
            Destroy(collision.gameObject);
            vida = vida - 1;
  
        }
        if (collision.gameObject.name.Equals("SuperDisparo(Clone)"))
        {
            Destroy(collision.gameObject);
            vida = vida - 2;

        }
       
        if (vida<=0)
        {
            Destroy(this.gameObject);
        }
        
    }

}
