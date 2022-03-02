using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carga : MonoBehaviour
{
    [SerializeField] float speed;
    public GameObject projectile;
    [SerializeField] float fireRate;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Colisionando con other:");
        Debug.Log(other.gameObject.name);
        Destroy(this.gameObject);
    }
}
