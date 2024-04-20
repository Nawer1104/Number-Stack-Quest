using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public List<GameObject> gameObjects;

    public List<Block> GetAListOfBlocksWithUniqueId(int id)
    {
        List<Block> blockList = new List<Block>();

        foreach(GameObject obj in gameObjects)
        {
            if (obj.GetComponent<Block>().uniqueId == id)
            {
                blockList.Add(obj.GetComponent<Block>());
            }
        }

        return blockList;
    }


    public static List<GameObject> GetAllChilds(GameObject Go)
    {
        List<GameObject> list = new List<GameObject>();
        for (int i = 0; i < Go.transform.childCount; i++)
        {
            list.Add(Go.transform.GetChild(i).gameObject);
        }
        return list;
    }
}
