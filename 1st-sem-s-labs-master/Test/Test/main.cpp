/*
    Автор: Рыжова Екатерина, группа 4302, rubicante@icloud.com
    Даты: начало разработки: 15.09; кончание разработки: 20.09
    Версия: 1
    Формулировка задания: Получить значение выражения по заданной формуле с применением схемы Горнера:
    P(x)=(9.09*x^8+9.09*x^6-9.09*x^4+9.09*x^2)/(9.09*x^9+9.09*x^7-9.09*x^3+9.09*x)
*/
#include <stdio.h>

int main (void) // void main (void)
{
    double x, p1, p2, P, z, z2;
    printf ("%s\n", "Автор: Рыжова Екатерина, группа 4302, rubicante@icloud.com");
    printf ("%s\n", "Даты: начало разработки: 15.09; окончание разработки: 20.09");
    printf ("%s\n", "Версия: 1");
    printf ("%s%s\n", "Формулировка задания: Получить значение выражения по заданной формуле \n с применением схемы Горнера:", "\n P(x)=(9.09*x^8+9.09*x^6-9.09*x^4+9.09*x^2)/(9.09*x^9+9.09*x^7-9.09*x^3+9.09*x)");
    printf ("%s\n", "Введите x ( !=0 ):");
    scanf ("%lf", &x);
    z=x*x;
    z2=z*z;
    p1= 9.09*z+9.09;
    printf ("%s%.3f\n", "1-е промежуточное значение = \t\t", p1);
    p1=p1*z-9.09;
    printf ("%s%.3f\n", "2-е промежуточное значение = \t\t", p1);
    p1=p1*z+9.09;
    printf ("%s%.3f\n", "3-е промежуточное значение = \t\t", p1);
    p1=p1*z;
    printf ("%s%.3f\n", "4-е промежуточное значение (числитель) = \t", p1);
    p2=9.09*z+9.09;
    printf ("%s%10.3f\n", "5-е промежуточное значение = ", p2);
    p2=p2*z2-9.09;
    printf ("%s%10.3f\n", "6-е промежуточное значение = ", p2);
    p2=p2*z+9.09;
    printf ("%s%10.3f\n", "7-е промежуточное значение = ", p2);
    p2=p2*x;
    printf ("%s%10.3f\n", "8-е промежуточное значение (знаменатель) = ", p2);
    P=p1/p2;
    printf ("%s%.3f%s%10.3f\n", "Результат вычислений P(", x,")=", P);
   
    return 0; // удалить
}
