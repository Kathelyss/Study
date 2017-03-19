

#ifndef __Ex_4_II___MyList__
#define __Ex_4_II___MyList__

#include <stdio.h>

struct MyList {
    MyList *next;
    int data;
};

MyList *newList();
void push(MyList *list, int newData);
int pop(MyList *list);
void printList(MyList *list);
long listCount(MyList *list);
MyList *lastElement(MyList *list);
void freeList(MyList *list);


#endif
