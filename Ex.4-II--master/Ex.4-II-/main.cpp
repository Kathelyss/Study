//
//  main.cpp
//  Ex.4-II-
//
//  Created by Thorax on 06.04.15.
//  Copyright (c) 2015 Thorax. All rights reserved.
//

#include <iostream>
#include "MyList.h"

int main()
{
    MyList *list = newList();
    list->data = 1;
    
    for (int i = 2; i < 10; i++) {
        push(list, i);
    }
    
    printf("Count of elements in list is %ld", listCount(list));
    printList(list);
    pop(list);
    printList(list);

    freeList(list);
    return 0;
}