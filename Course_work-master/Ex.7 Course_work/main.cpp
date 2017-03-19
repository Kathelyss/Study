/*
 Автор: Рыжова Екатерина, группа 4302;
 Даты: начало разработки: 1.12; окончание разработки: 8.12;
 Версия: 1;
 Формулировка задания: Дано N точек на плоскости. Для всех треугольников,
 образуемых любыми тремя точками, найти точки, располагающиеся внутри треугольников.
 */

#include <stdio.h>
#include <fstream>
#include <sstream>
#include <cmath>

//using namespace std;

unsigned const N = 2, M = 50;

void inputData(fstream& result, fstream& not_belongs, int dots, double Array[N][M]);
int trianglesWithDots(int dots);
bool dotBelongsToTriangle(double dx, double dy, double ax, double ay, double bx, double by, double cx, double cy);
double square(double ax, double ay, double bx, double by, double cx, double cy);

int main()
{
    cout << "Автор: Рыжова Екатерина, группа 4302 \n";
    cout << "Даты: начало разработки: 1.12; окончание разработки: 8.12\n";
    cout << "Версия: 1;\n";
    cout << "Формулировка задания: Дано N точек на плоскости. Для всех треугольников,\n" << "образуемых любыми тремя точками, найти точки, располагающиеся внутри треугольников.\n";
    cout << "Дальнейшие результаты работы программы смотрите в файлах point_well, point_bad, result, not_belongs.\n\n";
    
    fstream in_file, point_well, point_bad, result, not_belongs;
    
    double Array[N][M], x, y;
    
    in_file.open ("in_file.txt", ios::in);
    point_well.open ("point_well.txt", ios::out);
    point_bad.open ("point_bad.txt", ios::out);
    if ((!in_file) || (!point_well) || (!point_bad)) {
        cout << "Ошибка при открытии одного из основных файлов, дальнейшая работа невозможна.\n";
        return 1;
    } else {
        int dots = 0;
        string str;
        int badPoints = 0;
        point_bad << "Некорректные значения исходных данных:";
        bool pointIsBad = false;
        while (getline(in_file, str)) {
            if (stringstream(str) >> x >> y) {
                pointIsBad = false;
                for (int i = 0; i < dots; i++) {
                    if ((x == Array[0][i]) && (y == Array[1][i])) {
                        pointIsBad = true;
                        badPoints++;
                        break;
                    }
                }
                if (pointIsBad) {
                    point_bad <<"\nТочка {" << x << ";" << y << "} не включается в рассмотрение т. к. повторяется.";
                    continue;
                }
                Array[0][dots] = x;
                Array[1][dots] = y;
                dots++;
            } else
            {
                point_bad << "\n\"" << str << "\" не включается в рассмотрение из-за некорректности данных.";
                badPoints++;
            }
        }
        if (badPoints == 0) point_bad << " отсутствуют.";
        for (int i = 0; i < dots; i++) {
            point_well << Array[0][i] << " " << Array[1][i] << endl;
        }
        in_file.close();
        
        // проверка количества треугольников, которые можно создать из получившегося количества точек
        int triangles_count = trianglesWithDots(dots);
        cout << "Количество гипотетических треугольников: " << triangles_count << endl;
        result.open("result.txt", ios::out);
        not_belongs.open("not_belongs", ios::out);
        if (!result || !not_belongs) {
            cout << "Ошибка при открытии файлов на запись результатов.\n";
            return 1;
        } else {
            // проверка записи в массив (корректные точки)
            inputData(result, not_belongs, dots, Array);
            // создание треугольников
            int idx = 1;
            bool hasDotsInside = false, hasDotsOutside = false;
            for (int i = 0; i < dots; i++)
                for (int j = i+1; j < dots; j++)
                    for (int k = j+1; k < dots; k++) {
                        double ax = Array[0][i];
                        double ay = Array[1][i];
                        double bx = Array[0][j];
                        double by = Array[1][j];
                        double cx = Array[0][k];
                        double cy = Array[1][k];
                        if (!square(ax, ay, bx, by, cx, cy)) continue;
                        bool dot_inside = false, dot_outside = false;
                        for (int l = 0; l < dots; l++) {
                            double dx = Array[0][l];
                            double dy = Array[1][l];
                            if ((dx != ax || dy != ay) && (dx != bx || dy != by) && (dx != cx || dy != cy)) {
                                
                                bool belongs = dotBelongsToTriangle(dx, dy, ax, ay, bx, by, cx, cy);
                                if (belongs) {
                                    hasDotsInside = true;
                                    dot_inside = true;
                                    result << "Точка {" << dx << ";" << dy << "}\n";
                                } else {
                                    hasDotsOutside = true;
                                    dot_outside = true;
                                    not_belongs << "Точка {" << dx << ";" << dy << "}\n";
                                }
                            }
                        }
                        
                        if (dot_inside) {
                            result << "принадлежит треугольнику " << idx <<" с координатами : A{" << ax << ";" << ay << "} B{" << bx << ";" << by << "} C{" << cx << ";" << cy << "}.\n\n";
                        }
                        if (dot_outside) {
                            not_belongs << "не принадлежит треугольнику " << idx << " с координатами : A{" << ax << ";" << ay << "} B{" << bx << ";" << by << "} C{" << cx << ";" << cy << "}.\n\n";
                        }
                        idx++;
                    }
            cout << "Реальное количество треугольников: " << idx-1 << endl << endl;
            if (idx-1 == 0) {
                result << "Невозможно сформировать треугольники.\n";
                not_belongs << "Невозможно сформировать треугольники.\n";
            }
            if (idx-1 == 1) {
                result << "Недостаточно точек для проверки их принадлежности треугольнику.\n";
                not_belongs << "Недостаточно точек для проверки их принадлежности треугольнику.\n";
            }
            if ((!hasDotsOutside) && !(idx-1 == 0) && !(idx-1 == 1)) not_belongs << "Все точки принадлежат треугольнику(-кам).";
            if ((!hasDotsInside) && !(idx-1 == 0) && !(idx-1 == 1)) result << "Ни одна из точек не принадлежит треугольнику(-кам).";
        }
        point_well.close();
        point_bad.close();
        result.close();
        not_belongs.close();
    }
    
    return 0;
}

