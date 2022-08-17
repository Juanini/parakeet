using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

	private List<Plant> levelPlantsList;

	public void getLevelPlants()
	{
		levelPlantsList = new List<Plant>();
		
		int children = transform.childCount;
		for (int i = 0; i < children; ++i)
		{
			if(transform.GetChild(i).GetComponent<Plant>())
				levelPlantsList.Add(transform.GetChild(i).GetComponent<Plant>());
		}
	}

	public void turnOnPlantIcons()
	{
		for(int i = 0 ; i < levelPlantsList.Count ; i++)
		{
			levelPlantsList[i].turnOnPlantIcons();
		}
	}

	public void turnOffPlantIcons()
	{
		for(int i = 0 ; i < levelPlantsList.Count ; i++)
		{
			levelPlantsList[i].turnOffPlantIcons();
		}
	}
}
