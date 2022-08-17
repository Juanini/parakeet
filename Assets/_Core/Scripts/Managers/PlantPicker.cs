using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantPicker : MonoBehaviour {

	public static PlantPicker Instance;

	[Header("Plant Picker Button")]
	public GameObject plantPicker_btn;

	[Header("Plant Picker Panel")]
	public GameObject 	plantPicker_panel;
	public Image 		plantImg;
	public Image 		potImg;

	[Header("Plant Images")]
	public Sprite beePlantSprt;
	public Sprite birdPlantSprt;

	public Sprite potMaleImg;
	public Sprite potFemaleImg;


	//Private 
	private bool isPicking = false;

	private int currentPos 			= 0;
	private int currentPlantType 	= 1;

	private List<int> plantsList;
	
	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		Instance 	= this;
		plantsList 	= new List<int>();	
	}

	void Start () 
	{
	}

	void Update () 
	{
		
	}

	//Movement
	public void nextPlant()
	{
		currentPos++;
		if(currentPos > plantsList.Count - 1)
		{
			currentPos = 0;
		}

		setCurrentPlantType( plantsList[currentPos] );
	}

	public void prevPlant()
	{
		currentPos--;
		if(currentPos < 0)
		{
			currentPos = plantsList.Count - 1;
		}

		setCurrentPlantType( plantsList[currentPos] );
	}

	public void setCurrentPlantType(int _type)
	{
		currentPlantType = plantsList[currentPos];
		PlantDragAndDrop.Instance.setCurrentPlant(_type);
	}

	//
	public void showPlants()
	{
		isPicking = true;

		plantPicker_btn.SetActive(false);
		plantPicker_panel.SetActive(true);
	}

	public void showPickerBttn()
	{
		isPicking = false;
		
		plantPicker_btn.SetActive(true);
		plantPicker_panel.SetActive(false);
	}


}
