using Assets.Script;
using UnityEngine;

public class PipeMiddleController : MonoBehaviour
{
    public GameLogic logic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<GameLogic>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Collision with the Bird
        if (collision.gameObject.layer == 3)
        {
            logic.AddScore();
            logic.DisplayCurrentLvl();
            AudioController.uiAudioInstance.PlayCrossPipeSFX();
        }

    }
}
