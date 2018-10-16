#include "NativePlugin.h"

struct LittleData
{
	unsigned char data;
};

enum
{
	LittleDataArraySize = 50
};

static LittleData ArrayOfData[LittleDataArraySize];

bool LittleDataBoundsCheck(LittleData* ld)
{
	return ld != nullptr && ld >= ArrayOfData && ld < ArrayOfData + LittleDataArraySize;
}

DLL_EXPORT LittleData* CALL_CONV GetLittleDataPtr(int index)
{
	auto ld = ArrayOfData + index;
	return LittleDataBoundsCheck(ld) ? ld : nullptr;
}

DLL_EXPORT unsigned char CALL_CONV GetLittleDataData(LittleData* ld)
{
	return LittleDataBoundsCheck(ld) ? ld->data : 0;
}

DLL_EXPORT void CALL_CONV SetLittleDataData(LittleData* ld, unsigned char data)
{
	if (LittleDataBoundsCheck(ld))
		ld->data = data;
}
