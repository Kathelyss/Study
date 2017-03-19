/*«адание: ¬ывести двоичное представление числа (символа) на экран. 
  ”становить разр€ды (0/1), количество и номера которых ввод€тс€ с клавиатуры.
  ѕрименить функции раскраски символов в консоли.*/
#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <limits.h> 
#include <conio.h>
#include <Windows.h>
#include <math.h>

union DataType {
	char _char;
	int _int;
	float _float;
	double _double;
	unsigned int _unsigned_int;
	long long int _lli;
};
enum ConsoleColor {
	Black = 0,
	Blue = 1,
	Green = 2,
	Cyan = 3,
	Red = 4,
	Magenta = 5,
	Brown = 6,
	LightGray = 7,
	DarkGray = 8,
	LightBlue = 9,
	LightGreen = 10,
	LightCyan = 11,
	LightRed = 12,
	LightMagenta = 13,
	Yellow = 14,
	White = 15
};

void setColor(int text, int background) {
	HANDLE hand_output = GetStdHandle(STD_OUTPUT_HANDLE);
	SetConsoleTextAttribute(hand_output, (WORD)((background << 4) | text));
}
void checkColorInput(int &color) {
	while ((color > 16) || (color < 1))
	{
		printf("Please, enter right value: ");
		scanf("%d", &color);
	}
}
void chooseColors(int &background_color, int &text_color, int &changed_color, bool changed_exists)
{
	//вывод цветовой палитры на экран
	for (int i = 0; i < 16; i++)
	{
		setColor(White, (ConsoleColor)i);
		printf("\n         ");
		setColor(White, Black);
		printf(" - %d", i + 1);
	}

	printf("\nChoose background color: ");
	scanf("%d", &background_color);

	checkColorInput(background_color);

	printf("Choose textcolor: ");
	scanf("%d", &text_color);
	checkColorInput(text_color);

	if (changed_exists) {
		printf("Choose color for changed bits: ");
		scanf("%d", &changed_color);
		checkColorInput(changed_color);
	}
	else changed_color = text_color;
}

void printBinary(int bytes, DataType data) {
	long long int one = 1;
	for (int i = bytes * 8 - 1; i >= 0; i--) {
		printf("%d", !!(data._lli & (one << i)));
	}
}
void printBinaryColored(int bytes, DataType data, int *changed_bit_number, int count, int backgroundcolor, int textcolor, int changedcolor) {
	setColor(textcolor, backgroundcolor);
	long long int one = 1;
	for (int i = bytes*8 - 1; i >= 0; i--) {
		bool changed_bit = false;
		for (int x = 0; x < count; x++) {
			if (changed_bit_number[x] == i) {
				changed_bit = true;
				break;
			} else changed_bit = false;
		}
		if (changed_bit) {
			setColor(changedcolor, backgroundcolor); //если бит был изменен, то мен€ем цвет текста
			printf("%d", !!(data._lli & (one << i)));
			setColor(textcolor, backgroundcolor);
		} else {
			printf("%d", !!(data._lli & (one << i)));
		}
	}
	setColor(textcolor, backgroundcolor);
	setColor(White, Black);
}

int *setBits(int bytes, DataType &data, int count) {
	int num = 0;								//номер разр€да
	char set_to;								//во что устанавливать (0/1)			 
	int *changed_bits_numbers = new int(count);

	if (count < 0 || count > bytes * 8) {		//установить можно n разр€дов
		printf("Error: exceeded count's value range of digits!");
	}
	else {
		int c = 0;								//дл€ нагл€дности вывода
		int i = 0;								//счетчик итераций - установок разр€дов
		while (i < count) {						//пока число установленных разр€дов меньше за€вленного
			printf("%d) Digit to set: ", ++c);
			scanf(" %d", &num);
						
			if (num < 0 || num >= bytes * 8) {	//но номер разр€да не больше n-1 
				printf("Error: exceeded count's value range of digits!");
			}
			else {
				changed_bits_numbers[i] = num;  //запомнили номер измен€емого бита
				printf("Set to (0/1): ");		//во что устанавливаем
				scanf(" %c", &set_to);

				long long int one = 1;
				if (set_to == '0') {
					data._lli &= ~(one << num);
				}
				else if (set_to == '1') {
					data._lli |= (one << num);
				}
				else 
					printf("Error: unexpected symbol! This (%d) bit wouldn't be changed.\n", i);
			}
			i++;
		}
	}
	return changed_bits_numbers;
}
void colorBits(int bytes, DataType data, int count, int *changed_bits_numbers, bool changed_exists) {
	int backgroundcolor, textcolor, changedcolor;
	chooseColors(backgroundcolor, textcolor, changedcolor, changed_exists); //выбор цветов дл€ раскраски
	printBinaryColored(bytes, data, changed_bits_numbers, count, backgroundcolor - 1, textcolor - 1, changedcolor - 1); //вывод раскрашенного двоичного представлени€ на экран
}

