using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private PlayerController player;
    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        currentHealth = player.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            currentHealth -= 5;
            player.healthBar.value = currentHealth;

            if (currentHealth <= 0)
            {
                Destroy(gameObject);
                player.gameIsActive = false;
            }
        }
    }

    public void Heal()
    {
        currentHealth += (player.maxHealth / 10 * player.lifeSteal) / 2;
        player.healthBar.value = currentHealth;
        if (currentHealth >= player.maxHealth)
        {
            currentHealth = player.maxHealth;
        }
    }

}
