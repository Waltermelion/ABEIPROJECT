using UnityEngine;
using UnityEngine.SceneManagement;
public class EndCreditsManager : MonoBehaviour
{
    [SerializeField] private GameObject backButton;
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ButtonAppear()
    {
        backButton.SetActive(true);
    }
}