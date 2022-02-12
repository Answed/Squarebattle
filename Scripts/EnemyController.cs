using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public float speed;

    public int maxHealth;
    private int currentHealth;

    public GameObject explosion;

    private Vector2 movement;
    private GameObject player;
    public Slider healthBar;
    private Rigidbody2D rb;
    private Shop shop;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
        player = GameObject.FindGameObjectWithTag("Player");
        shop = GameObject.Find("GameManager").GetComponent<Shop>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        MoveEnemy(movement);
    }

    void MoveEnemy(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.CompareTag("Bullet"))
        {
            TakeDamage(player.GetComponent<PlayerController>().dm);
            Destroy(collision.gameObject);
        }   
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth;

        if (currentHealth <= 0)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            shop.UpdateScore(1);
            player.GetComponentInChildren<PlayerDamage>().Heal();
            Destroy(gameObject);
        }
    }
}
