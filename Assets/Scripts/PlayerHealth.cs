using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] int health = 10;
    [SerializeField] int healthDecrease = 1;
    [SerializeField] ParticleSystem playerdeath;
    [SerializeField] Text healthText;
    [SerializeField] AudioClip playerDamageSFX;


    void Start()
    {
        healthText.text = health.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().PlayOneShot(playerDamageSFX);
        health = health - healthDecrease;
        healthText.text = health.ToString();
        if (health <= 0)
        {
            Destroy(gameObject);
            var playerdeathparticles = Instantiate(playerdeath, transform.position, Quaternion.identity);
            playerdeathparticles.Play();
            Destroy(playerdeathparticles.gameObject, playerdeathparticles.main.duration);
            Destroy(gameObject);
        }
    }

    
        
}