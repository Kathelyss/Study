//
//  Files.cpp
//  Ex.6-II-(Course_work)
//
//  Created by Екатерина Рыжова on 14.05.15.
//  Copyright (c) 2015 Екатерина Рыжова. All rights reserved.
//

#include "Files.h"

int const N = 10; //число символов в файле =/

char* readFromFile(fstream &in_file){
    bool error = false;
    char *str = nullptr;
    str = (char *)malloc(N);
    
    in_file.open("in.txt", ios::in);
    if (!in_file) {
        error = true;
        cout << "Ошибка при открытии исходного файла";
    } else if (!error) {
        // отмена пропуска пробелов в файле
        in_file.unsetf(ios::skipws);
        
        cout << "Получаю данные из файла: ";
        
        for(int i = 0; i < N; i++) {
            in_file >> *(str+i);
            cout << *(str+i);
        }
        cout << endl;
    }
    in_file.close();
    
    return str;
}


//вдруг пригодится?
void writeToFile() {
    fstream out_file;
    bool error = false;
    
    out_file.open("out.txt", ios::out);
    if (!out_file) {
        error = true;
        cout << "Ошибка при открытии выходного файла";
    } else if (!error) {
        out_file << "Исходные данные:\n\n";
        //            printList(formular, out_file);
        
        out_file << "\n- - - - - - - - - - - - - - - - -\n\n" << "Результат:\n\n";
        //            printList(formular, out_file);
        
        //            if(!isEmpty(formular)) {
        //                cleaning(formular);
        //            }
    } out_file.close();
}