using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void playgame()
   {
      SceneManager.LoadScene("Level_0");
   }
}