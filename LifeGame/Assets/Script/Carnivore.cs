using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	private GameManager GameManagerObject;
	private CharacterController CarnivoreController;
	private int EatHerbivore = 0;

	void Start()
	{
		GameObject ManagerObject = GameObject.Find("GameManager");
		GameManagerObject = ManagerObject.GetComponent<GameManager>();

		CarnivoreController = GetComponent<CharacterController>();

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
		Move();

		LimitPosition();
	}
	/* 移動処理 */
	void Move()
	{
		Vector3 MoveDirection = new Vector3( Random.Range( -1, 2 ), 0, Random.Range( -1, 2 ) );
		MoveDirection *= MoveSpeed;
//		Debug.Log( MoveDirection );
		CarnivoreController.Move( MoveDirection * Time.deltaTime );
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
		if( other.gameObject.CompareTag("Herbivore") ){
//			Debug.Log( "Hit" );
			++EatHerbivore;
			Destroy( other.gameObject );
		}
	}
}
