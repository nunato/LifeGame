using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartBoardManager : MonoBehaviour
{
	private SequenceManager	SequenceMgr;
	[SerializeField]private Text GrassText;
	[SerializeField]private Text CarnivoreText;
	[SerializeField]private Text HerbivoreText;
	[SerializeField]private Slider			CarnivoreCountSlider;
	[SerializeField]private Slider			HerbivoreCountSlider;
	[SerializeField]private Slider			GrassCountSlider;

	void Start()
	{
		GameObject MngObj = GameObject.Find("GameManager");
		SequenceMgr = MngObj.GetComponent<SequenceManager>();
	}

	void Update()
	{
		GrassText.text = "草: " + GrassCountSlider.value;
		CarnivoreText.text = "肉食獣: " + CarnivoreCountSlider.value;
		HerbivoreText.text = "草食獣: " + HerbivoreCountSlider.value;
	}

	public void OnClickStart()
	{
		SequenceMgr.GameSequenceStetas = SequenceManager.GameStateList.SETUP;
		gameObject.SetActive(false);
	}
}
