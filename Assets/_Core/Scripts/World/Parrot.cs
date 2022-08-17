using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parrot : MonoBehaviour {

	public static Parrot Ins;

	private Animator mAnim;

	private string talkAnim = "ParrotTalk";
	private string oneShoot = "OneShoot";

	void Awake () 
	{
		Ins = this;	
		mAnim = GetComponent<Animator>();
	}

	void Start () 
	{
		
	}
	
	void Update () 
	{
		
	}

	public void talkOneShoot()
	{
		mAnim.Play(talkAnim);
		//mAnim.SetBool(oneShoot,true);
	}
}
