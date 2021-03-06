// NativePlugin.h
//

// extern "C":
// * specified to avoid name mangling
// * means that functions overloading cannot be used
// [https://docs.microsoft.com/en-us/cpp/cpp/extern-cpp?view=vs-2017]

// __declspec(dllexport):
// * specifies to the Microsoft compiler the symbols that will be accessible outside of the DLL
// [https://docs.microsoft.com/en-us/cpp/cpp/dllexport-dllimport?view=vs-2017]

// __stdcall:
// * specifies the calling convention for interoperability with .NET
// [https://docs.microsoft.com/en-us/cpp/cpp/stdcall?view=vs-2017]

#if defined(_WIN32) || defined(_WIN64) || defined(WINAPI_FAMILY) || defined(_XBOX_ONE)
#define DLL_EXPORT extern "C" __declspec(dllexport)
#define CALL_CONV __stdcall
#else
#define DLL_EXPORT extern "C"
#define CALL_CONV
#endif
