using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
   private void Start()
   {
      Cursor.lockState = CursorLockMode.None;
   }
   public void playgame()
   {
      SceneManager.LoadScene("Level_0");
   }
   public void ExitGame()
   {
      Application.Quit();
   }
}