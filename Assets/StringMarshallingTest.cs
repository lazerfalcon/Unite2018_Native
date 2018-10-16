using System;
using System.Runtime.InteropServices;

public partial class NativePlugin
{
	[DllImport(PluginName, EntryPoint = "GetName")]
	private static extern IntPtr GetNameImpl();
	public static string GetName()
	{ return Marshal.PtrToStringUni(GetNameImpl()); }

	[DllImport(PluginName)]
	public static extern void SetName([MarshalAs(UnmanagedType.LPWStr)] string name);

	[DllImport(PluginName, EntryPoint = "GetAlias")]
	private static extern IntPtr GetAliasImpl();
	public static string GetAlias()
	{ return Marshal.PtrToStringUni(GetAliasImpl()); }

	[DllImport(PluginName, EntryPoint = "ModifyText")]
	private static extern IntPtr ModifyTextImpl([MarshalAs(UnmanagedType.LPStr)] string text);

	public static string ModifyText(string text)
	{ return Marshal.PtrToStringAnsi(ModifyTextImpl(text)); }
}

public class StringMarshallingTest : UnityEngine.MonoBehaviour
{
	private void Start()
	{
		print("The developer's name is " + NativePlugin.GetName());
		print("(AKA " + NativePlugin.GetAlias() + ")");

		print(NativePlugin.ModifyText("MAGICAL TEXT"));
		//print(NativePlugin.ModifyText(null));
	}
}
