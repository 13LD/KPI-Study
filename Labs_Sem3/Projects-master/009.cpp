//
//  main.cpp
//  Solution 9
//
//  Created by  Lysogor Dima on 04.03.15.
//  Copyright (c) 2015  Lysogor Dima. All rights reserved.
//

#include <stdio.h>
#include <iostream>
#include <math.h>
#define ABC 1000

bool triplet(int a, int b, int c){
    return pow(a,2) + pow(b,2) == pow(c,2);
}

int main()
{
    for(int a=1;a<ABC;++a){
        for(int b=a;b<ABC;++b){
            int c = ABC - b - a;
            if (triplet(a, b, c)){
                printf("%3d,%3d,%3d\n",a,b,c);
                printf("%d\n",a*b*c);
            }
        }
    }
    return 0;
}
//31875000
