using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndCreditsManager : MonoBehaviour
{
    [SerializeField] private GameObject backButton;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ButtonAppear()
    {
        backButton.SetActive(true);
    }
}