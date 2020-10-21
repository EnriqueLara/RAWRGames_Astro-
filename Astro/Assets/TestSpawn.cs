using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawn : MonoBehaviour
{

    [SerializeField] int Id;
    [SerializeField] ItemDatabase2_0 itemDb;
    [SerializeField] Room room;
    [SerializeField] GameObject objectToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        itemDb.InventoryToDictionary();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("LM-" + Id.ToString());
            objectToSpawn = Instantiate(itemDb.GetItemWithKey("LM-" + Id.ToString()).itemUnityFields.itemDropPrefab);
            objectToSpawn.transform.parent = this.transform;
            room = objectToSpawn.GetComponent<Room>();
        }
    }
}
