using UnityEngine;

public class RottenAppleSpawner : MonoBehaviour
{

    public GameObject rottenApple;
    // GameObject endPoint;
    private float spawnRadius = 7f;
    private float spawnRate = 5.0f;
    private float timer = 0;

    Vector2 spawnAreaMin = new Vector2(9f, -3f);
    Vector2 spawnAreaMax = new Vector2(11f, 3f);


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnRottenApple();
       
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
            SpawnRottenApple();
            Debug.Log("Rotten apple spawned");
            timer = 0;
        }


    }
    public void SpawnRottenApple() {

        Vector2 spawnPosition = GetRandomPosition();
        GameObject newRottenApple = Instantiate(rottenApple, spawnPosition, Quaternion.identity);

        if (Physics2D.OverlapCircle(spawnPosition, spawnRadius, LayerMask.NameToLayer("Pipe")))
        {
            Debug.Log("Overlapping ALERT");
            //while (Physics2D.OverlapCircle(spawnPosition, spawnRadius, LayerMask.NameToLayer("Pipe")))
            //{
            //    spawnPosition = GetRandomPosition();
            //}
            //Instantiate(coin, spawnPosition, Quaternion.identity);

            //spawnPosition = GetRandomPosition();
            Instantiate(newRottenApple, spawnPosition, Quaternion.identity);
        }
        else
        {
            Instantiate(newRottenApple, spawnPosition, Quaternion.identity);
        }
    }


    Vector2 GetRandomPosition()
    {

        Vector2 randomPosition = new Vector2(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y)
            );

        return randomPosition;
    }


}
