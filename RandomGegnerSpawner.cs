using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGegnerSpawner : MonoBehaviour
{
    public GameObject Gegner;
    public Vector2 SpawnAreaSize;
    private float MinStartDelay = 0.1f; // Minimale Startverzögerung
    private float MaxStartDelay = 3f; // Maximale Startverzögerung
    public float spawnTime = 5f; // Aktuelle Spawnzeit
    private float timer;
    private float startDelay; // Startverzögerung

    void Start()
    {
        startDelay = Random.Range(MinStartDelay, MaxStartDelay);
    }

    void Update()
    {
        startDelay = Mathf.Max(0f, startDelay - Time.deltaTime);

        if (startDelay <= 0f)
        {
            timer += Time.deltaTime;
            if (timer > spawnTime)
            {
                SpawnGegner();
                timer = 0;

                spawnTime = Mathf.Max(1.6f, spawnTime - 0.2f);
            }
        }
    }

    void SpawnGegner()
    {
        float randomX = Random.Range(transform.position.x - SpawnAreaSize.x / 2, transform.position.x + SpawnAreaSize.x / 2);
        float randomY = Random.Range(transform.position.y - SpawnAreaSize.y / 2, transform.position.y + SpawnAreaSize.y / 2);
        Vector3 randomPos = new Vector3(randomX, randomY, transform.position.z);
        Instantiate(Gegner, randomPos, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(SpawnAreaSize.x, SpawnAreaSize.y, 0));
    }
}