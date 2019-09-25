#pragma once

#include "PluginSettings.h"
#include <string>
#include <vector>

class PLUGIN_API SaveLoad
{
	int versionNum = 0;

public:
	

private:
	std::string filePath;

public:
	void SetFilePath(std::string path);

	void SavePosition(std::string fileName, float values[9]);
	
	float* LoadPosition(std::string fileName);

};