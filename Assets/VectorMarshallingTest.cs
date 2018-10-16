using System.Runtime.InteropServices;
using UnityEngine;

public partial class NativePlugin
{
	[DllImport(PluginName)]
	public static extern Vector3 ConvertVector(Vector3Int vector);
}

public class VectorMarshallingTest : MonoBehaviour
{
	public Vector3Int Vector;

	private void Update()
	{
		transform.position = NativePlugin.ConvertVector(Vector);
	}
}
