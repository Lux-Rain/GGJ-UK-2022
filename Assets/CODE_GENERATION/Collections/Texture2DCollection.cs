using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[CreateAssetMenu(
	    fileName = "Texture2DCollection.asset",
	    menuName = SOArchitecture_Utility.COLLECTION_SUBMENU + "Texture2D",
	    order = 0)]
	public class Texture2DCollection : Collection<Texture2D>
	{
	}
}