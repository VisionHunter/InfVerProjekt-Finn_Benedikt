using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GegnerMovment : MonoBehaviour
{
    private GameObject player;
    public float speed;
    public bool istSpielerTot;
    public GameObject Explosion;
    private CameraShake cameraShake;
    AudioManager audioManager;
    private GameManagerScript KillCounter;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        KillCounter = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Projektil"))
        {
            Destroy(gameObject);
            Instantiate(Explosion, transform.position, Quaternion.identity);
            cameraShake.Shake();
            KillCounter.AddKillCount();

            audioManager.PlaySFX(audioManager.gegnerTot);
        }
    }

}
