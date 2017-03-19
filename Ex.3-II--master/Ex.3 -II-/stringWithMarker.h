

#ifndef __Ex_3__II___stringWithMarker__
#define __Ex_3__II___stringWithMarker__

#include <iostream>

typedef enum: int {
    ResultUnknown = 0,
    ResultOK,
    ResultNotOK,
    ResultOperatorNotFound,
} Result;

struct StringWithMarker {
    char *str;
    int count_of_elements;
    Result result;
    long evaluatedElements; //обработанные элементы
};

#endif
