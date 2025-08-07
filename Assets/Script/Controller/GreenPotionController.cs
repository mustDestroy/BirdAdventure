using Assets.Script;
using UnityEngine;

public class GreenPotionController : MonoBehaviour
{
    private float moveSpeed = 5;
    private float endPosX = -12.6f;

    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < endPosX)
        {
            Debug.Log("Green Potion deleted");
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        BirdController bird = collision.GetComponent<BirdController>();

        //Collision with the bird
        if ((collision.gameObject.layer == 3) && (bird.BirdIsPoisoned == true))
        {
            AudioController.uiAudioInstance.PlayInGameMusic();
            AudioController.uiAudioInstance.PlayPotionDrinkSFX();

            bird.SetCured();

            // set gravity back to the default one
            bird.MyRigidBody.gravityScale = 2.5f;
            Destroy(gameObject);
        }
        else
        {
            AudioController.uiAudioInstance.PlayPotionDrinkSFX();
            Destroy(gameObject);
        }

    }
}
