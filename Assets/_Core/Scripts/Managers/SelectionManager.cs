using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class SelectionManager : MonoBehaviour {

	public static SelectionManager Ins; 

	private GameObject mSelection;
	private Vector2 clickDestination;

	[HeaderAttribute("Selection Cursor")]
	public GameObject mCursor;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		Ins = this;	
	}

	void Start () 
	{
		
	}
	
	void Update () 
	{
		if(LevelManager.Ins.isControlsBlocked) { return; }

		
		for (var i = 0; i < Input.touchCount; ++i) 
		{
        	if (Input.GetTouch(i).phase == TouchPhase.Ended) 
			{
            	RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position), Vector2.zero);
				identifyAction(hitInfo);
			}
    	}

		if (Input.GetMouseButtonDown (0)) 
		{
			Vector2 pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos), Vector2.zero);
			identifyAction(hitInfo);
   		}

		if(!mSelection) 
		{
			mCursor.SetActive(false); 
			return; 
		}
		else
		{
			mCursor.SetActive(true);
			mCursor.transform.position = mSelection.transform.position;
		}

		if(!mSelection.GetComponent<Animal>().canBeSelected) { return; }

		if(Game.currentLevel == Game.LEVEL_1 &&
			Tutorial.Ins.isTutoActive)
		{
			Tutorial.Ins.initPhaseGoToMaleF();
		}
		
		if (Input.GetMouseButtonUp(0)) 
		{
			if(EventSystem.current.IsPointerOverGameObject()) { return; }

			clickDestination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			onClickDirection();
        }

		for (var j = 0; j < Input.touchCount; ++j) 
		{
        	if (Input.GetTouch(j).phase == TouchPhase.Ended) 
			{
				if(EventSystem.current.IsPointerOverGameObject(Input.GetTouch(j).fingerId)) { return; }
				
				clickDestination = Camera.main.ScreenToWorldPoint(Input.GetTouch(j).position);
				onClickDirection();
			}
		}
	}

	public GameObject getCurrentSelected()
	{
		return mSelection;
	}

	public void setSelection(GameObject _selection)
	{
		mSelection = _selection;
		SoundFX.Ins.Play(SoundFX.Ins.charSel);
	}

	public void onClickDirection()
	{
		mSelection.GetComponent<AnimalMovement>().move(clickDestination);
	}

	public void identifyAction(RaycastHit2D _hitInfo)
	{
		if(!_hitInfo) { return; }
				
		// POLLINATOR
		if(_hitInfo.transform.gameObject.tag == Game.TAG_ANIMAL)
		{
			setSelection(_hitInfo.transform.gameObject);
		}
		// PLANT
		else if(_hitInfo.transform.gameObject.tag == Game.TAG_PLANT)
		{
			if(!SelectionManager.Ins.getCurrentSelected()) { return; }

			PlantSelectionMngr.Ins.setSelection(_hitInfo.transform.gameObject);
		}
		// SEED
		else if(_hitInfo.transform.gameObject.tag == Game.TAG_SEED)
		{
			_hitInfo.transform.gameObject.GetComponent<Seed>().pickPlant();
		}
		// GROUND
		else if(_hitInfo.transform.gameObject.tag == Game.TAG_GROUND)
		{
			PlantSelectionMngr.Ins.setSelection(null);
		}
	}
}
