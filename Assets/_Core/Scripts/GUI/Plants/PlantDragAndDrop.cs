using UnityEngine;

public class PlantDragAndDrop : MonoBehaviour {

	public static PlantDragAndDrop Instance;

	public GameObject plantBeeMale;
	public GameObject plantBeeFemale;
	public GameObject plantBirdMale;
	public GameObject plantBirdFemale;

	private GameObject currentPlant;
	
	private Vector2 mousePosition;
	
	private bool isDragging = false;


	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		Instance = this;
	}

	void Start () 
	{
	}
	
	void Update () 
	{
		if (isDragging) 
		{
			mousePosition = Input.mousePosition;
			mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
			currentPlant.transform.position = mousePosition;	
		}
	}

	public void onDragPlant(){
		currentPlant.SetActive (true);
		isDragging = true;
	}

	public void onDropPlant(){
		if (isDragging) {
			isDragging = false;
		}
	}

	public void setCurrentPlant(int _type)
	{	

	}
}
