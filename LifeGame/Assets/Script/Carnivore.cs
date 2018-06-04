using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
 肉食獣クラス

 増殖：草食獣を一定数食べることで増える
 死亡：草食獣を一定時間食べない
 */
public class Carnivore : MonoBehaviour
{
	public GameObject CarnivoreObject;
	public float MoveSpeed;
	public int FullEatHerbivore;

	private Transform Herbivore;
	private int EatHerbivore = 0;
	private NavMeshAgent nav;
	private GameManager gameMgr;

	void Start()
	{
		nav = GetComponent<NavMeshAgent>();
		GameObject HerbObj = GameObject.FindGameObjectWithTag("Herbivore");
		if( HerbObj != null ){
			Herbivore = HerbObj.transform;
		}

		gameMgr = GameObject.Find("GameManager").GetComponent<GameManager>();

		EatHerbivore = 0;
	}

	void Update()
	{
		if( EatHerbivore > FullEatHerbivore ){
			EatHerbivore = 0;
			Birth();
		}
	}
	/* 生成処理 */
	void Birth()
	{
		Instantiate( CarnivoreObject, transform.position, Quaternion.identity );
	}

	void FixedUpdate()
	{
		/* 移動処理 */
		if( Herbivore != null ){
			nav.SetDestination( Herbivore.position );
		}
		else{
			GameObject HerbObj = GameObject.FindGameObjectWithTag("Herbivore");
			if( HerbObj != null ){
				Herbivore = HerbObj.transform;
				nav.SetDestination( Herbivore.position );
			}
			/* 見つからなかったとき */
			else{
				gameMgr.SetGameOver = true;
			}
		}
	}

	void OnCollisionEnter( Collision other )
	{
		if( other.gameObject.CompareTag("Herbivore") ){
			++EatHerbivore;
			Destroy( other.gameObject );
		}
	}
}
