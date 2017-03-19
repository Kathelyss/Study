//
//  MyList.cpp
//  Ex.4-II-
//
//  Created by Thorax on 06.04.15.
//  Copyright (c) 2015 Thorax. All rights reserved.
//

#include "MyList.h"
#include <stdlib.h>

MyList *newList()
{
    MyList *list = new MyList;//(MyList *)malloc(sizeof(MyList));
    list->next = nullptr;
    return list;
}

void push(MyList *list, int newData)
{
    MyList *newElement = newList();
    newElement->data = newData;
    MyList *last = lastElement(list);
    last->next = newElement;
}

int pop(MyList *list)
{
    MyList *element = list;
    MyList *previous = nullptr;
    while (element->next != nullptr) {
        previous = element;
        element = element->next;
    }
    int result = element->data;
    if (previous != nullptr) {
        previous->next = nullptr;
    }
    //free(element);
    delete element;
    return result;
}

void printList(MyList *list)
{
    printf("\n");
    MyList *element = list;
    while (element->next != nullptr) {
        printf("%d->", element->data);
        element = element->next;
    }
    printf("%d;", element->data);
}

long listCount(MyList *list)
{
    MyList *last = lastElement(list);
    return last - list + 1;
}

MyList *lastElement(MyList *list)
{
    MyList *element = list;
    while (element->next != nullptr) {
        element = element->next;
    }
    return element;
}

void freeList(MyList *list)
{
    MyList *element = list;
    while (element->next != nullptr) {
        MyList *tmp = element->next;
        delete element;
        element = tmp;
    }
//    free(element);
    delete element;
    printf("\nMyList deallocated\n");
}