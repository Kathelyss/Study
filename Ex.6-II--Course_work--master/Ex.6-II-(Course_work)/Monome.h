//
//  Monome.h
//  Ex.6-II-(Course_work)
//
//  Created by Екатерина Рыжова on 14.05.15.
//  Copyright (c) 2015 Екатерина Рыжова. All rights reserved.
//

#ifndef __Ex_6_II__Course_work___Monome__
#define __Ex_6_II__Course_work___Monome__

#include <iostream>
#include <fstream>

using namespace std;

struct Monome {
    double coefficient;
    int power;
};

struct Formular_M {
    Monome *first, *last, *current, *prevcurr;
};

#endif 
