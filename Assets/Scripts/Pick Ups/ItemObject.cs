using UnityEngine;
using System.Collections;


[System.Serializable]
public class ItemObject : ScriptableObject {

	public string itemName = "Item Name Here";
	public string description = "Description Goes Here";
	public GameObject assignedGameObject;
	public bool enabled;
}
