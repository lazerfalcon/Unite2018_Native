#include "NativePlugin.h"

// http://www.catb.org/esr/structure-packing/

// PAY ATTENTION TO:
// * The packing and alignment of data members!
// * The size of the data types that are being used!
//   * Depending on compilation settings, enums can have different sizes.
//     * Use "enum class" and specify the underlying byte representation.
//     * Test!
//   * On certain platforms, "unsigned long" is 32-bit and "unsigned long long" is 64-bit.
//   * The clean way around this is to use typedefs.

struct CppStructure
{
	unsigned long long value = 1000;
};

DLL_EXPORT CppStructure CALL_CONV GetStructure()
{ return CppStructure(); }

DLL_EXPORT void CALL_CONV PassStructureByReference(CppStructure& st)
{
	st.value *= 2;
}

DLL_EXPORT CppStructure CALL_CONV PassStructureByValue(CppStructure st)
{
	st.value += 200;
	return st;
}
