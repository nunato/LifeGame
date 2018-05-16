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

	void Start()
	{
		nav = GetComponent<NavMeshAgent>();
		Herbivore = GameObject.FindGameObjectWithTag( "Herbivore" ).transform;

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
			Herbivore = GameObject.FindGameObjectWithTag( "Herbivore" ).transform;
			nav.SetDestination( Herbivore.position );
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
