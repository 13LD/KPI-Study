//
//  main.cpp
//  Solution 34
//
//  Created by  Lysogor Dima on 05.03.15.
//  Copyright (c) 2015  Lysogor Dima. All rights reserved.
//

#include <iostream>
#include <stdio.h>
using namespace std;

long countFactor(int n){
    if(n==1 || n==0) return 1;
    else return countFactor(n-1)*n;
}

bool countSumOfFactor(int n){
    int buff = n;
    int sum = 0;
    int numb;
    while (buff!=0) {
        numb = buff % 10;
        buff = buff / 10;
        sum += countFactor(numb);
    }if (sum==n) return true;
    else return false;
}
int main() {
    int SUM = 0;
    int i = 1;
    while (i<1000000) {
        if (countSumOfFactor(i)) SUM +=i;
        i++;
    }
    cout <<SUM-3<<endl;
}
