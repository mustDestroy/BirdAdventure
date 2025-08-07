using Assets.Script;
using UnityEngine;

public class CoinController : MonoBehaviour
{
     GameLogic logic;
    private float moveSpeed = 5;
    private float endPosX = -12.6f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<GameLogic>();
    }

    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < endPosX)
        {
            Debug.Log("Coin deleted");
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        //Collision with the bird
        if (collision.gameObject.layer == 3)
        {
            AudioController.uiAudioInstance.PlayCoinCollectSFX();
            logic.AddCoin();
            Destroy(gameObject);
        }
    }
}
