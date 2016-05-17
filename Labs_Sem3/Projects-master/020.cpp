#include <stdio.h>

#define MAX 500

int main(){
  int factor[MAX]={0};
  int i,x,y,v,f,sum;

  factor[0]=1;
  y=2;

  while (y<101){
    v = 0;
    for (i=0;i<MAX;i++){
      x = factor[i]*y + v;
      v = 0;
      if (x > 9){
        f = x % 10;
        v = x / 10;
      }else
         f = x;
         factor[i] = f;
    }
   y++;
  }
  sum=0;
  for (i=MAX-1;i>=0;i--)
    sum=sum+factor[i];
  printf("%3d\n",sum);
  return 0;
}
