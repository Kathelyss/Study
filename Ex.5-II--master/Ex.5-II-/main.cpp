/*
 Автор: Екатерина Рыжова, группа 4302
 Даты: начало разработки: 16.04; окончание разработки: 16.04
 Версия: 1
 Формулировка задания: В списке из каждой группы подряд идущих одинаковых
 элементов оставить только один.
 */

#include "MyList.h"

int main()
{
    //    cout << "Автор: Екатерина Рыжова, группа 4302\n";
    //    cout << "Даты: начало разработки: 16.04; окончание разработки: 16.04\n";
    //    cout << "Версия: 1\n";
    //    cout << "Формулировка задания: В списке из каждой группы подряд идущих\nодинаковых элементов оставить только один\n";
    
    //создание первоначальных элементов
    Elem *list;
    Formular formular;
    initEmpty(formular);
    
    fstream in_file, out_file;
    
    in_file.open("in.txt", ios::in);
    if (!in_file) {
        cout << "Ошибка при открытии исходного файла";
        return 1;
    } else {
        //получить значения из файла
        past(list, formular, in_file);
        
        out_file.open("out.txt", ios::out);
        if (!out_file) {
            cout << "Ошибка при открытии выходного файла";
            return 1;
        } else {
            out_file << "Исходные данные:\n\n";
            printList(formular, out_file);
            
            //удалить повторяющиеся элементы
            processList(list, formular);
            out_file << "\n- - - - - - - - - - - - - - - - -\n\n" << "Результат:\n\n";
            printList(formular, out_file);
            
            if(!isEmpty(formular)) {
                cleaning(formular);
            }
        } out_file.close();
    } in_file.close();
    return 0;
}
