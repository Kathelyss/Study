//
//  List.h
//  Ex.6-II-(Course_work)
//
//  Created by Екатерина Рыжова on 14.05.15.
//  Copyright (c) 2015 Екатерина Рыжова. All rights reserved.
//

#ifndef __Ex_6_II__Course_work___List__
#define __Ex_6_II__Course_work___List__

#include <stdio.h>

template <typename T> struct Formular {
    T *first, *last, *current, *prevcurr;
};

template <typename T>
struct List {
    T *value;
    List *next;
   
    void initEmpty(Formular<T> &t);
    void setNext(T *p, T *q);
    T *getNext(T *p);
    void setFirst(Formular<T> &t, T *q);
    T *getFirst(Formular<T> &t);
    
    void setLast(Formular<T> &t, T *q);
    T *getLast(Formular<T> &t);
    void setCurrent(Formular<T> &t, T *q);
    T *getCurrent(Formular<T> &t);
    void setPrevcurr(Formular<T> &t, T *q);
    T *getPrevcurr(Formular<T> &t);
    
};

#endif
