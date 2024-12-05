using UnityEngine;

[CreateAssetMenu(fileName = "LevelSO", menuName = "Scriptable Object/LevelSO")]
public class LevelSO : ScriptableObject
{
    public Chunk[] chunks;
}
