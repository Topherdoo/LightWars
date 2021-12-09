using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    public int health;
    public AudioClip playerDeath;
    public int amount = 20;
    public GameObject enemy;
    public Rigidbody _body;

    public TextMeshProUGUI healthText;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindWithTag("Enemy");
        _body = GetComponent<Rigidbody>();
    }

    public void TakeDamage(int amount)
    {
        int healthDamage = amount;

        health -= healthDamage;

        if (health <= 5)
        {
            //GetComponent<AudioSource>().PlayOneShot(playerDeath);
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        _body.angularVelocity = Vector3.zero;

        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(amount);
        }
    }

    // Update is called once per frame
    void Update()
    {
        healthText.SetText("Health: " + health);
    }
}
