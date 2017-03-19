
#include "MyList.h"

//связь между элементами
//void setNext(Monome *p, Monome *q)
//{
//    p->next = q;
//}

//Monome *getNext(Monome *p)
//{
//    return p->next;
//}

//???
//int getInfo(Monome *p)
//{
//    return p->coefficient;
//}

//void initElemWithValue(Monome *p, double coefficient, int power)
//{
//    p->coefficient = coefficient;
//    p->power = power;
//    p->next = nullptr;
//}

//void setFirst(Formular &t, Monome *q)
//{
//    t.first = q;
//}

//Monome *getFirst(Formular &t)
//{
//    return t.first;
//}

//void setLast(Formular &t, Monome *q)
//{
//    t.last = q;
//}

//Monome *getLast(Formular &t)
//{
//    return t.last;
//}

//void setCurrent(Formular &t, Monome *q)
//{
//    t.current = q;
//}

//Monome *getCurrent(Formular &t)
//{
//    return t.current;
//}

//void setPrevcurr(Formular &t, Monome *q)
//{
//    t.prevcurr = q;
//}

//Monome *getPrevcurr(Formular &t)
//{
//    return t.prevcurr;
//}

////инициализация
//void initEmpty(Formular &t)
//{
//    setFirst(t, nullptr);
//    setCurrent(t, nullptr);
//    setPrevcurr(t, nullptr);
//    setLast(t, nullptr);
//}

////проверка пустоты списка
//bool isEmpty(Formular &t)
//{
//    if (getFirst(t) == nullptr) {
//        return true; //да, пуст
//    } else {
//        return false; //нет, не пуст
//    }
//}

//void goBeginning(Formular &t)
//{
//    setCurrent(t, getFirst(t));
//    setPrevcurr(t, nullptr);
//}

//void goNext(Formular &t)
//{
//    setPrevcurr(t, getCurrent(t)); //t.prevcurr = t.curent;
//    setCurrent(t, getNext(getCurrent(t))); //t.current = t.current->next
//}

//void printList(Formular &t, fstream &out_file)
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

////вставка с консоли
//void pastConsole(Monome *p, Formular &t, int count)
//{
//    double coeff;
//    int pow;
//    int i = 0;
//    while(i < count) {
//        cout << "Введите коэффициент перед х: ";
//        cin >> coeff;
//        cout << "Введите степень х: ";
//        cin >> pow;
//        p = new Monome;
//        initElemWithValue(p, coeff, pow);
//        if (isEmpty(t)) {
//            setFirst(t, p);
//            setLast(t, p);
//            setPrevcurr(t, p);
//            setCurrent(t, p);
//        } else {
//            setNext(getLast(t), p);
//            setLast(t, p);
//        }
//        i++;
//    }
//}

////вставка из файла
//void past(Monome *p, Formular &t, fstream &in_file)
//{
//    cout << "Получаю данные из файла: ";
//    double coeff;
//    int pow;
//    while(!in_file.eof()) {
//        in_file >> coeff >> pow;
////        if (!data) break;
//        p = new Monome;
//        initElemWithValue(p, coeff, pow);
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

////удаление списка
//void cleaning(Formular &t)
//{
//    goBeginning(t);
//    while (getCurrent(t) != nullptr) {
//        goNext(t);
//        delete getFirst(t);
//        setFirst(t, getCurrent(t));
//    }
//}

//void processList (Monome *p, Formular &t)
//{
//    goBeginning(t);
//    goNext(t);
//    while (getCurrent(t) != nullptr) {
//        Monome *prev = getPrevcurr(t);
//        Monome *curr = getCurrent(t);
//        if (getInfo(prev) == getInfo(curr)) {
//            Monome *next = getNext(curr); //curr->next;
//            delete curr;
//            setNext(prev, next); //prev->next = next;
//            setCurrent(t, prev);
//        }
//        goNext(t);
//    }
//}

