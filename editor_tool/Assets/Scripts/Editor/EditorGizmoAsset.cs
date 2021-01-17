using UnityEngine;

namespace technical.test.editor
{
    [CreateAssetMenu(fileName = "Gizmo Editor Asset", menuName = "Custom/Create Editor Gizmo Asset")]
    public class EditorGizmoAsset : ScriptableObject
    {
        [SerializeField] private Gizmo[] _gizmos = default;

        public override string ToString()
        {
            return "Gizmo count : " + _gizmos.Length;
        }
    }

}