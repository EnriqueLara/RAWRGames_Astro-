using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//[CustomEditor(typeof(ItemDataBase))]
public class ItemDataBaseEditor : Editor
{
    //private ItemDataBase itemDb;
    //public Inventory materialDb;
    //private string searchString = "";
    //private bool shouldSearch;

    //// private bool ShowAllInformation;
    //private void OnEnable()
    //{
    //    itemDb = (ItemDataBase)target;
    //}
    //public override void OnInspectorGUI()
    //{
    //    base.OnInspectorGUI();

    //    if (itemDb)
    //    {
    //        GUIStyle labelStyle = new GUIStyle(GUI.skin.label);
    //        labelStyle.wordWrap = true;

    //        EditorGUILayout.BeginHorizontal("Box");
    //        GUILayout.Label("This database is the general Item Database (Weapons and Gear), it shouldnt be edited in runtime", labelStyle);
    //        EditorGUILayout.EndHorizontal();

    //        EditorGUILayout.BeginHorizontal("Box");
    //        GUILayout.Label("Num of Items: " + itemDb.items.Count);
    //        EditorGUILayout.EndHorizontal();
    //        EditorGUILayout.BeginHorizontal("Box");
    //        GUILayout.Label("Search: ");
    //        searchString = GUILayout.TextField(searchString);
    //        EditorGUILayout.EndHorizontal();

    //        if(GUILayout.Button("Add Item"))
    //        {
            
    //            AddItemWindow.ShowEmptyWindow(itemDb);
    //        }


    //        if(System.String.IsNullOrEmpty(searchString))
    //        {
    //            shouldSearch = false;
    //        }
    //        else
    //        {
    //            shouldSearch = true;
    //        }

    //        foreach (Item item in itemDb.items)
    //        {
    //            if(shouldSearch)
    //            {
    //                if(item.info.Name.Contains(searchString) || item.info.ID.ToString().Contains(searchString))
    //                {
    //                    DisplayItem(item);
    //                }
    //            }
    //            else
    //            {
    //                DisplayItem(item);
    //            }
    //        }

    //        if(deleteditem != null)
    //        itemDb.items.Remove(deleteditem);
            
    //    }
    //}
    //private Item deleteditem;
    //private void DisplayItem(Item _item)
    //{
    //    GUIStyle labelStyle = new GUIStyle(GUI.skin.label);
    //    labelStyle.wordWrap = true;
    //    GUIStyle valueStyle = new GUIStyle(GUI.skin.label);
    //    valueStyle.wordWrap = true;
    //    valueStyle.alignment = TextAnchor.MiddleLeft;
    //    valueStyle.fixedWidth = 200;
    //    valueStyle.margin = new RectOffset(0, 120, 0, 0);

    //    EditorGUILayout.BeginVertical("Box");


    //    EditorGUILayout.BeginHorizontal("Box");
    //    GUILayout.Label("Name: ");
    //    GUILayout.Label(_item.info.Name,valueStyle);
    //    EditorGUILayout.EndHorizontal();

    //    EditorGUILayout.BeginHorizontal("Box");
    //    GUILayout.Label("ID: ");
    //    GUILayout.Label(_item.info.ID.ToString(), valueStyle);
    //    EditorGUILayout.EndHorizontal();


        
    //    EditorGUILayout.BeginHorizontal("Box");
    //    GUILayout.Label("Show All Item Information: ");
    //    _item.ShowAllInfo = EditorGUILayout.Toggle(_item.ShowAllInfo);
    //    EditorGUILayout.EndHorizontal();

    //    if (_item.ShowAllInfo)
    //    {

    //        //EditorGUILayout.BeginHorizontal("Box");
    //        GUILayout.Label("Description: ");
    //        _item.scrollPos = EditorGUILayout.BeginScrollView(_item.scrollPos, GUILayout.MinHeight(3), GUILayout.MaxHeight(50));
    //        GUILayout.Label(_item.info.description, labelStyle);
    //        EditorGUILayout.EndScrollView();
    //        //EditorGUILayout.EndHorizontal();

    //        EditorGUILayout.BeginHorizontal("Box");
    //        GUILayout.Label("Type: ");
    //        GUILayout.Label(_item.info.type.ToString(), valueStyle);
    //        EditorGUILayout.EndHorizontal();

    //        if (_item.info.type == ItemEnums.ItemType.Equipment)
    //        {
    //            EditorGUILayout.BeginHorizontal("Box");
    //            GUILayout.Label("Gear type: ");
    //            GUILayout.Label(_item.gearType.ToString(), valueStyle);
    //            EditorGUILayout.EndHorizontal();
    //        }

    //        EditorGUILayout.BeginHorizontal("Box");
    //        GUILayout.Label("Rarity: ");
    //        GUILayout.Label(_item.info.rarity.ToString(), valueStyle);
    //        EditorGUILayout.EndHorizontal();

