using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using ItemEnums2_0;

public class ModifyItemWindow2_0 : EditorWindow
{
    private static ItemDatabase2_0 db;
    private static EditorWindow window;
    private static Item2_0 newItem;
    private static Item2_0 modifiedItem;

    private bool shouldEditId;
    private bool shouldEditCRO;
    private bool shouldDisableConfirmIdButton;

    private GUILayoutOption[] options = { GUILayout.MaxWidth(150.0f), GUILayout.MinWidth(325.0f) };
    private Vector2 scrollPos;
    private Vector2 descScrollPos;
    private bool shouldDisable;

    private static Vector2[] auxRo = new Vector2[10];
    private static string auxID = "";

    private int numRCO;

    public static void ShowModifyItemWindow(ItemDatabase2_0 _db, Item2_0 _item)
    {
        db = _db;
        window = GetWindow<ModifyItemWindow2_0>();
        window.maxSize = new Vector2(500, 600);
        window.minSize = new Vector2(500, 600);

        modifiedItem = _item;

        newItem = new Item2_0();
        newItem.itemInfo = _item.itemInfo;
        newItem.itemUnityFields = _item.itemUnityFields;
        newItem.equipmentType = _item.equipmentType;
        newItem.equipmentStats = _item.equipmentStats;
        newItem.equipmentPrefab = _item.equipmentPrefab;
        newItem.weaponStats = _item.weaponStats;
        newItem.weaponPrefabs = _item.weaponPrefabs;
        newItem.numOfReqObj = _item.numOfReqObj;

        auxID = _item.itemInfo.itemId;
        auxID = auxID.Substring(2);
        auxRo = new Vector2[10];
        for (int i = 0; i < _item.numOfReqObj; i++)
        {
            auxRo[i].x = _item.requiredObjs[i].x;
            auxRo[i].y = _item.requiredObjs[i].y;
        }
    }

    public void OnGUI()
    {
        DisplayNewItem(newItem);


        if (GUILayout.Button("Confirm"))
        {
            ModifyItem();
        }

        EditorGUI.EndDisabledGroup();
    }

