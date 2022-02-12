using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeyAttack : MonoBehaviour
{
    public float timeBtwShot;
    private float nextShot;
    public float range;
    public GameObject bullet;
    public GameObject player;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(GameObject.Find("Player").transform.position);

        if (nextShot < Time.deltaTime && Vector2.Distance(transform.position, player.transform.position) <= range)
        {
            Debug.Log("ATTACK");
            nextShot = timeBtwShot + Time.deltaTime;
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }
}
