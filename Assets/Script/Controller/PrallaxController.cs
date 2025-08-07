using UnityEngine;

public class PrallaxController: MonoBehaviour
{


    [SerializeField] private float prallaxEffect;
    private Transform[] parts;
    private float width;

    // I do not need properties here,
    // since I dont want to change this class' fields externally

    void Start()
    {
        int count = transform.childCount;
        parts = new Transform[count];
        for (int i = 0; i < count; i++)
        {
            parts[i] = transform.GetChild(i);
        }

        SpriteRenderer sr = parts[0].GetComponent<SpriteRenderer>();
        width = sr.bounds.size.x;
    }

    void Update()
    {
        transform.position += Vector3.left * prallaxEffect * Time.deltaTime;

        foreach (Transform part in parts)
        {
            // Use the camera's left edge (in world units)
            float cameraLeftEdge = Camera.main.transform.position.x - (Camera.main.orthographicSize * Camera.main.aspect);

            // If the right edge of the tile is left of the camera's left edge
            float partRightEdge = part.position.x + (width / 2f);
            if (partRightEdge < cameraLeftEdge)
            {
                // Find the rightmost tile
                Transform rightmost = parts[0];
                for (int i = 1; i < parts.Length; i++)
                {
                    if (parts[i].position.x > rightmost.position.x)
                        rightmost = parts[i];
                }

                // Reposition this tile to the right of the rightmost one
                part.position = new Vector3(
                    rightmost.position.x + width,
                    part.position.y,
                    part.position.z
                );
            }
        }


    }
}
