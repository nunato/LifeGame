using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carnivore : MonoBehaviour
{
	private static int Count = 0;
	private static int MaxCount = 0;

	public int MaxCarnivoreCount
	{
		get{ return MaxCount;}
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
