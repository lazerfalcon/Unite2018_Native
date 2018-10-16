using System.Runtime.InteropServices;
using UnityEngine;

public partial class NativePlugin
{
	[DllImport(PluginName, EntryPoint = "FillArray")]
	private static extern int FillArrayPrivate(int[] integers, int size, int value);

	public static int FillArray(int[] integers, int value)
	{
		return FillArrayPrivate(integers, integers.Length, value);
	}

	[DllImport(PluginName)]
	public static extern int Fiverize(Vector2[] vecs, int size);
}

public class ArrayMarshallingTest : MonoBehaviour
{
	public int[] Integers = new int[40];

	private void Start()
	{
		NativePlugin.FillArray(Integers, 125);
	}
}
