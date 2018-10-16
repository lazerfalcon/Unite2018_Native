using System;
using System.Runtime.InteropServices;
using UnityEngine;

public partial class NativePlugin
{
	[DllImport(PluginName)]
	public static extern IntPtr GetLittleDataPtr(int index);

	[DllImport(PluginName)]
	public static extern byte GetLittleDataData(IntPtr data);

	[DllImport(PluginName)]
	public static extern void SetLittleDataData(IntPtr data, byte value);
}

public class LittleDataArray
{
	IntPtr GetPointer(int i)
	{
		var ptr = NativePlugin.GetLittleDataPtr(i);
		if (ptr == IntPtr.Zero)
			throw new System.IndexOutOfRangeException("Index out of bounds: " + i);

		return ptr;
	}

	public byte this[int i]
	{
		get { return NativePlugin.GetLittleDataData(GetPointer(i)); }
		set { NativePlugin.SetLittleDataData(GetPointer(i), value); }
	}
}

[ExecuteInEditMode]
public class PointerMarshallingTest : MonoBehaviour
{
	public int Index;
	public bool Set = false;
	public byte Value = 0;

	private void Update()
	{
		var ptr = NativePlugin.GetLittleDataPtr(Index);
		if (ptr == IntPtr.Zero)
			return;

		if (Set)
			NativePlugin.SetLittleDataData(ptr, Value);
		else
			Value = NativePlugin.GetLittleDataData(ptr);
	}
}
