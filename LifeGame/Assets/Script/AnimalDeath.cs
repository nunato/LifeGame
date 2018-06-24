using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalDeath : MonoBehaviour
{
	public int		ObjectLifeFrame;

	private int		Frame;

	void Start()
	{
		Frame = ObjectLifeFrame;
	}

	void Update()
	{
		CheckObjectLife();
	}

	/* 自身の寿命判定 */
	private void CheckObjectLife()
	{
		if( Frame == 0 ){
			Destroy( gameObject );
		}
		else{
			Frame--;
		}
	}
}
