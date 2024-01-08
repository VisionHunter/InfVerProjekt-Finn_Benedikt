using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Bewegen
    public Rigidbody2D rb;
    public float moveSpeed;
    private Vector2 forceToApply;
    private Vector2 PlayerInput;
    public float forceDamping;

    //Spieler auf Random Position spawnen
    public Vector2 SpawnAreaSize;

    //Verweise für andere Scripts
    public static bool istSpielerTot;
    public GameManagerScript gameManager;
    public shooting shooting;

    private void Start()
    {
        istSpielerTot = false;

        //Spieler auf Random Position spawnen
        float randomX = Random.Range(transform.position.x - SpawnAreaSize.x / 2, transform.position.x + SpawnAreaSize.x / 2);
        float randomY = Random.Range(transform.position.y - SpawnAreaSize.y / 2, transform.position.y + SpawnAreaSize.y / 2);
        transform.position = new Vector3(transform.position.x + randomX, transform.position.y + randomY, 0);
    }

    void Update()
    {
        PlayerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }
    
    void FixedUpdate()
    {
        if (!istSpielerTot)
        {
            Vector2 moveForce = PlayerInput * moveSpeed;
            moveForce += forceToApply;
            forceToApply /= forceDamping;
            if (Mathf.Abs(forceToApply.x) <= 0.01f && Mathf.Abs(forceToApply.y) <= 0.01f)
            {
                forceToApply = Vector2.zero;
            }
            rb.velocity = moveForce;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Gegner") && !istSpielerTot)
        {
            gameManager.gameOver();
            istSpielerTot = true;
            shooting.enabled = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(SpawnAreaSize.x, SpawnAreaSize.y, 0));
    }
}
