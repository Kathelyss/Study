/*
 Автор: Екатерина Рыжова, группа 4302
 Даты: начало разработки: 15.02; окончание разработки: 25.02;
 Версия: 1
 Формулировка задания: Заданная строка состоит из слов,
 разделенных одним или несколькими пробелами. Найти последнее слово,
 начинающееся с заданного символа.
 */

#include <iostream>
#include <fstream>
#include <string.h>

using namespace std;

unsigned const N = 10000;

int main()
{
    cout << "Автор: Екатерина Рыжова, группа 4302 \n";
    cout << "Даты: начало разработки: 15.02; окончание разработки: 25.02;\n";
    cout << "Версия: 1\n";
    cout << "Формулировка задания: Заданная строка состоит из слов,\nразделенных одним или несколькими пробелами. Найти последнее слово,\nначинающееся с заданного символа.\n\n";
    cout << "Дальнейшие результаты работы программы смотрите в файле out.txt\n";
    
    char A[N], symbol = 0;
    fstream in_file, out_file;
    
    // открытие файла на чтение
    in_file.open ("in.txt", ios::in);
    if (!in_file) {
        cout << "Ошибка при открытии исходного файла\n";
    } else {
        // считывание размера массива и искомого символа
        in_file >> symbol;
        // отмена пропуска пробелов в файле
        in_file.unsetf(ios::skipws);
        // открытие файла на запись
        out_file.open ("out.txt", ios::out);
        if (!out_file) {
            cout << "Ошибка при открытии выходного файла\n";
        }
    }
    
    // вывод заголовка, считывание и вывод исходного массива
    out_file << "Исходные данные:\n\n";
    while (in_file.getline(A, N)) {
        out_file << A;
    }
    if (A[0] == '\0') {
        out_file << "Ошибка: строка не содержит элементов\n\n";
        return 1;
    }
    out_file << "\n\n- - - - - - - - - - \n\n";
    in_file.close();
    
    
    char *p = A;
    char *last = nullptr;
    //    cout << "фраза: " << p << endl;
    
    // создание искомой строки
    char searchstr[2];
    searchstr[0] = symbol;
    searchstr[1] = '\0';
    
    while ((p = strstr(p, searchstr)) != NULL) {
        if (*(p-1) == ' ' || p == A) {
            last = p;
        }
        p++;
    }
    
    // вывод результата
    out_file << "Результат:\n\n";
    if (last != NULL) {
        out_file << "Последнее слово, начинающееся с символа '" << symbol << "' - ";
        //        cout << "Последнее слово, начинающееся с символа '" << symbol << "' - ";
        
        for (int i = 0; *(last+i) != ' ' && *(last+i) != '\0'; i++) {
            //            cout << *(last+i);
            out_file << *(last+i);
        }
        //        cout << endl;
        
    } else {
        out_file << "Слово, начинающееся с символа '" << symbol << "', не обнаружено";
        cout << "Слово, начинающееся с символа '" << symbol << "', не обнаружено\n";
    }
    
    out_file.close();
    
    return 0;
}
