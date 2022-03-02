using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] float speed;
    public GameObject projectile;
    [SerializeField] float fireRate;
    private float nextFire = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(projectile, transform.position, transform.rotation);
        }
        //transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
       /* Debug.Log("Colisionando con other:");
        Debug.Log(other.gameObject.name);*/
        Destroy(this.gameObject);
    }
}
