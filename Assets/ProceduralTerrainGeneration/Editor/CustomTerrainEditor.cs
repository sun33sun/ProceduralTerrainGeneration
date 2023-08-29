using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CustomTerrain))]
[CanEditMultipleObjects]
public class CustomTerrainEditor : Editor
{
    //properties---------
    private SerializedProperty randomHeightRange;
    private SerializedProperty  heightMapImage;
    private SerializedProperty  heightMapScale;
    //fold outs---------
    private bool showRandom = false;
    private bool showLoadHeights = false;
    
    private void OnEnable()
    {
        randomHeightRange = serializedObject.FindProperty("randomHeightRange");
        heightMapImage = serializedObject.FindProperty("heightMapImage");
        heightMapScale = serializedObject.FindProperty("heightMapScale");
    }
    
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        CustomTerrain terrain = (CustomTerrain)target;
        showRandom = EditorGUILayout.Foldout(showRandom, "Random");
        showLoadHeights = EditorGUILayout.Foldout(showLoadHeights, "Load HeightMap");
        
        if (showRandom)
        {
            EditorGUILayout.LabelField("",GUI.skin.horizontalScrollbar);
            GUILayout.Label("Set Heights Between Random Values",EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(randomHeightRange);
            if (GUILayout.Button("Random Heights"))
            {
                terrain.RandomTerrain();
            }
            EditorGUILayout.LabelField("",GUI.skin.horizontalScrollbar);
        }
        if (showLoadHeights)
        {
            EditorGUILayout.LabelField("",GUI.skin.horizontalScrollbar);
            GUILayout.Label("Load Heights From Texture",EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(heightMapImage);
            EditorGUILayout.PropertyField(heightMapScale);
            EditorGUILayout.LabelField("",GUI.skin.horizontalScrollbar);
            if (GUILayout.Button("Load Texture"))
            {
                terrain.LoadTexture();
            }
            EditorGUILayout.LabelField("",GUI.skin.horizontalScrollbar);
        }
        if (GUILayout.Button("Reset Heights"))
        {
            terrain.ResetTerrain();
        }
        serializedObject.ApplyModifiedProperties();
    }
}
