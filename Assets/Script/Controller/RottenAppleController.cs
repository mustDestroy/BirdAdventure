using Assets.Script;
using UnityEngine;


public class RottenAppleController : MonoBehaviour
{
    private float moveSpeed = 5;
    private float endPosX = -12.6f;


    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < endPosX)
        {
            Debug.Log("RottenApple deleted");
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        BirdController bird = collision.GetComponent<BirdController>();

        //Collision with the bird
        if ((collision.gameObject.layer == 3) && (bird.BirdIsPoisoned == false))
        {
            bird.SetPoisoned();
            AudioController.uiAudioInstance.PlayAppleBiteSFX();
            AudioController.uiAudioInstance.PlayFightMusic();

            //set the gravitation to double
            bird.MyRigidBody.gravityScale = 4f;
            Destroy(gameObject);
        }
        else
        {
            AudioController.uiAudioInstance.PlayAppleBiteSFX();
            Destroy(gameObject);
        }
    }
}
