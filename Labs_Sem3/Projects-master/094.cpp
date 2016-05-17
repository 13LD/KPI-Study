//
//  main.cpp
//  Solution 94
//
//  Created by  Lysogor Dima on 04.03.15.
//  Copyright (c) 2015  Lysogor Dima. All rights reserved.
//

#include<stdio.h>
#include<math.h>

long contribution(long x) {
    long c = 0;

    long temp = 3 * x * x - (2 * x) - 1;
    long root = (long)sqrt((double)temp);
    if (root * root == temp) {
        c += 3 * x + 1;
    }
  
    temp = 3 * x * x + (2 * x) - 1;
    root = (long)sqrt((double)temp);
    if (root * root == temp) {
        c += 3 * x - 1;
    }
    return c;
}
int main() {
    long ans = 0;
    for (long i = 3; i * 3 < 1000000000; i+=2) {
        ans += contribution(i);
    }
    printf("%ld\n", ans);
    return 0;
}
