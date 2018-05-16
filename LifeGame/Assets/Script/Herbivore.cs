using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
 草食獣クラス

 増殖：草を一定数食べることで増える
 死亡：草を一定時間食べない、または肉食獣に食べられる
 */
public class Herbivore : MonoBehaviour
{
	public GameObject HerbivoreObject;
	public float MoveSpeed;
	public int FullEatGrass;

	private Transform Grass;
	private int EatGrass = 0;
	private NavMeshAgent nav;

	void Start()
	{
		nav = GetComponent<NavMeshAgent>();
		Grass = GameObject.FindGameObjectWithTag( "Grass" ).transform;

		EatGrass = 0;
	}

	void Update()
	{
		if( EatGrass > FullEatGrass ){
			EatGrass = 0;
			Birth();
		}
	}
	/* 生成処理 */
	void Birth()
	{
		Instantiate( HerbivoreObject, transform.position, Quaternion.identity );
	}

	void FixedUpdate()
	{
		/* 移動処理 */
		if( Grass != null ){
			nav.SetDestination( Grass.position );
		}
		else{
			Grass = GameObject.FindGameObjectWithTag( "Grass" ).transform;
			nav.SetDestination( Grass.position );
		}
	}

	void OnCollisionEnter( Collision other )
	{
		if( other.gameObject.CompareTag("Grass") ){
//			Debug.Log( "Hit" );
			++EatGrass;
			Destroy( other.gameObject );
		}
	}
}
