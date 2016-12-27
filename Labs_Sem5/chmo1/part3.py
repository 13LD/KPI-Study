import math


def equation(x):
    return 33 * math.pow(x, 7) + (-37) * math.pow(x, 6) + (-432) * math.pow(x, 5) + (159) * math.pow(x, 4) + \
           971 * math.pow(x, 3) + (-184) * math.pow(x, 2) + (-73) * x + 14


def equation_dx(x):
    return 231 * math.pow(x, 6) + (-222) * math.pow(x, 5) - 2160 * math.pow(x, 4) + 636 * math.pow(x,3) + 2913 * x * x + (-368) * x - 73


def stopping_criterion(a_list, b_list):
    max_value = 0
    for i in range(len(a_list)):
        b = b_list[i]
        a = a_list[i] ** 2
        tmp = math.fabs(1 - float(b) / float(a))
        if tmp > max_value:
            max_value = tmp
    if max_value < 10 * 0.1:
        return True


def squaring(a_list):
    b_list = []
    for k in range(len(a_list)):
        sum_ = 0
        for j in range(1, len(a_list) - k):
            if ((k - j) < 0) or ((k + j) >= len(a_list)):
                break
            sum_ += a_list[k - j] * a_list[k + j] * (-1) ** j
        b_list.append(a_list[k] ** 2 + 2 * sum_)
    return b_list


def lobachevsky_method(a_list, b_list, p):
    x_list = []
    for k in range(1, len(b_list)):
        tmp = float(b_list[len(b_list) - 1 - k]) / float(b_list[len(b_list) - k])
        x = tmp ** (1.0 / (2.0 ** p))
        if (float(a_list[len(a_list) - 1 - k]) / float(a_list[len(a_list) - k])) > 0:
            x = -x
        x_list.append(x)
    return x_list


def lob():

    b_list = []
    a_list = [14, -73, -184, 971, 159, -432, -37, 33]
    a_start_list = a_list
    count = 1
    while True:
        b_list = squaring(a_list)
        if stopping_criterion(a_list, b_list):
            break
        a_list = b_list
        count += 1
    print count
    x_list = lobachevsky_method(a_start_list, b_list, count)
    print x_list
    newton_method(x_list,0.0000001)


def stopping_criterion_for_newton(b, a, accuracy):
    if math.fabs(b - a) < accuracy:
        return True
    return False


def newton_method(x_list, accuracy):
    new_x_list = []
    for x_k in x_list:
        while True:
            x_k_1 = x_k - equation(x_k) / equation_dx(x_k)
            if stopping_criterion_for_newton(x_k_1, x_k, accuracy):
                new_x_list.append(x_k_1)
                break
            x_k = x_k_1
    for x in new_x_list:
        print "x = {}".format(x)
