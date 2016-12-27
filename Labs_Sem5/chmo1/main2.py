import part2
import math
import plotIters as plt

def solveHalf(xn, xk):
    a = xn
    b = xk
    iterlist = list()

    while (b - a > 0.0000001):
        c = (a + b) / 2
        iterlist.append(c)
        if part2.equation(b) * part2.equation(c) < 0:
            a = c
        else:
            b = c
    x = (a + b) / 2
    iterlist.append(x)
    print "Half " + str(x)
    return  iterlist


def solveMPI(l, r):
    epsi = 0.0000001
    alpha = part2.equation_dx(l)
    gamma = part2.equation_dx(r)
    lambd = 2 / (alpha + gamma)
    iterlist = list()

    def stepIter(x):
        return x - lambd * part2.equation(x)

    q = (gamma - alpha) / (gamma + alpha)
    stopCriteria = math.fabs(((1 - q) / q) * epsi)

    xprev = l
    x = stepIter(l)
    while math.fabs(x - xprev) > stopCriteria:
        iterlist.append(xprev)
        xprev = x
        x = stepIter(xprev)

    print "MPI " + str(x)
    return iterlist

#Root1
l1 = -8.0
r1 = -7.5

#Root2
l2 = -5.0
r2 = -4.0

#Root3
l3 = -1.7
r3 = -1.2

#Root4
l4 = 1.4
r4 = 1.9

#Root5
l5 = 4.0
r5 = 5.0

# #Root6
# l6 = 1.1
# r6 = 1.3
#
# #Root7
# l7 = 2.3
# r7 = 2.7
#
# #Root8
# l8 = 3
# r8 = 3.15

# lists = []
#
# lists.append(solveHalf(l1, r1))
# lists.append(solveHalf(l2, r2))
# lists.append(solveHalf(l3, r3))
# lists.append(solveHalf(l4, r4))
# lists.append(solveHalf(l5, r5))
# # lists.append(solveHalf(l6, r6))
# # lists.append(solveHalf(l7, r7))
# # lists.append(solveHalf(l8, r8))
#
# f = open("part2.txt", "w")
# for item in lists:
#     f.write(str(item) + "\n")
# f.close()


if (part2.equation(l1) * part2.equation(r1)) < 0:
    print "OK"
    iters = solveHalf(l4, r4)
    iters_two = solveMPI(l4, r4)
    plt.build_iter_graphics([iters,iters_two])




else:
    print "Wrong bounds"
