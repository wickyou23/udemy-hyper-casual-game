using UnityEngine;

public class Chunk : MonoBehaviour
{
    public enum ChunkSize
    {
        Small,
        Medium,
        Large
    }

    [Header("Setting")]
    [SerializeField] private Vector3 size;
    [SerializeField] private ChunkSize chunkSize;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public float GetLength()
    {
        return size.z;
    }

    public float GetWidth()
    {
        return size.x;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, size);
    }

    public ChunkSize GetSize()
    {
        return chunkSize;
    }
}
