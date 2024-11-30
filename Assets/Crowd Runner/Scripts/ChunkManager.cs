using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    public static ChunkManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    [Header("Elements")]
    [SerializeField] private Chunk[] chunksPrefabs;
    [SerializeField] private Chunk finishChunk;
    [SerializeField] private Chunk startChunk;

    private Chunk finishChunkInstance;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 initPosition = Vector3.zero;

        Instantiate(startChunk, initPosition, Quaternion.identity, transform);
        initPosition.z += startChunk.GetLength() / 2;

        for (int i = 0; i < 5; i++)
        {
            Chunk chunkCreater = chunksPrefabs[Random.Range(0, chunksPrefabs.Length)];
            initPosition.z += chunkCreater.GetLength() / 2;
            Chunk chunk = Instantiate(chunkCreater, initPosition, Quaternion.identity, transform);
            initPosition.z += chunk.GetLength() / 2;
        }

        initPosition.z += finishChunk.GetLength() / 2;
        finishChunkInstance = Instantiate(finishChunk, initPosition, Quaternion.identity, transform);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public float GetFinhisLineZ()
    {
        return finishChunkInstance.transform.localPosition.z;
    }
}
