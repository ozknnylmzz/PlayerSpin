using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Player.Spin.Editor
{
    [CustomEditor(typeof(SpinItem))]
    public class SpinItemEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI(); 
            
            SpinItem spinItem = (SpinItem)target;

            
            EditorGUI.BeginChangeCheck(); 
            Sprite newSprite = (Sprite)EditorGUILayout.ObjectField("Spin Item Image", spinItem.SpinItemImage.sprite, typeof(Sprite), allowSceneObjects: false);
            if(EditorGUI.EndChangeCheck()) 
            {
                Undo.RecordObject(spinItem.SpinItemImage, "Change Spin Item Image");
                spinItem.SpinItemImage.sprite = newSprite; 
                EditorUtility.SetDirty(spinItem.SpinItemImage); 
            }
        }
    }
}

