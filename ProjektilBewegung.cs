using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjektilBewegung : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    public GameObject Explosion;
    
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
        Instantiate(Explosion, transform.position, Quaternion.identity);
    }

}
