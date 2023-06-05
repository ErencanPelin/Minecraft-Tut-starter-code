using UnityEngine;

namespace Eren.MinecraftTut.Runtime.Block
{
    [CreateAssetMenu(fileName = "newBlockClass", menuName = "World/BlockClass")]
    public class BlockClass : ScriptableObject
    {
        [field: SerializeField] public string name { get; private set; }
        [field: SerializeField] public Texture2D[] texture { get; private set; }
    }
}
