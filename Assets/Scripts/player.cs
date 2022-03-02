using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;



public class player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject SuperDisparo;
    
    [SerializeField] float fireRateb;
    [SerializeField] float fireRateB;
    private float nextFire = 0.0f;
    bool cambio=false;

    float minX, maxX, minY, maxY;
    //antes del start
 
    // Start is called before the first frame update
    void Start()
    {
      Vector2 esqInfIzq =  (Camera.main).ViewportToWorldPoint(new Vector2(0, 0));
      Vector2 esqSupDer =  (Camera.main).ViewportToWorldPoint(new Vector2(1, 1));

        minX = esqInfIzq.x;
        maxX = esqSupDer.x;
        minY = esqInfIzq.y; 
        maxY = esqSupDer.y;

        //Debug.Log("MinX: " + minX);

    }

    // Update is called once per frame
    void Update()
    {

        
        float dirH = Input.GetAxis("Horizontal");
        float dirV = Input.GetAxis("Vertical");

        transform.Translate(new Vector2(dirH * speed * Time.deltaTime, dirV * speed * Time.deltaTime));

        // Verficiar position
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, minX, maxX),
            Mathf.Clamp(transform.position.y, minY, maxY)
            );


        if(Input.GetKeyDown(KeyCode.C))
        {
             if(cambio==false)
            {
                cambio = true;
            }
            else
            {
                cambio = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Input.GetKeyUp(KeyCode.P))
            {
                Instantiate(SuperDisparo, transform.position, transform.rotation);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            if(cambio==false)
            {
                fireRateb = 0.3f;
                nextFire = Time.time + fireRateb;
                Instantiate(bullet, transform.position, transform.rotation);
            }
            if (cambio == true)

            {
                fireRateB = 1.0f;
                nextFire = Time.time + fireRateB;
                Instantiate(SuperDisparo, transform.position, transform.rotation);
            }
            
        }
        
    }


}
