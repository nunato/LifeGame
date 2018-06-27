using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalBirth : MonoBehaviour
{
	public int			NextBirthCount;

	private int			TargetCount;
	private string		TargetTag;

	void Start()
	{
		TargetCount = 0;
		TargetTag = AnimalUtil.GetTargetTag( gameObject.tag );
	}

	void Update()
	{
		CheckBirthCount();
	}

	/* 子供の生成 */
	private void CheckBirthCount()
	{
		if( TargetCount >= NextBirthCount ){
			TargetCount = 0;
			Vector3 childPosition = new Vector3( transform.position.x, transform.position.y + 1, transform.position.z );
			Instantiate( gameObject, childPosition, Quaternion.identity );
		}
	}

	void OnCollisionEnter( Collision other )
	{
		if( TargetTag != null && other.gameObject.CompareTag( TargetTag ) ){
			++TargetCount;
			Destroy( other.gameObject );
		}
	}
}
