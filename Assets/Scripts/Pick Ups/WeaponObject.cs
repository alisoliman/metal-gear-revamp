using UnityEngine;
using System.Collections;


[System.Serializable]
public class WeaponObject : ScriptableObject {

	public string weaponName = "Weapon Name Here";
	public string description = "Description Goes Here";
	public GameObject assignedGameObject;
	public bool enabled;
}
