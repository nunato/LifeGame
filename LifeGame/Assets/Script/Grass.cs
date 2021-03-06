﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 草クラス

 増殖：タイマーでランダムなところに生成
 死亡：草食獣に食べられる
 */
public class Grass : MonoBehaviour
{
	public float SpawnTimeSec = 100;
	public int SpawnLimit = 100;

	private static int SpawnCount = 0;
	private BoardManager BoardMgr;
	private SequenceManager SequenceMgr;

	void Start()
	{
		GameObject ManagerObject = GameObject.Find("GameManager");
		BoardMgr = ManagerObject.GetComponent<BoardManager>();
		SequenceMgr = ManagerObject.GetComponent<SequenceManager>();

		StartCoroutine( Spawn() );
	}

	IEnumerator Spawn()
	{
		/* 生成時に増殖しないようにフラグ */
		bool IsStart = true;
		while(true){
			if( IsStart == false &&
				SpawnCount < SpawnLimit &&
				SequenceMgr.GameSequenceStetas != SequenceManager.GameStateList.END ){
				Vector3 NewPosition;
				NewPosition.y = 0;
				NewPosition.x = Random.Range( 0.5f, BoardMgr.BoardWidth - 0.5f );
				NewPosition.z = Random.Range( 0.5f, BoardMgr.BoardHeight - 0.5f );

				Instantiate( gameObject, NewPosition, Quaternion.identity );
				++SpawnCount;
			}
			IsStart = false;
			yield return new WaitForSeconds( SpawnTimeSec );
		}
	}

	void OnDestroy()
	{
		--SpawnCount;
	}
}
