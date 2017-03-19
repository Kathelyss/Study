/*
 Автор: Рыжова Екатерина, группа 4302, rubicante@icloud.com
 Даты: начало разработки: 22.09; окончание разработки: 27.09
 Версия: 1
 Формулировка задания: Для заданного числового значения установить бит
 с указанным номером при использовании типа long int.
*/

#include <iostream> // <iostream.h>

using namespace std; // удалить

int main (void) // void main (void)
{
 // cout << sizeof(long int)*8 << "\n";
    long int number, z;
    int position;
    cout << "Автор: Рыжова Екатерина, группа 4302, rubicante@icloud.com \n";
    cout << "Даты: начало разработки: 22.09; окончание разработки: 27.09 \n";
    cout << "Версия: 1 \n";
    cout << "Формулировка задания: Для заданного числового значения установить бит \n" << "с указанным номером при использовании типа long int. \n";
    z = 1;
    z <<= sizeof(int)*8-1; // ПОМЕНЯТЬ НА ЛОНГ ИНТ!!!
    cout << "Введите число, принадлежащее промежутку [-2147483648 ; 2147483647]: \n";
    cin >> number;
    cout << (z&number? "1":"0"); //1
    z >>= 1;
    cout << (z&number? "1":"0"); //2
    z >>= 1;
    cout << (z&number? "1":"0"); //3
    z >>= 1;
    cout << (z&number? "1":"0"); //4
    z >>= 1;
    cout << (z&number? "1":"0"); //5
    z >>= 1;
    cout << (z&number? "1":"0"); //6
    z >>= 1;
    cout << (z&number? "1":"0"); //7
    z >>= 1;
    cout << (z&number? "1":"0"); //8
    z >>= 1;
    cout << (z&number? "1":"0"); //9
    z >>= 1;
    cout << (z&number? "1":"0"); //10
    z >>= 1;
    cout << (z&number? "1":"0"); //11
    z >>= 1;
    cout << (z&number? "1":"0"); //12
    z >>= 1;
    cout << (z&number? "1":"0"); //13
    z >>= 1;
    cout << (z&number? "1":"0"); //14
    z >>= 1;
    cout << (z&number? "1":"0"); //15
    z >>= 1;
    cout << (z&number? "1":"0"); //16
    z >>= 1;
    cout << (z&number? "1":"0"); //17
    z >>= 1;
    cout << (z&number? "1":"0"); //18
    z >>= 1;
    cout << (z&number? "1":"0"); //19
    z >>= 1;
    cout << (z&number? "1":"0"); //20
    z >>= 1;
    cout << (z&number? "1":"0"); //21
    z >>= 1;
    cout << (z&number? "1":"0"); //22
    z >>= 1;
    cout << (z&number? "1":"0"); //23
    z >>= 1;
    cout << (z&number? "1":"0"); //24
    z >>= 1;
    cout << (z&number? "1":"0"); //25
    z >>= 1;
    cout << (z&number? "1":"0"); //26
    z >>= 1;
    cout << (z&number? "1":"0"); //27
    z >>= 1;
    cout << (z&number? "1":"0"); //28
    z >>= 1;
    cout << (z&number? "1":"0"); //29
    z >>= 1;
    cout << (z&number? "1":"0"); //30
    z >>= 1;
    cout << (z&number? "1":"0"); //31
    z >>= 1;
    cout << (z&number? "1":"0") << "\n"; //32 (икс выведен)
    cout << "Введите позицию для изменения (от 32 до 1): \n";
    cin >> position;
    z <<= (position-1);
    // cout << "число = " << bitset<sizeof(int)*8>(number) << endl;
    //cout << "z = " << bitset<sizeof(int)*8>(number) << endl;
    cout << "Устанавливаем бит: \n";
    number |= z;
   // cout << "проверка " << bitset<sizeof(int)*8>(number) << endl;
    //number = (position == 32) ? ~number+1 : number | z; // вариант для инверсии
    z = 1;
    z <<= (sizeof(int)*8-1);
    cout << (z&number? "1":"0"); //1
    z >>= 1;
    cout << (z&number? "1":"0"); //2
    z >>= 1;
   cout << (z & number? "1":"0"); //3
    z >>= 1;
    cout << (z&number? "1":"0"); //4
    z >>= 1;
    cout << (z&number? "1":"0"); //5
    z >>= 1;
    cout << (z&number? "1":"0"); //6
    z >>= 1;
    cout << (z&number? "1":"0"); //7
    z >>= 1;
    cout << (z&number? "1":"0"); //8
    z >>= 1;
    cout << (z&number? "1":"0"); //9
    z >>= 1;
    cout << (z&number? "1":"0"); //10
    z >>= 1;
    cout << (z&number? "1":"0"); //11
    z >>= 1;
    cout << (z&number? "1":"0"); //12
    z >>= 1;
    cout << (z&number? "1":"0"); //13
    z >>= 1;
    cout << (z&number? "1":"0"); //14
    z >>= 1;
    cout << (z&number? "1":"0"); //15
    z >>= 1;
    cout << (z&number? "1":"0"); //16
    z >>= 1;
    cout << (z&number? "1":"0"); //17
    z >>= 1;
    cout << (z&number? "1":"0"); //18
    z >>= 1;
    cout << (z&number? "1":"0"); //19
    z >>= 1;
    cout << (z&number? "1":"0"); //20
    z >>= 1;
    cout << (z&number? "1":"0"); //21
    z >>= 1;
    cout << (z&number? "1":"0"); //22
    z >>= 1;
    cout << (z&number? "1":"0"); //23
    z >>= 1;
    cout << (z&number? "1":"0"); //24
    z >>= 1;
    cout << (z&number? "1":"0"); //25
    z >>= 1;
    cout << (z&number? "1":"0"); //26
    z >>= 1;
    cout << (z&number? "1":"0"); //27
    z >>= 1;
    cout << (z&number? "1":"0"); //28
    z >>= 1;
    cout << (z&number? "1":"0"); //29
    z >>= 1;
    cout << (z&number? "1":"0"); //30
    z >>= 1;
    cout << (z&number? "1":"0"); //31
    z >>= 1;
    cout << (z&number? "1":"0") << "\n"; //32 (число выведено)
    cout << "В десятичном представлении является числом: \n" << number << "\n";
    
    return 0; //удалить
}
