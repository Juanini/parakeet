using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalRef : MonoBehaviour {

	public static AnimalRef Ins;

	[HeaderAttribute("")]
	public Animal Bee;
	public Animal Humming;
	public Animal Fly;
	public Animal Bat;
	public Animal Hermit;
	public Animal Squirrel;
	public Animal Wind;

	void Awake () 
	{
		Ins = this;
	}
	
	void Update () 
	{
		
	}

	public void spawnPollinator()
	{
		switch(Game.currentCharacter)
		{
			case Game.TYPE_BEE:
			Bee.spawn();
			break;

			case Game.TYPE_HUMMING:
			Humming.spawn();
			break;

			case Game.TYPE_FLY:
			Fly.spawn();
			break;

			case Game.TYPE_BAT:
			Bat.spawn();
			break;

			case Game.TYPE_HERMIT:
			Hermit.spawn();
			break;

			case Game.TYPE_SQUIRREL:
			Squirrel.spawn();
			break;

			case Game.TYPE_WIND:
			Wind.spawn();
			break;
		}
	}
	
}
