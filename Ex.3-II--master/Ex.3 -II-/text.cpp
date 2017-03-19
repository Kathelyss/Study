

#include "text.h"
#include "stringWithMarker.h"
#include "funcForStringWithMarker.h"
#include <fstream>

StringWithMarker* newString(Text &structure)
{
    if (structure.strings == nullptr) {
        structure.strings_size = 0;
    }
    structure.strings_size++;
    structure.strings = (StringWithMarker *)realloc(structure.strings, sizeof(StringWithMarker)*structure.strings_size);
    return structure.strings+structure.strings_size-1;//указатель на только что добавленную строку
}

void inText(std::fstream &in_file, std::fstream &out_file, Text &str)
{
    in_file.open("in.txt", std::ios::in);
    if (!in_file) {
        std::cout << "Ошибка при открытии исходного файла\n";
        exit(1);
    } else {
        std::cout << "\nВведите маркер: ";
        std::cin >> str.marker;
        
        out_file.open("out.txt", std::ios::out);
        if (!out_file) {
            std::cout << "Ошибка при открытии выходного файла\n";
            exit(1);
        } else {
            out_file << "Исходные данные:\n";
            int count_of_chars = 0;
            while (!in_file.eof()) {
                out_file << "\n";
                StringWithMarker *s = newString(str);
                s->str = (char *)malloc(100);
                
                s->count_of_elements = inStringWithMarker(in_file, out_file, s->str, str.marker);
                
                in_file.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
                count_of_chars += s->count_of_elements;//количество элементов до маркера (в каждой строке)
            }
            if (count_of_chars < 1) {
                std::cout << "Ошибка: исходный файл пуст\n";
                exit(1);
            }
        }
    }
    in_file.close();
}

void processText(Text &str)
{
    int i = 0;
    while (i < str.strings_size) {
        processStringWithMarker(str.strings+i);
        i++;
    }
}

void outText(std::fstream &out_file, Text &str)
{
    out_file << "\n\n- - - - - - - - - - - - - - - - -\n\n" << "Результат:\n\n";
    int i = 0;
    while (i < str.strings_size) {
        outStringWithMarker(out_file, str.strings+i);
        i++;
    }
}