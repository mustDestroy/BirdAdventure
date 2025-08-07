using UnityEngine;

public class CoinSpawner : MonoBehaviour
{

    [SerializeField] private GameObject endPoint;
    [SerializeField] private GameObject coin;
    private float spawnRadius;
    private float spawnRate;
    private float timer;

    private Vector2 spawnAreaMin = new Vector2(9f, -3f);
    private Vector2 spawnAreaMax = new Vector2(11f, 3f);

    public float SpawnRadius
    {
        get { return spawnRadius; }
        set { spawnRadius = value; }
    }
    public float SpawnRate
    {
        get { return spawnRate; }
        set { spawnRate = value; }
    }
    public float Timer
    {
        get { return timer; }
        set { timer = value; }
    }

    //Maybe wee need these properties in further releases, but I set it to private until then
    private Vector2 SpawnAreaMin
    {
        get { return spawnAreaMin; }
        set { spawnAreaMin = value; }
    }
    private Vector2 SpawnAreaMax
    {
        get { return spawnAreaMax; }
        set { spawnAreaMax = value; }
    }


    private void Awake()
    {
        SpawnRadius = 7.0f;
        spawnRate = 1.0f;
        Timer = 0.0f;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnCoin();
    }

    void Update()
    {
        if (spawnRate > timer)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            SpawnCoin();
            Debug.Log("Coin spawned spawned");
            timer = 0;
        }

    }

    void SpawnCoin()
    {
        Vector2 spawnPosition = GetRandomPosition();
        GameObject newCoin = Instantiate(coin, spawnPosition, Quaternion.identity);

        if (Physics2D.OverlapCircle(spawnPosition, spawnRadius, LayerMask.NameToLayer("Pipe")))
        {
            Debug.Log("Overlapping ALERT");
            //while (Physics2D.OverlapCircle(spawnPosition, spawnRadius, LayerMask.NameToLayer("Pipe")))
            //{
            //    spawnPosition = GetRandomPosition();
            //}
            //Instantiate(coin, spawnPosition, Quaternion.identity);

            spawnPosition = GetRandomPosition();
            Instantiate(newCoin, spawnPosition, Quaternion.identity);
        }
        else
        {
            Instantiate(newCoin, spawnPosition, Quaternion.identity);
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
    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector2 vector = GetRandomPosition();
        Gizmos.DrawSphere(vector, 5);
    }*/
}
