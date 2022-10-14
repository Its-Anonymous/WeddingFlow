using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using JSONParser;

public class objectProperty
{
    public string prefabName;
    public Vector2 coords;   
}

public class saveData
{
    public string backgroundName;
    public List<objectProperty> objectInfo = new List<objectProperty>();
}

public class SaveLoadManager : MonoBehaviour
{
    public string fileSavePath = "/Users/Game/Desktop/";
    public GameObject spawner;

  public void saveData()
    {
        var dataToSave = new saveData();
        dataToSave.backgroundName = "";
        foreach(Transform child in spawner.transform)
        {
            var obj = new objectProperty();
            obj.prefabName = child.GetComponent<ItemScript>().itemName;
            obj.coords = child.position;
            dataToSave.objectInfo.Add(obj);
        }
        var dataToJson = JsonConvert.SerializeObject(dataToSave, Formatting.Indented);
        System.IO.File.WriteAllText(fileSavePath + "saveData.json", dataToJson);
    }

    public void loadData()
    {
        var saveFile = System.IO.File.ReadAllText(fileSavePath + "saveData.json");
        var savedData = SaveSystem.FromJson(saveFile);
        foreach(var item in savedData.ObjectInfo)
        {
            Vector2 posToInstantiate = new Vector2((float)item.Coords.X, (float)item.Coords.Y);
            GameObject obje = Instantiate(Resources.Load(item.PrefabName, typeof(GameObject)) as GameObject, spawner.transform.position, Quaternion.identity, spawner.transform);
            obje.transform.position = posToInstantiate;
        }    
    }
}
