using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using ItemEnums2_0;

public class AddItemWindow2_0 : EditorWindow
{
    private static ItemDatabase2_0 db;
    private static EditorWindow window;
    private static Item2_0 newItem;

    private GUILayoutOption[] options = { GUILayout.MaxWidth(150.0f), GUILayout.MinWidth(325.0f) };
    private Vector2 scrollPos;
    private bool shouldDisable;
    private bool shouldDisableAmount;
    private bool shouldDisableID;
    private bool shouldDisableRarity;

    private Vector2[] auxRO = new Vector2[10];
    private string auxID = "";

    public static void ShowEmptyWindow(ItemDatabase2_0 _db)
    {
        db = _db;
        window = GetWindow<AddItemWindow2_0>();
        window.maxSize = new Vector2(500, 750);
        window.minSize = new Vector2(500, 750);
        newItem = new Item2_0();


    }
    private void OnGUI()
    {
        DisplayNewItem(newItem);

        if (GUILayout.Button("Confirm"))
        {
            AddItem();
        }
    }

    private void AddItem()
    {
        Undo.RecordObject(db, "Item Added");

        //asignar el id dependiendo el tipo
        switch (newItem.itemInfo.itemType)
        {
            case ItemType.Material:
                newItem.itemInfo.itemId = "M-" + auxID;
                break;
            case ItemType.Equipment:
                newItem.itemInfo.itemId = "E-" + auxID;
                break;
            case ItemType.Weapon:
                newItem.itemInfo.itemId = "W-" + auxID;
                break;
            case ItemType.LevelModule:
                newItem.itemInfo.itemId = "LM-" + auxID;
                break;
        }

        db.items.Add(newItem);
        EditorUtility.SetDirty(db);
        window.Close();

        newItem.requiredObjs = new Vector2[10];
        for (int i = 0; i < newItem.numOfReqObj; i++)
        {
            newItem.requiredObjs[i] = auxRO[i];
        }
    }
    private void DisplayNewItem(Item2_0 _item)
    {
        GUIStyle textAreaStyle = new GUIStyle(GUI.skin.textArea);
        textAreaStyle.wordWrap = true;
        GUIStyle valueStyle = new GUIStyle(GUI.skin.label);
        valueStyle.wordWrap = true;
        valueStyle.alignment = TextAnchor.MiddleLeft;
        valueStyle.fixedWidth = 200;
        valueStyle.margin = new RectOffset(0, 120, 0, 0);

        EditorGUILayout.BeginVertical("Box");


        scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.MinHeight(3), GUILayout.MaxHeight(750));

        EditorGUILayout.BeginHorizontal("Box");
        GUILayout.Label("ITEM INFORMATION: ");
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal("Box");
        GUILayout.Label("Name: ");
        _item.itemInfo.itemName = EditorGUILayout.TextField(_item.itemInfo.itemName, options);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal("Box");
        _item.itemInfo.itemType = (ItemType)EditorGUILayout.EnumPopup("Item Type", _item.itemInfo.itemType, options);
        EditorGUILayout.EndHorizontal();

        if(_item.itemInfo.itemType == ItemType.Null)
        {
            shouldDisableID = true;
        }
        else
        {
            shouldDisableID = false;
        }

        EditorGUI.BeginDisabledGroup(shouldDisableID);

        EditorGUILayout.BeginHorizontal("Box");
        GUILayout.Label("Item ID: ");
        auxID = EditorGUILayout.TextField(auxID, options);
        EditorGUILayout.EndHorizontal();

        




        switch (_item.itemInfo.itemType)
        {
            case ItemType.Material:
                if(db.FindMaterial(auxID) == null)
                {
                    shouldDisable = false;
                }
                else
                {
                    shouldDisable = true;
                }
                break;

            case ItemType.Equipment:
                if (db.FindEquipment(auxID) == null)
                {
                    shouldDisable = false;
                }
                else
                {
                    shouldDisable = true;
                }
                break;

            case ItemType.Weapon:
                if (db.FindWeapon(auxID) == null)
                {
                    shouldDisable = false;
                }
                else
                {
                    shouldDisable = true;
                }
                break;
            case ItemType.LevelModule:
                if (db.FindModule(auxID) == null)
                {
                    shouldDisable = false;
                }
                else
                {
                    shouldDisable = true;
                }
                break;
        }
        