// вывод исходных данных
void inputData(fstream& result, fstream& not_belongs, int dots, double Array[N][M])
{
    result << "Координаты точек: \n";
    not_belongs << "Координаты точек:\n";
    for (int t = 0; t < dots; t++) {
        result << t+1 << ". {" << Array[0][t] << ";" << Array[1][t] << "}\n";
        not_belongs << t+1 << ". {" << Array[0][t] << ";" << Array[1][t] << "}\n";
    }
    result << endl;
    not_belongs << endl;
}

// подсчет количества треуг по количеству точек
int trianglesWithDots(int dots)
{
    return dots*(dots-1)*(dots-2)/6;
}

// принадлежность точки треугольнику
bool dotBelongsToTriangle(double dx, double dy, double ax, double ay, double bx, double by, double cx, double cy)
{
    double S, S1, S2, S3;
    double eps = 0.0001;
    S = square(ax, ay, bx, by, cx, cy);
    if (S == 0) return false;
    S1 = square(ax, ay, bx, by, dx, dy);
    S2 = square(ax, ay, dx, dy, cx, cy);
    S3 = square(dx, dy, bx, by, cx, cy);
    if ((S1 <= eps) || (S2 <= eps) || (S3 <= eps)) return false;
    double result = fabs((S - (S1+S2+S3)));
    return result <= eps;
}

// расчет площади треугольника
double square(double ax, double ay, double bx, double by, double cx, double cy)
{
    return fabs(((bx-ax)*(cy-ay) - (cx-ax)*(by-ay)))/2;
}
