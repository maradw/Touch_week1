using UnityEditor;
using UnityEngine;

namespace Assets.Week1
{
    [CreateAssetMenu(fileName = "Sprite", menuName = "SpriteData", order = 1)]
    public class GameImage : ScriptableObject
    {
        //[MenuItem("Tools/MyTool/Do It in C#")]
        static void DoIt()
        {
           // EditorUtility.DisplayDialog("MyTool", "Do It in C# !", "OK", "");
        }
        public Sprite _gameImage;
    }
}