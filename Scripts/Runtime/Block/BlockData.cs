namespace Eren.MinecraftTut.Runtime.Block
{
    public struct BlockData
    {
        public int x, y, z;
        public byte blockType;

        public BlockData(int x, int y, int z, BlockType blockType)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.blockType = (byte)blockType;
        }
    }
}