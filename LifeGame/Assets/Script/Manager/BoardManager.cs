using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
	private float GameBoardWidth = 40;
	private float GameBoardHeight = 22;

	public float BoardWidth
	{
		get{ return GameBoardWidth;}
	}

	public float BoardHeight
	{
		get{ return GameBoardHeight;}
	}
}
