//
//  main.cpp
//  Solution 25
//
//  Created by  Lysogor Dima on 05.03.15.
//  Copyright (c) 2015  Lysogor Dima. All rights reserved.
//

#include <stdio.h>

int getDigits(long double n){
    int flag=0;
    while(n>1){
        flag++;
        n/=10;
    }
    return flag;
}

int main(){
    long double a,b,sum,i=0;
    int digits,count=2;

    a=1;
    b=1;
    sum=0;
    while(1){
        count++;
        sum=a+b;
        
        a=b;
        b=sum;
        digits=getDigits(sum);
        
        if(digits==1000)
            break;
        i++;
    }
    printf("Answer : %d\n",count);
}
