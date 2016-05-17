//
//  main.cpp
//  Solution 4
//
//  Created by  Lysogor Dima on 04.03.15.
//  Copyright (c) 2015  Lysogor Dima. All rights reserved.
//

#include <iostream>
#include <stdlib.h>
#include <stdio.h>

int main() {
    enum { A=100000, B=10000, C=1000, c=100, b=10, a=1, T=10 };
    int m, n, p, q=111111, r=143, s=777;
    int nDel, nLo, nHi, inner=0, n11=999;
    
    for (m=999; m>99; --m) {
        nHi = n11;  nDel = 11;
        if (m%11==0) {
            nHi = 999;  nDel = 1;
        }
        nLo = q/m-1;
        if (nLo < m) nLo = m-1;
        
        for (n=nHi; n>nLo; n -= nDel) {
            ++inner;
            p = m * n;
            if (p%T==p/A && (p/B)%T==(p/b)%T && (p/C)%T==(p/c)%T) {
                q=p; r=m; s=n;
                printf ("%d at %d * %d\n", q, r, s);
                break;
            }
            
        }
    }
    printf ("Final result:  %d at %d * %d   inner=%d\n", q, r, s, inner);
    return 0;
}
