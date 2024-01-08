using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    private bool canFire;
    private float timer;
    public float timeBetweemFiring;
    public GameManagerScript gameManagerScript;
    AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rot = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rot.y, rot.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (!canFire)
        {
            timer += Time.deltaTime;
            if(timer > timeBetweemFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

        if (Input.GetButtonDown("Fire1") && canFire && !gameManagerScript.isPaused)
        {
            canFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);

            audioManager.PlaySFX(audioManager.Schuss);
        }
    }
}