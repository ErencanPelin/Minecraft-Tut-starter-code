using UnityEngine;

namespace Eren.MinecraftTut.Runtime.WorldGen
{
    public class WorldGenerator : MonoBehaviour
    {
        [SerializeField] private WorldSettings worldSettings;

        private Transform _transform;
        
        private void Awake()
        {
            _transform = transform;
            
            var newChunk = new Chunk(0, 0, 0, worldSettings.chunkSize, _transform, worldSettings.chunkPrefab);
            var newChunk1 = new Chunk(1, 0, 0, worldSettings.chunkSize, _transform, worldSettings.chunkPrefab);
        }
    }
}
