import math


def equation(x):
    return x * math.sin(5 * x) - 5 * math.exp(x - math.pi * 3) * math.cos(x)


def equation_dx(x):
    return 10 * math.exp(x - 3 * math.pi) * math.sin(x) + 5 *(2 * math.cos(5 * x) - 5 * x * math.sin(5 * x))





def hord(a, b):
    return a - ((equation(a) * (b - a)) / (equation(b) - equation(a)))

