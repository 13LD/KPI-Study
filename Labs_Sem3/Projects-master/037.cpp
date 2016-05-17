//
//  main.cpp
//  Solution 37
//
//  Created by  Lysogor Dima on 06.03.15.
//  Copyright (c) 2015  Lysogor Dima. All rights reserved.
//


#include <math.h>
#include <stdio.h>

bool isPrime(long n){
    if(n==0 || n==1) return false;
    for(int i=2; i<=sqrt(n); i++){
        if(!(n%i)) return false;
    }
    return true;
}


long multTen(int n){
    long tmp = 1;
    for(int i=0; i<n;i++) tmp*=10;
    return tmp;
}

bool isTruncatable(long n){
    
    if (!isPrime(n)) return false;
    long tmp1=n, tmp2=n;
    int deg=0;
    while (tmp1>0){
        if(!isPrime(tmp1)) return false;
        tmp1/=10;
        deg++;
    }
    while (tmp2>0){
        if(!isPrime(tmp2)) return false;
        tmp2%=multTen(deg-1);
        deg--;
    }
    return true;
}

int main(){
    long sum = 0;
    int cnt = 0;
    long num = 10;
    while (cnt<11){
        if(isTruncatable(num)){
            sum+=num;
            cnt++;
        }
        num++;
    }
    printf("%ld",sum);
}
