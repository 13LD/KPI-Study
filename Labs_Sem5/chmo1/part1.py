import math


def equation(x):
    return math.pow((5 - x), 1/3) * math.cos(x) + x * math.sin(math.pi - 2 * x)


def equation_dx(x):
    return -math.pow((5 - x), 1/3) * math.sin(x) + math.sin(2 * x) + (math.cos(x) / 3 * math.pow((5 - x), 2/3)) + 2 * x * math.cos(2 * x)


def equation_dxx(x):
    return (2 *  math.sin(x) / 3  * math.pow((5 - x), 2/3) - 4 * x * math.sin(2 * x) - math.pow((5 - x), 1/3)) * math.cos(x) -(2 * math.cos(x) / (9 * math.pow((5 - x), 5/3))) + 4 * math.cos(2 * x)
