public partial class NativePlugin
{
	// Use "__Internal" when static linking
	// Use the plug-in's name when dynamic linking
#if (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
	public const string PluginName = "__Internal";
#else
	public const string PluginName = "NativePlugin";
#endif
}
