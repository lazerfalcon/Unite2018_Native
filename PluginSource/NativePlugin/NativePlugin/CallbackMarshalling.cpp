#include "NativePlugin.h"

typedef void(CALL_CONV * Logger)(const char*);

DLL_EXPORT void CALL_CONV DoExtensiveWork(Logger logger, int steps)
{
	logger("Starting initialization work...");

	if (steps > 0)
		logger("Doing work...");

	if (steps > 1)
		logger("Doing MOAR work...");

	if (steps < 3)
		logger("Initialization failed.");
	else if (steps == 3)
		logger("Initialization completed with errors.");
	else
		logger("Initialization complete.");
}
