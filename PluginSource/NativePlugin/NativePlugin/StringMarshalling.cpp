#include "NativePlugin.h"
#include <string>

std::wstring name = L"Shawn Jason Laptiste";

DLL_EXPORT const wchar_t* CALL_CONV GetName()
{ return name.c_str(); }

DLL_EXPORT void CALL_CONV SetName(const wchar_t* n)
{
	if (n)
		name = n;
	else
		name.clear();
}

DLL_EXPORT const wchar_t* CALL_CONV GetAlias()
{
	return L"lazerfalcon";
}

std::string textBuffer;

// This function is NOT thread-safe! It works fine as a naive implementation that is used in simple contexts.
DLL_EXPORT const char* CALL_CONV ModifyText(const char* text)
{
	if (text)
		textBuffer = std::string("<color=#FF0000>****</color> <color=#0000FF>") + text + std::string("</color> <color=#FF0000>****</color>");
	else
		textBuffer.clear();

	return textBuffer.c_str();
}
