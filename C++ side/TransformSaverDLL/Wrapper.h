#pragma once
#include "PluginSettings.h"
#include "SaveLoad.h"

#ifdef __cplusplus
extern "C"
{
#endif

	//Put functions here
	//PLUGIN_API void SetFilePath(std::string path);

	PLUGIN_API void SavePosition(float values[9]);

	PLUGIN_API float* LoadPosition();

#ifdef __cplusplus
}
#endif