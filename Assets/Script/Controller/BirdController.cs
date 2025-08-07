using Assets.Script;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    [SerializeField] private GameLogic logic;
    [SerializeField] private Rigidbody2D myRigidBody;
    [SerializeField] private Sprite healthySprite;
    [SerializeField] private Sprite poisonedSprite;
    [SerializeField] private Animator tailAnimator;
    [SerializeField] private GameObject tail;


    private SpriteRenderer birdBodyRenderer;
    private Coroutine fadeCoroutine;



    private SpriteRenderer tailRenderer;
    //private SpriteRenderer tailPoisonedRenderer;

    private float flapStrength;
    private bool birdIsAlive;
    private float topDeadZoneY;
    private float bottomDeadZoneY;
    private bool birdIsPoisoned;
    private string birdName;
    private float fadeDuration;


    // PROPERTIES
    public float FlapStrength
    {
        get { return flapStrength; }
        set
        {
            if (value > 0) { flapStrength = value; }
            else { throw new Exception("Error Flap Strength: Flap Strength cannot be " + value + " !"); }

        }
    }
    public bool BirdIsAlive
    {
        get { return birdIsAlive; }
        set { birdIsAlive = value; }
    }
    public float TopDeadZoneY
    {
        get { return topDeadZoneY; }
        set { topDeadZoneY = value; }
    }
    public float BottomDeadZoneY
    {
        get { return BottomDeadZoneY; }
        set { bottomDeadZoneY = value; }
    }
    public bool BirdIsPoisoned
    {
        get { return birdIsPoisoned; }
        set { birdIsPoisoned = value; }
    }
    public Rigidbody2D MyRigidBody
    {
        get { return myRigidBody; }
        set { myRigidBody = value; }
    }
    public string BirdName
    {
        get { return birdName; }
        set { birdName = value; }
    }
    public float FadeDuration
    {
        get
        {
            return fadeDuration;
        }
        set
        {
            fadeDuration = value;
        }
    }

    // Set the default values 
    void Awake()
    {
        

        FlapStrength = 4f;
        BirdIsAlive = true;
        TopDeadZoneY = 5.97f;
        BottomDeadZoneY = -5.97f;
        BirdIsPoisoned = false;
        MyRigidBody.gravityScale = 2.5f;
        BirdName = "Larry Bird";
        FadeDuration = 0.1f;


        tailRenderer = tail.GetComponent<SpriteRenderer>();
        birdBodyRenderer = GetComponent<SpriteRenderer>();

        tailAnimator.Play("Normal", 0, 0f);





    }

    void Start()
    {
        gameObject.name = "BirdAdventure";

    }

    void Update()
    {
        // control the flap by hitting space button
        if (Input.GetKeyDown(KeyCode.Space) == true && BirdIsAlive == true)
        {
            myRigidBody.linearVelocity = new Vector2(myRigidBody.linearVelocityX, 2f * flapStrength);
        }

        if ((transform.position.y > topDeadZoneY || transform.position.y < bottomDeadZoneY) && BirdIsAlive)
        {
            logic.GameOver();
            BirdIsAlive = false;
        }

        // destory the game object only when it left the screen at them bottom of the scene
        //if the bird goes off the screen in the top then we see it's falling down through the screen
        if (transform.position.y < bottomDeadZoneY)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //cheking collision with pipes
        if (birdIsAlive)
        {
            logic.GameOver();
            birdIsAlive = false;
        }

    }

    public void SetPoisoned()
    {
        // Stop other fading to prevent overlapping fades
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
        }
        fadeCoroutine = StartCoroutine(FadeToSprite(poisonedSprite));
       
        BirdIsPoisoned = true;
        tail.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        tailAnimator.SetTrigger("TgPoisoned");

    }

    public void SetCured()
    {

        // Stop other fading to prevent overlapping fades
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
        }
        fadeCoroutine = StartCoroutine(FadeToSprite(healthySprite));
        BirdIsPoisoned = false;

        //have to change the scale, becaue of the tail sprite's size are differents
        tail.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        tailAnimator.SetTrigger("TgCured");
    }


    private IEnumerator FadeToSprite(Sprite newSprite)
    {
        yield return StartCoroutine(FadeOutPoisonEffect());
        birdBodyRenderer.sprite = newSprite;
        yield return StartCoroutine(FadeInPoisonEffect());
    }

    private IEnumerator FadeInPoisonEffect()
    {
        float time = 0f;
        Color c = birdBodyRenderer.color;

        while (time < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, time / fadeDuration);
            birdBodyRenderer.color = new Color(c.r, c.g, c.b, alpha);
            time += Time.deltaTime;
            yield return null;
        }

        // set visibility to max
        birdBodyRenderer.color = new Color(c.r, c.g, c.b, 1f);
    }

    private IEnumerator FadeOutPoisonEffect()
    {
        float time = 0f;
        Color c = birdBodyRenderer.color;

        while (time < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, time / fadeDuration);
            birdBodyRenderer.color = new Color(c.r, c.g, c.b, alpha);
            time += Time.deltaTime;
            yield return null;
        }

        // set INvisibility to max
        birdBodyRenderer.color = new Color(c.r, c.g, c.b, 0f);
    }

 

 


}



