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

        [HideInInspector]
        public GameObject gizmoObject;

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

        public Gizmo Update(Gizmo gizmo){
            /*if(gizmo.Position == Tools.handlePosition ){
                //Debug.Log("Tools");
                Position = Tools.handlePosition;   
            }else{
                Debug.Log("Position");
                Position = gizmo.Position;
                gizmoObject.transform.position = Position;
            }*/
            Position = Tools.handlePosition; 
            Name = gizmo.Name;  
            ChangeName();   
            return this;        
        }

        public void EditMode(){
            Tools.hidden = !Tools.hidden;
            Selection.activeGameObject = gizmoObject;
            if( Tools.hidden ){
                Tools.current = Tool.Move;
            }
        }

        private void ChangeName(){
            gizmoObject.transform.GetChild(0).gameObject.GetComponent<TextMesh>().text = Name;
            gizmoObject.name = Name;
        }

        public Gizmo ResetPosition(){
            Position = new Vector3(0f,0f,0f);
            gizmoObject.transform.position = Position;
            return this;
        }

        
    }

}