int main() {
	bool repeat = true;			// продолжать ли работу с программой
	char set_bits = 'n';		// устанавливать ли биты
	char color_bits = 'n';		// раскрашивать ли двоичное представление числа

	while (repeat) {
		bool changed_exists = false;//были ли изменены биты
		int choosen_data_type = 0;
		printf("Choose type of data:\n1 - char;\n2 - int;\n3 - float;\n4 - double;\n5 - unsigned int.\n");
		scanf(" %d", &choosen_data_type);

		DataType data;
		int count_of_digits_to_set = 0; //количество разр€дов дл€ установки
		int *changed_bits_numbers = new int(count_of_digits_to_set);

		switch (choosen_data_type) {
			case 1: { //char
				printf("Input symbol:\n");				
				data._char = _getch();
				printBinary(sizeof(data._char), data);
				break;
			}
			case 5: { //unsigned int
			long long tmp = 0;
			printf("Input number: ");
				scanf("%lli", &tmp);
				if (tmp < 0 || tmp > UINT_MAX) {
					printf("\nError: exceeded the value range of unsigned int!");
					break;
				}
				data._unsigned_int = (unsigned)tmp;
				printBinary(sizeof(data._unsigned_int), data);
				break;
			}
			case 3: { //float
				printf("Input number: ");
				scanf("%f", &data._float);
				printBinary(sizeof(data._float), data);
				break;
			}
			////втора€ и треть€ части задани€
			case 2: { //int
				printf("Input number: ");
				int tmp = 0;
				scanf("%d", &tmp);
				if (tmp > INT_MAX || tmp < INT_MIN) {
					printf("\nError: exceeded value range of int (long)!");
					break;
				}
				data._int = (int)tmp;
				printBinary(sizeof(data._int), data);

				printf("\nDo you want to set bits? (Y/N) ");
				scanf(" %c", &set_bits);
				if (set_bits == 'y' || set_bits == 'Y') {
					printf("Input count of digits to set: ");
					scanf(" %d", &count_of_digits_to_set);
					if (count_of_digits_to_set > 0) changed_exists = true;

					changed_bits_numbers = setBits(sizeof(data._int), data, count_of_digits_to_set);

					printBinary(sizeof(data._int), data);
					printf("\nNew value is: %d", data._int);
				}

				printf("\nDo you want to color digits? (Y/N) ");
				scanf(" %c", &color_bits);
				if (color_bits == 'y' || color_bits == 'Y') {
					colorBits(sizeof(data._int), data, count_of_digits_to_set, changed_bits_numbers, changed_exists);
				} 
				break;
			}
			case 4: { //double
				printf("Input number: ");
				/*
				int tmp = 0;
				scanf("%lf", &tmp);
				if (tmp > DOUBLE_MAX || tmp < ) {
					printf("\nError: exceeded value range of double!");
					break;
				}
				data._double = (double)tmp;
				*/
				scanf("%lf", &data._double);
				printBinary(sizeof(data._double), data);

				printf("\nDo you want to set bits? (Y/N) ");
				scanf(" %c", &set_bits);
				if (set_bits == 'y' || set_bits == 'Y') {
					printf("Input count of digits to set: ");
					scanf(" %d", &count_of_digits_to_set);
					if (count_of_digits_to_set > 0) changed_exists = true;

					changed_bits_numbers = setBits(sizeof(data._double), data, count_of_digits_to_set);

					printBinary(sizeof(data._double), data);
					printf("\nNew value is: %.25lf", data._double);
				}

				printf("\nDo you want to color digits? (Y/N) ");
				scanf(" %c", &color_bits);
				if (color_bits == 'y' || color_bits == 'Y') {
					colorBits(sizeof(data._double), data, count_of_digits_to_set, changed_bits_numbers, changed_exists);
				}
				break;
			}
			default: {
				printf("Error: unexpected sybmol!");
				int f = getchar();
			}
		}
		
		char temp;
		printf("\nDo you want to run this program again? (Y/N) ");
		scanf(" %c", &temp);
		if (temp == 'y' || temp == 'Y') repeat = true;
		else repeat = false;
	}
	return 0;
}