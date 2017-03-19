
#include "List.h"
#include "Polynome.h"
#include "Monome.h"
#include "Files.h"

int main() {
    
    List<Polynome> *polynome_list = new List<Polynome>;
    List<Monome> *monome_list= new List<Monome>;
    Formular<Polynome> formular_p;
    Formular<Monome> formular_m;
    polynome_list->initEmpty(formular_p);
    monome_list->initEmpty(formular_m);
    
    fstream in_file;
    readFromFile(in_file);
    
    Monome *m;
    m->coefficient =5;
    m->power =2;
    
    monome_list->setFirst(formular_m, m);

    //создать мономы
    //pastConsole(list, formular, n);
    //создать полиномы
    //заполнить полиномы мономами
    //вывести их
    //операция сложения + вывод
    //операция вычитания + вывод
    //операция умножения + вывод
    
    return 0;
}
