/*
 Автор: Екатерина Рыжова, группа 4302
 Даты: начало разработки: 5.03; окончание разработки: 19.03;
 Версия: 1
 Формулировка задания: В строке, среди знаков которой могут встречаться
 круглые скобки, проверить, предшествует ли каждая открывающая скобка
 соответствующей закрывающей.
 */

#include <iostream>
#include <fstream>
#include <string>
#include <locale>

using namespace std;

unsigned const F = 10000;

char *myStrchr (char *str, char symbol);
//открытие файла, считывание строки и подсчет реального числа символов в строке
void inputTextLength (int *const_count, int *real_count, char *str);
//открытие файла, ввод маркера и считывание строки до маркера
void inputTextMarker(int *const_count, char *Mark, char *str);
void processLength(fstream &out_file, char *str, int *const_count);
void processMarker(fstream &out_file, char *str, char marker);
void length();
void marker();
void outResult(fstream &out_file, int opened_bracket, int closed_bracket, int checker);

int main()
{
    setlocale(LC_ALL, "rus");
    char choice;
    //        cout << "Автор: Екатерина Рыжова, группа 4302 \n";
    //        cout << "Даты: начало разработки: 5.03; окончание разработки: 19.03;\n";
    //        cout << "Версия: 1\n";
    //        cout << "Формулировка задания: В строке, среди знаков которой могут встречаться\nкруглые скобки, проверить, предшествует ли каждая открывающая скобка\nсоответствующей закрывающей\n\n";
    cout << "\nВнутреннее представление: введите M, если хотите работать с маркером, либо L, если хотите работать с длиной: ";
    cin >> choice;
    
    if (choice == 'L' || choice == 'l') {
        length();//вызов функции для работы с длиной
    } else {
        if (choice == 'M' || choice == 'm') {
            marker();//вызов функции для работы с маркером
        } else {
            cout << "Ошибка: введен некорректный символ\n";
            return 1;
        }
    }
    return 0;
}

#pragma mark - мои функции

//аналог strchr из string
char *myStrchr (char *str, char symbol)
{
    //    char *symbol_exists = str;
    while (*str) {
        if (*str == symbol) return str;
        str++;
    }
    return nullptr;
}

//открытие файла, считывание строки и подсчет реального числа символов в строке
void inputTextLength (int *const_count, int *real_count, char *str)
{
    fstream in_file ("in.txt", ios::in);
    if (!in_file) {
        cout << "Ошибка при открытии исходного файла\n";
    } else {
        if (!in_file.getline(str, *const_count)) {
            cout << "Ошибка: исходный файл пуст\n";
            exit(1);
        } else {
            in_file.getline(str, *const_count);
            while (*(str+(*real_count)) != '\0')
                (*real_count)++;
        }
    }
    in_file.close();
}

//открытие файла, ввод маркера и считывание строки до маркера
void inputTextMarker(int *const_count, char *Mark, char *str)
{
    fstream in_file ("in.txt", ios::in);
    if (!in_file) {
        cout << "Ошибка при открытии исходного файла\n";
    } else {
        if (!in_file.getline(str, *const_count)) {
            cout << "Ошибка: исходный файл пуст\n";
            exit(1);
        } else {
            cout << "Введите искомый символ: ";
            cin >> (*Mark);
            in_file.getline(str, *const_count);
        }
    }
    in_file.close();
}

//обработка строки с длиной
void processLength(fstream &out_file, char *str, int *const_count)
{
    int opened_bracket = 0, closed_bracket = 0;
    int checker = 0;
    
    for (int i = 0; i < *const_count; i++) {
        if (*(str+i) == '(') {
            opened_bracket++;
            checker++;
        }
        if (*(str+i) == ')') {
            closed_bracket++;
            checker--;
            if (checker < 0) {
                break;
            }
        }
    }
    outResult(out_file, opened_bracket, closed_bracket, checker);
}

//обработка строки с маркером
void processMarker(fstream &out_file, char *str, char marker)
{
    int opened_bracket = 0, closed_bracket = 0;
    int checker = 0;
    
    for (int i = 0; *(str+i) != marker; i++) {
        if (*(str+i) == '(') {
            opened_bracket++;
            checker++;
        }
        if (*(str+i) == ')') {
            closed_bracket++;
            checker--;
            if (checker < 0) {
                break;
            }
        }
    }
    outResult(out_file, opened_bracket, closed_bracket, checker);
}

