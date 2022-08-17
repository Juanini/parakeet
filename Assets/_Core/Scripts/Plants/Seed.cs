using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Seed : MonoBehaviour {

	[HeaderAttribute("Seed Elements")]
	public GameObject ground;
	public GameObject flower;
	public GameObject palito;

	public Sprite squirrelSeed;
	public Sprite normalSeed;
	
	
	private bool isGroundSeed;

	public ParticleSystem clouds;

	private Transform mTransform;
	private Rigidbody2D mRigidbody;
	private Animator mAnimation;
	private SpriteRenderer mSpriteR;

	private string germinateAnim = "SeedGerminate";

	private bool canBePicked = false;

	private GameObject currentGroundSeed;

	void Awake () 
	{
		mTransform 	= GetComponent<Transform>();
		mRigidbody 	= GetComponent<Rigidbody2D>();
		mAnimation 	= GetComponent<Animator>();
		mSpriteR 	= GetComponent<SpriteRenderer>();
	}

	public void setSquirrelSeed()
	{
		
		mAnimation.enabled = false;
		mSpriteR.sprite = squirrelSeed;
		palito.SetActive(false);
	}

	public void setCurrentGroundSeed(GameObject _obj)
	{
		currentGroundSeed = _obj;
	}

	public void setGroundSeed()
	{
		isGroundSeed = true;
	}

	public void spawn(Vector2 _initPos, Vector2 _endPos)
	{
		SoundFX.Ins.Play(SoundFX.Ins.seedDrop);

		mSpriteR.enabled = true;
		transform.position = _initPos;
		mRigidbody.DOJump(_endPos,0.6f,1,1.0f).OnComplete(germinate);	
	}

	public void germinate()
	{
		if(!isGroundSeed)
			ground.SetActive(true);

		mAnimation.Play(germinateAnim);
		Invoke("showFlower",1.5f);
	}

	public void showFlower()
	{
		SoundFX.Ins.Play(SoundFX.Ins.plantAppear);

		canBePicked = true;

		clouds.gameObject.SetActive(true);
		clouds.Play();
		mSpriteR.enabled = false;
		flower.SetActive(true);

		if(Game.currentLevel == Game.LEVEL_1 &&
			Tutorial.Ins.isTutoActive)
		{
			Tutorial.Ins.initPhaseE();
		}
	}

	/// <summary>
	/// This function is called when the object becomes enabled and active.
	/// </summary>
	void OnEnable()
	{
		
	}

	/// <summary>
	/// This function is called when the behaviour becomes disabled or inactive.
	/// </summary>
	void OnDisable()
	{
		clouds.gameObject.SetActive(false);
		mAnimation.Play("SeedIdle");
		
		mSpriteR.enabled = true;
		mSpriteR.sprite = normalSeed;
		
		flower.SetActive(false);
		ground.SetActive(false);
		
		isGroundSeed = false;
		mAnimation.enabled = true;
		palito.SetActive(true);

	}

	public void pickPlant()
	{
		if(!canBePicked) { return; }
		
		canBePicked = false;
		ground.SetActive(false);
		goToCounter();
	}

	public void goToCounter()
	{
		mRigidbody.DOMove(	LevelManager.Ins.getCounterPosition(GetComponent<PlantType>().getPlantType()),
							0.6f).OnComplete(addFlowerToCounter);
	}

	public void addFlowerToCounter()
	{
		LevelManager.Ins.increaseCounter(GetComponent<PlantType>().getPlantType());
		gameObject.SetActive(false);

		if(currentGroundSeed)
			currentGroundSeed.SetActive(false);
	}
	
}
