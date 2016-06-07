betafunc <- function(a,b, size){ 
  for(i in 1:size){ 
    x1 <- 0 
    x2 <- 0 
    while (x1 + x2 <= 1) { 
      x1 <- runif(1) ^ (1 / a) 
      x2 <- runif(1) ^ (1 / b) 
    } 
    print(x1 / (x1 + x2)) 
  } 
} 


normrand <- function(size){ 
  for(i in 1:size/2){ 
    s <- 1 
    v1 <- 0 
    v2 <- 0 
    while(s >= 1){ 
      v1 <- 2 * runif(1) - 1 
      v2 <- 2 * runif(1) - 1 
      s <- v1^2 + v2^2 
    } 
    w1 = v1 * (sqrt(-2 * log(s) / s)) 
    w2 = v2 * (sqrt(-2 * log(s) / s)) 
    print(w1) 
    print(w2) 
  } 
} 

stud <- function(size){ 
  c = rt(50, 4) 
  f1 <- graph_debs(c) 
  f2 <- graph_cdf(c) 
  Sys.sleep(50) 
} 

graph_debs <- function(c){ 
  x11() 
  hist(c, main="Density", border="blue", col="red", xlim=c(-5, 5), ylim =c(0.0, 1.0), las=1, breaks=5, prob = TRUE) 
  lines(density(c)) 
} 

graph_cdf <- function(c){ 
  x11() 
  hist(c, main="cdf", border="blue", col="red", xlim=c(-5, 5), ylim =c(0.0, 1.0), las=1, breaks=5, prob = TRUE) 
  lines(ecdf(c)) 
} 


built_in <- function(size, a, b){ 
  a <- runif(size, min=a, max=b) 
  print(a) 
} 

f <- stud(50)