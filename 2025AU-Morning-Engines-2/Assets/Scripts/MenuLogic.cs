using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLogic : MonoBehaviour
{

    public GameObject MainMenu;
    public GameObject CreditsMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public void Play_game()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit_game()
    {
        Application.Quit();
        Debug.Log("QUIT");
    }

    public void Credits_page()
    {
        MainMenu.SetActive(false);
        CreditsMenu.SetActive(true);
    }

    public void Back_Button()
    {
        CreditsMenu.SetActive(false);
        MainMenu.SetActive(true);
    }
}
