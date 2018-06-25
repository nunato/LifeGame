using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalMovement : MonoBehaviour
{
	public float			MoveSpeed = 5;

	private NavMeshAgent	TargetNav;
	private GameObject[]	TargetObjects;
	private GameObject		NearTargetObject;
	private string			TargetTag;

	void Start()
	{
		TargetNav = GetComponent<NavMeshAgent>();
		TargetNav.speed = MoveSpeed;
		/* 近いターゲットを探す */
		TargetTag = AnimalUtil.GetTargetTag( gameObject.tag );
		SearchNearTarget();
	}

	void Update()
	{
		MoveFocusTarget();
	}

	private void SearchNearTarget()
	{
		TargetObjects = GameObject.FindGameObjectsWithTag( TargetTag );
		float minDis = 1000f;
		foreach( GameObject target in TargetObjects ){
			float dis = Vector3.Distance( transform.position, target.transform.position);
			if( dis < minDis ){
				minDis = dis;
				NearTargetObject = target;
			}
		}
	}

	private void MoveFocusTarget()
	{
		/* 移動処理、ターゲットも移動するため毎フレームナビゲーションを呼び出す */
		if( NearTargetObject != null && TargetNav.pathPending == false ){
			TargetNav.SetDestination( NearTargetObject.transform.position );
		}
		else{
			/* 見つからなかったとき、新しく近いターゲットを探す */
			SearchNearTarget();
			if( NearTargetObject != null && TargetNav.pathPending == false ){
				TargetNav.SetDestination( NearTargetObject.transform.position );
			}
			/* それでも見つからなかったとき */
			else{
				//動きを止める
				TargetNav.Stop();
			}
		}
	}
}
