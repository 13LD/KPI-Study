exponential.dist <- function(n=50,a=0.74,unif.custom=T){
  y <-c()
  for (i in 1:n) {
    x <- 1
    x <- -(a * log(unif(unif.custom)))
    y <- c(y, x)
  }
  y
}
