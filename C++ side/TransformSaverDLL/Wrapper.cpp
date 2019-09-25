#include "Wrapper.h"

SaveLoad saveLoad;

PLUGIN_API void SavePosition(float values[9])
{
	return saveLoad.SavePosition("Assets/savedFile.txt", values);
}

PLUGIN_API float* LoadPosition()
{
	return saveLoad.LoadPosition("Assets/savedFile.txt");
}
