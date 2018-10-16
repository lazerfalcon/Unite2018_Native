using System;
using System.Runtime.InteropServices;

public partial class NativePlugin
{
	[DllImport(PluginName)]
	public static extern IntPtr CreateCppClass();

	[DllImport(PluginName)]
	public static extern void DestroyCppClass(IntPtr ptr);

	[DllImport(PluginName)]
	public static extern float CppClass_Value_get(IntPtr ptr);

	[DllImport(PluginName)]
	public static extern void CppClass_Value_set(IntPtr ptr, float value);

	[DllImport(PluginName)]
	public static extern int CppClass_Function(IntPtr ptr);
}

public class CppClassProxy
{
	private IntPtr CppPtr = NativePlugin.CreateCppClass();

	~CppClassProxy()
	{
		NativePlugin.DestroyCppClass(CppPtr);
		CppPtr = IntPtr.Zero;
	}

	public float Value
	{
		get { return NativePlugin.CppClass_Value_get(CppPtr); }
		set { NativePlugin.CppClass_Value_set(CppPtr, value); }
	}

	public int Function()
	{
		return NativePlugin.CppClass_Function(CppPtr);
	}
}

public class MarshallingStructuresTest02 : UnityEngine.MonoBehaviour
{
	private void Start()
	{
		var c = new CppClassProxy();
		print(c.Value + " " + c.Function());
		c.Value = 80.5f;
		print(c.Value + " " + c.Function());
	}
}
