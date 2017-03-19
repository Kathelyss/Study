/*
 Автор: Рыжова Екатерина, группа 4302
 Даты: начало разработки: 11.11; окончание разработки: 16.11;
 Версия: 1
 Формулировка задания: Определить, является ли заданная матрица А размера NxM
 ортонормированной.
 */

#include <iostream>
#include <fstream>

unsigned const N = 3, M = 4;

using namespace std;
// объявление функций:
// чтение исходных данных из файла
void readFile(fstream& in_file, fstream& out_file, int& n, int m, int Array[N][M]);
// операция определения ортонормированности
bool ortogonal(int n, int m, int Array[N][M]);
// вывод результата в выходной файл
void writeResult(fstream& out_file, bool orto);

int main (void)

{
    cout << "Автор: Рыжова Екатерина, группа 4302 \n";
    cout << "Даты: начало разработки: 11.11; окончание разработки: 16.11\n";
    cout << "Версия: 1\n";
    cout << "Формулировка задания: Определить, является ли заданная матрица А размера NxM ортонормированной.\n";
    cout << "Примечание: матрица является ортонормированной, " << "если скалярное произведение каждой пары различных строк равно 0, " << "а скалярное произведение каждой строки на себя равно 1.\n\n";
    cout << "Дальнейшие результаты работы программы смотрите в файле out.txt\n\n";
    
    int A[N][M], n, m;
    fstream in_file, out_file;
    in_file.open ("in.txt", ios::in); // открытие исходного файла на чтение
    if (!in_file) {
        cout << "Ошибка при открытии исходного файла\n";
    } else {
        in_file >> n >> m; // считывание размера матрицы
        out_file.open ("out.txt", ios::out); // открытие выходного файла на запись
        if (!out_file) {
            cout << "Ошибка при открытии выходного файла\n";
        } else {
            if ((n <= 0) || ( m <= 0)) { // проверка корректности значений размера массива
                n = 0; m = 0;
                out_file << "Ошибка: формируется массив из 0 элементов\n\n";
                return 1;
            }
        }
    }
    readFile(in_file, out_file, n, m, A);
    in_file.close();
    bool orto = ortogonal(n, m, A);
    writeResult(out_file, orto);
    out_file.close();
    return 0;
}

#pragma mark - Описание функций

/**
 чтение исходных данных из файла
 n передается со знаком &: если значение n изменится в функции,
 оно изменится и в остальной программе
 */
void readFile(fstream& in_file, fstream& out_file, int& n, int m, int Array[N][M])
{
    int t;
    out_file << "Исходные данные:\n\n";
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < m; j++) {
            if (in_file >> t) {
                Array[i][j] = t;
                if (n > N) {
                    cout << "Ошибка: количество строк превышает допустимый размер, обрабатывается массив из " << N << " строк\n\n";
                    n = N;
                }
            } else {
                if (j < m) {
                    cout << "Недостаточно значений в " << n << "-й строке." << endl;
                    cout << "Должно быть " << m << ", считано " << j << endl;
                    n--;
                    cout << "Для корректной работы программы количество строк сокращено до " << n << endl;
                    break;
                }
            }
        }
        // игнорирование всех знаков после обусловленного в файле количества символов
        in_file.ignore(numeric_limits<streamsize>::max(),'\n');
    }
    
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < m; j++) {
            out_file << Array[i][j] << " ";
        }
        out_file << endl;
    }
}

/**
 операция определения ортонормированности
 */
bool ortogonal(int n, int m, int Array[N][M])
{
    bool sqr = false; //A1^2
    for (int i = 0; i < n; i++) {
        int sum = 0;
        for (int j = 0; j < m; j++){
            int elem = Array[i][j];
            int sqr_elem = elem*elem; // квадрат элемента
            if (sqr_elem == 0 || sqr_elem == 1) {
                sum += elem*elem;
            } else {
                return false;
            }
        }
        if (sum == 1) {
            sqr = true;
        } else return false;
    }
    int sum = 0;
    for (int i = 0; i < m; i++) { // "палец" на столбец
        for (int j = 0; j < n; j++){ // "палец" на строку
            for (int k = j+1; k < n; k++) {// "палец" на строку+1
                sum += Array[j][i]*Array[k][i];
                if (sum != 0) return false;
            }
        }
        if (sum == 0 && sqr) return true;
    }
    return false;
}

/**
 вывод результата в выходной файл
 */
void writeResult(fstream& out_file, bool orto)
{
    if (orto)
        out_file << "\nДанная матрица является ортонормированной";
    else
        out_file << "\nДанная матрица не является ортонормированной";
}
