//
//  main.cpp
//  Solution 3
//
//  Created by  Lysogor Dima on 04.03.15.
//  Copyright (c) 2015  Lysogor Dima. All rights reserved.
//

#include <iostream>
#include <stdio.h>
#include <math.h>

int main() {
    int64_t number = 600851475143;
    unsigned int max_prime = 0;
    unsigned int i = 3;
    while (number != 1) {
        if ((number % i)) {
            i += 2;
        } else {
            max_prime = i;
            number = number/i;
        }
    }
    printf("%d\n", max_prime);
    return(0);
}
