using UnityEngine;

namespace Eren.MinecraftTut.Runtime.WorldGen
{
    [CreateAssetMenu(fileName = "newWorldSettings", menuName = "World/WorldSettings")]
    public class WorldSettings : ScriptableObject
    {
        [field: SerializeField] public int chunkSize { get; private set; }
        [field: SerializeField] public GameObject chunkPrefab { get; private set; }
    }
}