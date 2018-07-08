using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herbivore : MonoBehaviour
{
	private static int Count = 0;
	private static int MaxCount = 0;

	public int MaxHarbivoreCount
	{
		get{ return MaxCount;}
	}

	public int CarnivoreCount
	{
		get{ return Count;}
	}

	void Start()
	{
		Count++;

		if( MaxCount < Count ){
			MaxCount = Count;
		}
	}

	void OnDestroy()
	{
		Count--;
	}
}
