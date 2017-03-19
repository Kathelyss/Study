

#ifndef Ex_3__II__funcForText_h
#define Ex_3__II__funcForText_h

#include "text.h"
#include <fstream>

void newString(Text &structure, StringWithMarker *array);
void inText(std::fstream &in_file, std::fstream &out_file, Text &structure);
void processText(Text &structure);
void outText(std::fstream &out_file, Text &structure);

#endif
