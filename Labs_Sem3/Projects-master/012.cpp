//
//  main.cpp
//  Solution 12
//
//  Created by  Lysogor Dima on 04.03.15.
//  Copyright (c) 2015  Lysogor Dima. All rights reserved.
//

#include <cstdio>
#include <cmath>
#include <iostream>

int get_num_divisors(int num){
    int counter = 0;
    int running = 1;
    while (running <= sqrt(num)) {
        if (!(num % running))
            counter++;
        running++;
    }
    return counter;
}

int main(){
    int last = 500;
    last /= 2;
    int num = 0;
    int i = 0;
    int j = 1;
    while (num < last) {
        i = i + j;
        num = get_num_divisors(i);
        j++;
    }
    printf("%d\n", i);
    return(0);
}
