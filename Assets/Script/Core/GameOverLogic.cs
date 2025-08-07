using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using Assets.Script;

public class GameOverLogic : MonoBehaviour
{

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
        AudioController.uiAudioInstance.PlayInGameMusic();
    }
    public void ExitGame()
    {
        Debug.Log("Game exited");
        Application.Quit();
    }
}
