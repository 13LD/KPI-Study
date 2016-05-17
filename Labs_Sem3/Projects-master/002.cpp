//
//  main.cpp
//  Solution 2
//
//  Created by  Lysogor Dima on 04.03.15.
//  Copyright (c) 2015  Lysogor Dima. All rights reserved.
//

#include <stdio.h>

int Arr[100];

int main(){
    Arr[0] = 1;
    Arr[1] = 1;
    int sum = 0;
    for (int i = 2;i < 100 ; i++){
        Arr[i] = Arr[i-1] + Arr[i-2];
        if (Arr[i] > 4000000)
            break;
        if (Arr[i]%2 == 0)
            sum +=Arr[i];
        printf("%d\n",Arr[i]);
    }
    printf("%d\n",sum);
    return 0;
}
