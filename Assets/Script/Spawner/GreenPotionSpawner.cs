using UnityEngine;

public class GreenPotionSpawner : MonoBehaviour
{

    // GameObject endPoint;
    public GameObject greenPotion;
    private float spawnRadius = 7f;
    private float spawnRate = 8.0f;
    private float timer = 0;

    Vector2 spawnAreaMin = new Vector2(9f, -3f);
    Vector2 spawnAreaMax = new Vector2(11f, 3f);



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnGreenPotion();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnRate > timer)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            SpawnGreenPotion();
            Debug.Log("Green potion spawned");
            timer = 0;
        }


    }

    void SpawnGreenPotion()
    {
        Vector2 spawnPosition = GetRandomPosition();
        GameObject newPotion = Instantiate(greenPotion, spawnPosition, Quaternion.identity);

        if (Physics2D.OverlapCircle(spawnPosition, spawnRadius, LayerMask.NameToLayer("Pipe")))
        {
            Debug.Log("Overlapping Green Potion ALERT");
            //while (Physics2D.OverlapCircle(spawnPosition, spawnRadius, LayerMask.NameToLayer("Pipe")))
            //{
            //    spawnPosition = GetRandomPosition();
            //}
            //Instantiate(coin, spawnPosition, Quaternion.identity);

            spawnPosition = GetRandomPosition();
            //Instantiate(newPotion, spawnPosition, Quaternion.identity);
        }
        else
        {
            Instantiate(newPotion, spawnPosition, Quaternion.identity);
        }
    }

    public Vector2 GetRandomPosition()
    {

        Vector2 randomPosition = new Vector2(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y)
            );

        return randomPosition;
    }
}

