//
//  main.cpp
//  Solution 18
//
//  Created by  Lysogor Dima on 05.03.15.
//  Copyright (c) 2015  Lysogor Dima. All rights reserved.
//

#include<stdio.h>
#include<stdlib.h>


int main()
{
    FILE *f;
    int Array[15][15],max1[15],max2[15],i=0,j=0,maximum=0;
    
    f=fopen("tree.txt","r");
    i=0;
    for(i=0;i<15;i++)
        for(j=0;j<=i;j++){
            fscanf(f,"%d",&Array[i][j]);
        }
    
    for(i=0;i<15;i++){
        for(j=0;j<=i;j++){
            if(i==0){
                max1[j]=Array[i][j];
                continue;
            }
            else if((j-1)<0){
                max2[j]=Array[i][j]+max1[j];
            }else if(j==i)
                max2[j]=Array[i][j]+max1[j-1];
            else
                max2[j]=Array[i][j]+((max1[j-1]>max1[j])?max1[j-1]:max1[j]);
        }
        
        if(i==0)
            continue;
        
        for(j=0;j<=i;j++)
            max1[j]=max2[j];
    }
    
    for(i=0;i<15;i++)
        if(maximum<max2[i])
            maximum=max2[i];
    printf("Answer = %d\n\n",maximum);
    
}
