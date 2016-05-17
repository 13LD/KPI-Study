//
//  main.cpp
//  Solution 10
//
//  Created by  Lysogor Dima on 04.03.15.
//  Copyright (c) 2015  Lysogor Dima. All rights reserved.
//

#include <stdio.h>
#include <math.h>

#define BELOW 2000000

int isaprime(int num){
    
    int i;
    
    for (i = 2; i <= sqrt(num); i++) {
        if (num % i == 0) {
            return 0;
        }
    }
    
    return 1;
}


int main (){
    
    int i;
    long sum = 0;
    
    for (i = 2; i < BELOW; i++){
        if (isaprime(i) == 1){
            sum = sum + i;
        }
    }
    printf("sum: %ld\n", sum);
    
    return 0;
}

