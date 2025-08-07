using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using Assets.Script;

public class MainMenuLogic : MonoBehaviour
{
     void Start()
    {
        AudioController.uiAudioInstance.PlayLobbyMusic();
    }
    public void StartGame()
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
