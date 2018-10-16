#include "NativePlugin.h"

#include <chrono>  // chrono::system_clock
#include <ctime>   // localtime
#include <sstream> // stringstream
#include <iomanip> // put_time
#include <string>  // string

enum WeekDay : int
{
	Sunday, Monday, Tuesday, Wednesday,
	Thursday, Friday, Saturday
};

int dayOfTheWeek()
{
	// from https://stackoverflow.com/questions/17223096/outputting-date-and-time-in-c-using-stdchrono
	int day = 0;
	auto now = std::chrono::system_clock::now();
	auto in_time_t = std::chrono::system_clock::to_time_t(now);

	std::stringstream ss;
	ss << std::put_time(std::localtime(&in_time_t), "%w");
	ss >> day;
	return day;
}

DLL_EXPORT WeekDay CALL_CONV GetDayOfTheWeek()
{
#if (defined AT_UNITE_LA_2018_4_LULZ)
	return Wednesday;
#else
	return (WeekDay)dayOfTheWeek();
#endif
}

DLL_EXPORT int CALL_CONV IsWednesday(WeekDay day)
{ return day == Wednesday; }

DLL_EXPORT int CALL_CONV GetDaysSinceSunday(WeekDay day)
{ return day; }
