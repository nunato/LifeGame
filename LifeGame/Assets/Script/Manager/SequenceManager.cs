using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 ゲーム管理クラス
 */
public class SequenceManager : MonoBehaviour
{
	public enum GameStateList{
		START,		/* ゲーム開始 */
		SETUP,		/* 初期生成 */
		PLAYING,	/* ゲーム中 */
		END,		/* 終了状態 */
	}

	private GameStateList SequenceState;
	[SerializeField]private Carnivore CarnivoreObj;
	[SerializeField]private Herbivore HerbivoreObj;
	[SerializeField]private GameObject PanelObj;
	[SerializeField]private Text LifeTimeText;
	[SerializeField]private Text CarnivoreCountText;
	[SerializeField]private Text HarbivoreCountText;
	private static float GameTime = 0;

	public GameStateList GameSequenceStetas
	{
		set{ SequenceState = value;}
		get{ return SequenceState;}
	}

	void Start()
	{
		SequenceState = GameStateList.START;
	}

	void Update()
	{
		if( SequenceState == GameStateList.PLAYING ){
			GameTime += Time.deltaTime;
		}
		if( GameObject.FindWithTag("Carnivore") == null	&&
			GameObject.FindWithTag("Herbivore") == null	&&
			SequenceState == GameStateList.PLAYING		){
			SequenceState = GameStateList.END;
			PanelObj.SetActive(true);
			int ActiveTime = (int)GameTime;
			LifeTimeText.text = "生存期間: " + ActiveTime + " 秒";
			CarnivoreCountText.text = "肉食獣: " + CarnivoreObj.MaxCarnivoreCount + " 体";
			HarbivoreCountText.text = "草食獣: " + HerbivoreObj.MaxHarbivoreCount + " 体";
		}
	}
}
