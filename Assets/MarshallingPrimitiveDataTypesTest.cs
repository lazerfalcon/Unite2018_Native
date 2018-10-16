using System.Runtime.InteropServices;
using UnityEngine;

public partial class NativePlugin
{
	[DllImport(PluginName)]
	public static extern ulong GetValue();

	[DllImport(PluginName)]
	public static extern void GetData(out float data);

	[DllImport(PluginName)]
	public static extern void SetData(float data);

	[DllImport(PluginName)]
	public static extern float GetReferenceDataValue();
}

public class MarshallingPrimitiveDataTypesTest : MonoBehaviour
{
	private void Start()
	{
		float d = 0;
		NativePlugin.GetData(out d);
		print("Data = " + d);

		NativePlugin.SetData(90);
		NativePlugin.GetData(out d);
		print("Data = " + d);

		//NativePlugin.SetData(NativePlugin.GetReferenceDataValue());
	}
}
