

#include "stringWithMarker.h"
#include <fstream>

int inStringWithMarker(std::fstream &in_file, std::fstream &out_file, char *str, char marker)
{
    int count_of_elements = 0;
    char *found_marker = nullptr;
    
    while (*(str+count_of_elements) != marker) {
        //находить конец строки
        if (in_file.peek() == '\n') break;
        in_file >> *(str+count_of_elements);
        
        if (*(str+count_of_elements) == marker) {
            found_marker = str+count_of_elements;
            break;
        }
        if (*(str+count_of_elements) == '\0') {
            break;
        }
        
        out_file << *(str+count_of_elements);
        std::cout << *(str+count_of_elements);
        count_of_elements++;
    }
    if (found_marker) {
        std::cout << "  >> количество символов до маркера: " << count_of_elements << "\n";
    } else {
        std::cout << "  >> в строке нет данного маркера (строка будет обработана полностью)\n";
    }
    return count_of_elements;
}

void processStringWithMarker(StringWithMarker *structure)
{
    // проверка на дурацкие случаи
    int checker = 0;
    char *first_open_bracket = nullptr;
    char *last_closing_bracket = nullptr;
    bool is_expression = false;
    
    for (int i = 0; i < structure->count_of_elements; i++) {
        char *element = structure->str+i;
        if (*element == '(') {
            checker++;
        }
        if (*element == ')') {
            checker--;
            if (checker < 0) {
                break;
            }
        }
        //проверка вхождений логических операторов
        if (checker > 0) {
            if (*element == '&' && *(element+1) == '&') {
                is_expression = true;
            }
            if (*element == '|' && *(element+1) == '|') {
                is_expression = true;
            }
            if (*element == '!' && *(element+1) != '=') {
                is_expression = true;
            }
        }
        //установка внешних скобок
        if (first_open_bracket == nullptr && checker > 0) {
            first_open_bracket = element;
        }
        if (first_open_bracket != nullptr && last_closing_bracket == nullptr && checker == 0) {
            last_closing_bracket = element;
            break;
        }
    }
    //формирование результата
    if (first_open_bracket != nullptr && last_closing_bracket != nullptr) {
        if (checker == 0) {
            if (is_expression == false) {
                structure->result = ResultOperatorNotFound;
            } else {
                structure->evaluatedElements = last_closing_bracket-(first_open_bracket+1);
                structure->result = ResultOK;
            }
        } else {
            structure->result = ResultNotOK;
        }
    } else {
        structure->result = ResultNotOK;
    }
    
}

void outStringWithMarker(std::fstream &out_file, StringWithMarker *structure)
{
    switch (structure->result) {
        case ResultOK:
            std::cout << "Длина логического оператора (в знаках) равна: " << structure->evaluatedElements << "\n";
            out_file << "Длина логического оператора (в знаках) равна: " << structure->evaluatedElements << "\n";
            break;
        case ResultNotOK:
            std::cout << "Выражение некорректно, обработка строки невозможна\n";
            out_file << "Выражение некорректно, обработка строки невозможна\n";
            break;
        case ResultOperatorNotFound:
            std::cout << "Обрабатываемая строка не содержит логический оператор\n";
            out_file << "Обрабатываемая строка не содержит логический оператор\n";
            break;
            
        default: break;
    }
}



