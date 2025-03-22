using UnityEditor;
using UnityEngine;

namespace Assets.Week1
{
    [CreateAssetMenu(fileName = "Color", menuName = "ColorData", order = 1)]
    public class GameColors : ScriptableObject
    {
        [MenuItem("Tools/MyTool/Do It in C#")]
        static void DoIt()
        {
            EditorUtility.DisplayDialog("MyTool", "ola", "OK", "");
        }
        public Color _colorData;

    }
}