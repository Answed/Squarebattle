using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    public int score;
    public int weaponUpgradeCost = 5;
    public int shipUpgradeCost = 5;
    public int shipDriveUpgradeCost = 5;
    private int weaponsLvl;
    private int shipLvl;
    private int shipDriveLvl;
    private int[] upgradeMultiplikator = { 5, 5, 5 };
    public TextMeshProUGUI scoreText;
    public List<TextMeshProUGUI> shipdata;
    public TextMeshProUGUI gameOver;
    public TextMeshProUGUI weaponsText;
    public Button weapons;
    public Button ship;
    public Button shipDrive;
    public Button backToMainMenu;
    public Button[] gameOverButtons;
    private PlayerController player;

    private int buttonPress = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();

        score = 0;
        scoreText.text = "Score: " + score;

        shipdata[0].text = player.dm + " :Damage\n" + player.timeBtwShots + " :Attackspeed";
        shipdata[1].text = player.maxHealth + " :Health\n" + player.lifeSteal + " :LifeSteal";
        shipdata[2].text = player.movementSpeed + " :Speed\n" + player.rotationSpeed + " :Rotation";

        for (int i = 0; i <= 3; i++)
        {
            shipdata[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < gameOverButtons.Length; i++)
        {
            gameOverButtons[i].gameObject.SetActive(false);
        }
        gameOver.gameObject.SetActive(false);

        weapons.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Weapons\nScore: " + weaponUpgradeCost;
        ship.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Ship\nScore: " + shipUpgradeCost;
        shipDrive.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Ship Drive\nScore: " + shipDriveUpgradeCost;

        ship.gameObject.SetActive(false);
        weapons.gameObject.SetActive(false);
        shipDrive.gameObject.SetActive(false);
        backToMainMenu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && player.gameIsActive == true)
        {
            buttonPress++;
            if (buttonPress >= 2)
            {
                buttonPress = 0;
            }
        }

          switch (buttonPress)
          {
              case 1:
                ship.gameObject.SetActive(true);
                weapons.gameObject.SetActive(true);
                shipDrive.gameObject.SetActive(true);
                backToMainMenu.gameObject.SetActive(true);
                for (int i = 0; i <= 3; i++)
                {
                    shipdata[i].gameObject.SetActive(true);
                }
                shipdata[0].text = player.dm + " :Damage\n" + player.timeBtwShots + " :Attackspeed";
                shipdata[1].text = player.maxHealth + " :Health\n" + player.lifeSteal + " :LifeSteal";
                shipdata[2].text = player.movementSpeed + " :Speed\n" + player.rotationSpeed + " :Rotation";
                break;
              default:
                ship.gameObject.SetActive(false);
                weapons.gameObject.SetActive(false);
                shipDrive.gameObject.SetActive(false);
                backToMainMenu.gameObject.SetActive(false);
                for (int i = 0; i <= 3; i++)
                {
                  shipdata[i].gameObject.SetActive(false);
                }
                  break;
          }

        if (player.gameIsActive == false)
        {
            for (int i = 0; i < gameOverButtons.Length; i++)
            {
                gameOverButtons[i].gameObject.SetActive(true);
            }
            gameOver.gameObject.SetActive(true);
        }
    }

    public void UpdateScore(int scoretoAdd)
    {
        score += scoretoAdd;
        scoreText.text = "Score: " + score;
    }

    public void Weapons()
    {
        if (score >= weaponUpgradeCost)
        {
            weaponsLvl++;
            UpdateScore(-weaponUpgradeCost);
            if (weaponsLvl == upgradeMultiplikator[0])
            {
                if (weaponsLvl == 10)
                {
                    player.dualShotIsActive = true;
                }
                else
                {
                    player.dm += 5;
                }
                upgradeMultiplikator[0] += 5;
            }
            else
            {
                player.timeBtwShots -= 0.125f;
            }
            weaponUpgradeCost = Mathf.RoundToInt(weaponUpgradeCost * 1.5f);
            weapons.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Weapons\nScore: " + weaponUpgradeCost;
        }
    }

    public void Ship()
    {
        if (score >= shipUpgradeCost)
        {
            shipLvl++;
            UpdateScore(-shipUpgradeCost);
            if (shipLvl == upgradeMultiplikator[1])
            {
                upgradeMultiplikator[1] += 5;
                player.lifeSteal++;
            }else
            {
                player.maxHealth += 5;
                player.healthBar.maxValue = player.maxHealth;
            }
            shipUpgradeCost = Mathf.RoundToInt(shipUpgradeCost * 1.5f);
            ship.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Ship\nScore: " + shipUpgradeCost;
        }
    }

    public void ShipDrive()
    {
        if (score >= shipDriveUpgradeCost)
        {
            shipDriveLvl++;
            UpdateScore(-shipDriveUpgradeCost);
            if (shipDriveLvl == upgradeMultiplikator[2])
            {
                if (shipDriveLvl == 10)
                {
                    player.dashIsActive = true;
                }
                else{
                    player.movementSpeed += 1.25f;
                }
                upgradeMultiplikator[2] += 5;
            }else
            {
                player.rotationSpeed += 2.5f;
            }
            shipDriveUpgradeCost = Mathf.RoundToInt(shipDriveUpgradeCost * 1.5f);
            shipDrive.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Ship Drive\nScore: " + shipDriveUpgradeCost;
        }
    }

    public void Escape()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("PlayScene");
    }
}
