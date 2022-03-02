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
    [SerializeField] GameObject Carga;

    [SerializeField] float fireRateb;
    [SerializeField] float fireRateB;
    [SerializeField] float fireRateC;
    private float nextFire = 0.0f;
    bool cambio=false;
    float startTime;

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
        startTime = Time.time;

        //Debug.Log("MinX: " + minX);

    }

    // Update is called once per frame
    void Update()
    {

        int tiempo = (int)Time.time;
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
       
        if (Input.GetKey(KeyCode.Y) && tiempo % 3  == 0)
        {
                Instantiate(Carga, transform.position, transform.rotation);       
        }
        if(tiempo%3==0)
        tiempo = 0;

        Debug.Log(tiempo);

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
                fireRateb = 0.3f;//por default
                nextFire = Time.time + fireRateb;
                Instantiate(bullet, transform.position, transform.rotation);
            }
            if (cambio == true)

            {
                fireRateB = 1.0f;//por default
                nextFire = Time.time + fireRateB;
                Instantiate(SuperDisparo, transform.position, transform.rotation);
            }
            
        }
        
    }


}