    private void ModifyItem()
    {
        Undo.RecordObject(db, "Item Modified");
        modifiedItem.itemInfo = newItem.itemInfo;
        modifiedItem.itemUnityFields = newItem.itemUnityFields;
        modifiedItem.equipmentType = newItem.equipmentType;
        modifiedItem.equipmentStats = newItem.equipmentStats;
        modifiedItem.equipmentPrefab = newItem.equipmentPrefab;
        modifiedItem.weaponStats = newItem.weaponStats;
        modifiedItem.weaponPrefabs = newItem.weaponPrefabs;
        modifiedItem.numOfReqObj = newItem.numOfReqObj;
        modifiedItem.requiredObjs = new Vector2[newItem.numOfReqObj];
        modifiedItem.requiredObjs = auxRo;

        

        EditorUtility.SetDirty(db);
        window.Close();
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

        
        //Edit Id button
        if(shouldEditId)
        {
            if (_item.itemInfo.itemType == ItemEnums2_0.ItemType.Material)
            {
                EditorGUILayout.BeginHorizontal("Box");
                GUILayout.Label("ID: ");
                GUILayout.Label("M-");
                auxID = EditorGUILayout.TextField(auxID, options);

                if("M-" + auxID  != _item.itemInfo.itemId)
                {
                    //Search in database for an item with same id
                    if(db.FindMaterial(auxID) != null || System.String.IsNullOrEmpty(auxID))
                    {
                        //item with same ID founded
                        shouldDisableConfirmIdButton = true;
                    }
                    else
                    {
                        shouldDisableConfirmIdButton = false;
                    }
                }
                else
                {
                    shouldDisableConfirmIdButton = false;
                }
                
            }
            if (_item.itemInfo.itemType == ItemEnums2_0.ItemType.Weapon)
            {
                EditorGUILayout.BeginHorizontal("Box");
                GUILayout.Label("ID: ");
                GUILayout.Label("W-");
                auxID = EditorGUILayout.TextField(auxID, options);

                if ("W-" + auxID != _item.itemInfo.itemId)
                {
                    //Search in database for an item with same id
                    if (db.FindMaterial(auxID) != null || System.String.IsNullOrEmpty(auxID))
                    {
                        //item with same ID founded
                        shouldDisableConfirmIdButton = true;
                    }
                    else
                    {
                        shouldDisableConfirmIdButton = false;
                    }
                }
                else
                {
                    shouldDisableConfirmIdButton = false;
                }
                
            }
            if (_item.itemInfo.itemType == ItemEnums2_0.ItemType.Equipment)
            {
                EditorGUILayout.BeginHorizontal("Box");
                GUILayout.Label("ID: ");
                GUILayout.Label("E-");
                auxID = EditorGUILayout.TextField(auxID, options);

                if ("E-" + auxID != _item.itemInfo.itemId)
                {
                    //Search in database for an item with same id
                    if (db.FindMaterial(auxID) != null || System.String.IsNullOrEmpty(auxID))
                    {
                        //item with same ID founded
                        shouldDisableConfirmIdButton = true;
                    }
                    else
                    {
                        shouldDisableConfirmIdButton = false;
                    }
                }
                else
                {
                    shouldDisableConfirmIdButton = false;
                }

            }
            
            EditorGUI.BeginDisabledGroup(shouldDisableConfirmIdButton);

            if (GUILayout.Button("Confirm"))
                {
                    shouldEditId = false;
                }

                EditorGUI.EndDisabledGroup();

                //EditorGUILayout.EndHorizontal();
        }
        else
        {
            if (_item.itemInfo.itemType == ItemType.Material)
            {
                EditorGUILayout.BeginHorizontal("Box");
                GUILayout.Label("ID: ");
                GUILayout.Label("M-" + auxID, options);
                //_item.itemInfo.itemId = EditorGUILayout.TextField(_item.itemInfo.itemId, options);
            }
            if (_item.itemInfo.itemType == ItemType.Weapon)
            {
                EditorGUILayout.BeginHorizontal("Box");
                GUILayout.Label("ID: ");
                GUILayout.Label("W-" + auxID, options);
                //_item.itemInfo.itemId = EditorGUILayout.TextField(_item.itemInfo.itemId, options);
            }
            if (_item.itemInfo.itemType == ItemEnums2_0.ItemType.Equipment)
            {
                EditorGUILayout.BeginHorizontal("Box");
                GUILayout.Label("ID: ");
                GUILayout.Label("E-" + auxID, options);
                //_item.itemInfo.itemId = EditorGUILayout.TextField(_item.itemInfo.itemId, options);
            }


            if (GUILayout.Button("Modify ID"))
            {
                shouldEditId = true;
            }
        }

        EditorGUILayout.EndHorizontal();


        EditorGUILayout.BeginHorizontal("Box");
        GUILayout.Label("ITEM INFORMATION: ");
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal("Box");
        GUILayout.Label("Name: ");
        _item.itemInfo.itemName = EditorGUILayout.TextField(_item.itemInfo.itemName, options);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal("Box");
        GUILayout.Label("Type: ");
        GUILayout.Label(_item.itemInfo.itemType.ToString(), options);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal("Box");
        GUILayout.Label("Description: ");
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal("Box");
        descScrollPos = EditorGUILayout.BeginScrollView(descScrollPos, GUILayout.MinHeight(3), GUILayout.MaxHeight(100));
        _item.itemInfo.itemDescription = EditorGUILayout.TextArea(_item.itemInfo.itemDescription, textAreaStyle, GUILayout.MinHeight(200));
        EditorGUILayout.EndScrollView();
        EditorGUILayout.EndHorizontal();
        

        EditorGUILayout.BeginHorizontal("Box");
        _item.itemInfo.itemRarity = (ItemRarity)EditorGUILayout.EnumPopup("Item Rarity", _item.itemInfo.itemRarity, options);
        EditorGUILayout.EndHorizontal();

        //display Weaponinformation
        if(_item.itemInfo.itemType == ItemEnums2_0.ItemType.Weapon)
        {
            EditorGUILayout.BeginHorizontal("Box");
            GUILayout.Label("WEAPON STATS: ");
            EditorGUILayout.EndHorizontal();
            

            EditorGUILayout.BeginHorizontal("Box");
            GUILayout.Label("Max durability: ");
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
        }
        if(_item.itemInfo.itemType == ItemEnums2_0.ItemType.Equipment)
        {
            EditorGUILayout.BeginHorizontal("Box");
            _item.equipmentType = (EquipmentStructs.EquipmentType)EditorGUILayout.EnumPopup("Equipment Type", _item.equipmentType, options);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal("Box");
            GUILayout.Label("EQUIPMENT STATS: ");
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
            GUILayout.Label("Oxygen Use: ");
            _item.equipmentStats.equipmentOxygenUse = EditorGUILayout.FloatField(_item.equipmentStats.equipmentOxygenUse, options);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal("Box");
            GUILayout.Label("Movement Speed: ");
            _item.equipmentStats.equipmentMovementSpeed = EditorGUILayout.FloatField(_item.equipmentStats.equipmentMovementSpeed, options);
            EditorGUILayout.EndHorizontal();
        }

        //Crafting materials

        if (_item.itemInfo.itemType != ItemType.Material)
        {
            _item.requiredObjs = new Vector2[10];
            

            //change quantity of RCO
            EditorGUILayout.BeginHorizontal("Box");
                

            if(!shouldEditCRO)
            {
                GUILayout.Label("Required crafting materials: " + _item.numOfReqObj);
                if (GUILayout.Button("Edit RCO"))
                {
                    shouldEditCRO = true;
                }
            }
            else
            {
                GUILayout.Label("Required crafting materials: ");
                _item.numOfReqObj = EditorGUILayout.IntField(_item.numOfReqObj);

                if (GUILayout.Button("Confirm RCO"))
                {
                    shouldEditCRO = false;
                }
            }

            
                EditorGUILayout.EndHorizontal();



            for (int i = 0; i < _item.numOfReqObj; i++)
            {
                

                EditorGUILayout.BeginHorizontal("Box");
                GUILayout.Label("Element" + 1 + ":");
                EditorGUILayout.EndHorizontal();

                //1.0
                EditorGUILayout.BeginHorizontal("Box");
                GUILayout.Label((i + 1) + " Item ID: ");

                auxRo[i].x = EditorGUILayout.IntField((int)auxRo[i].x, options);
                EditorGUILayout.EndHorizontal();

                if (db.FindMaterial(auxRo[i].x.ToString()) != null)
                {
                    shouldDisable = false;
                }
                else
                {
                    shouldDisable = true;
                }

                EditorGUI.BeginDisabledGroup(shouldDisable);
                EditorGUILayout.BeginHorizontal("Box");
                GUILayout.Label((i + 1) + " amount needed: ");
                auxRo[i].y = EditorGUILayout.IntField((int)auxRo[i].y, options);
                EditorGUILayout.EndHorizontal();

                EditorGUI.EndDisabledGroup();



            }



        }

        //unity fields

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

        //EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndScrollView();
        EditorGUILayout.EndVertical();

    }





}
