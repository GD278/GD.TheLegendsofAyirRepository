using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject CreditsMenu;
    // Start is called before the first frame update
    void Start()
	{
       ShowMainMenu();
	}
    public void ShowMainMenu()
	{
        MainMenu.SetActive(true);
        CreditsMenu.SetActive(false);
    }
    public void ShowCredits()
	{
        MainMenu.SetActive(false);
        CreditsMenu.SetActive(true);
    }

    public void Play()
	{
        SceneManager.LoadScene("Level01");
	}
    public void Quit()
	{
        Application.Quit(0);
	}
}
