using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

namespace technical.test.editor
{
    public class EditorGizmoWindow : EditorWindow
    {
        string text;
        new Vector3 position;
        Gizmo[] _gizmos;
        


        public EditorGizmoAsset data;

        
        // Add menu item named "My Window" to the Window menu
        [MenuItem("Window/Custom/Editor Gizmos")]
        public static void ShowWindow()
        {
            //Show existing window instance. If one doesn't exist, make one.
            EditorWindow.GetWindow(typeof(EditorGizmoWindow));
        }

        public void Awake()
        {
            Debug.Log("Awake");
            _gizmos = data.GetGizmo();
        }
        
        void OnGUI()
        {   
            GUILayout.Label ("Gizmo Editor", EditorStyles.boldLabel);
            GUILayout.BeginHorizontal();
            GUILayout.Label("Text");
            GUILayout.Space(180);
            GUILayout.Label("Position");
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();

            for(int i = 0; i < _gizmos.Length; i++)
            {
                GUILayout.BeginHorizontal();
                _gizmos[i].Name = EditorGUILayout.TextField (_gizmos[i].Name,GUILayout.ExpandWidth(false));
                GUILayout.Label("x");
                _gizmos[i].Position.x = EditorGUILayout.FloatField(_gizmos[i].Position.x,GUILayout.ExpandWidth(false));
                GUILayout.Label("y");
                _gizmos[i].Position.y = EditorGUILayout.FloatField(_gizmos[i].Position.y,GUILayout.ExpandWidth(false));
                GUILayout.Label("z");
                _gizmos[i].Position.z = EditorGUILayout.FloatField(_gizmos[i].Position.z,GUILayout.ExpandWidth(false));
                if (GUILayout.Button("Edit"))
                {
                    data.SetGizmo(i,_gizmos[i]);
                }
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();
            }

        }
    }
}