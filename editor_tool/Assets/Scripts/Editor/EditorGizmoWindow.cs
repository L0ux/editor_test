using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace technical.test.editor
{
    public class EditorGizmoWindow : EditorWindow
    {
        Gizmo[] _gizmos;
        
        public EditorGizmoAsset data;

        private bool[] editGizmo;

        
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
            Array.Resize(ref editGizmo,_gizmos.Length);
        }
        
        void OnGUI()
        {   
            _gizmos = data.GetGizmo();
            Array.Resize(ref editGizmo,_gizmos.Length);
            GUILayout.Label ("Gizmo Editor", EditorStyles.boldLabel);
            if (GUILayout.Button("Add Gizmo",GUILayout.ExpandWidth(false)))
            {
                data.AddGizmo();
                data.OnValidate();
            }
            GUILayout.BeginHorizontal();
            GUILayout.Label("Text");
            GUILayout.Space(180);
            GUILayout.Label("Position");
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();

            GUIStyle colorStyle = new GUIStyle(EditorStyles.textField);
            colorStyle.normal.textColor = Color.red;

            for(int i = 0; i < _gizmos.Length; i++)
            {   
                if(editGizmo[i]){
                    colorStyle.normal.textColor = Color.red;
                    data.UpdateGizmo(i);
                }else{
                    if(EditorGUIUtility.isProSkin){
                        colorStyle.normal.textColor = Color.white;
                    }else{
                        colorStyle.normal.textColor = Color.black;
                    }
                }
                GUILayout.BeginHorizontal();
                _gizmos[i].Name = EditorGUILayout.TextField (_gizmos[i].Name,colorStyle,GUILayout.ExpandWidth(false));
                GUILayout.Label("x");
                _gizmos[i].Position.x = EditorGUILayout.FloatField(_gizmos[i].Position.x,colorStyle,GUILayout.ExpandWidth(false));
                GUILayout.Label("y");
                _gizmos[i].Position.y = EditorGUILayout.FloatField(_gizmos[i].Position.y,colorStyle,GUILayout.ExpandWidth(false));
                GUILayout.Label("z");
                _gizmos[i].Position.z = EditorGUILayout.FloatField(_gizmos[i].Position.z,colorStyle,GUILayout.ExpandWidth(false));
                if (GUILayout.Button("Edit"))
                {
                    data.SetGizmo(i,_gizmos[i]);
                    editGizmo[i] = !editGizmo[i];
                    data.OnValidate();

                }
                if (GUILayout.Button("Remove Gizmo",GUILayout.ExpandWidth(false)))
                {
                    data.RemoveGizmo(_gizmos[i]);
                    data.OnValidate();
                }
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();
            }

        }
    }
}