    //        EditorGUILayout.BeginHorizontal("Box");
    //        GUILayout.Label("Level: ");
    //        GUILayout.Label(_item.info.level.ToString(), valueStyle);
    //        EditorGUILayout.EndHorizontal();

    //        EditorGUILayout.BeginHorizontal("Box");
    //        GUILayout.Label("Max Level: ");
    //        GUILayout.Label(_item.info.maxLevel.ToString(), valueStyle);
    //        EditorGUILayout.EndHorizontal();

    //        EditorGUILayout.BeginHorizontal("Box");
    //        GUILayout.Label("Durability: ");
    //        GUILayout.Label(_item.info.durability.ToString(), valueStyle);
    //        EditorGUILayout.EndHorizontal();

    //        if (_item.info.type == ItemEnums.ItemType.Weapon)
    //        {
    //            EditorGUILayout.BeginHorizontal("Box");
    //            GUILayout.Label("---------------------WEAPON STATS------------------");
    //            EditorGUILayout.EndHorizontal();

    //            EditorGUILayout.BeginHorizontal("Box");
    //            GUILayout.Label("Damage: ");
    //            GUILayout.Label(_item.weaponStats.damage.ToString(), valueStyle);
    //            EditorGUILayout.EndHorizontal();

    //            EditorGUILayout.BeginHorizontal("Box");
    //            GUILayout.Label("Fire Rate: ");
    //            GUILayout.Label(_item.weaponStats.fireRate.ToString(), valueStyle);
    //            EditorGUILayout.EndHorizontal();

    //            EditorGUILayout.BeginHorizontal("Box");
    //            GUILayout.Label("Critical Hit Chance: ");
    //            GUILayout.Label(_item.weaponStats.criticalHitChance.ToString(), valueStyle);
    //            EditorGUILayout.EndHorizontal();

    //            EditorGUILayout.BeginHorizontal("Box");
    //            GUILayout.Label("Critical Hit Damage: ");
    //            GUILayout.Label(_item.weaponStats.criticalHitDamage.ToString(), valueStyle);
    //            EditorGUILayout.EndHorizontal();

    //            EditorGUILayout.BeginHorizontal("Box");
    //            GUILayout.Label("Bullet Speed: ");
    //            GUILayout.Label(_item.weaponStats.bulletSpeed.ToString(), valueStyle);
    //            EditorGUILayout.EndHorizontal();

    //            EditorGUILayout.BeginHorizontal("Box");
    //            GUILayout.Label("Range: ");
    //            GUILayout.Label(_item.weaponStats.range.ToString(), valueStyle);
    //            EditorGUILayout.EndHorizontal();

    //            EditorGUILayout.BeginHorizontal("Box");
    //            GUILayout.Label("Impact: ");
    //            GUILayout.Label(_item.weaponStats.impact.ToString(), valueStyle);
    //            EditorGUILayout.EndHorizontal();

    //            //-------------------------WEAPON PREFABS-----------------

    //            EditorGUILayout.BeginHorizontal("Box");
    //            GUILayout.Label("Projectile Prefab: ");
    //            if (_item.weaponPrefabs.projectilePrefab)
    //                GUILayout.Label(_item.weaponPrefabs.projectilePrefab.ToString(), valueStyle);
    //            EditorGUILayout.EndHorizontal();

    //            EditorGUILayout.BeginHorizontal("Box");
    //            GUILayout.Label("Weapon Prefab: ");
    //            if (_item.weaponPrefabs.weaponPrefab)
    //                GUILayout.Label(_item.weaponPrefabs.weaponPrefab.ToString(), valueStyle);
    //            EditorGUILayout.EndHorizontal();
    //        }
    //        else if (_item.info.type == ItemEnums.ItemType.Equipment)
    //        {
    //            EditorGUILayout.BeginHorizontal("Box");
    //            GUILayout.Label("Gear type: ");
    //            GUILayout.Label(_item.gearType.ToString(), valueStyle);
    //            EditorGUILayout.EndHorizontal();

    //            EditorGUILayout.BeginHorizontal("Box");
    //            GUILayout.Label("---------------------GEAR STATS------------------");
    //            EditorGUILayout.EndHorizontal();

    //            EditorGUILayout.BeginHorizontal("Box");
    //            GUILayout.Label("Health: ");
    //            GUILayout.Label(_item.gearStats.health.ToString(), valueStyle);
    //            EditorGUILayout.EndHorizontal();

    //            EditorGUILayout.BeginHorizontal("Box");
    //            GUILayout.Label("Armor: ");
    //            GUILayout.Label(_item.gearStats.armor.ToString(), valueStyle);
    //            EditorGUILayout.EndHorizontal();

