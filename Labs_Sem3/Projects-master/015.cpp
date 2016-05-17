//
//  main.cpp
//  Solution 15
//
//  Created by  Lysogor Dima on 04.03.15.
//  Copyright (c) 2015  Lysogor Dima. All rights reserved.
//

#include <stdio.h>
#include <iostream>
#define N 22

int64_t Array[N][N];

int main(){
    for (int i = 0; i < N; ++i)
        for (int j = 0; j < N; ++j)
            Array[i][j] = 0;
    Array[1][1] = 1;
    for (int i = 1; i < N; ++i){
        for (int j = 1; j < N; ++j){
            if (i == j && i == 1)
                continue;
            Array[i][j] = Array[i - 1][j] + Array[i][j - 1];
        }
    }
    printf("%lld\n", Array[N-1][N-1]);
    return 0;
}
