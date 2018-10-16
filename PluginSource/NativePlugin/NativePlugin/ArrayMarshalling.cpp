#include "NativePlugin.h"

DLL_EXPORT int CALL_CONV FillArray(int* integers, int size, int v)
{
	if (!integers || size < 0)
		return 0;

	for (int i = 0; i < size; ++i)
		integers[i] = v;

	return size;
}

struct CppVector2
{
	float x;
	float y;
};

DLL_EXPORT int CALL_CONV Fiverize(CppVector2* vecArray, int size)
{
	if (vecArray == nullptr || size < 0)
		return 0;

	for (int i = 0; i < size; ++i)
		vecArray[i].x = vecArray[i].y = 5;

	return size;
}