    //            EditorGUILayout.BeginHorizontal("Box");
    //            GUILayout.Label("Oxygen Use: ");
    //            GUILayout.Label(_item.gearStats.oxygenUse.ToString(), valueStyle);
    //            EditorGUILayout.EndHorizontal();

    //            EditorGUILayout.BeginHorizontal("Box");
    //            GUILayout.Label("Movement Speed: ");
    //            GUILayout.Label(_item.gearStats.movementSpeed.ToString(), valueStyle);
    //            EditorGUILayout.EndHorizontal();

    //            EditorGUILayout.BeginHorizontal("Box");
    //            GUILayout.Label("Prefab: ");
    //            if (_item.gearPrefab.prefab)
    //                GUILayout.Label(_item.gearPrefab.prefab.ToString(), valueStyle);
    //            EditorGUILayout.EndHorizontal();
    //        }

    //        EditorGUILayout.BeginHorizontal("Box");
    //        GUILayout.Label("State: ");
    //        GUILayout.Label(_item.hiddenInfo.state.ToString(), valueStyle);
    //        EditorGUILayout.EndHorizontal();

    //        EditorGUILayout.BeginHorizontal("Box");
    //        GUILayout.Label("Locked Icon: ");
    //        if (_item.unityFields.lockedIcon)
    //            GUILayout.Label(_item.unityFields.lockedIcon.ToString(), valueStyle);
    //        EditorGUILayout.EndHorizontal();

    //        EditorGUILayout.BeginHorizontal("Box");
    //        GUILayout.Label("Common Icon: ");
    //        if (_item.unityFields.commonIcon)
    //            GUILayout.Label(_item.unityFields.commonIcon.ToString(), valueStyle);
    //        EditorGUILayout.EndHorizontal();

    //        EditorGUILayout.BeginHorizontal("Box");
    //        GUILayout.Label("Uncommon Icon: ");
    //        if (_item.unityFields.uncommonIcon)
    //            GUILayout.Label(_item.unityFields.uncommonIcon.ToString(), valueStyle);
    //        EditorGUILayout.EndHorizontal();

    //        EditorGUILayout.BeginHorizontal("Box");
    //        GUILayout.Label("Rare Icon: ");
    //        if (_item.unityFields.rareIcon)
    //            GUILayout.Label(_item.unityFields.rareIcon.ToString(), valueStyle);
    //        EditorGUILayout.EndHorizontal();

    //        EditorGUILayout.BeginHorizontal("Box");
    //        GUILayout.Label("Epic Icon: ");
    //        if (_item.unityFields.epicIcon)
    //            GUILayout.Label(_item.unityFields.epicIcon.ToString(), valueStyle);
    //        EditorGUILayout.EndHorizontal();

    //        EditorGUILayout.BeginHorizontal("Box");
    //        GUILayout.Label("Legendary Icon: ");
    //        if (_item.unityFields.legendaryIcon)
    //            GUILayout.Label(_item.unityFields.legendaryIcon.ToString(), valueStyle);
    //        EditorGUILayout.EndHorizontal();

    //        EditorGUILayout.BeginHorizontal("Box");
    //        GUILayout.Label("Mythic Icon: ");
    //        if (_item.unityFields.mythicIcon)
    //            GUILayout.Label(_item.unityFields.mythicIcon.ToString(), valueStyle);
    //        EditorGUILayout.EndHorizontal();

    //        EditorGUILayout.BeginHorizontal("Box");
    //        GUILayout.Label("---------------------REQUIRED OBJECTS------------------");
    //        EditorGUILayout.EndHorizontal();

    //        for(int i = 0; i < _item.numOfReqObj; i++)
    //        {
    //            EditorGUILayout.BeginHorizontal("Box");
    //            GUILayout.Label("Required Item ID: ");
    //            GUILayout.Label(_item.requiredObjs[i].x.ToString() + "  (" + materialDb.FindMaterial((int)_item.requiredObjs[i].x).Name +")", valueStyle);
    //            EditorGUILayout.EndHorizontal();

    //            EditorGUILayout.BeginHorizontal("Box");
    //            GUILayout.Label("Required Item amount: ");
    //            GUILayout.Label(_item.requiredObjs[i].y.ToString(), valueStyle);
    //            EditorGUILayout.EndHorizontal();
    //        }
    //    }

    //        EditorGUILayout.BeginHorizontal("Box");
    //        if (GUILayout.Button("Modify"))
    //        {
    //            ModifyItemWindow.ShowModifyItemWindow(itemDb, _item);
    //        }
    //        if (GUILayout.Button("Delete"))
    //        {
    //            deleteditem = _item;
    //            //itemDb.items.Remove(_item);
    //        }
    //        EditorGUILayout.EndHorizontal();
    //        EditorGUILayout.EndVertical();
        
    //}
}