//вывод результата
void outResult(fstream &out_file, int opened_bracket, int closed_bracket, int checker)
{
    out_file << "\n- - - - - - - - - - - - - - - - -\n\n" << "Результат:\n";
    string mssg;
    if (opened_bracket != 0 || closed_bracket != 0) {
        if (checker == 0) {
            mssg = "\nКаждая открывающая скобка предшествует соответствующей закрывающей\n";
        } else {
            if (checker > 0) {
                mssg = "\nОткрывающих скобок больше, чем закрывающих (не каждая открывающая скобка предшествует соответствующей закрывающей)\n";
            } else {
                mssg = "\nНе каждая открывающая скобка предшествует закрывающей\n";
            }
        }
    } else {
        mssg = "\nОбрабатываемая строка не содержит скобок, или начинается с закрывающей/открывающей скобки\n";
    }
    cout << mssg;
    out_file << mssg;
}


void length()
{
    struct structure
    {
        char array[F+1];
        int len;
    } String;
    
    int real_count = 0, N = F+1;
    String.len = 0;
    
    fstream out_file ("out.txt", ios::out);
    if (!out_file) {
        cout << "Ошибка при открытии выходного файла\n";
    } else {
        char *str = String.array;
        
        inputTextLength(&N, &real_count, str);
        out_file << "Исходные данные:\n\n" << String.array << "\n\n- - - - - - - - - - - - - - - - -\n\n";
        
        fstream in_file1 ("in.txt", ios::in);
        if (in_file1)
        {
            cout << "Введите длину строки для обработки: ";
            cin >> String.len;
            
            //для этого нужен был подсчет real_count в inputTextLength
            if (real_count < String.len) {
                cout << "Ошибка: строка содержит меньше символов, чем было введено; обрабатывается реальное число символов ("<< real_count << ")\n";
                String.len = real_count;
            }
            
            char choice_1;
            cout << "\nВнешнее представление: введите M, если хотите работать с маркером, либо L, если хотите работать с длиной: ";
            cin >> choice_1;
            
            if (choice_1 == 'L' || choice_1 == 'l') {
                in_file1.getline(String.array, String.len+1);
                out_file << "До маркера встречаются следующие символы:\n" << String.array << "\n";
                processLength(out_file, str, &String.len);//вызов функции для работы с длиной
                cout << String.array << "\n";
            } else {
                if (choice_1 == 'M' || choice_1 == 'm') {
                    int numOfIndexOfMarker = String.len, i;
                    char markerViaLength;
                    for (i = 0; (str+i) < (str+numOfIndexOfMarker); i++) {
                        in_file1 << String.array[i];
                        markerViaLength = *(str+i+1);
                    }
                    
                    out_file << "В обозначенной длине (" << String.len << ") до первого вхождения маркера встречаются следующие символы:\n";
                    for (i = 0; *(str+i) != markerViaLength; i++) {
                        cout << String.array[i];
                        out_file << String.array[i];
                    }
                    out_file << "\n";
                    cout << "\nМаркер: " << markerViaLength;
                    processMarker(out_file, str, markerViaLength);//вызов функции для работы с маркером через маркер
                } else {
                    cout << "Ошибка: введен некорректный символ\n";
                    exit(1);
                }
            }
        }
        in_file1.close();
    }
    out_file.close();
}


void marker()
{
    struct structure
    {
        char array[F+1];
        char mark;
    } String;
    
    int N = F+1;
    
    fstream out_file ("out.txt", ios::out);
    if (!out_file) {
        cout << "Ошибка при открытии выходного файла\n";
    } else {
        char *str = String.array;
        char marker = String.mark;
        
        inputTextMarker(&N, &String.mark, str);
        out_file << "Исходные данные:\n\n" << String.array << "\n\n- - - - - - - - - - - - - - - - -\n\n";
        
        fstream in_file1 ("in.txt", ios::in);
        if (in_file1)
        {
            //проверка наличия маркера в строке
            char *searching_marker = myStrchr(str, String.mark);
            
            if (searching_marker == nullptr) {
                cout << "Строка не содержит введенного символа\n";
                out_file << "Строка не содержит введенного символа\n";
                exit(1);
            }
            
            in_file1.getline(String.array, N, String.mark);
            out_file << "До маркера встречаются следующие символы:\n" << String.array << "\n";
            
            int size = int(searching_marker - str);//кол-во символов до маркера
            
            char choice_2;
            cout << "\nВнешнее представление: введите M, если хотите работать с маркером, либо L, если хотите работать с длиной: ";
            cin >> choice_2;
            
            if (choice_2 == 'L' || choice_2 == 'l') {
                //                cout << "Кол-во символов до маркера: " << size;
                processLength(out_file, str, &size);//вызов функции для работы с длиной
            } else {
                if (choice_2 == 'M' || choice_2 == 'm') {
                    processMarker(out_file, str, marker);//вызов функции для работы с маркером
                } else {
                    cout << "Ошибка: введен некорректный символ\n";
                    exit(1);
                }
            }
            cout << String.array << "\n";
        }
        in_file1.close();
    }
    out_file.close();
}