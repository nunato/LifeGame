using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	}

	void Update()
	{
		if( SequenceState == GameStateList.END ){
#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
#else
			Application.Quit();
#endif
		}
	}
}
