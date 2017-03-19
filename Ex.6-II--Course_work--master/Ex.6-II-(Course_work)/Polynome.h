//
//  Polynome.h
//  Ex.6-II-(Course_work)
//
//  Created by Екатерина Рыжова on 14.05.15.
//  Copyright (c) 2015 Екатерина Рыжова. All rights reserved.
//

#ifndef __Ex_6_II__Course_work___Polynome__
#define __Ex_6_II__Course_work___Polynome__

#include <stdio.h>
#include "Monome.h"

struct Polynome {
    Monome *monome;
    Polynome *next;
};

struct Formular_P {
    Polynome *first, *last, *current, *prevcurr;
};

//связь между элементами
void setNext(Polynome *p, Polynome *q);
Polynome *getNext(Polynome *p);

int getInfo(Polynome *p);

void initElemWithValue(Polynome *p, Monome *monome);

void setFirst(Formular_P &t, Polynome *q);
Polynome *getFirst(Formular_P &t);

void setLast(Formular_P &t, Polynome *q);
Polynome *getLast(Formular_P &t);

void setCurrent(Formular_P &t, Polynome *q);
Polynome *getCurrent(Formular_P &t);

void setPrevcurr(Formular_P &t, Polynome *q);
Polynome *getPrevcurr(Formular_P &t);

void initEmpty(Formular_P &t);

bool isEmpty(Formular_P &t);

void goBeginning(Formular_P &t);

void goNext(Formular_P &t);

void printList(Formular_P &t, fstream &out_file);

//вставка из файла
void past(Polynome *p, Formular_P &t, fstream &in_file);

void processList (Polynome *p, Formular_P &t);

//удаление списка
void cleaning(Formular_P &t);

#endif