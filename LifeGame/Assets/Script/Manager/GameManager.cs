using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 ゲーム管理クラス
 */
public class GameManager : MonoBehaviour
{
	public enum GameStateList{
		SETUP,		/* 初期生成 */
		PLAYING,	/* ゲーム中 */
		END,		/* 終了状態 */
	}

	private float GameBoardWidth = 40;
	private float GameBoardHeight = 22;

	private GameStateList SequenceState;
	[SerializeField]private GameObject PanelObj;
	[SerializeField]private GameObject TextObj;
	private float GameTime;

	public float BoardWidth
	{
		get{ return GameBoardWidth;}
	}

	public float BoardHeight
	{
		get{ return GameBoardHeight;}
	}

	public GameStateList GameSequenceStetas
	{
		set{ SequenceState = value;}
		get{ return SequenceState;}
	}

	void Start()
	{
		SequenceState = GameStateList.SETUP;
		GameTime = 0;
	}

	void Update()
	{
		GameTime += Time.deltaTime;
		if( GameObject.FindWithTag("Carnivore") == null	&&
			GameObject.FindWithTag("Herbivore") == null	&&
			SequenceState != GameStateList.END			){
			SequenceState = GameStateList.END;
			PanelObj.SetActive(true);
			TextObj.SetActive(true);
			Text targetText = TextObj.GetComponent<Text>();
			int ActiveTime = (int)GameTime;
			targetText.text = "生存期間: " + ActiveTime + "秒";
		}
	}
}
