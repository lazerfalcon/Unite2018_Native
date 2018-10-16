using System.Runtime.InteropServices;
using UnityEngine;

public enum InitializationSteps : int
{
	Intro,
	DoingWork,
	DoingMoreWork,
	Completed,
	CompletedWithErrors,
}

public partial class CallbackMarshallingTest : MonoBehaviour
{
	public InitializationSteps FinalStep;

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate void LoggerInteropDelegate([MarshalAs(UnmanagedType.LPStr)] string message);

	[DllImport(NativePlugin.PluginName)]
	private static extern void DoExtensiveWork(LoggerInteropDelegate logger, InitializationSteps steps);
	private LoggerInteropDelegate Logger = new LoggerInteropDelegate(LogFunction);

	private void Start()
	{
		DoExtensiveWork(Logger, FinalStep);
	}

	[AOT.MonoPInvokeCallback(typeof(LoggerInteropDelegate))]
	private static void LogFunction(string message)
	{
		print("Native Message: " + message);
	}
}
