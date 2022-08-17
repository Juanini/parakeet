using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundForSeed : MonoBehaviour {

	[HeaderAttribute("Type")]
	public bool isHerrmit = false;
	public bool isSquirrel = false;

	private bool isActive = true;
	private Animal mAnimal;

	void Start () 
	{
		
	}
	
	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D _col)
	{
		if(_col.gameObject.tag == Game.TAG_ANIMAL)
		{
			mAnimal = _col.GetComponent<Animal>();

			if(mAnimal.getCurrentPollen() <= 0) { return; }

			if(!isActive) { return; }

			
			if(!mAnimal.GetComponent<Properties>().isSquirrel && !mAnimal.GetComponent<Properties>().isHermmit)
			return;

			GameObject seed;
			seed  = LevelManager.Ins.seedsPool.getPooledObj();
			seed.GetComponent<Seed>().setCurrentGroundSeed(gameObject);

			if(Game.currentCharacter == Game.TYPE_SQUIRREL)
			{
				seed.GetComponent<Seed>().setSquirrelSeed();
			}
			seed.GetComponent<Seed>().setGroundSeed();

			seed.GetComponent<PlantType>().setType(Game.currentCharacter);
			
			seed.SetActive(true);
			seed.GetComponent<Seed>().spawn(_col.transform.position,transform.position);
			
			mAnimal.removePollenBlock();

			isActive = false;
		}
	}
}