        EditorGUI.EndDisabledGroup();
        if (System.String.IsNullOrEmpty(auxID))
        {
            shouldDisable = true;
        }
        EditorGUI.BeginDisabledGroup(shouldDisable);
        
        EditorGUILayout.BeginHorizontal("Box");
        _item.itemInfo.itemRarity = (ItemRarity)EditorGUILayout.EnumPopup("Item Rarity", _item.itemInfo.itemRarity, options);
        EditorGUILayout.EndHorizontal();

        if (_item.itemInfo.itemRarity == ItemRarity.Null)
        {
            shouldDisableRarity = true;
        }
        else
        {
            shouldDisableRarity = false;
        }

        EditorGUI.BeginDisabledGroup(shouldDisableRarity);


        //EditorGUILayout.BeginHorizontal("Box");
        GUILayout.Label("Description: ");
        _item.itemInfo.itemDescription = EditorGUILayout.TextArea(_item.itemInfo.itemDescription, textAreaStyle, GUILayout.MinHeight(70));
        //EditorGUILayout.EndHorizontal();



        if (_item.itemInfo.itemType == ItemType.Equipment)
        {
            EditorGUILayout.BeginHorizontal("Box");
            GUILayout.Label("EQUIPMENT STATS: ");
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal("Box");
            _item.equipmentType = (EquipmentStructs.EquipmentType)EditorGUILayout.EnumPopup("Gear Type", _item.equipmentType, options);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal("Box");
            GUILayout.Label("Health: ");
            _item.equipmentStats.equipmentHealth = EditorGUILayout.FloatField(_item.equipmentStats.equipmentHealth, options);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal("Box");
            GUILayout.Label("Armor: ");
            _item.equipmentStats.equipmentArmor = EditorGUILayout.FloatField(_item.equipmentStats.equipmentArmor, options);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal("Box");
            GUILayout.Label("Durability: ");
            _item.equipmentStats.equipmentDurability = EditorGUILayout.FloatField(_item.equipmentStats.equipmentDurability, options);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal("Box");
            GUILayout.Label("Movement Speed: ");
            _item.equipmentStats.equipmentMovementSpeed = EditorGUILayout.FloatField(_item.equipmentStats.equipmentMovementSpeed, options);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal("Box");
            GUILayout.Label("Oxygen Use: ");
            _item.equipmentStats.equipmentOxygenUse = EditorGUILayout.FloatField(_item.equipmentStats.equipmentOxygenUse, options);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal("Box");
            GUILayout.Label("CRAFTING MATERIALS: ");
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal("Box");
            GUILayout.Label("Number of elements: ");
            _item.numOfReqObj = EditorGUILayout.IntField(_item.numOfReqObj, options);
            EditorGUILayout.EndHorizontal();

            _item.requiredObjs = new Vector2[_item.numOfReqObj];


            for (int i = 0; i < _item.numOfReqObj; i++)
            {
                EditorGUILayout.BeginHorizontal("Box");
                GUILayout.Label("Element " + (i + 1) + " Item ID: ");
                auxRO[i].x = EditorGUILayout.IntField((int)auxRO[i].x, options);
                EditorGUILayout.EndHorizontal();

                if (db.FindMaterial(auxRO[i].x.ToString()) != null)
                {
                    shouldDisable = false;
                }
                else
                {
                    shouldDisable = true;
                }

                EditorGUI.BeginDisabledGroup(shouldDisable);
                EditorGUILayout.BeginHorizontal("Box");
                GUILayout.Label("Element " + (i + 1) + " amount needed: ");
                auxRO[i].y = EditorGUILayout.IntField((int)auxRO[i].y, options);
                EditorGUILayout.EndHorizontal();
                EditorGUI.EndDisabledGroup();


            }

        }

