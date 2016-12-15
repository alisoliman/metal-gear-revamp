using UnityEngine;
using System.Collections;
using UnityEditor;

public class MakeObject 
{
	[MenuItem("Assets/Create/Weapon Object")]
	public static void CreateWeapon()
	{
		WeaponObject asset = ScriptableObject.CreateInstance<WeaponObject> ();
		AssetDatabase.CreateAsset (asset, "Assets/NewWeaponObject.asset");
		AssetDatabase.SaveAssets ();
		EditorUtility.FocusProjectWindow ();
		Selection.activeObject = asset;
	}

	[MenuItem("Assets/Create/Item Object")]
	public static void CreateItem()
	{
		ItemObject asset = ScriptableObject.CreateInstance<ItemObject> ();
		AssetDatabase.CreateAsset (asset, "Assets/NewItemObject.asset");
		AssetDatabase.SaveAssets ();
		EditorUtility.FocusProjectWindow ();
		Selection.activeObject = asset;
	}

}
