using UnityEngine;

public class PipeSpawner: MonoBehaviour
{
    [SerializeField] private GameObject pipe;
    [SerializeField] private float spawnRate;
    [SerializeField] private float heightOffset;
    [SerializeField] private float timer;


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
    public float HeightOffset
    {
        get { return heightOffset; }
        set { heightOffset = value; }
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        SpawnPipe();
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
            SpawnPipe();
            timer = 0;
        }
    }

    void SpawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint)), transform.rotation);
    }
}
