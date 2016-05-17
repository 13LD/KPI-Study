//
//  main.cpp
//  Solution 39
//
//  Created by  Lysogor Dima on 06.03.15.
//  Copyright (c) 2015  Lysogor Dima. All rights reserved.
//

#include <iostream>
#include <stdio.h>
#define N 1001


bool angelTriangel(int a, int b, int c){
    return a*a + b*b == c*c;
}

int main() {
    int SUM;
    int s = 0;
    int MAXSUM = 0;
    for(SUM = 3;SUM < N;++SUM){
        int solution = 0;
        for (int a = 1; a < SUM; ++a) {
            for (int b = a; b < SUM; ++b) {
                int c = SUM - b - a;
                if (angelTriangel(a,b,c)) {
                    solution++;
                }
            }
        }
        if (solution > s) {
            s = solution;
            MAXSUM = SUM;
        }
    }
    printf("%d\n",MAXSUM);
    return 0;
}
