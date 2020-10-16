using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ItemDatabase2_0))]
public class ItemDatabase2_0Editor : Editor
{
    private ItemDatabase2_0 itemDb;
    private string searchString = "";
    private bool shouldSearch;

    private bool showMaterials = true;
    private bool showEquipment = true;
    private bool showWeapons = true;
    private bool showModules = true;

    private void OnEnable()
    {
        itemDb = (ItemDatabase2_0)target;
        
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if(itemDb)
        {
            

            GUIStyle labelStyle = new GUIStyle(GUI.skin.label);
            labelStyle.wordWrap = true;

            EditorGUILayout.BeginHorizontal("Box");
            GUILayout.Label("This database is the general Item Database (Weapons,Equipment and materials), it shouldnt be edited in runtime", labelStyle);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal("Box");
            GUILayout.Label("Num of Items: " + itemDb.items.Count);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal("Box");
            GUILayout.Label("Search: ");
            searchString = GUILayout.TextField(searchString);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal("Box");
            GUILayout.Label("Materials: ");
            showMaterials = EditorGUILayout.Toggle(showMaterials);
            GUILayout.Label("Equipment: ");
            showEquipment = EditorGUILayout.Toggle(showEquipment);
            GUILayout.Label("Weapons: ");
            showWeapons = EditorGUILayout.Toggle(showWeapons);
            GUILayout.Label("Modules: ");
            showModules = EditorGUILayout.Toggle(showModules);
            EditorGUILayout.EndHorizontal();


            if (GUILayout.Button("Add Item"))
            {

                AddItemWindow2_0.ShowEmptyWindow(itemDb);
            }

            if (System.String.IsNullOrEmpty(searchString))
            {
                shouldSearch = false;
            }
            else
            {
                shouldSearch = true;
            }

            foreach (Item2_0 item in itemDb.items)
            {
                if (shouldSearch)
                {
                    if (item.itemInfo.itemName.Contains(searchString) || item.itemInfo.itemId.Contains(searchString))                        
                    {
                        DisplayItem(item);
                    }
                }
                else
                {
                    if(showMaterials && item.itemInfo.itemType == ItemEnums2_0.ItemType.Material)
                    {
                        DisplayItem(item);
                    }
                    if (showEquipment && item.itemInfo.itemType == ItemEnums2_0.ItemType.Equipment)
                    {
                        DisplayItem(item);
                    }
                    if (showWeapons && item.itemInfo.itemType == ItemEnums2_0.ItemType.Weapon)
                    {
                        DisplayItem(item);
                    }
                    if (showModules && item.itemInfo.itemType == ItemEnums2_0.ItemType.LevelModule)
                    {
                        DisplayItem(item);
                    }


                }

                //if (deleteditem != null)
                //    itemDb.items.Remove(deleteditem);
            }
        }
        
    }
    private Item2_0 deleteditem;

    public void DeleteItem()
    {
        if (deleteditem != null)
            itemDb.items.Remove(deleteditem);
    }

