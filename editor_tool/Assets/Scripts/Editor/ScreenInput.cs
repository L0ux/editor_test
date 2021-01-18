using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace technical.test.editor
{
    [InitializeOnLoad]
    public class SceneGUIGenericMenu : Editor {

        public static EditorGizmoAsset data = new EditorGizmoWindow().data;

        static SceneGUIGenericMenu () {
            SceneView.duringSceneGui += OnSceneGUI;
        }

        static void OnSceneGUI (SceneView sceneview) {
            if (Event.current.button == 1)
            {   
                if (Event.current.type == EventType.MouseDown)
                {        
                    Vector3 distanceFromCam = new Vector3(Camera.main.transform.position.x,Camera.main.transform.position.y,0);
                    Plane plane = new Plane(Vector3.forward, distanceFromCam);
                    Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
                    float distanceIntersection = 0.0f;
                    plane.Raycast(ray, out distanceIntersection);
                    clearLog();
                    Gizmo[] gizmos = data.GetGizmo();
                    foreach (Gizmo gizmo in gizmos)
                    {   
                        float radius = gizmo.gizmoObject.GetComponent<SphereCollider>().radius;
                        GenericMenu menu = new GenericMenu();
                        if( Vector3.Distance(gizmo.Position,ray.GetPoint(distanceIntersection)) < radius){
                            Gizmo touched = gizmo;
                            menu.AddItem(new GUIContent("Reset position"), false, Reset, touched);
                            menu.AddItem(new GUIContent("Delete gizmo"), false, Delete, touched);
                            menu.ShowAsContext();
                            break;
                        }else{
                            menu.AddItem(new GUIContent("Add gizmo"), false, Add, ray.GetPoint(distanceIntersection));
                            menu.ShowAsContext();
                            break;
                        }
                    }
                }
            }
        }

        static void Reset (object obj) {
            Gizmo gizmo = (Gizmo) obj;
            data.ResetGizmoPosition(gizmo);
        }

        static void Delete (object obj) {
            Gizmo gizmo = (Gizmo) obj;
            data.RemoveGizmo(gizmo);
        }

        static void Add(object obj) {
            Vector3 position = (Vector3) obj;
            data.AddGizmo(position);
        }


        private static void clearLog(){
            var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
            var type = assembly.GetType("UnityEditor.LogEntries");
            var method = type.GetMethod("Clear");
            method.Invoke(new object(), null);
        }
    }
}
