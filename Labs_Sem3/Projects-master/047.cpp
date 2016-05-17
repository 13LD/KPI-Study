//
//  main.cpp
//  Solution 47
//
//  Created by  Lysogor Dima on 06.03.15.
//  Copyright (c) 2015  Lysogor Dima. All rights reserved.
//

#include<stdio.h>
#include<stdlib.h>
#include<math.h>


int isPrime(long n){
    int i;
    for(i=2;i<=(long)sqrt((double)n);i++)
        if(n%i==0)
            return 0;
    return 1;
}

int no_of_distinct_prime_factor(long n)
{
    int i,counter=0;
    long product=1;
    if(isPrime(n))
        return 1;
    for(i=2;i<=n/2;i++)
    {
        if(product*i > n)
            break;
        if(n%i==0 && isPrime(i))
        {
            product*=i;
            counter++;
        }
    }
    return counter;
}



int main(){
    long c=4,i,j;
    int flag;
    
    for(i=2;;i++){
        flag=1;
        for(j=0;j<c;j++)
            if(!(c==no_of_distinct_prime_factor(i+j))){
                flag=0;
                break;
            }
        
        if(flag){
            printf("Answer = %ld\n",i);
            break;
        }
    }
}
   
