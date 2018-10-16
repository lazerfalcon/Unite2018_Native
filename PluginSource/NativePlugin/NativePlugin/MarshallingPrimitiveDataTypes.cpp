#include "NativePlugin.h"

const float ReferenceDataValue = 90000.0f;
static float Data = ReferenceDataValue;

DLL_EXPORT int CALL_CONV GetValue() { return 32; }

DLL_EXPORT void CALL_CONV GetData(float& data) { data = Data; }
DLL_EXPORT void CALL_CONV SetData(float data) { Data = data; }

DLL_EXPORT float CALL_CONV GetReferenceDataValue() { return ReferenceDataValue; }

DLL_EXPORT void* CALL_CONV GetPtr() { return &Data; }
