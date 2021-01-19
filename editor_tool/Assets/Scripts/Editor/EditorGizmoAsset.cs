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


        //Récupère la liste des gizmos
        public Gizmo[] GetGizmo(){
            return _gizmos;
        }

        //Rend éditable un gizmo
        public void EditGizmo(Gizmo gizmo){
            for( int i = 0; i < _gizmos.Length; i++){
                if( gizmo.Equals(_gizmos[i]) ){
                    _gizmos[i].EditMode();
                    break;
                }
            }
        }

        //Ajoute un gizmo au centre
        public void AddGizmo(){
            Array.Resize(ref _gizmos,_gizmos.Length+1);
            _gizmos[_gizmos.GetUpperBound(0)] = new Gizmo("new",new Vector3(0f,0f,0f),gizmoPrefab);
        }

        //Ajoute un gizmo à la position donnée
        public void AddGizmo(Vector3 position){
            Array.Resize(ref _gizmos,_gizmos.Length+1);
            _gizmos[_gizmos.GetUpperBound(0)] = new Gizmo("new",position,gizmoPrefab);
        }

        //Retire un gizmo à la liste
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


        //Met à jour le gizmo donné
        public void UpdateGizmo(Gizmo gizmo){
            for( int i = 0; i < _gizmos.Length; i++){
                if( gizmo.Equals(_gizmos[i]) ){
                    _gizmos[i].Update(gizmo);
                    break;
                }
            }
        }

        //Reset la position du gizmo
        public void ResetGizmoPosition(Gizmo gizmo){
            for( int i = 0; i < _gizmos.Length; i++){
                if( gizmo.Equals(_gizmos[i]) ){
                    _gizmos[i] = _gizmos[i].ResetPosition();
                    break;
                }
            }
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