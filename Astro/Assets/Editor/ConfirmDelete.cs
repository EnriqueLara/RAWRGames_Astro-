using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ConfirmDelete : EditorWindow
{
    private static ItemDatabase2_0 db;
    private static EditorWindow deleteWindow;
    public static Item2_0 deleteItem;

    public static void ShowConfirmDeleteItemWindow()
    {
        deleteWindow = GetWindow<ConfirmDelete>();
        deleteWindow.maxSize = new Vector2(500, 100);
        deleteWindow.minSize = new Vector2(500, 100);
    }
    public void OnGUI()
    {
        GUIStyle textAreaStyle = new GUIStyle(GUI.skin.textArea);
        textAreaStyle.wordWrap = true;
        GUIStyle valueStyle = new GUIStyle(GUI.skin.label);
        valueStyle.wordWrap = true;
        valueStyle.alignment = TextAnchor.MiddleLeft;
        valueStyle.fixedWidth = 200;
        valueStyle.margin = new RectOffset(0, 120, 0, 0);

        EditorGUILayout.BeginVertical("Box");

        EditorGUILayout.BeginHorizontal("Box");
        GUILayout.Label("¿Are you sure you want to delete this item?");
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal("Box");
        if (GUILayout.Button("Cancel"))
        {
            deleteWindow.Close();
        }
        if (GUILayout.Button("Confirm"))
        {
            //Delete Item
            DeleteItem();
            deleteWindow.Close();
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.EndVertical();
    }
    public static void SetDeleteItem(ItemDatabase2_0 _db, Item2_0 _deleteItem)
    {
        db = _db;
        deleteItem = _deleteItem;
    }
    public static void DeleteItem()
    {
        if (deleteItem != null)
        {
            //db.DebugSomething("jalo");
            db.items.Remove(deleteItem);
        }
    }

}
