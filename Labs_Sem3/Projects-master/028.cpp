//
//  main.cpp
//  Solution 28
//
//  Created by  Lysogor Dima on 06.03.15.
//  Copyright (c) 2015  Lysogor Dima. All rights reserved.
//

#include<stdio.h>
#include<math.h>
#include<stdlib.h>


long fun(int n)
{
    long sum1=0,sum2=0,sum3=0,sum4=0;
    int temp;
    temp=2*n+1;
    sum1=pow((double)temp,2);
    sum2=pow((double)temp-2,2)+temp-1;
    sum3=sum2+2*n;
    sum4=sum3+2*n;
    return (sum1+sum2+sum3+sum4);
}

int main(){
    int i;
    long sum=1;
    for(i=1;i<=500;i++)
        sum+=fun(i);
    
    printf("Answer = %ld\n",sum);
}
