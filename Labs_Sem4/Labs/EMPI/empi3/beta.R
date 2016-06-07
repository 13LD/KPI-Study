betta <- function(n = 50, a = 6.1, b = 7.9, unif.custom=T) {
  y <- c()
  for(i in 1:n){
    y1 <- 1
    y2 <- 1
    while (y1 + y2 > 1) {
      y1 <- unif(unif.custom) ^ (1 / a)
      y2 <- unif(unif.custom) ^ (1 / b)
    }
    y <- c(y, y1 / (y1 + y2))
  }
  y
}

student.dist <- function(n = 50, k = 3, unif.custom = T){
  y <- c()
  for(i in 1:n){
    y1 <- 1
    y2 <- 1
    z <- 1
    while (exp(-z - y2) >= (1 - z)) {
      y1 <- rnorm(1, 0, 1)
      y2 <- exponential.dist(1, 2/(k-1), unif(unif.custom))
      z <- (y1 ^ 2)/(k - 2) 
    }
    y <- c(y, y1 / sqrt((1 - 2/k) * (1 - z)))
  }
  y
}

task3 <- function(n = 50){
  y <- c()
  y <- c(y, runif(n, 0, 1))
  y
}

task <- function(n = 50){
  y <- c()
  y <- c(y, runif(n, 30, 50))
  y
}

