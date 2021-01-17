using UnityEngine;
using UnityEditor;
using System;

namespace technical.test.editor
{
    [CreateAssetMenu(fileName = "Gizmo Editor Asset", menuName = "Custom/Create Editor Gizmo Asset")]
    public class EditorGizmoAsset : ScriptableObject
    {   

        [SerializeField] private GameObject gizmoPrefab = null;
        [SerializeField] private Gizmo[] _gizmos = default;


        public override string ToString()
        {
            return "Gizmo count : " + _gizmos.Length;
        }

        public Gizmo[] GetGizmo(){
            return _gizmos;
        }

        public void SetGizmo(int index,Gizmo g){
            _gizmos[index].EditMode();
            _gizmos[index] = g;
        }

        public void AddGizmo(){
            Array.Resize(ref _gizmos,_gizmos.Length+1);
            _gizmos[_gizmos.GetUpperBound(0)] = new Gizmo("new",new Vector3(0f,0f,0f),gizmoPrefab);
        }

        public void RemoveGizmo(Gizmo gizmo){
            for( int i = 0; i < _gizmos.Length; i++){
                if( gizmo.Equals(_gizmos[i]) ){
                    gizmo.DestroyObject();
                    for( int j = i; j < _gizmos.Length -1; j++){
                        _gizmos[j] = _gizmos[j+1];
                    } 
                    Array.Resize(ref _gizmos,_gizmos.Length-1);
                    break;
                }
            }
        }

        public void UpdateGizmo(int index){
            _gizmos[index].Position = _gizmos[index].Update();
        }

        public void OnValidate() {
            Debug.Log(Time.time);
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