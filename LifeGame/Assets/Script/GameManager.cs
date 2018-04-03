using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 ゲーム管理クラス
 */
public class GameManager : MonoBehaviour
{
	public float LimitLeft = 20;
	public float LimitTop = 11;

	private float CountTime = 0;

	public float BoardLimitLeft
	{
		get{ return LimitLeft;}
	}

	public float BoardLimitTop
	{
		get{ return LimitTop;}
	}

	void Update()
	{
		CountTime += Time.deltaTime;
//		Debug.Log("Time: " + CountTime);
	}
}
