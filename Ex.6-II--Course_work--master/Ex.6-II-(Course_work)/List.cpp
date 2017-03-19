//
//  List.cpp
//  Ex.6-II-(Course_work)
//
//  Created by Екатерина Рыжова on 14.05.15.
//  Copyright (c) 2015 Екатерина Рыжова. All rights reserved.
//

#include "List.h"

template<typename T>
 void List<T>::setNext(T *p, T *q)
{
    p->next = q;
}

template<typename T>
void List<T>::initEmpty(Formular<T> &t)
{
    setFirst(t, nullptr);
    setCurrent(t, nullptr);
    setPrevcurr(t, nullptr);
    setLast(t, nullptr);
}

template<typename T>
T *List<T>::getNext(T *p)
{
    return p->next;
}

template<typename T>
void List<T>::setFirst(Formular<T> &t, T *q)
{
    t.first = q;
}

template<typename T>
T *List<T>::getFirst(Formular<T> &t)
{
    return t.first;
}

template<typename T>
void List<T>::setLast(Formular<T> &p, T *q)
{
    p->last = q;
}

template<typename T>
T *List<T>::getLast(Formular<T> &t)
{
    return t.last;
}

template<typename T>
void List<T>::setCurrent(Formular<T> &p, T *q)
{
    p->current = q;
}

template<typename T>
T *List<T>::getCurrent(Formular<T> &t)
{
    return t.current;
}

template<typename T>
void List<T>::setPrevcurr(Formular<T> &p, T *q)
{
    p->prevcurr = q;
}

template<typename T>
T *List<T>::getPrevcurr(Formular<T> &t)
{
    return t.prevcurr;
}



