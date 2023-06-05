using Eren.MinecraftTut.Runtime.Block;
using UnityEngine;

namespace Eren.MinecraftTut.Runtime.WorldGen
{
    public class Chunk
    {
        private int rootX, rootY, rootZ, stopX, stopY, stopZ;
        private BlockData[] blockData;
        private GameObject chunkObject;
        private ChunkMesher chunkMesher;
        private MeshFilter meshFilter;
        private MeshCollider meshCollider;
        
        public Chunk(int rootX, int rootY, int rootZ, int chunkSize, Transform worldTransform, GameObject chunkPrefab)
        {
            this.rootX = rootX * chunkSize;
            this.rootY = rootY * chunkSize;
            this.rootZ = rootZ * chunkSize;
            stopX = this.rootX + chunkSize;
            stopY = this.rootY + chunkSize;
            stopZ = this.rootZ + chunkSize;
            
            blockData = new BlockData[chunkSize * chunkSize * chunkSize];

            chunkObject = Object.Instantiate(chunkPrefab, new Vector3(rootX, rootY, rootZ), Quaternion.identity, worldTransform);
            chunkObject.name = $"{rootX} | {rootY} | {rootZ}";

            meshFilter = chunkObject.GetComponent<MeshFilter>();
            meshCollider = chunkObject.GetComponent<MeshCollider>();
            
            chunkMesher = new ChunkMesher(rootX, rootY, rootZ, blockData);
            
            RefreshChunkData();
            RedrawChunk();
        }

        private void RefreshChunkData()
        {
            blockData[0] = new BlockData(rootX, rootY, 0, BlockType.dirt);
            blockData[1] = new BlockData(1, 0, 0, BlockType.dirt);
            blockData[2] = new BlockData(0, 1, 0, BlockType.dirt);
            blockData[3] = new BlockData(0, 0, 1, BlockType.dirt);
        }

        //add the chunk into the world
        private void RedrawChunk()
        {
            var newMesh = chunkMesher.RecalculateMesh();
            meshFilter.mesh = newMesh;
            meshCollider.sharedMesh = newMesh;
        }
    }
}