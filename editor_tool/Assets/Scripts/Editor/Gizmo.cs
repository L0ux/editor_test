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
        public bool isEditing;

        [HideInInspector]
        public GameObject gizmoObject;

        public Gizmo(string name, Vector3 position,GameObject gizmoPrefab)
        {
            Name = name;
            Position = position;
            gizmoObject = UnityEngine.Object.Instantiate(gizmoPrefab, position, Quaternion.identity);
            gizmoObject.name = Name;
            Tools.hidden = true;
            isEditing = false;
        }


        //Détruit le GameObject lié au gizmo
        public void DestroyObject(){
            UnityEngine.Object.DestroyImmediate(gizmoObject);
        }

        //Met à jour la position et le nom du gizmo
        public Gizmo Update(Gizmo gizmo){
            Position = Tools.handlePosition;
            Position = new Vector3((float)Math.Round(Position.x,2),(float)Math.Round(Position.y,2),(float)Math.Round(Position.z,2));
            Name = gizmo.Name;  
            ChangeName();   
            return this;        
        }

        //Rend le gizmo editable ou non
        public void EditMode(){
            isEditing = !isEditing;
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

        //Reset la position du gizmo
        public Gizmo ResetPosition(){
            Position = new Vector3(0f,0f,0f);
            gizmoObject.transform.position = Position;
            return this;
        }

        
    }

}