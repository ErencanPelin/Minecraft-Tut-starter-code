using System.Collections.Generic;
using Eren.MinecraftTut.Runtime.Block;
using UnityEngine;

namespace Eren.MinecraftTut.Runtime.WorldGen
{
    public class ChunkMesher
    {
        private int rootX, rootY, rootZ;
        private BlockData[] blockData;

        private List<Vector3> vertices;
        private List<int> triangles;
        
        public ChunkMesher(int rootX, int rootY, int rootZ, BlockData[] blockData)
        {
            this.rootX = rootX;
            this.rootY = rootY;
            this.rootZ = rootZ;
            this.blockData = blockData;
            vertices = new List<Vector3>();
            triangles = new List<int>();
        }
        
        public Mesh RecalculateMesh()
        {
            int triIndex = 0;

            //define mesh
            foreach (BlockData block in blockData)
            {
                if (block.blockType == 0) continue;
                DrawCube(block.x, block.y, block.z, (BlockType)block.blockType, triIndex);
                triIndex += 24;
            }
            
            var newMesh = new Mesh
            {
                vertices = vertices.ToArray(),
                triangles = triangles.ToArray()
            };
            newMesh.RecalculateNormals();
            return newMesh;
        }

        private void DrawCube(int x, int y, int z, BlockType blockType, int triIndex)
        {
            var newMesh = new Mesh();
    
            //define cube mesh
            //front face
            vertices.Add(new Vector3(x, y, z)); //0
            vertices.Add(new Vector3(x, y + 1, z)); //1
            vertices.Add(new Vector3(x + 1, y + 1, z)); //2
            vertices.Add(new Vector3(x + 1, y, z)); //3
            
            triangles.Add(triIndex);
            triangles.Add(triIndex + 1);
            triangles.Add(triIndex + 2);

            triangles.Add(triIndex + 2);
            triangles.Add(triIndex + 3);
            triangles.Add(triIndex);
            
            //top face
            vertices.Add(new Vector3(x, y + 1, z)); //4
            vertices.Add(new Vector3(x, y + 1, z + 1)); //5
            vertices.Add(new Vector3(x + 1, y + 1, z)); //6
            vertices.Add(new Vector3(x + 1, y + 1, z + 1)); //7

            triangles.Add(triIndex + 4);
            triangles.Add(triIndex + 5);
            triangles.Add(triIndex + 6);

            triangles.Add(triIndex + 5);
            triangles.Add(triIndex + 7);
            triangles.Add(triIndex + 6);

            //right face
            vertices.Add(new Vector3(x + 1, y, z)); //8
            vertices.Add(new Vector3(x + 1, y + 1, z)); //9
            vertices.Add(new Vector3(x + 1, y + 1, z + 1)); //10
            vertices.Add(new Vector3(x + 1, y, z + 1)); //11

            triangles.Add(triIndex + 8);
            triangles.Add(triIndex + 9);
            triangles.Add(triIndex + 10);

            triangles.Add(triIndex + 11);
            triangles.Add(triIndex + 8);
            triangles.Add(triIndex + 10);
            
            //left face
            vertices.Add(new Vector3(x, y, z)); //12
            vertices.Add(new Vector3(x, y + 1, z)); //13
            vertices.Add(new Vector3(x, y + 1, z + 1)); //14
            vertices.Add(new Vector3(x, y, z + 1)); //15

            triangles.Add(triIndex + 14);
            triangles.Add(triIndex + 13);
            triangles.Add(triIndex + 12);

            triangles.Add(triIndex + 14);
            triangles.Add(triIndex + 12);
            triangles.Add(triIndex + 15);
            
            //bottom face
            vertices.Add(new Vector3(x, y, z)); //16
            vertices.Add(new Vector3(x, y, z + 1)); //17
            vertices.Add(new Vector3(x + 1, y, z)); //18
            vertices.Add(new Vector3(x + 1, y, z + 1)); //19

            triangles.Add(triIndex + 18);
            triangles.Add(triIndex + 17);
            triangles.Add(triIndex + 16);

            triangles.Add(triIndex + 18);
            triangles.Add(triIndex + 19);
            triangles.Add(triIndex + 17);
            
            //back face
            vertices.Add(new Vector3(x, y, z + 1)); //20
            vertices.Add(new Vector3(x, y + 1, z + 1)); //21
            vertices.Add(new Vector3(x + 1, y + 1, z + 1)); //22
            vertices.Add(new Vector3(x + 1, y, z + 1)); //23
            
            triangles.Add(triIndex + 22);
            triangles.Add(triIndex + 21);
            triangles.Add(triIndex + 20);

            triangles.Add(triIndex + 20);
            triangles.Add(triIndex + 23);
            triangles.Add(triIndex + 22);
        }
    }
}