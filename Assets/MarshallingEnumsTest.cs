using System.Runtime.InteropServices;
using UnityEngine;

public enum WeekDay : int
{
	Sunday, Monday, Tuesday, Wednesday,
	Thursday, Friday, Saturday
}

public class MarshallingEnumsTest : MonoBehaviour
{
	[DllImport(NativePlugin.PluginName)]
	private static extern WeekDay GetDayOfTheWeek();

	[DllImport(NativePlugin.PluginName)]
	private static extern bool IsWednesday(WeekDay day);

	private void Start()
	{
		var day = GetDayOfTheWeek();
		print(day);
		if (IsWednesday(day))
			print("Today is Wednesday!!!");
	}
}
