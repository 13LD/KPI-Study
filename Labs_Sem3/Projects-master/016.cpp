//
//  main.cpp
//  Solution 16
//
//  Created by  Lysogor Dima on 05.03.15.
//  Copyright (c) 2015  Lysogor Dima. All rights reserved.
//

#include <iostream>
#include <stdio.h>

#define N 1000

char Array[400] = {0};
char one = 0;

int main()
{
    Array[0] = 2;
    for (int i = 1; i < N; i++)
    {
        for (int j = 0; j < 400; j++)
        {
            Array[j] = Array[j]*2 + one;
            if (Array[j] > 9)
            {
                Array[j] -= 10;
                one = 1;
            }
            else one = 0;
        }
        
    }
    int sum = 0;
    for (int j = 0; j < 400; j++)
    {
        sum += Array[j];
    }
    printf("%d\n",sum);
    return 0;
}
