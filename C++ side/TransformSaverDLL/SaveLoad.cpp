#include "SaveLoad.h"
#include <fstream>
#include <sstream>

void SaveLoad::SetFilePath(std::string path)
{
	filePath = path;
}

void SaveLoad::SavePosition(std::string fileName, float values[9])
{
	std::ofstream saveFile;
	saveFile.open(filePath + fileName);
	if (saveFile.is_open())
	{
		saveFile << std::to_string(versionNum) << "\n";
		for (int i = 0; i < 9; i++)
		{
			saveFile << std::to_string(values[i]) + "/";
		}
		saveFile << "\nEND";

		saveFile.close();
	}
}

float* SaveLoad::LoadPosition(std::string fileName)
{
	std::ifstream saveFile;
	saveFile.open(filePath + fileName);

	float values[9];
	std::string str;

	if (saveFile.is_open())
	{
		std::getline(saveFile, str);
		int vNum = std::stoi(str);
		
		switch (vNum)
		{
		case 0:
			int count = 0;
			std::getline(saveFile, str);
			std::stringstream ss(str);
			while (std::getline(ss, str, '/') && count < 9)
			{
				values[count] = std::stof(str); count++;
			}
			break;
		}

		saveFile.close();
		return values;
	}
	return nullptr;
}
