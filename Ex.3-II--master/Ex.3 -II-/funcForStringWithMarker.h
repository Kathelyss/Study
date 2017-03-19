

#ifndef Ex_3__II__funcForStringWithMarker_h
#define Ex_3__II__funcForStringWithMarker_h

#include "stringWithMarker.h"
#include <fstream>

int inStringWithMarker(std::fstream &in_file, std::fstream &out_file, char *str, char marker);
void processStringWithMarker(StringWithMarker *str);
void outStringWithMarker(std::fstream &out_file, StringWithMarker *str);

#endif
