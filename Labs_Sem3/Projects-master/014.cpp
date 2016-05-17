//
//  main.cpp
//  Solution 14
//
//  Created by  Lysogor Dima on 05.03.15.
//  Copyright (c) 2015  Lysogor Dima. All rights reserved.
//

#include <iostream>
#define number 1000000
using namespace std;


int main (){
    long seqLength = 0;
    long startNum = 0;
    long sequence;
    
    for (int i = 2; i <= number; i++) {
        int length = 1;
        sequence = i;
        while (sequence != 1) {
            if ((sequence % 2) == 0) {
                sequence = sequence / 2;
            } else {
                sequence = sequence * 3 + 1;
            }
            length++;
        }
        if (length > seqLength) {
            seqLength = length;
            startNum = i;
        }
    }
    cout <<"the number : " << startNum << endl;
}
