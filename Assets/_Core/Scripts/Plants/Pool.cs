using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour {

	[HeaderAttribute("Object to pool")]
	public GameObject mObj;
	public int totalObj;

	private List<GameObject> objList;

	void Start()
	{
		objList = new List<GameObject>();
		fillList();
	}

	private void fillList()
    {
        for (int i = 0; i < totalObj; i++)
        {
            GameObject obj;
            obj = Instantiate(mObj);

            if (obj == null) { return; }
            
            obj.SetActive(false);
            objList.Add(obj);
        }
    }

	public GameObject getPooledObj()
    {
        for (int i = 0; i < objList.Count; i++)
        {
            if (!objList[i].activeInHierarchy)
            {
                return objList[i];
            }
        }

        return null;
    }
}
