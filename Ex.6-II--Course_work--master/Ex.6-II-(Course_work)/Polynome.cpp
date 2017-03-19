//
//  Polynome.cpp
//  Ex.6-II-(Course_work)
//
//  Created by Екатерина Рыжова on 14.05.15.
//  Copyright (c) 2015 Екатерина Рыжова. All rights reserved.
//

#include "Polynome.h"

////связь между элементами
//void setNext(Polynome *p, Polynome *q)
//{
//    p->next = q;
//}
//
//Polynome *getNext(Polynome *p)
//{
//    return p->next;
//}
//
////???
////Monome *getInfo(Polynome *p)
////{
////    return p->monome;
////}
//
//void initElemWithValue(Polynome *p, Monome *monome)
//{
//    p->monome = monome;
//    p->next = nullptr;
//}
//
//void setFirst(Formular_P &t, Polynome *q)
//{
//    t.first = q;
//}
//
//Polynome *getFirst(Formular_P &t)
//{
//    return t.first;
//}
//
//void setLast(Formular_P &t, Polynome *q)
//{
//    t.last = q;
//}
//
//Polynome *getLast(Formular_P &t)
//{
//    return t.last;
//}
//
//void setCurrent(Formular_P &t, Polynome *q)
//{
//    t.current = q;
//}
//
//Polynome *getCurrent(Formular_P &t)
//{
//    return t.current;
//}
//
//void setPrevcurr(Formular_P &t, Polynome *q)
//{
//    t.prevcurr = q;
//}
//
//Polynome *getPrevcurr(Formular_P &t)
//{
//    return t.prevcurr;
//}
//
////инициализация
//void initEmpty(Formular_P &t)
//{
//    setFirst(t, nullptr);
//    setCurrent(t, nullptr);
//    setPrevcurr(t, nullptr);
//    setLast(t, nullptr);
//}
//
////проверка пустоты списка
//bool isEmpty(Formular_P &t)
//{
//    if (getFirst(t) == nullptr) {
//        return true; //да, пуст
//    } else {
//        return false; //нет, не пуст
//    }
//}
//
//void goBeginning(Formular_P &t)
//{
//    setCurrent(t, getFirst(t));
//    setPrevcurr(t, nullptr);
//}
//
//void goNext(Formular_P &t)
//{
//    setPrevcurr(t, getCurrent(t)); //t.prevcurr = t.curent;
//    setCurrent(t, getNext(getCurrent(t))); //t.current = t.current->next
//}
//
//void printList(Formular_P &t, fstream &out_file)
//{
//    goBeginning(t);
//    while (getCurrent(t) != nullptr) {
//        cout << getInfo(getCurrent(t)) << " -> ";
//        out_file << getInfo(getCurrent(t)) << " -> ";
//        goNext(t);
//    }
//    cout << "X\n";
//    out_file << "X\n";
//}
//
////вставка из файла
//void past(Polynome *p, Formular_P &t, fstream &in_file)
//{
//    cout << "Получаю данные из файла: ";
//    double coeff;
//    int pow;
//    while(!in_file.eof()) {
//        in_file >> coeff >> pow;
//        //        if (!data) break;
//        p = new Polynome;
//        initElemWithValue(p, monome);
//        if (isEmpty(t)) {
//            setFirst(t, p);
//            setLast(t, p);
//            setPrevcurr(t, p);
//            setCurrent(t, p);
//        } else {
//            setNext(getLast(t), p);
//            setLast(t, p);
//        }
//    }
//}
//
//удаление списка
//void cleaning(Formular_P &t)
//{
//    goBeginning(t);
//    while (getCurrent(t) != nullptr) {
//        goNext(t);
//        delete getFirst(t);
//        setFirst(t, getCurrent(t));
//    }
//}
//
//void processList (Polynome *p, Formular_P &t)
//{
//    goBeginning(t);
//    goNext(t);
//    while (getCurrent(t) != nullptr) {
//        Polynome *prev = getPrevcurr(t);
//        Polynome *curr = getCurrent(t);
//        if (getInfo(prev) == getInfo(curr)) {
//            Polynome *next = getNext(curr); //curr->next;
//            delete curr;
//            setNext(prev, next); //prev->next = next;
//            setCurrent(t, prev);
//        }
//        goNext(t);
//    }
//}


