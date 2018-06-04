using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 ゲーム管理クラス
 */
public class GameManager : MonoBehaviour
{
	private float LimitLeft = 20;
	private float LimitTop = 11;
	private bool isGameOver = false;

	public float BoardLimitLeft
	{
		get{ return LimitLeft;}
	}

	public float BoardLimitTop
	{
		get{ return LimitTop;}
	}

	public bool SetGameOver
	{
		set{ isGameOver = value;}
	}

	void Update()
	{
		if( isGameOver == true ){
#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
#else
			Application.Quit();
#endif
		}
	}
}
