using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalDeath : MonoBehaviour
{
	public int			ObjectLifeFrame;

	private int			Frame;
	private GameObject	GrassPrefab;

	void Start()
	{
		Frame = ObjectLifeFrame;

		GrassPrefab = (GameObject)Resources.Load("Prefabs/Grass");
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
			Instantiate( GrassPrefab, transform.position, Quaternion.identity );
		}
		else{
			Frame--;
		}
	}
}
