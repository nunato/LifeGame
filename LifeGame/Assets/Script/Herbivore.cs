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
	private GameManager GameManagerObject;
	private int EatGrass = 0;
	private NavMeshAgent nav;

	void Start()
	{
		GameObject ManagerObject = GameObject.Find("GameManager");
		GameManagerObject = ManagerObject.GetComponent<GameManager>();

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

		LimitPosition();
	}

	/* 座標の調整 */
	void LimitPosition()
	{
		/* RigitBodyがないのでy座標を固定できないので */
		if( transform.position.y != 0 ){
			transform.position = new Vector3( transform.position.x, 0, transform.position.z );
		}

		if( transform.position.x > GameManagerObject.BoardLimitLeft ){
			transform.position = new Vector3( GameManagerObject.BoardLimitLeft, 0, transform.position.z );
		}
		else if( transform.position.x < -GameManagerObject.BoardLimitLeft ){
			transform.position = new Vector3( -GameManagerObject.BoardLimitLeft, 0, transform.position.z );
		}
		if( transform.position.z > GameManagerObject.BoardLimitTop ){
			transform.position = new Vector3( transform.position.x, 0, GameManagerObject.BoardLimitTop );
		}
		else if( transform.position.z < -GameManagerObject.BoardLimitTop ){
			transform.position = new Vector3( transform.position.x, 0, -GameManagerObject.BoardLimitTop );
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
