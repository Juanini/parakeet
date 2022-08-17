using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimalMovement : MonoBehaviour {

	private Transform 	mTransform;
	private Rigidbody2D mRigidBody;
	private SpriteRenderer mSpriteR;
	private Animal mAnimal;
	private Animator mAnimator;

	private Vector2 destinationPos;
	private Vector3[] path;

	private bool isMoving = false;

	void Start () 
	{
		mTransform 	= GetComponent<Transform>();
		mRigidBody 	= GetComponent<Rigidbody2D>();
		mSpriteR 	= GetComponent<SpriteRenderer>();
		mAnimal 	= GetComponent<Animal>();
		mAnimator 	= GetComponent<Animator>();
	}
	
	void Update () 
	{
		checkFacing();
	}

	public void checkFacing()
	{
		if(destinationPos.x > mTransform.position.x)
		{
			mSpriteR.flipX = true;
		}
		else
		{
			mSpriteR.flipX = false;
		}

		if(mAnimal.isSquirrel)
		if(isMoving)
		{
			if(mAnimal.isSquirrel) { mAnimator.Play("SquirrelWalk"); }
		}
		else
		{
			if(mAnimal.isSquirrel) { mAnimator.Play("SquirrelIdle"); }
		}
	}

	public void spawn()
	{
		mTransform.position = LevelManager.Ins.pollinatorsSpawnPos.position;
	}

	public void setDestinationPos(Vector2 _pos)
	{
		destinationPos = _pos;
	}

	public void move(Vector2 _pos)
	{
		setDestinationPos(_pos);
		isMoving = !mRigidBody.DOMove(_pos,1).SetEase(Ease.Linear).IsComplete();
	}

	public void moveOnFailMatch(Vector2 _pos)
	{
		isMoving = !mRigidBody.DOMove(_pos,1f).SetEase(Ease.Linear).OnComplete(moveAwayRandom).IsComplete();
	}

	public void moveAwayRandom()
	{
		SoundFX.Ins.Play(SoundFX.Ins.matchFailSnd);
		mAnimal.showFailExpression();
		Vector2 pos;
		pos =  (Random.insideUnitCircle * 3.0f) + new Vector2(mTransform.position.x,mTransform.position.y);
		setDestinationPos(pos);
		isMoving = !mRigidBody.DOMove(pos,2).SetEase(Ease.Linear).IsComplete();
	}

	//Path Movement

	public void moveOnPath(Vector3[] _path)
	{
		path = _path;
		mTransform.DOPath(_path,2,PathType.Linear,PathMode.Sidescroller2D)
		.OnWaypointChange(waypointChange)
		.OnComplete(pathCompleted);
	}

	public void waypointChange(int _index)
	{
		setDestinationPos(path[_index]);
	}

	public void pathCompleted()
	{
		mAnimal.onPathComplete();
	}

	
}
