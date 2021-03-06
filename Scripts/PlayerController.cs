Cousing System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public float rotationSpeed;
    public float timeBtwShots;
    private float nextShot;
    public float timeBtwDash;
    private float nextDash;
    public int maxHealth;
    public int lifeSteal;
    public int dm;
    public bool dualShotIsActive = false;
    public bool dashIsActive = false;
    public bool gameIsActive;
    public GameObject rotate;
    public GameObject bullet;
    public GameObject shootPos;
    public GameObject dualPos1;
    public GameObject dualPos2;
    public GameObject[] telePos;
    private Rigidbody2D rb2D;

    public Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
        rb2D = GetComponent<Rigidbody2D>();
        gameIsActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontal * movementSpeed * Time.deltaTime);
        transform.Translate(Vector3.up * vertical * movementSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rotate.transform.Rotate(new Vector3(0, 0, 10) * rotationSpeed * Time.deltaTime * -1, Space.Self);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotate.transform.Rotate(new Vector3(0, 0, 10) * rotationSpeed * Time.deltaTime * 1);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && nextShot < Time.time && dualShotIsActive == false)
        {
            nextShot = Time.time + timeBtwShots;
            Instantiate(bullet, shootPos.transform.position, rotate.transform.rotation);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && nextShot < Time.time && dualShotIsActive == true)
        {
            nextShot = Time.time + timeBtwShots;
            Instantiate(bullet, dualPos1.transform.position, rotate.transform.rotation);
            Instantiate(bullet, dualPos2.transform.position, rotate.transform.rotation);
        }

        if (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.DownArrow) && dashIsActive == true && nextDash <= Time.time)
        {
            nextDash = Time.time + timeBtwDash;
            transform.position = telePos[0].transform.position;
        }else if (Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.DownArrow) && dashIsActive == true && nextDash <= Time.time)
        {
            nextDash = Time.time + timeBtwDash;
            transform.position = telePos[1].transform.position;
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKeyDown(KeyCode.DownArrow) && dashIsActive == true && nextDash <= Time.time)
        {
            nextDash = Time.time + timeBtwDash;
            transform.position = telePos[2].transform.position;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.DownArrow) && dashIsActive == true && nextDash <= Time.time)
        {
            nextDash = Time.time + timeBtwDash;
            transform.position = telePos[3].transform.position;
        }
  
    }
}
