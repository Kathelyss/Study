

#include "MyList.h"

//связь между элементами
void setNext(Elem *p, Elem *q)
{
    p->next = q;
}

Elem *getNext(Elem *p)
{
    return p->next;
}

int getInfo(Elem *p)
{
    return p->info;
}

void initElemWithValue(Elem *p, int data)
{
    p->info = data;
    p->next = nullptr;
}

void setFirst(Formular &t, Elem *q)
{
    t.first = q;
}

Elem *getFirst(Formular &t)
{
    return t.first;
}

void setLast(Formular &t, Elem *q)
{
    t.last = q;
}

Elem *getLast(Formular &t)
{
    return t.last;
}

void setCurrent(Formular &t, Elem *q)
{
    t.current = q;
}

Elem *getCurrent(Formular &t)
{
    return t.current;
}

void setPrevcurr(Formular &t, Elem *q)
{
    t.prevcurr = q;
}

Elem *getPrevcurr(Formular &t)
{
    return t.prevcurr;
}

//инициализация
void initEmpty(Formular &t)
{
    setFirst(t, nullptr);
    setCurrent(t, nullptr);
    setPrevcurr(t, nullptr);
    setLast(t, nullptr);
}

//проверка пустоты списка
bool isEmpty(Formular &t)
{
    if (getFirst(t) == nullptr) {
        return true; //да, пуст
    } else {
        return false; //нет, не пуст
    }
}

void goBeginning(Formular &t)
{
    setCurrent(t, getFirst(t));
    setPrevcurr(t, nullptr);
}

void goNext(Formular &t)
{
    setPrevcurr(t, getCurrent(t)); //t.prevcurr = t.curent;
    setCurrent(t, getNext(getCurrent(t))); //t.current = t.current->next
}

void printList(Formular &t, fstream &out_file)
{
    goBeginning(t);
    while (getCurrent(t) != nullptr) {
        cout << getInfo(getCurrent(t)) << " -> ";
        out_file << getInfo(getCurrent(t)) << " -> ";
        goNext(t);
    }
    cout << "X\n";
    out_file << "X\n";
}

//вставка из файла
void past(Elem *p, Formular &t, fstream &in_file)
{
    cout << "Получаю данные из файла: ";
    int data;
    while(!in_file.eof()) {
        in_file >> data;
        if (!data) break;
        p = new Elem;
        initElemWithValue(p, data);
        if (isEmpty(t)) {
            setFirst(t, p);
            setLast(t, p);
            setPrevcurr(t, p);
            setCurrent(t, p);
        } else {
            setNext(getLast(t), p);
            setLast(t, p);
        }
    }
}

//удаление списка
void cleaning(Formular &t)
{
    goBeginning(t);
    while (getCurrent(t) != nullptr) {
        goNext(t);
        delete getFirst(t);
        setFirst(t, getCurrent(t));
    }
}

void processList (Elem *p, Formular &t)
{
    goBeginning(t);
    goNext(t);
    while (getCurrent(t) != nullptr) {
        Elem *prev = getPrevcurr(t);
        Elem *curr = getCurrent(t);
        if (getInfo(prev) == getInfo(curr)) {
            Elem *next = getNext(curr); //curr->next;
            delete curr;
            setNext(prev, next); //prev->next = next;
            setCurrent(t, prev);
        }
        goNext(t);
    }
}

//void processList (Elem *p, Formular &t)
//{
//    goBeginning(t);
//    if (getFirst(t)->next != nullptr) {
////        goNext(t);
//        while (goNext(t) != nullptr) {
//            Elem *curr = getCurrent(t);
//            Elem *next = getNext(curr);
//            Elem *prev = getPrevcurr(t);
//            if (curr->info == prev->info) {
//                delete curr;
//                prev->next = next;
//                setCurrent(t, prev);
//            }
//        }
//    }
//}