    private void DisplayItem(Item2_0 _item)
    {
        GUIStyle labelStyle = new GUIStyle(GUI.skin.label);
        labelStyle.wordWrap = true;
        GUIStyle valueStyle = new GUIStyle(GUI.skin.label);
        valueStyle.wordWrap = true;
        valueStyle.alignment = TextAnchor.MiddleLeft;
        valueStyle.fixedWidth = 200;
        valueStyle.margin = new RectOffset(0, 120, 0, 0);

        EditorGUILayout.BeginVertical("Box");



        EditorGUILayout.BeginHorizontal("Box");
        GUILayout.Label("ID: ");
        GUILayout.Label(_item.itemInfo.itemId, valueStyle);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal("Box");
        GUILayout.Label("Name: ");
        GUILayout.Label(_item.itemInfo.itemName, valueStyle);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal("Box");
        GUILayout.Label("Description: ");
        GUILayout.Label(_item.itemInfo.itemDescription, valueStyle);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal("Box");
        GUILayout.Label("Type: ");
        GUILayout.Label(_item.itemInfo.itemType.ToString(), valueStyle);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal("Box");
        GUILayout.Label("Item Rarity: ");
        GUILayout.Label(_item.itemInfo.itemRarity.ToString(), valueStyle);
        EditorGUILayout.EndHorizontal();

        if(_item.itemInfo.itemType != ItemEnums2_0.ItemType.Material)
        {
            EditorGUILayout.BeginHorizontal("Box");
            GUILayout.Label("Show All Item Information: ");
            _item.showAllInfo = EditorGUILayout.Toggle(_item.showAllInfo);
            EditorGUILayout.EndHorizontal();
        }

        if(_item.showAllInfo)
        {
            switch(_item.itemInfo.itemType)
            {
                case ItemEnums2_0.ItemType.Material:


                    break;
                case ItemEnums2_0.ItemType.LevelModule:


                    break;
                case ItemEnums2_0.ItemType.Equipment:

                    EditorGUILayout.BeginHorizontal("Box");
                    GUILayout.Label("Equipment Type: ");
                    GUILayout.Label(_item.equipmentType.ToString(), valueStyle);
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal("Box");
                    GUILayout.Label("Level: ");
                    GUILayout.Label(_item.equipmentStats.equipmentLevel.ToString(), valueStyle);
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal("Box");
                    GUILayout.Label("Health: ");
                    GUILayout.Label(_item.equipmentStats.equipmentHealth.ToString(), valueStyle);
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal("Box");
                    GUILayout.Label("Armor: ");
                    GUILayout.Label(_item.equipmentStats.equipmentArmor.ToString(), valueStyle);
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal("Box");
                    GUILayout.Label("Oxygen Use: ");
                    GUILayout.Label(_item.equipmentStats.equipmentOxygenUse.ToString(), valueStyle);
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal("Box");
                    GUILayout.Label("Movement Speed: ");
                    GUILayout.Label(_item.equipmentStats.equipmentMovementSpeed.ToString(), valueStyle);
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal("Box");
                    GUILayout.Label("Show Crafting Materials: ");
                    _item.showCraftingMaterials = EditorGUILayout.Toggle(_item.showCraftingMaterials);
                    EditorGUILayout.EndHorizontal();

                    if (_item.showCraftingMaterials)
                    {
                        EditorGUILayout.BeginHorizontal("Box");
                        GUILayout.Label("------------------REQUIRED CRAFTING OBJECTS------------------");
                        EditorGUILayout.EndHorizontal();

                        for (int i = 0; i < _item.numOfReqObj; i++)
                        {
                            EditorGUILayout.BeginHorizontal("Box");
                            GUILayout.Label("Required Item ID: ");
                            GUILayout.Label(_item.requiredObjs[i].x.ToString() + "  (" + itemDb.FindMaterial(_item.requiredObjs[i].x.ToString()).itemInfo.itemName + ")", valueStyle);
                            EditorGUILayout.EndHorizontal();

                            EditorGUILayout.BeginHorizontal("Box");
                            GUILayout.Label("Required Item amount: ");
                            GUILayout.Label(_item.requiredObjs[i].y.ToString(), valueStyle);
                            EditorGUILayout.EndHorizontal();
                        }
                    }

                    break;

                case ItemEnums2_0.ItemType.Weapon:

                    EditorGUILayout.BeginHorizontal("Box");
                    GUILayout.Label("Level: ");
                    GUILayout.Label(_item.weaponStats.weaponLevel.ToString(), valueStyle);
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal("Box");
                    GUILayout.Label("MAx Durability: ");
                    GUILayout.Label(_item.weaponStats.weaponMaxDurability.ToString(), valueStyle);
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal("Box");
                    GUILayout.Label("Damage: ");
                    GUILayout.Label(_item.weaponStats.weaponDamage.ToString(), valueStyle);
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal("Box");
                    GUILayout.Label("Fire Rate: ");
                    GUILayout.Label(_item.weaponStats.weaponFireRate.ToString(), valueStyle);
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal("Box");
                    GUILayout.Label("Critical Hit Chance: ");
                    GUILayout.Label(_item.weaponStats.weaponCritHitChance.ToString(), valueStyle);
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal("Box");
                    GUILayout.Label("Critical Hit Damage: ");
                    GUILayout.Label(_item.weaponStats.weaponCritHitDamage.ToString(), valueStyle);
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal("Box");
                    GUILayout.Label("Bullet Speed: ");
                    GUILayout.Label(_item.weaponStats.weaponBulletSpeed.ToString(), valueStyle);
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal("Box");
                    GUILayout.Label("Range: ");
                    GUILayout.Label(_item.weaponStats.weaponRange.ToString(), valueStyle);
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal("Box");
                    GUILayout.Label("Impact: ");
                    GUILayout.Label(_item.weaponStats.weaponImpact.ToString(), valueStyle);
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal("Box");
                    GUILayout.Label("Weapon Prefab: ");
                    GUILayout.Label(_item.weaponPrefabs.weaponPrefab.ToString(), valueStyle);
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal("Box");
                    GUILayout.Label("Projectile Prefab: ");
                    GUILayout.Label(_item.weaponPrefabs.weaponProjectilePrefab.ToString(), valueStyle);
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal("Box");
                    GUILayout.Label("Show Crafting Materials: ");
                    _item.showCraftingMaterials = EditorGUILayout.Toggle(_item.showCraftingMaterials);
                    EditorGUILayout.EndHorizontal();

                    if (_item.showCraftingMaterials)
                    {
                        EditorGUILayout.BeginHorizontal("Box");
                        GUILayout.Label("------------------REQUIRED CRAFTING OBJECTS------------------");
                        EditorGUILayout.EndHorizontal();

                        for (int i = 0; i < _item.numOfReqObj; i++)
                        {
                            EditorGUILayout.BeginHorizontal("Box");
                            GUILayout.Label("Required Item ID: ");
                            GUILayout.Label(_item.requiredObjs[i].x.ToString() + "  (" + itemDb.FindMaterial(_item.requiredObjs[i].x.ToString()).itemInfo.itemName + ")", valueStyle);
                            EditorGUILayout.EndHorizontal();

                            EditorGUILayout.BeginHorizontal("Box");
                            GUILayout.Label("Required Item amount: ");
                            GUILayout.Label(_item.requiredObjs[i].y.ToString(), valueStyle);
                            EditorGUILayout.EndHorizontal();
                        }
                    }

                    break;
            }
        }

        EditorGUILayout.BeginHorizontal("Box");
        GUILayout.Label("Item Drop Prefab: ");
        if(_item.itemUnityFields.itemDropPrefab)
            GUILayout.Label(_item.itemUnityFields.itemDropPrefab.ToString(), valueStyle);
        EditorGUILayout.EndHorizontal();



        if(_item.itemUnityFields.itemIcon)
        {
            GUIStyle spriteStyle = new GUIStyle(GUI.skin.label);
            spriteStyle.fixedHeight = 100;
            spriteStyle.fixedWidth = 100;
            spriteStyle.alignment = TextAnchor.UpperLeft;
            spriteStyle.contentOffset = new Vector2(-250,20);


            EditorGUILayout.BeginHorizontal("Box");
            GUILayout.Label("Item Icon: ");
            GUILayout.Label(_item.itemUnityFields.itemIcon.texture,spriteStyle);
            EditorGUILayout.EndHorizontal();
        }


        EditorGUILayout.BeginHorizontal("Box");
        if (GUILayout.Button("Modify"))
        {
            ModifyItemWindow2_0.ShowModifyItemWindow(itemDb, _item);
        }
        if (GUILayout.Button("Delete"))
        {
            ConfirmDelete.SetDeleteItem(itemDb,_item);
            ConfirmDelete.ShowConfirmDeleteItemWindow();

            //deleteditem = _item;
            //itemDb.items.Remove(_item);
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndVertical();
    }
}
