//
//  main.cpp
//  Solution 6
//
//  Created by  Lysogor Dima on 04.03.15.
//  Copyright (c) 2015  Lysogor Dima. All rights reserved.
//

#include <iostream>
#include <stdio.h>
#define N 101

int main(int argc, const char * argv[]) {
    int64_t sum1= 0;
    int64_t sum2 = 0;
    for(int i=1;i< N;++i){
        sum1+=i*i;
        sum2+=i;
    }
    printf("%lld\n",sum2*sum2 - sum1);
    return 0;
}
