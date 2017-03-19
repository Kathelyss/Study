//
//  main.cpp
//  Labyrinth
//
//  Created by Екатерина Рыжова on 09.05.15.
//  Copyright (c) 2015 Екатерина Рыжова. All rights reserved.
//

#include <iostream>
#include <stdlib.h>

using namespace std;

int main() {
    int n = 10; //т. к. лабиринт квадратный
    int array[n][n]; //т. к. лабиринт квадратный
    int i = 0, j = 0;
    
    int enter = arc4random_uniform(n-2)+1; //генерируем номер ячейки, где будет вход
    int exit = arc4random_uniform(n-2)+1; //генерируем номер ячейки, где будет выход
    cout << "enter = " << enter+1 << " exit = " << exit+1 << "\n\n";
    
    for (i = 0; i < n; i++) {
        for (j = 0; j < n; j++) {
            //генерируем рамку (периметр)
            if ((i == 0) || (j == 0) || (i == n-1) || (j == n-1)) {
                if (!(i == 0 && j == enter) && !(i == n-1 && j == exit)) {
                    array[i][j] = 1;
                } else {
                    array[i][j] = 0;
                }
            } else {
                if ((i-1 == 0 && j == enter) || (i+1 == n-1 && j == exit)) {
                    array[i][j] = 0;
                } else {
                    array[i][j] = arc4random_uniform(2);
                    
                    //генерация лабиринта
                    
                }
            }
            
            if (array[i][j] == 1) {
                cout << "⬛️";
            } else {
                cout << "⬜️";
            }
            
        }
        cout << endl;
    }
    
    return 0;
}
