using System.Collections;
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
	public GameObject GrassObject;
	public int SpawnLimit = 100;

	private static int SpawnCount = 0;
	private GameManager GameManagerObject;

	void Start()
	{
		GameObject ManagerObject = GameObject.Find("GameManager");
		GameManagerObject = ManagerObject.GetComponent<GameManager>();

		StartCoroutine( Spawn() );
	}

	IEnumerator Spawn()
	{
		/* 生成時に増殖しないようにフラグ */
		bool IsStart = true;
		while(true){
			if( IsStart == false && SpawnCount < SpawnLimit ){
				Vector3 NewPosition;
				NewPosition.y = 0;
				NewPosition.x = Random.Range( -( GameManagerObject.BoardLimitLeft ), GameManagerObject.BoardLimitLeft );
				NewPosition.z = Random.Range( -( GameManagerObject.BoardLimitTop ), GameManagerObject.BoardLimitTop );

				Instantiate( GrassObject, NewPosition, Quaternion.identity );
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
