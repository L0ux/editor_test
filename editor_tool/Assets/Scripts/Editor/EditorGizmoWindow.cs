using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace technical.test.editor
{
    public class EditorGizmoWindow : EditorWindow
    {
        private Gizmo[] _gizmos;
        
        [SerializeField]
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
            //Debug.Log("Awake");
            UpdateGizmoList();
        }


        private void UpdateGizmoList(){
            _gizmos = data.GetGizmo();
            Array.Resize(ref editGizmo,_gizmos.Length);
        }
        
        void OnGUI()
        {   
            UpdateGizmoList();
            GUILayout.Label ("Gizmo Editor", EditorStyles.boldLabel);
            if (GUILayout.Button("Add Gizmo",GUILayout.ExpandWidth(false)))
            {
                data.AddGizmo();
                data.OnValidate();
                UpdateGizmoList();
            }
            GUILayout.BeginHorizontal();
            GUILayout.Label("Text");
            GUILayout.Space(180);
            GUILayout.Label("Position");
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();

            GUIStyle colorStyle = new GUIStyle(EditorStyles.textField);

            for(int i = 0; i < _gizmos.Length; i++)
            {   
                if(editGizmo[i]){
                    colorStyle.normal.textColor = Color.red;
                }else{
                    if(EditorGUIUtility.isProSkin){
                        colorStyle.normal.textColor = Color.white;
                    }else{
                        colorStyle.normal.textColor = Color.black;
                    }
                }

                GUILayout.BeginHorizontal();
                if(editGizmo[i]){
                    _gizmos[i].Name = EditorGUILayout.TextField (_gizmos[i].Name,colorStyle,GUILayout.ExpandWidth(false));
                    GUILayout.Label("x");
                    _gizmos[i].Position.x = EditorGUILayout.FloatField(_gizmos[i].Position.x,colorStyle,GUILayout.ExpandWidth(false));
                    GUILayout.Label("y");
                    _gizmos[i].Position.y = EditorGUILayout.FloatField(_gizmos[i].Position.y,colorStyle,GUILayout.ExpandWidth(false));
                    GUILayout.Label("z");
                    _gizmos[i].Position.z = EditorGUILayout.FloatField(_gizmos[i].Position.z,colorStyle,GUILayout.ExpandWidth(false));
                    data.UpdateGizmo(i,_gizmos[i]);
                }else{
                    EditorGUILayout.TextField (_gizmos[i].Name,colorStyle,GUILayout.ExpandWidth(false));
                    GUILayout.Label("x");
                    EditorGUILayout.FloatField(_gizmos[i].Position.x,colorStyle,GUILayout.ExpandWidth(false));
                    GUILayout.Label("y");
                    EditorGUILayout.FloatField(_gizmos[i].Position.y,colorStyle,GUILayout.ExpandWidth(false));
                    GUILayout.Label("z");
                    EditorGUILayout.FloatField(_gizmos[i].Position.z,colorStyle,GUILayout.ExpandWidth(false));
                }

                if (GUILayout.Button("Edit"))
                {
                    data.SetGizmo(i,_gizmos[i]);
                    editGizmo[i] = !editGizmo[i];
                }
                if (GUILayout.Button("Delete Gizmo",GUILayout.ExpandWidth(false)))
                {
                    if(EditorUtility.DisplayDialog("Warning delete confirmation","Confirm delete "+_gizmos[i].Name+ " gizmo ?","Confirm","Cancel") ){
                        data.RemoveGizmo(_gizmos[i]);
                        UpdateGizmoList();
                    }
                }
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();
            }

        }
    }
}