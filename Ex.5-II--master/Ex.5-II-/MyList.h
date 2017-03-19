

#ifndef __Ex_5_II___MyList__
#define __Ex_5_II___MyList__

#include <iostream>
#include <fstream>

using namespace std;

struct Elem {
    int info;
    Elem *next;
};

struct Formular {
    Elem *first, *last, *current, *prevcurr;
};

//связь между элементами
void setNext(Elem *p, Elem *q);
Elem *getNext(Elem *p);

int getInfo(Elem *p);

void initElemWithValue(Elem *p, int data);

void setFirst(Formular &t, Elem *q);
Elem *getFirst(Formular &t);

void setLast(Formular &t, Elem *q);
Elem *getLast(Formular &t);

void setCurrent(Formular &t, Elem *q);
Elem *getCurrent(Formular &t);

void setPrevcurr(Formular &t, Elem *q);
Elem *getPrevcurr(Formular &t);

void initEmpty(Formular &t);

bool isEmpty(Formular &t);

void goBeginning(Formular &t);

void goNext(Formular &t);

void printList(Formular &t, fstream &out_file);

//вставка из файла
void past(Elem *p, Formular &t, fstream &in_file);

void processList (Elem *p, Formular &t);

//удаление списка
void cleaning(Formular &t);

#endif
