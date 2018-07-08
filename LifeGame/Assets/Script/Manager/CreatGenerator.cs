using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 初期生成
 */
public class CreatGenerator : MonoBehaviour
{
	[SerializeField]private GameObject	Carnivore;
	[SerializeField]private GameObject	Herbivore;
	[SerializeField]private GameObject	Grass;
	private SequenceManager	SequenceMgr;
	private BoardManager	BoardMgr;
	private int			CarnivoreCount = 1;
	private int			HerbivoreCount = 4;
	private int			GrassCount = 12;

	void Start()
	{
		GameObject MngObj = GameObject.Find("GameManager");
		BoardMgr = MngObj.GetComponent<BoardManager>();
		SequenceMgr = MngObj.GetComponent<SequenceManager>();

		if( SequenceMgr.GameSequenceStetas == SequenceManager.GameStateList.SETUP ){
			CreateCreat();
			SequenceMgr.GameSequenceStetas = SequenceManager.GameStateList.PLAYING;
		}
	}

	private void CreateCreat()
	{
		for( int i = 0; i < CarnivoreCount; i++ ){
			Vector3 NewPosition;
			NewPosition.y = 0;
			NewPosition.x = Random.Range( 0.5f, BoardMgr.BoardWidth - 0.5f );
			NewPosition.z = Random.Range( 0.5f, BoardMgr.BoardHeight - 0.5f );
			Instantiate( Carnivore, NewPosition, Quaternion.identity );
		}
		for( int i = 0; i < HerbivoreCount; i++ ){
			Vector3 NewPosition;
			NewPosition.y = 0;
			NewPosition.x = Random.Range( 0.5f, BoardMgr.BoardWidth - 0.5f );
			NewPosition.z = Random.Range( 0.5f, BoardMgr.BoardHeight - 0.5f );
			Instantiate( Herbivore, NewPosition, Quaternion.identity );
		}
		for( int i = 0; i < GrassCount; i++ ){
			Vector3 NewPosition;
			NewPosition.y = 0;
			NewPosition.x = Random.Range( 0.5f, BoardMgr.BoardWidth - 0.5f );
			NewPosition.z = Random.Range( 0.5f, BoardMgr.BoardHeight - 0.5f );
			Instantiate( Grass, NewPosition, Quaternion.identity );
		}
	}
}
