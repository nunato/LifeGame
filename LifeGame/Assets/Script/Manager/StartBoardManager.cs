using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBoardManager : MonoBehaviour
{
	private SequenceManager	SequenceMgr;

	void Start()
	{
		GameObject MngObj = GameObject.Find("GameManager");
		SequenceMgr = MngObj.GetComponent<SequenceManager>();
	}

	public void OnClickStart()
	{
		SequenceMgr.GameSequenceStetas = SequenceManager.GameStateList.SETUP;
		gameObject.SetActive(false);
	}
}
