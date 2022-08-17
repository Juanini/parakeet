using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Plant : MonoBehaviour {

	[HeaderAttribute("Gender")]
	public bool isMale;
	public bool isFemale;
	public bool isMaleAndFemale;
 
	[HeaderAttribute("Particles")]
	public ParticleSystem pollenParticles;
	public ParticleSystem heartParticles;

	[HeaderAttribute("Positions")]
	public Transform topCursorPos;
	public Transform pistilPos;
	public Transform seedPos_1;
	public Transform seedPos_2;

	[HeaderAttribute("Pot Sprites")]
	public Sprite malePot;
	public Sprite femalePot;
	public Sprite bothPot;

	[HeaderAttribute("Flower parts")]
	public SpriteRenderer flowerSprt;
	public SpriteRenderer potSprt;

	public Transform[] waypoints;

	private bool hasPollen = false;
	public bool canBeSelected = true;

	[HeaderAttribute("Plant Icons List ")]
	public SpriteRenderer colorIconSprt;
	public SpriteRenderer nectarIconSprt;
	public SpriteRenderer odorIconSprt;
	public SpriteRenderer shapeIconSprt;

	[HeaderAttribute("Color Sprites")]
	public GameObject iconsObj;
	public Sprite colorYellow;
	public Sprite colorRed;
	public Sprite colorLight;
	public Sprite colorDark;

	[HeaderAttribute("Nectar Sprites")]
	public Sprite nectarPresent;
	public Sprite nectarHidden;
	public Sprite nectarAbundant_Hidden;
	public Sprite nectarNone;

	[HeaderAttribute("Odor Sprites")]
	public Sprite odorFresh;
	public Sprite odorNone;
	public Sprite odorFruitsy;
	public Sprite odorPutrid;

	[HeaderAttribute("Shape Sprites")]
	public Sprite shapeLanding;
	public Sprite shapeTubular;
	public Sprite shapeBowl;
	public Sprite shapeTraplike;

	private Transform mTransform; 

	void Awake()
	{
		setUpFlower();
		mTransform = GetComponent<Transform>();
	}

	public void onMatchSucces()
	{
		Invoke("activateHeartParticles",0.6f);
	}

	public void activateHeartParticles()
	{
		heartParticles.gameObject.SetActive(true);
		heartParticles.Play();
		SoundFX.Ins.Play(SoundFX.Ins.matchSuccessSnd);
	}

	public Vector3[] getAroundPath()
	{
		Vector3[] path;
		path = new Vector3[waypoints.Length];

		for(int i = 0; i < waypoints.Length; i++ )
		{
			path[i] = waypoints[i].position;
		}

		return path;
	}

	//Set
	public void setUpFlower()
	{
		if(GetComponent<Properties>().isHermmit || GetComponent<Properties>().isSquirrel) 
		{
			pollenParticles.gameObject.SetActive(false);
			potSprt.gameObject.SetActive(false);
			return;
		}

		if(isFemale)
		{
			pollenParticles.gameObject.SetActive(false);
			potSprt.sprite = femalePot;
		}
		else if(isMale)
		{
			pollenParticles.gameObject.SetActive(true);
			potSprt.sprite = malePot;
			
		}
		else if(isMaleAndFemale)
		{
			pollenParticles.gameObject.SetActive(true);
			potSprt.sprite = bothPot;			
		}
	}

	//Pollination
	public void pollinate()
	{
		if(isMale || isFemale)
			SelectionManager.Ins.setSelection(null);
		
		dissmissPlant();

		GameObject seed;
		seed  = LevelManager.Ins.seedsPool.getPooledObj();
		seed.GetComponent<PlantType>().setType(GetComponent<PlantType>().getPlantType());
		seed.SetActive(true);
		seed.GetComponent<Seed>().spawn(pistilPos.position,seedPos_1.position);

		GameObject seed2;
		seed2  = LevelManager.Ins.seedsPool.getPooledObj();
		seed2.GetComponent<PlantType>().setType(GetComponent<PlantType>().getPlantType());
		seed2.SetActive(true);
		seed2.GetComponent<Seed>().spawn(pistilPos.position,seedPos_2.position);
	}

	public void dissmissPlant()
	{
		canBeSelected = false;
		mTransform.DOScale(new Vector3(0.1f,0.1f,0.1f),1.5f).SetEase(Ease.InQuint)
		.OnComplete(onCompleteDissmiss);

		if(PlantSelectionMngr.Ins.getCurrentSelected() == gameObject)
		{
			PlantSelectionMngr.Ins.setSelection(null);
		}
	}

	public void onCompleteDissmiss()
	{
		gameObject.SetActive(false);
	}

	public void turnOnPlantIcons()
	{
		if(isFemale) { return; }
		if(isMaleAndFemale) { return; }
		if(GetComponent<Properties>().isHermmit || GetComponent<Properties>().isSquirrel) { return; }
		
		iconsObj.SetActive(true);
	}

	public void turnOffPlantIcons()
	{
		if(isFemale) { return; }
		iconsObj.SetActive(false);
	}

	public void setUpIcons()
	{
		switch(GetComponent<PlantType>().getPlantType())
		{
			case Game.TYPE_BEE:
			colorIconSprt.sprite 	= colorYellow;
			nectarIconSprt.sprite 	= nectarPresent;
			odorIconSprt.sprite 	= odorFresh;
			shapeIconSprt.sprite 	= shapeLanding;
			break;

			case Game.TYPE_HUMMING:

			colorIconSprt.sprite 	= colorRed;
			nectarIconSprt.sprite 	= nectarHidden;
			odorIconSprt.sprite 		= odorNone;
			shapeIconSprt.sprite 	= shapeTubular;
			break;

			case Game.TYPE_FLY:

			colorIconSprt.sprite 	= colorDark;
			nectarIconSprt.sprite 	= nectarNone;
			odorIconSprt.sprite 		= odorPutrid;
			shapeIconSprt.sprite 	= shapeTraplike;
			break;

			case Game.TYPE_BAT:

			colorIconSprt.sprite 	= colorLight;
			nectarIconSprt.sprite 	= nectarAbundant_Hidden;
			odorIconSprt.sprite 		= odorFruitsy;
			shapeIconSprt.sprite 	= shapeBowl;
			break;

			case Game.TYPE_HERMIT:
			
			break;

			case Game.TYPE_SQUIRREL:
			
			break;

			case Game.TYPE_WIND:
			
			colorIconSprt.sprite 	= colorYellow;
			nectarIconSprt.sprite 	= nectarPresent;
			odorIconSprt.sprite 		= odorFresh;
			shapeIconSprt.sprite 	= shapeLanding;
			break;
		}
	}
}
