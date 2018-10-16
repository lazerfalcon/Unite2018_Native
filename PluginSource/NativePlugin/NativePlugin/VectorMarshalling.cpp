#include "NativePlugin.h"

struct V3
{
	float X;
	float Y;
	float Z;
};

struct V3i
{
	int X;
	int Y;
	int Z;
};

DLL_EXPORT V3 CALL_CONV ConvertVector(V3i v)
{
	return { static_cast<float>(v.X), static_cast<float>(v.Y), static_cast<float>(v.Z) };
}
