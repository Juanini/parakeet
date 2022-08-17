using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSelectionMngr : MonoBehaviour {

	public static PlantSelectionMngr Ins;

	private GameObject mSelection;
	
	[HeaderAttribute("Selection Cursor")]
	public GameObject mCursor;

	void Awake () 
	{
		Ins = this;
	}
	
	void Update () 
	{
		if(!mSelection) 
		{ 
			mCursor.SetActive(false);
			return;
		}

		if(!SelectionManager.Ins.getCurrentSelected()) 		{ return; }
		if(!mSelection.GetComponent<Plant>().canBeSelected) { return; }

		mCursor.SetActive(true);
		
		mCursor.transform.position = 
		mSelection.GetComponent<Plant>().topCursorPos.position;
	}

	public void setSelection(GameObject _selection)
	{
		mSelection = _selection;
	}

	public GameObject getCurrentSelected()
	{
		return mSelection;
	}
}
