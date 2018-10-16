using System.Runtime.InteropServices;

public struct AnalogousCSharpStructure
{
	public ulong TheValue;
}

public partial class NativePlugin
{
	[DllImport(PluginName)]
	public static extern AnalogousCSharpStructure GetStructure();

	[DllImport(PluginName)]
	public static extern void PassStructureByReference(ref AnalogousCSharpStructure structure);

	[DllImport(PluginName)]
	public static extern AnalogousCSharpStructure PassStructureByValue(AnalogousCSharpStructure structure);
}

public class MarshallingStructuresTest01 : UnityEngine.MonoBehaviour
{
	private void Start()
	{
		var st = NativePlugin.GetStructure();
		print("Value = " + st.TheValue);

		NativePlugin.PassStructureByReference(ref st);
		print("Value = " + st.TheValue);

		var st2 = NativePlugin.PassStructureByValue(st);
		print("Value = " + st2.TheValue);
	}
}
