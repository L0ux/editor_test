using UnityEngine;
using UnityEditor;

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

        public Gizmo[] GetGizmo(){
            return _gizmos;
        }

        public void SetGizmo(int index,Gizmo g){
            _gizmos[index] = g;
        }
    }

    [CustomEditor(typeof(EditorGizmoAsset))]
    public class EditorGizmoAssetEditor : Editor
    {

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            if( GUILayout.Button("Open Editor Window")){
                EditorGizmoWindow window = ScriptableObject.CreateInstance<EditorGizmoWindow>();
                window.Show();
            }
        }
    }

}