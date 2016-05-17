//
//  main.cpp
//  Solution 7
//
//  Created by  Lysogor Dima on 04.03.15.
//  Copyright (c) 2015  Lysogor Dima. All rights reserved.
//

#include <stdio.h>
#include <math.h>

#define COUNTING_SIZE 20000000


int isaprime (int num) {
    
    int i;
    
    for (i = 2; i <= sqrt(num); i++) {
        if (num % i == 0) {
            return 0;
        }
        else {
            ;
        }
    }
    
    return 1;
}


int main() {
    
    int i;
    long sum = 0;
    long count = 0;
    
    for (i = 2; i < COUNTING_SIZE; i++){
        if (isaprime(i) == 1){
            count++;
            if(count == 10001) printf ("%d\n",i);
        }
    }
    return 0;
}