        if(_item.itemInfo.itemType == ItemType.Weapon)
        {
            EditorGUILayout.BeginHorizontal("Box");
            GUILayout.Label("WEAPON STATS: ");
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal("Box");
            GUILayout.Label(" Max Durability: ");
            _item.weaponStats.weaponMaxDurability = EditorGUILayout.FloatField(_item.weaponStats.weaponMaxDurability, options);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal("Box");
            GUILayout.Label("Damage: ");
            _item.weaponStats.weaponDamage = EditorGUILayout.FloatField(_item.weaponStats.weaponDamage, options);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal("Box");
            GUILayout.Label("Fire Rate: ");
            _item.weaponStats.weaponFireRate = EditorGUILayout.FloatField(_item.weaponStats.weaponFireRate, options);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal("Box");
            GUILayout.Label("Critical Hit Chance: ");
            _item.weaponStats.weaponCritHitChance = EditorGUILayout.FloatField(_item.weaponStats.weaponCritHitChance, options);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal("Box");
            GUILayout.Label("Critical Hit Damage: ");
            _item.weaponStats.weaponCritHitDamage = EditorGUILayout.FloatField(_item.weaponStats.weaponCritHitDamage, options);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal("Box");
            GUILayout.Label("Bullet Speed: ");
            _item.weaponStats.weaponBulletSpeed = EditorGUILayout.FloatField(_item.weaponStats.weaponBulletSpeed, options);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal("Box");
            GUILayout.Label("Range: ");
            _item.weaponStats.weaponRange = EditorGUILayout.FloatField(_item.weaponStats.weaponRange, options);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal("Box");
            GUILayout.Label("Impact: ");
            _item.weaponStats.weaponImpact = EditorGUILayout.FloatField(_item.weaponStats.weaponImpact, options);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal("Box");
            GUILayout.Label("WEAPON PREFABS: ");
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal("Box");
            GUILayout.Label("Weapon Prefab: ");
            _item.weaponPrefabs.weaponPrefab = (GameObject)EditorGUILayout.ObjectField(_item.weaponPrefabs.weaponPrefab, typeof(GameObject), false, options);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal("Box");
            GUILayout.Label("Projectile Prefab: ");
            _item.weaponPrefabs.weaponProjectilePrefab = (GameObject)EditorGUILayout.ObjectField(_item.weaponPrefabs.weaponProjectilePrefab, typeof(GameObject), false, options);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal("Box");
            GUILayout.Label("CRAFTING MATERIALS: ");
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal("Box");
            GUILayout.Label("Number of elements: ");
            _item.numOfReqObj = EditorGUILayout.IntField(_item.numOfReqObj, options);
            EditorGUILayout.EndHorizontal();

            _item.requiredObjs = new Vector2[_item.numOfReqObj];


            for (int i = 0; i < _item.numOfReqObj; i++)
            {
                EditorGUILayout.BeginHorizontal("Box");
                GUILayout.Label("Element " + (i + 1) + " Item ID: ");
                auxRO[i].x = EditorGUILayout.IntField((int)auxRO[i].x, options);
                EditorGUILayout.EndHorizontal();

                if (db.FindMaterial(auxRO[i].x.ToString()) != null)
                {
                    shouldDisable = false;
                }
                else
                {
                    shouldDisable = true;
                }

                EditorGUI.BeginDisabledGroup(shouldDisable);
                EditorGUILayout.BeginHorizontal("Box");
                GUILayout.Label("Element " + (i + 1) + " amount needed: ");
                auxRO[i].y = EditorGUILayout.IntField((int)auxRO[i].y, options);
                EditorGUILayout.EndHorizontal();
                EditorGUI.EndDisabledGroup();


            }
        }



        EditorGUILayout.BeginHorizontal("Box");
        GUILayout.Label("ITEM UNITY FIELDS: ");
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal("Box");
        GUILayout.Label("Drop Item Prefab: ");
        _item.itemUnityFields.itemDropPrefab = (GameObject)EditorGUILayout.ObjectField(_item.itemUnityFields.itemDropPrefab, typeof(GameObject), false, options);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal("Box");
        GUILayout.Label("Item Icon: ");
        _item.itemUnityFields.itemIcon = (Sprite)EditorGUILayout.ObjectField(_item.itemUnityFields.itemIcon, typeof(Sprite), false, options);
        EditorGUILayout.EndHorizontal();


        EditorGUILayout.EndScrollView();

        EditorGUILayout.EndVertical();
    }
}
