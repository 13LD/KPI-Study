//
//  main.cpp
//  Solution 21
//
//  Created by  Lysogor Dima on 05.03.15.
//  Copyright (c) 2015  Lysogor Dima. All rights reserved.
//

#include <iostream>

using namespace std;

bool Suitable(int n){
    long long tmp = 0;
    for (int i=1; i<=n/2;i++){
        if(!(n%i)) tmp+=i;
    }
    long long rev = 0;
    for (int j=1; j<=tmp/2;j++){
        if(!(tmp%j))
        rev+=j;
    }
    if ((rev==n)&&(n!=tmp))
        return 1;
    return 0;
}
int main(){
    long long sum = 0;
    int i = 1;
    while (i<10000)
    {
        if(Suitable(i)) sum+=i;
        i++;
    }
    printf("%lld\n", sum);
}
