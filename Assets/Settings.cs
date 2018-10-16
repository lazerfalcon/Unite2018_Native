public enum TimeOfDay
{
	Morning,
	Day,
	Afternoon,
	Night,
};

public enum SpectrumFlags
{
	UltraLowFrequency = 1 << 0,
	Radiowaves = 1 << 1,
	Microwaves = 1 << 2,
	Infrared = 1 << 3,
	Visible = 1 << 4,
	Ultraviolet = 1 << 5,
	GammaRays = 1 << 6,
};
