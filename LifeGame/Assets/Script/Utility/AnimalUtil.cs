using UnityEngine;

public static class AnimalUtil
{
	/* ターゲットのタグを返す */
	public static string GetTargetTag( string ObjectTag )
	{
		string tag;

		switch( ObjectTag ){
			case "Carnivore":
				tag = "Herbivore";
				break;
			case "Herbivore":
				tag = "Grass";
				break;
			default:
				tag = null;
				break;
		}
		return tag;
	}
}