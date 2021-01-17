using System;
using UnityEngine;
using UnityEditor;

namespace technical.test.editor
{
    [Serializable]
    public struct Gizmo
    {
        public string Name;   
        public Vector3 Position;

        private GameObject gizmoObject;

        public Gizmo(string name, Vector3 position,GameObject gizmoPrefab)
        {
            Name = name;
            Position = position;
            gizmoObject = UnityEngine.Object.Instantiate(gizmoPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            gizmoObject.name = Name;
            Tools.hidden = true;
        }

        public void DestroyObject(){
            UnityEngine.Object.DestroyImmediate(gizmoObject);
        }

        public Vector3 Update(){
            Debug.Log(Tools.handlePosition);
            return Tools.handlePosition;        }

        public void EditMode(){
            Tools.hidden = !Tools.hidden;
            if( Tools.hidden ){
                Tools.current = Tool.Move;
                Selection.activeGameObject = gizmoObject;
            }
        }

        
    }

}