using System;
using UnityEngine;

public class CoinChunkGenerate : MonoBehaviour
{
    public enum CoinPosition
    {
        Left,
        Right,
        Center
    }

    [Header("Elements")]
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private Chunk chunk;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CoinPosition[] positions = (CoinPosition[])Enum.GetValues(typeof(CoinPosition));
        int numberOfCoin = NumberOfCoinBySize(chunk.GetSize());

        for (int i = 0; i < numberOfCoin; i++)
        {
            CoinPosition CoinPosition = positions[UnityEngine.Random.Range(0, positions.Length - 1)];
            GameObject coin = Instantiate(coinPrefab, transform);
            coin.transform.localPosition = GetPosition(CoinPosition, i, numberOfCoin);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private Vector3 GetPosition(CoinPosition position, int cointIndex, int numberOfCoin)
    {
        float lengthOfCoin = chunk.GetLength() / numberOfCoin;
        float zPosition = -(chunk.GetLength() / 2) + (lengthOfCoin * cointIndex) + (lengthOfCoin / 2);
        switch (position)
        {
            case CoinPosition.Left:
                return new Vector3(-chunk.GetWidth() / 4, 1.5f, zPosition);
            case CoinPosition.Right:
                return new Vector3(chunk.GetWidth() / 4, 1.5f, zPosition);
            case CoinPosition.Center:
                return new Vector3(0, 1.5f, zPosition);
            default:
                return Vector3.zero;
        }
    }

    private int NumberOfCoinBySize(Chunk.ChunkSize size)
    {
        switch (size)
        {
            case Chunk.ChunkSize.Small:
                return UnityEngine.Random.Range(1, 3);
            case Chunk.ChunkSize.Medium:
                return UnityEngine.Random.Range(3, 5);
            case Chunk.ChunkSize.Large:
                return UnityEngine.Random.Range(5, 7); ;
            default:
                return 0;
        }
    }
}
