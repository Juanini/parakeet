using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Florist : MonoBehaviour {

	public static Florist Ins;

	private Animator mAnim;

	private string talkAnim = "FloristTalk";
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
		mAnim.SetBool(oneShoot,true);
	}
}
