using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

	public static DialogManager Ins;

	public GameObject panel;
	public Text title;
	public Text desc;

	void Awake () 
	{
		Ins = this;
	}

	void Start () 
	{
		
	}

	public void showDialog(string _title,string _text)
	{
		panel.SetActive(true);
		title.text 	= _title;
		desc.text 	= _text;
	}

	public void hideDialog()
	{
		panel.SetActive(false);
		title.text 	= "";
		desc.text 	= "";
	}
}
