using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Button[] buttons;
    public Button returnButton;
    public TextMeshProUGUI howToPlay;

    // Start is called before the first frame update
    void Start()
    {
        returnButton.gameObject.SetActive(false);
        howToPlay.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void HowToPlay()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].gameObject.SetActive(false);
        }
        returnButton.gameObject.SetActive(true);
        howToPlay.gameObject.SetActive(true);
    }
    public void Return()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].gameObject.SetActive(true);
        }
        returnButton.gameObject.SetActive(false);
        howToPlay.gameObject.SetActive(false);
    }
}
