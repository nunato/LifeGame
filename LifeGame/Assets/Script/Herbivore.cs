using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	private GameManager GameManagerObject;
	private CharacterController HerbivoreController;
	private int EatGrass = 0;

	void Start()
	{
		GameObject ManagerObject = GameObject.Find("GameManager");
		GameManagerObject = ManagerObject.GetComponent<GameManager>();

		HerbivoreController = GetComponent<CharacterController>();

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
		Move();

		LimitPosition();
	}

	/* 移動処理 */
	void Move()
	{
		Vector3 MoveDirection = new Vector3( Random.Range( -1, 2 ), 0, Random.Range( -1, 2 ) );
		MoveDirection *= MoveSpeed;
//		Debug.Log( MoveDirection );
		HerbivoreController.Move( MoveDirection * Time.deltaTime );
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

	void OnControllerColliderHit( ControllerColliderHit other )
	{
		if( other.gameObject.CompareTag("Grass") ){
//			Debug.Log( "Hit" );
			++EatGrass;
			Destroy( other.gameObject );
		}
	}
}
